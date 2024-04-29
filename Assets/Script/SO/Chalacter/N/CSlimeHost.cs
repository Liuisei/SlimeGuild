using System.Collections.Generic;
using System.Linq;
using UnityEngine;

///<summary> Attacker 宿家主</summary>
[CreateAssetMenu(fileName = "Host", menuName = "CharacterN/CSlimeHost")]
public class CSlimeHost : GameCharacter
{
    public override string Description =>
        $"毎日予約で埋まっている宿屋の主。"               +
        $"\nスライム王国の攻撃力+{PowerFunction()}" +
        $"\n\n 加護：スライム王国"                 +
        $"\nバッファー";

    public override string Tip =>
        $"バッファー" +
        $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p => p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power;
        }
    }

    public override int PowerFunction()
    {
        return 30 + Getlevel() * 3;
    }
}