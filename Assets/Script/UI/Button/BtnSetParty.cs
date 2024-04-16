using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetParty : MyButton
{

    protected override void OnButtonUp()
    {
        DataManager.Instance.PartySetUp();
    }
}
