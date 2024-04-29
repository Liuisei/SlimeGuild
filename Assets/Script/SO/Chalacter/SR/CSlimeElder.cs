using System.Collections.Generic;
using UnityEngine;

/// <summary>Attacker 長老</summary>
[CreateAssetMenu(fileName = "Elder", menuName = "CharacterSR/CSlimeElder")]
public class CSlimeElder : GameCharacter
{
    public override string Description =>
            $"スライム村を束ねる長老。"            +
            $"\n攻撃力：{PowerFunction()}" +
            $"\n\n 加護：スライム王国"          +
            $"\nアタッカー"                        ;

    public override string Tip =>
            $"アタッカー" +
            $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return 1000 + Getlevel() * 500;
    }
}