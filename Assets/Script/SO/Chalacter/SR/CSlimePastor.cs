using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer 牧師 </summary>
[CreateAssetMenu(fileName = "Pastor", menuName = "CharacterSR/CSlimePastor")]
public class CSlimePastor : GameCharacter
{
    public override string Description =>
        $"国では有名な優しい牧師さん。" +
        $"\nスライム王国に" +
        $"\n攻撃力+{PowerFunction()}" +
        $"\n\n加護：スライム王国";

    public override string Tip =>
        $"バッファー" +
        $"\nスライム王国に" +
        $"\n攻撃力+{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.SlimeCuntry));

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power;
        }
    }

    public override int PowerFunction()
    {
        return 100 + Getlevel() * 3;
    }
}