using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO Item Database", menuName = "Database/Item Database")]
public class CharacterDatabase : ScriptableObject
{
    public List<GameCharacter> characters = new List<GameCharacter>();
    
    public GameCharacter  GetCharacter(int id)
    {
        return characters[id];
    }
}
