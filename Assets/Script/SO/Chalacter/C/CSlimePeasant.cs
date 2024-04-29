using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Peasant", menuName = "Character/CSlimePeasant")]
public class CSlimePeasant : GameCharacter
{
    public override string Description
    {
        get => $"スライム王国の平民。"              +
               $"\n攻撃力：{PowerFunction()}" +
               $"\n\n加護：スライム王国"           +
               $"\nアタッカー";
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
        return  Getlevel() * 5;
    }
}