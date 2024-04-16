using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AUGPower : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    public void OnEnable()
    {
        DataManager.Instance.OnNowPowerChanged += UpdateText;
        UpdateText();
    }
    public void OnDisable()
    {
        DataManager.Instance.OnNowPowerChanged += UpdateText;
    }
    public void UpdateText()
    {
        textMeshProUGUI.text = DataManager.Instance.NowPower.ToString();
    }
}