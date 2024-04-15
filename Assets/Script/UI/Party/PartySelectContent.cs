using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartySelectContent : MonoBehaviour,IPointerUpHandler
{
    [SerializeField]
    private RawImage characterImage;

    [SerializeField]
    private TextMeshProUGUI haveCountText;
    

    [SerializeField]
    private int characterId;
    

    
    private bool _isSelected = false;
    
    [SerializeField]
    private GameObject characterSelectedPanel;
    
    
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
        if (haveCountText == null) Debug.LogError("HaveCountText is not set");
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
        if (_isSelected == false)
        {
            if (DataManager.Instance.IsPartyIndexMax()) return;
            DataManager.Instance.SelectPartyIndex++;
            _isSelected = true;
            characterSelectedPanel.SetActive(true);
            // DataManager.Instance.AddSelectPartyList(characterId);
        }
        else
        {
            _isSelected = false;
            characterSelectedPanel.SetActive(false);
            // DataManager.Instance.RemoveSelectPartyList(characterId);
        }
    }
}