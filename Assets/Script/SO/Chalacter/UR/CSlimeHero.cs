using System.Collections.Generic;
using UnityEngine;

/// <summary>Attacker 勇者 </summary>
[CreateAssetMenu(fileName = "Hero", menuName = "CharacterUR/CSlimeHero")]
public class CSlimeHero : GameCharacter
{
    public override string Description =>
        $"伝説の勇者。"                  +
        $"\n攻撃力：{PowerFunction()}" +
        $"\n\n加護：勇者パーティー"            +
        $"\nアタッカー";

    public override string Tip =>
        $"アタッカー" +
        $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return   Getlevel() * 10000;
    }
}