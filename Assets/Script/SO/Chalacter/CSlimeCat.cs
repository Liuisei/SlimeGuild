using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName = "Character/CSlimeCat")]
public class CSlimeCat : GameCharacter
{
    public override string Description
    {
        get => "Cat gives +10 to attribute hero party and slime kingdom";
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

    public override int PowerFunction(int level)
    {
        return 100 + level * 1;
    }
}