using UnityEngine;

public abstract class GameCharacter : ScriptableObject
{
    public          int           characterId;
    public          CharacterType characterName;            // キャラクターの名前
    public          Texture       characterIcon;            // キャラクターのアイコン
    public          int           rarity;                   //レア度
    public abstract string        Description { get;} // キャラクターの説明
    
    public abstract int ActivateAbility(int value); // アビリティをアクティベートする抽象メソッド
}

public enum CharacterType
{
    Peasant, //農夫
    Police,　//警察
    Fisherman,　//漁師
    Florist,　//花屋
    Cat,　//猫
    Dog,　//犬
    Soldier,　//兵士
    Innkeeper,　//宿主
    Blacksmith,　//鍛冶屋
    CatholicNun,　//カトリック修道女
    Pastor, //牧師
    Merchant, //商人
    Knight, //騎士
    Chef, //シェフ
    Eldest, //長老
    Wizard, //魔法使い
    Soothsayer, //占い師
    Warrior, //戦士
    King, //王様
    Queen, //王妃
    Hero, //勇者
}

public enum SkillType
{
    Attacker,
    Buffer,
    Supporter,
}