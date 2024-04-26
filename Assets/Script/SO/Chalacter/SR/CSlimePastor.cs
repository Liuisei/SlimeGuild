using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pastor", menuName = "CharacterSR/CSlimePastor")]
public class CSlimePastor : GameCharacter
{
    public override string Description
    {
        get => $"スライム王国の衛兵。"           +
               $"\n攻撃力：{PowerFunction()}" +
               $"\n加護：スライム王国";
        
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
        return 1000 + Getlevel();
    }
}

