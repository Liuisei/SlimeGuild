using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName = "Character/CSlimeCat")]
public class CSlimeCat : GameCharacter
{
    public override string Description =>
        $"勇者と行動したスライム王国の伝説の猫。"     +
        $"\n勇者パーティーとスライム王国に"       +
        $"\n攻撃力+{PowerFunction()}" +
        $"\n\n加護：勇者パーティー、スライム王国"   +
        $"\nバッファー";

    public override string Tip =>
        $"バッファー"                +
        $"\n勇者パーティー,スライム王国に" +
        $"\n攻撃力+{power}";


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
        return 20 + Getlevel() * 2;
    }
}