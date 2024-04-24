using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class GameCharacter : ScriptableObject
{
    public int            characterId;   // キャラクターのID
    public CharacterType  characterName; // キャラクターの名前
    public Rarity         rarity;        //レア度
    public List<Property> propertys;     //属性
    public SkillType      skillType;     //スキルの種類
    public Texture textureSlime;       // キャラクターのアイコン
    public Texture textureBack;        // キャラクターの背景
    public Texture textureClothes;     // キャラクターの服
    public Texture textureHat;         // キャラクターの帽子
    public Texture textureWeaponRight; // キャラクターの右手の武器
    public Texture textureWeaponLeft;  // キャラクターの左手の武器
    
    public int     power = 0;              // キャラクターのパワー

    
    public abstract string Description { get; } // キャラクターの説明
    public abstract string Tip { get; } // キャラクターのヒント

    public abstract void Buff(List<GameCharacter> targetGameCharacters); // bafferのスキル
    public abstract int  PowerFunction();         // キャラクターのパワー


    protected int Getlevel()
    {
        return DataManager.Instance.GetCharacterLevel(characterId);
    }

    public void ResetPower()
    {
        power = PowerFunction();
    }
}

public enum CharacterType //キャラクターの名前
{
    Peasant,     //農夫
    Police,      //警察
    Fisherman,   //漁師
    Florist,     //花屋
    Cat,         //猫
    Dog,         //犬
    Soldier,     //兵士
    Innkeeper,   //宿主
    Blacksmith,  //鍛冶屋
    CatholicNun, //カトリック修道女
    Pastor,      //牧師
    Merchant,    //商人
    Knight,      //騎士
    Chef,        //シェフ
    Eldest,      //長老
    Wizard,      //魔法使い
    Soothsayer,  //占い師
    Warrior,     //戦士
    King,        //王様
    Queen,       //王妃
    Hero,        //勇者
}

public enum Property //属性
{
    SlimeCuntry, //スライム王国
    BraveParty,  //勇者パーティー
}

public enum SkillType
{
    Attacker, //基本攻撃力を持ってるキャラクター,攻撃力の範囲は、1~1000
    Buffer,   //バフ対象はAttacker,バフの範囲は、+1~100。倍率の場合は、+0.1~10
}

public enum Rarity
{
    C,   //コモン
    N,   //ノーマル
    R,   //レア
    SR,  //スーパーレア
    SSR, //スーパースーパーレア
    UR,  //ウルトラレア
}