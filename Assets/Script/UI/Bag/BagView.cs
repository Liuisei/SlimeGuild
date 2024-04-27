using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagView : MonoBehaviour , IPointerUpHandler , IPointerDownHandler ,IPointerClickHandler
{
    [SerializeField]
    private CharacterView characterViewPrefab;

    [SerializeField]
    TextMeshProUGUI textLevel; // キャラクターのレベル
    [SerializeField]
    TextMeshProUGUI textQuantity; // キャラクターの所持数
    
    /// <summary>
    ///  キャラクターのインデックスを設定する
    /// </summary>
    /// <param name="id"></param>
    public void SetBagData(int id)
    {
        UpdateBugContent(id);
    }

    private void Awake()
    {
        if (characterViewPrefab == null) Debug.LogError("CharacterViewPrefab is not set");
        if (textLevel           == null) Debug.LogError("TextLevel is not set");
        if (textQuantity        == null) Debug.LogError("TextQuantity is not set");
    }

    private void UpdateBugContent(int id)
    {
        textLevel.text = "Lv:"  + DataManager.Instance.GetCharacterLevel(id).ToString();
        textQuantity.text = "x" + DataManager.Instance.GetCharacterQuantity(id).ToString();
        characterViewPrefab.CharacterId = id;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DataManager.Instance.DetialSPawn(characterViewPrefab.CharacterId);

    }
}