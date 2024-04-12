using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  class Textview : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    // Text プロパティを追加して、外部からのアクセスを制御する
    public Text TextComponent
    {
        get { return _text; }
        set { _text = value; }
    }

    private void OnEnable()
    {
        // DataManager インスタンスの OnMoneyChanged イベントに購読
        DataManager.Instance.OnMoneyChanged += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        // 解除する必要がある場合、OnDisable でイベントの購読解除を行う
        DataManager.Instance.OnMoneyChanged -= UpdateText;
    }

    public void UpdateText()
    {
        // DataManager インスタンスの Money プロパティを参照してテキストを更新
        _text.text = DataManager.Instance.Money.ToString();
    }
}