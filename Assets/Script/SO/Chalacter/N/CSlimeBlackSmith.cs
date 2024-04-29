using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer 鍛冶屋</summary>
[CreateAssetMenu(fileName = "Blacksmith", menuName = "CharacterN/CSlimeBlacksmith")]
public class CSlimBlacksmith : GameCharacter
{
    public override string Description =>
        $"勇者を支えるスライム王国の名匠。"                    +
        $"\n勇者パーティーに攻撃力*{PowerFunction()/10f}" +
        $"\nスライム王国に攻撃力＋{PowerFunction()}"      +
        $"\n\n加護：勇者パーティー、スライム王国"               +
        $"\nバッファー";

    public override string Tip =>
        $"バッファー"                 +
        $"\n勇者パーティーに攻撃力*{power/10f}" +
        $"\nスライム王国に攻撃力＋{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty) );
        var targetPartiesSlime = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetMember in targetParties)
        {
            targetMember.power = (int)(targetMember.power *  power / 10f);
        }
        foreach (var targetMember in targetPartiesSlime)
        {
            targetMember.power += power ;
        }
    }

    public override int PowerFunction()
    {
        return 30 + Getlevel() * 1;
    }
}