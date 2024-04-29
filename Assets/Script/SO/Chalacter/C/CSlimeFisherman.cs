using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fisherman", menuName = "Character/CSlimeFisherman")]
public class CSlimeFisherman : GameCharacter
{
    public override string Description =>
        $"スライム王国の漁夫"               +
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
        return 20 + Getlevel() * 3;
    }
}