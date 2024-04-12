using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SO Item Database", menuName = "Database/Item Database")]
public class CharacterDatabase : ScriptableObject
{
    public List<GachaCharacter> characters = new List<GachaCharacter>();
}
