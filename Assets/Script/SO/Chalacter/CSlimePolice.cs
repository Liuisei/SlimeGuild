using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Police", menuName = "Character/CSlimePolice")]
public class CSlimePolice : GameCharacter
{
    public override string Description
    {
        get => "警察は、治安を守ることが得意なキャラクターです";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        
    }

    public override int PowerFunction(int level)
    {
        return 1000;
    }
}

