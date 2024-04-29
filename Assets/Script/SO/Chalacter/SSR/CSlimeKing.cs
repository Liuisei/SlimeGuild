using System.Collections.Generic;
using UnityEngine;

/// <summary> Attacker　王様 </summary>
[CreateAssetMenu(fileName = "King", menuName = "CharacterSSR/CSlimeKing")]
public class CSlimeKing : GameCharacter
{
    public override string Description =>
        $"スライム王国の国王。" +
        $"\n攻撃力：{PowerFunction()}" +
        $"\n加護：スライム王国";

    public override string Tip =>
        $"アタッカー" +
        $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return 1000 + Getlevel() * 2;
    }
}