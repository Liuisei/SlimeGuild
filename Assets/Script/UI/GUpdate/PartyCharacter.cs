using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartyCharacter : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private RawImage characterImage;

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
        if (characterImage == null)
        {
            Debug.LogError("Graphic component is not assigned in " + gameObject.name);
            enabled = false;
        }
    }


    private void UpdateGraphic()
    {
        if (_viewId == -1)
        {
            characterImage.texture = null;
            return;
        }

        characterImage.texture = DataManager.Instance.CharacterDatabase.characters[ViewId].characterIcon;
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