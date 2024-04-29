using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Buffer 魔法使い</summary>
[CreateAssetMenu(fileName = "Magician", menuName = "CharacterSR/CSlimeMagician")]
public class CSlimeMagician : GameCharacter
{
    public override string Description =>
        $"勇者をサポートする魔法使い。" +
        $"\n勇者パーティーに"        +
        $"\n攻撃力+{PowerFunction()}"  +
        $"\n\n加護：勇者パーティー";
    
    public override string Tip =>
            $"バッファー"                +
            $"\n勇者パーティーに" +
            $"\n攻撃力+{PowerFunction()}";

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        var targetParties = targetGameCharacters.Where(p =>
            p.propertys.Contains(Property.BraveParty));

        foreach (var targetMember in targetParties)
        {
            targetMember.power += power;
        }
    }

    public override int PowerFunction()
    {
        return 1000 + Getlevel() * 3;
    }
}