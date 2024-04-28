using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Blacksmith", menuName = "CharacterN/CSlimeBlacksmith")]
public class CSlimBlacksmith : GameCharacter
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
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty) || p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power;
        }
    }

    public override int PowerFunction()
    {
        return 1000 + Getlevel() * 1;
    }
}

