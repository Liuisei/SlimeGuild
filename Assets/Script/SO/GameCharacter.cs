using Unity.VisualScripting;
using UnityEngine;

public abstract class GameCharacter : ScriptableObject
{
    public          int           characterId;
    public          CharacterName characterName;            // キャラクターの名前
    public          Texture       characterIcon;            // キャラクターのアイコン
    public          int           rarity;                   //レア度
    public abstract string        Description { get;} // キャラクターの説明
    
    public abstract void ActivateAbility(); // アビリティをアクティベートする抽象メソッド
}

public enum CharacterName
{
    Mage,
    Warrior,
    Archer,
    Paladin,
    Tank,
}