using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
    public RawImage _textureRearitySF; // キャラクターのレアリティ

    [SerializeField]
    public RawImage _textureBackSF; // キャラクターの背景

    [SerializeField]
    private RawImage _textureSlimeSF; // キャラクターのスライム

    [SerializeField]
    public RawImage _textureClothesSF; // キャラクターの服

    [SerializeField]
    public RawImage _textureHatSF; // キャラクターの帽子

    [SerializeField]
    public RawImage _textureWeaponRightSF; // キャラクターの右手の武器

    [SerializeField]
    public RawImage _textureWeaponLeftSF; // キャラクターの左手の武器

    [SerializeField]
    private int _characterIdSF;

    private void Start()
    {
        RawImageUPdate();
        
    }

    public int CharacterId
    {
        get => _characterIdSF;
        set
        {
            _characterIdSF = value;
            RawImageUPdate();
        }
    }

    private void Awake()
    {
        if (_textureRearitySF     == null) Debug.LogError("TextureRearity is not set");
        if (_textureBackSF        == null) Debug.LogError("TextureBack is not set");
        if (_textureSlimeSF       == null) Debug.LogError("TextureSlime is not set");
        if (_textureClothesSF     == null) Debug.LogError("TextureClothes is not set");
        if (_textureHatSF         == null) Debug.LogError("TextureHat is not set");
        if (_textureWeaponRightSF == null) Debug.LogError("TextureWeaponRight is not set");
        if (_textureWeaponLeftSF  == null) Debug.LogError("TextureWeaponLeft is not set");
    }

    public void RawImageUPdate()
    {
        if (_characterIdSF == -1)
        {
            SetTextureAlpha(_textureRearitySF, DataManager.Instance.CharacterDatabase.rarityTextures[0]);
            SetTextureAlpha(_textureBackSF, 0);
            SetTextureAlpha(_textureSlimeSF, 0);
            SetTextureAlpha(_textureClothesSF, 0);
            SetTextureAlpha(_textureHatSF, 0);
            SetTextureAlpha(_textureWeaponRightSF, 0);
            SetTextureAlpha(_textureWeaponLeftSF, 0);
            return;
        }

        var characterDatabaseCharacter =
            DataManager.Instance.CharacterDatabase.characters.Find(character => character.characterId == _characterIdSF);
        if (characterDatabaseCharacter != null)
        {
            SetTextureAlpha(_textureRearitySF,
                DataManager.Instance.CharacterDatabase.rarityTextures[(int)characterDatabaseCharacter.rarity]);
            SetTextureAlpha(_textureBackSF, characterDatabaseCharacter.textureBack);
            SetTextureAlpha(_textureSlimeSF, characterDatabaseCharacter.textureSlime);
            SetTextureAlpha(_textureClothesSF, characterDatabaseCharacter.textureClothes);
            SetTextureAlpha(_textureHatSF, characterDatabaseCharacter.textureHat);
            SetTextureAlpha(_textureWeaponRightSF, characterDatabaseCharacter.textureWeaponRight);
            SetTextureAlpha(_textureWeaponLeftSF, characterDatabaseCharacter.textureWeaponLeft);
        }
        else
        {
            Debug.LogError($"Character with ID {_characterIdSF} not found in the database.");
        }
    }

    void SetTextureAlpha(RawImage image, Texture texture)
    {
        //NULL RETURN
        image.texture = texture ?? image.texture;
        image.color = new Color(image.color.r, image.color.g, image.color.b, texture ? 1 : 0);
    }

    void SetTextureAlpha(RawImage image, int alpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }
}