using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClicker : MyButton
{
    protected override void OnButtonUp()
    {
        DataManager.Instance.ClickAddMoney();
        SoundManager.Instance.PlaySE(SeSoundData.Se.Clicker);
    }
}