using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PartySelectContent : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private int characterId;

    private bool _isSelected = false;

    [SerializeField]
    private GameObject characterSelectedPanel;

    [SerializeField]
    private CharacterView characterView;

    [SerializeField]
    private TextMeshProUGUI partyNumberText;
    
    [SerializeField]
    private TextMeshProUGUI textLevel; // キャラクターのレベル


    private void Start()
    {
        UpdateIsSelected();
    }

    public void UpdatePartySelectContent(int id)
    {
        characterId = id;
        characterView.CharacterId = id;
        textLevel.text = "Lv:" + DataManager.Instance.GetCharacterLevel(id);
    }


    /// <summary>
    ///  パーティーに選択されているかどうかを更新する
    /// </summary>
    private void UpdateIsSelected()
    {
        if (DataManager.Instance.PartyList.Contains(characterId))
        {
            _isSelected = true;
            characterSelectedPanel.SetActive(true);
            partyNumberText.SetText(DataManager.Instance.PartyList.IndexOf(characterId).ToString());
        }
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