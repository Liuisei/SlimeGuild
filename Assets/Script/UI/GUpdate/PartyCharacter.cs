using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartyCharacter : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    
    [SerializeField]
    private CharacterView characterViewPrefab;

    private int _viewId;

    public int ViewId
    {
        get => _viewId;
        set
        {
            _viewId = value;
            UpdateGraphic();
            
        }
    }

    protected void Awake()
    {
        if (characterViewPrefab == null)
        {
            Debug.LogError("CharacterViewPrefab is not set");
            enabled = false;
        }
    }


    private void UpdateGraphic()
    {
        characterViewPrefab.CharacterId = _viewId;
        Debug.Log("UpdateIcon: " + ViewId);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (_viewId == -1)
        {
            Debug.Log("None Character Seted");
            return;
        }
        Debug.Log("PartyCharacter OnPointerUp");
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PartyCharacter OnPointerDown");
    }
}