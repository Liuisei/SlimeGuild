using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PartySelectContent : MonoBehaviour, IPointerUpHandler,IPointerDownHandler
{
    [SerializeField]
    private RawImage characterImage;
    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private int characterId;
    private bool _isSelected = false;
    [SerializeField]
    private GameObject characterSelectedPanel;
    
    [FormerlySerializedAs("partyIndexText")]
    [SerializeField]
    private TextMeshProUGUI partyNumberText;

    
    public int CharacterId
    {
        set
        {
            characterId = value;
            UpdateCharacterImage();
            UpdateLevelTextCountText();
            UpdateIsSelected();
        }
    }

    private void Awake()
    {
        if (characterImage == null) Debug.LogError("CharacterImage is not set");
        if (levelText      == null) Debug.LogError("levelText is not set");
    }

    private void UpdateIsSelected()
    {
        if (DataManager.Instance.PartyList.Contains(characterId))
        {
            _isSelected = true;
            characterSelectedPanel.SetActive(true);
            partyNumberText.SetText(DataManager.Instance.PartyList.IndexOf(characterId).ToString());
        }
    }
    
    private void UpdateCharacterImage()
    {
        characterImage.texture = DataManager.Instance.CharacterDatabase.characters[characterId].textureSlime;
    }

    private void UpdateLevelTextCountText()
    {
        levelText.SetText("X" + DataManager.Instance.GetCharacterHaveCount(characterId).ToString());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isSelected == false)
        {
            if (DataManager.Instance.IsPartyIndexMax()) return;
            _isSelected = true;
            characterSelectedPanel.SetActive(true); 
            
            partyNumberText.SetText(DataManager.Instance.AddSelectPartyList(characterId).ToString());
        }
        else
        {
            _isSelected = false;
            characterSelectedPanel.SetActive(false);
             DataManager.Instance.RemoveSelectPartyList(characterId);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PartySelectContent OnPointerDown");
    }
}