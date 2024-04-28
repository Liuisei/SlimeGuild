using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Florist", menuName = "Character/CSlimeFlorist")]
public class CSlimeFlorist : GameCharacter
{
    public override string Description
    {
        get =>
            $"皆が大好きな花屋さん"                     +
            $"\nスライム王国のアイドルだ。"                  +
            $"\nスライム王国に攻撃力*{PowerFunction()/10f}" +
            $"\n\n加護：スライム王国";
    }

    public override string Tip
    {
        get => $"バッファー"      +
               $"\nスライム王国に" +
               $"\n攻撃力X{power/10f}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetPartys = targetGameCharacters.Where(p => p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetmenber in targetPartys)
        {
            targetmenber.power = (int)(targetmenber.power*power/10f);
        }
    }

    public override int PowerFunction()
    {
        return 10+ Getlevel() ;
    }
}