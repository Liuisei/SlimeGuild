using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagContent : MonoBehaviour,IPointerUpHandler
{
    [SerializeField]
    private RawImage characterImage;

    [SerializeField]
    private TextMeshProUGUI haveCountText;
    

    [SerializeField]
    private int characterId;
    
    
    public int CharacterId
    {
        set
        {
            characterId = value;
            UpdateCharacterImage();
            UpdaterHaveCountText();
        } 
    }
    private void Awake()
    {
        if (characterImage == null) Debug.LogError("CharacterImage is not set");
        if (haveCountText  == null) Debug.LogError("HaveCountText is not set");
    }
    private void UpdateCharacterImage()
    {
        characterImage.texture = DataManager.Instance.CharacterDatabase.GetCharacter(characterId).characterIcon;
    }
    private void UpdaterHaveCountText()
    {
        haveCountText.SetText(DataManager.Instance.GetCharacterHaveCount(characterId).ToString());
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}