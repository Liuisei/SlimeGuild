using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary> Buffer 料理人</summary>
[CreateAssetMenu(fileName = "Cook", menuName = "CharacterR/CSlimeCook")]
public class CSlimeCook : GameCharacter
{
    public override string Description =>
        $"国王も認める国一番の料理人。"          +
        $"\n攻撃力+{PowerFunction()}" +
        $"\n\n加護：スライム王国"           +
        $"\nバッファー";

    public override string Tip =>
        $"バッファー"             +
        $"\n勇者パーティー,スライム王国に" +
        $"\n攻撃力+{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p => p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power;
        }
    }

    public override int PowerFunction()
    {
        return Getlevel() * 100;
    }
}