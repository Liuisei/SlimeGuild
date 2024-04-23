using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Florist", menuName = "Character/CSlimeFlorist")]
public class CSlimeFlorist : GameCharacter
{
    public override string Description
    {
        get =>
            "Flower is a buffer character that is good at increasing the attack power of characters with the attribute Slimecontury.";
    }

    public override void Buff(List<GameCharacter> targetGameCharacters)
    {
    }

    public override int PowerFunction(int level)
    {
        return 100 + level * 1;
    }
}