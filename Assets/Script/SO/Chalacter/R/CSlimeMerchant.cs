using System.Collections.Generic;
using UnityEngine;

/// <summary>Attacker 商人</summary>
[CreateAssetMenu(fileName = "Merchant", menuName = "CharacterR/CSlimeMerchant")]
public class CSlimeMerchant : GameCharacter
{
    public override string Description =>
        $"国で売買する商人。" +
        $"\n攻撃力：{PowerFunction()}" +
        $"\n\n 加護：スライム王国";

    public override string Tip =>
        $"アタッカー" +
        $"\n攻撃力：{power}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction()
    {
        return 50 + Getlevel() * 1;
    }
}