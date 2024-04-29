using System.Collections.Generic;
using UnityEngine;

/// <summary>アタッカー　戦士 </summary>
[CreateAssetMenu(fileName = "Warrior", menuName = "CharacterSR/CSlimeWarrior")]
public class CSlimeWarrior : GameCharacter
{
    public override string Description =>
        $"勇者をサポートする戦士。" +
        $"\n攻撃力：{PowerFunction()}" +
        $"\n\n 加護：勇者パーティー";

    public override string Tip =>
        $"アタッカー" +
        $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return 100 + Getlevel()　* 2;
    }
}