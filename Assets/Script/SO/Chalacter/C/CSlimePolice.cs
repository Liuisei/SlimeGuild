using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Police", menuName = "Character/CSlimePolice")]
public class CSlimePolice : GameCharacter
{
    public override string Description
    {
        get => $"スライム王国の警備隊。"           +
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

