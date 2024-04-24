using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fisherman", menuName = "Character/CSlimeFisherman")]
public class CSlimeFisherman : GameCharacter
{
    public override string Description
    {
        get => $"毎日一杯釣れる。"              +
               $"\n攻撃力：{PowerFunction()}" +
               $"\n 加護：スライム王国";
    }

    public override string Tip
    {
        get => $"攻撃力：{power}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return 100 + Getlevel() * 10;
    }
}