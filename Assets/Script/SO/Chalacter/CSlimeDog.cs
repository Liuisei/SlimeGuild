using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dog", menuName = "Character/CSlimeDog")]
public class CSlimeDog : GameCharacter
{
    public override string Description
    {
        get => "犬は、属性勇者パーティーとスライム王国に属してます。";
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

