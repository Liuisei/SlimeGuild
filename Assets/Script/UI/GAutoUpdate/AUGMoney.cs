using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AUGMoney : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    public void OnEnable()
    {
        DataManager.Instance.OnMoneyChanged += UpdateText;
        UpdateText();
    }
    public void OnDisable()
    {
        DataManager.Instance.OnMoneyChanged += UpdateText;
    }
    public void UpdateText()
    {
        textMeshProUGUI.text = DataManager.Instance.Money.ToString();
    }
}