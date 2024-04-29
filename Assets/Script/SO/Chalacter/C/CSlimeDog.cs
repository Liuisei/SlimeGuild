using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dog", menuName = "Character/CSlimeDog")]
public class CSlimeDog : GameCharacter
{
    public override string Description
    {
        get => $"勇者と行動したスライム王国の伝説の犬。"     +
               $"\n攻撃力：{PowerFunction()}" +
               $"\n\n加護：勇者パーティー、スライム王国"   +
               $"\nアタッカー";
    }

    public override string Tip
    {
        get => $"アタッカー" +
               $"\n攻撃力：{power}";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        //アタッカーなので使わない
    }


    public override int PowerFunction()
    {
        return 10 + Getlevel() * 5;
    }
}