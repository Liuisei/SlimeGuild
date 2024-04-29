using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer 占い師</summary>
[CreateAssetMenu(fileName = "Soothsayer", menuName = "CharacterR/CSlimeSoothsayer")]
public class CSlimeSoothsayer : GameCharacter
{
    public override string Description =>
        $"ちょっぴり怪しい占い師。" +
        $"\n勇者パーティーに" +
        $"\n攻撃力+{PowerFunction()}" +
        $"\n\n加護：勇者パーティー";

    public override string Tip =>
        $"バッファー" +
        $"\nスライム王国に" +
        $"\n攻撃力+{power * 2}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p => p.propertys.Contains(Property.BraveParty));

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power * 2;
        }
    }

    public override int PowerFunction()
    {
        return 50 + Getlevel() * 2;
    }
}