using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Peasant", menuName = "Character/CSlimePeasant")]
public class CSlimePeasant : GameCharacter
{
    public override string Description
    {
        get => "農家は、農作物を育てることが得意なキャラクターです。";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        
    }

    public override int PowerFunction(int level)
    {
        return 100 + level * 1 ;
    }


}
