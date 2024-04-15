using UnityEngine;

public abstract class GameCharacter : ScriptableObject
{
    public int           characterId;
    public CharacterName characterName; // キャラクターの名前
    public Texture       characterIcon; // キャラクターのアイコン
    public int           rarity;        //レア度


    public abstract void ActivateAbility(GameObject player); // アビリティをアクティベートする抽象メソッド
}

public enum CharacterName
{
    Mage,
    Warrior,
    Archer,
    Paladin,
    Tank,
}