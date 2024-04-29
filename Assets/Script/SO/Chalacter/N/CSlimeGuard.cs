using System.Collections.Generic;
using UnityEngine;

/// <summary>Attacker 衛兵</summary>
[CreateAssetMenu(fileName = "Guard", menuName = "CharacterN/CSlimeGuard")]
public class CSlimeGuard : GameCharacter
{
    public override string Description =>
        $"スライム王国の衛兵"               +
        $"\n国の見回りを任されている。"         +
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
        return 50 + Getlevel() * 5;
    }
}