using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Cook", menuName = "CharacterR/CSlimeCook")]
public class CSlimeCook : GameCharacter
{
    public override string Description
    {
        get => $"スライム王国の衛兵。"           +
               $"\n攻撃力：{PowerFunction()}" +
               $"\n加護：スライム王国";
       
    }

    public override string Tip
    {
        get => $"攻撃力：{power}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetPartys = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty));

        foreach (var targetmenber in targetPartys)
        {
            targetmenber.power += power;
        }
    }

    public override int PowerFunction()
    {
        return 200 + Getlevel() * 2;
    }
}

