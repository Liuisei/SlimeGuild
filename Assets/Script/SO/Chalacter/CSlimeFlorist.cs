using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Florist", menuName = "Character/CSlimeFlorist")]
public class CSlimeFlorist : GameCharacter
{
    public override string Description
    {
        get =>
            $"皆が大好きな花屋さん、スライム王国のアイドルだ。"                     +
            $"\n{Property.SlimeCuntry}に攻撃力+{PowerFunction()}" +
            $"\n加護：スライム王国";
    }

    public override string Tip
    {
        get => $"スライム王国に" +
               $"\n攻撃力X{power}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetPartys = targetGameCharacters.Where(p => p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetmenber in targetPartys)
        {
            targetmenber.power *= power;
        }
    }

    public override int PowerFunction()
    {
        return 1+ Getlevel() ;
    }
}