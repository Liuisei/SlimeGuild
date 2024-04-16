using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UGCharactorIcon : MonoBehaviour,IPointerUpHandler
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

    protected  void Awake()
    {
        if (characterImage == null)
        {
            Debug.LogError("Graphic component is not assigned in " + gameObject.name);
            enabled = false;
        }
    }

    void Start()
    {
        UpdateGraphic();
    }
    

    private void UpdateGraphic()
    {
        characterImage.texture = DataManager.Instance.CharacterDatabase.characters[ViewId].characterIcon;
        Debug.Log("UpdateIcon: " + ViewId);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("UGCharactorIcon OnPointerUp");
    }
}