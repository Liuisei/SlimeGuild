using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
    public RawImage textureRearity; // キャラクターのレアリティ

    [SerializeField]
    public RawImage textureBack; // キャラクターの背景

    [SerializeField]
    private RawImage textureSlime; // キャラクターのスライム

    [SerializeField]
    public RawImage textureClothes; // キャラクターの服

    [SerializeField]
    public RawImage textureHat; // キャラクターの帽子

    [SerializeField]
    public RawImage textureWeaponRight; // キャラクターの右手の武器

    [SerializeField]
    public RawImage textureWeaponLeft; // キャラクターの左手の武器

    [SerializeField]
    private int characterId;

    private void Start()
    {
        RawImageUPdate();
    }

    public int CharacterId
    {
        set
        {
            characterId = value;
            RawImageUPdate();
        }
    }

    private void Awake()
    {
        if (textureRearity     == null) Debug.LogError("TextureRearity is not set");
        if (textureBack        == null) Debug.LogError("TextureBack is not set");
        if (textureSlime       == null) Debug.LogError("TextureSlime is not set");
        if (textureClothes     == null) Debug.LogError("TextureClothes is not set");
        if (textureHat         == null) Debug.LogError("TextureHat is not set");
        if (textureWeaponRight == null) Debug.LogError("TextureWeaponRight is not set");
        if (textureWeaponLeft  == null) Debug.LogError("TextureWeaponLeft is not set");
    }

    public void RawImageUPdate()
    {
        var characterDatabaseCharacter = DataManager.Instance.CharacterDatabase.characters[characterId];
        if (characterDatabaseCharacter != null)
        {
            SetTextureAlpha(textureRearity, DataManager.Instance.CharacterDatabase.rarityTextures[(int)characterDatabaseCharacter.rarity]);
            SetTextureAlpha(textureBack, characterDatabaseCharacter.textureBack);
            SetTextureAlpha(textureSlime, characterDatabaseCharacter.textureSlime);
            SetTextureAlpha(textureClothes, characterDatabaseCharacter.textureClothes);
            SetTextureAlpha(textureHat, characterDatabaseCharacter.textureHat);
            SetTextureAlpha(textureWeaponRight, characterDatabaseCharacter.textureWeaponRight);
            SetTextureAlpha(textureWeaponLeft, characterDatabaseCharacter.textureWeaponLeft);
        }
        else
        {
            Debug.LogError($"Character with ID {characterId} not found in the database.");
        }
    }

    void SetTextureAlpha(RawImage image, Texture texture)
    {
        image.texture = texture ?? image.texture;
        image.color = new Color(image.color.r, image.color.g, image.color.b, texture ? 1 : 0);
    }
}