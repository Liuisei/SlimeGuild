using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary> Buffer 料理人</summary>
[CreateAssetMenu(fileName = "Cook", menuName = "CharacterR/CSlimeCook")]
public class CSlimeCook : GameCharacter
{
    public override string Description =>
        $"国王も認める国一番の料理人。" +
        $"\n攻撃力+{PowerFunction()}" +
        $"\n\n加護：スライム王国";

    public override string Tip =>
        $"バッファー" +
        $"\n勇者パーティー,スライム王国に" +
        $"\n攻撃力+{power * 2}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty) || p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power * 2;
        }
    }

    public override int PowerFunction()
    {
        return 60 + Getlevel() * 1;
    }
}