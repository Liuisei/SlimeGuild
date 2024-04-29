using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer　王妃</summary>
[CreateAssetMenu(fileName = "Queen", menuName = "CharacterSSR/CSlimeQueen")]
public class CSlimeQueen : GameCharacter
{
    public override string Description =>
        $"スライム王国の王妃。"                   +
        $"\n国王に攻撃力*{PowerFunction()}" +
        $"\n\n加護：スライム王国"                +
        $"\nバッファー";

    public override string Tip =>
            $"バッファー" +
            $"\n国王に攻撃力X{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(e => e.characterName == CharacterType.King);
        
        foreach (var targetMember in targetParties)
        {
            targetMember.power *= power;
        }
    }

    public override int PowerFunction()
    {
        return   Getlevel() * 5;
    }
}