using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer 占い師</summary>
[CreateAssetMenu(fileName = "Soothsayer", menuName = "CharacterR/CSlimeSoothsayer")]
public class CSlimeSoothsayer : GameCharacter
{
    public override string Description =>
        $"ちょっぴり怪しい占い師。"                  +
        $"\nパーティーに攻撃力X{PowerFunction()}" +
        $"\n\n加護：スライム王国"                 +
        $"\nバッファー";

    public override string Tip =>
        $"バッファー" +
        $"\nパーティーに攻撃力X{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        foreach (var targetMember in targetGameCharacters)
        {
            targetMember.power *= power;
        }
    }

    public override int PowerFunction()
    {
        return Getlevel();
    }
}