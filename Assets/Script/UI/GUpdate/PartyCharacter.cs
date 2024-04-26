using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartyCharacter : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler,
    IPointerExitHandler
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
    }


    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_viewId == -1)
        {
            Debug.Log("None Character Seted");
        }
        else
        {
            Debug.Log("Character Seted");
            StartCoroutine(LogAfterDelay());
        }
    }

    private IEnumerator LogAfterDelay()
    {
        Debug.Log("Character Tip1");
        yield return new WaitForSeconds(1);
        Debug.Log("Character Tip");
        DataManager.Instance.TipSpawn(_viewId);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
    }
}