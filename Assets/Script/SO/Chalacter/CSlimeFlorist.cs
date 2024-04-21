using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Florist", menuName = "Character/CSlimeFlorist")]
public class CSlimeFlorist : GameCharacter
{
    public override string Description
    {
        get => "花屋はバッファーで、属性Slimeconturyのキャラクターの攻撃力を上げることが得意なキャラクターです。";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction(int level)
    {
        return 100 + level * 1;
        
    }

 
}
