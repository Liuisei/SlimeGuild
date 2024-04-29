using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer　王妃</summary>
[CreateAssetMenu(fileName = "Queen", menuName = "CharacterSSR/CSlimeQueen")]
public class CSlimeQueen : GameCharacter
{
    public override string Description =>
        $"スライム王国の王妃。" +
        $"\nスライム王国に" +
        $"\n攻撃力*{PowerFunction()}" +
        $"\n\n加護：スライム王国";

    public override string Tip =>
            $"バッファー" +
            $"\nスライム王国に" +
            $"\n攻撃力X{power * 99}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetMember in targetParties)
        {
            //パワーが100倍になるようにBuffする
            targetMember.power += power * 99;
        }
    }

    public override int PowerFunction()
    {
        return 100 + Getlevel() * 1;
    }
}