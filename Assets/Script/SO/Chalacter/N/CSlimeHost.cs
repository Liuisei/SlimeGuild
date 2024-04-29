using System.Collections.Generic;
using UnityEngine;

///<summary> Attacker 宿家主</summary>
[CreateAssetMenu(fileName = "Host", menuName = "CharacterN/CSlimeHost")]
public class CSlimeHost : GameCharacter
{
    public override string Description =>
        $"毎日予約で埋まっている宿屋の主。" +
        $"\n攻撃力：{PowerFunction()}" +
        $"\n\n 加護：スライム王国";

    public override string Tip =>
        $"アタッカー" +
        $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return 30 + Getlevel() * 1;
    }
}