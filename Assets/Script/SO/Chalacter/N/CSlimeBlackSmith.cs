using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer 鍛冶屋</summary>
[CreateAssetMenu(fileName = "Blacksmith", menuName = "CharacterN/CSlimeBlacksmith")]
public class CSlimBlacksmith : GameCharacter
{
    public override string Description =>
        $"勇者を支える名匠。" +
        $"\n攻撃力+{PowerFunction()}" +
        $"\n\n加護：勇者パーティー、スライム王国";

    public override string Tip =>
        $"バッファー" +
        $"\n勇者パーティー,スライム王国に" +
        $"\n攻撃力+{power * 2}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty) || p.characterName == CharacterType.Knight ||  p.characterName == CharacterType.Guard);

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power * 2;
        }
    }

    public override int PowerFunction()
    {
        return 30 + Getlevel() * 1;
    }
}