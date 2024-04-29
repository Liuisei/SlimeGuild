using System.Collections.Generic;
using UnityEngine;

/// <summary>Attacker 騎士</summary>
[CreateAssetMenu(fileName = "Knight", menuName = "CharacterR/CSlimeKnight")]
public class CSlimeKnight : GameCharacter
{
    public override string Description =>
        $"国を守る王様直属の騎士。"            +
        $"\n攻撃力：{PowerFunction()}" +
        $"\n\n 加護：スライム王国"          +
        $"\nアタッカー";

    public override string Tip =>
        $"アタッカー" +
        $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return  Getlevel() * 200;
    }
}