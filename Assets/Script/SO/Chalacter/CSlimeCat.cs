using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName = "Character/CSlimeCat")]
public class CSlimeCat : GameCharacter
{
    public override string Description
    {
        get => $"勇者パーティーと行動したスライム王国の伝説の猫。"               +
               $"\n勇者パーティーとスライム王国に攻撃力+{PowerFunction()}" +
               $"\n加護：勇者パーティー、スライム王国";
    }

    public override string Tip
    {
        get => $"勇者パーティー,スライム王国に" +
               $"\n攻撃力+{PowerFunction()}";
    }


    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetPartys = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty) || p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetmenber in targetPartys)
        {
            targetmenber.power += power;
        }
    }

    public override int PowerFunction()
    {
        return 100 + Getlevel() * 1;
    }
}