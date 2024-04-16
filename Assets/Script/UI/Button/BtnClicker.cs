using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClicker : MyButton
{
    protected override void OnButtonUp()
    {
        DataManager.Instance.Money += DataManager.Instance.NowPower;
        Debug.Log("Money: " + DataManager.Instance.Money);
    }
}