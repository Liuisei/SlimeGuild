using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Knight", menuName = "CharacterR/CSlimeKnight")]
public class CSlimeKnight : GameCharacter
{
    public override string Description
    {
        get => $"スライム王国の騎士。"              +
               $"\n攻撃力：{PowerFunction()}" +
               $"\n\n加護：スライム王国";
    }

    public override string Tip
    {
        get => $"アタッカー" +
               $"\n攻撃力：{power}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {

    }

    public override int PowerFunction()
    {
        return 1000 + Getlevel();
    }
}