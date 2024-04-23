using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dog", menuName = "Character/CSlimeDog")]
public class CSlimeDog : GameCharacter
{
    public override string Description
    {
        get => "The dog belongs to the attribute hero party and the slime kingdom.";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
        //アタッカーなので使わない
    }

 
    public override int PowerFunction(int level)
    {
        return 100 + level * 1 ;
    }
}

