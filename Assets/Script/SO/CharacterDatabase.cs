using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO Item Database", menuName = "Database/Item Database")]
public class CharacterDatabase : ScriptableObject
{
    public List<GameCharacter> characters     = new List<GameCharacter>();
    public List<Texture>       rarityTextures = new List<Texture>(); //6種類のレアリティのテクスチャを格納するリスト
}