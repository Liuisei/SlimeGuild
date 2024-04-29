using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer 牧師 </summary>
[CreateAssetMenu(fileName = "Pastor", menuName = "CharacterSR/CSlimePastor")]
public class CSlimePastor : GameCharacter
{
    public override string Description =>
        $"勇者パーティーの優しい牧師。"                    +
        $"\n勇者パーティーに攻撃力*{PowerFunction()*2}" +
        $"\nスライム王国に攻撃力*{PowerFunction()}"    +
        $"\n\n加護：勇者パーティー"                    +
        $"\nバッファー";

    public override string Tip =>
        $"バッファー"                          +
        $"\nスライム王国に攻撃力*{PowerFunction()}" +
        $"\n勇者パーティーに攻撃力*{PowerFunction()*2}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.SlimeCuntry));
        var targetPartieB = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty));

        foreach (var targetMember in targetParties)
        {
            targetMember.power *= power;
        }
        foreach (var targetMember in targetPartieB)
        {
            targetMember.power *= power*2;
        }
    }

    public override int PowerFunction()
    {
        return  Getlevel();
    }
}