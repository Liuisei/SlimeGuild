using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPartySelect : MyButton
{
    [SerializeField]
    private GameObject partyMask;

    [SerializeField]
    private bool isPartyMask = false;
    protected override void OnButtonUp()
    {
        Debug.Log("BtnPartySelect");
        if (isPartyMask == false && DataManager.Instance.IsPartyIndexMax() == false)
        {
            partyMask.SetActive(true);
            isPartyMask = true;
            DataManager.Instance.SelectPartyIndex++;
        }
        else
        {
            partyMask.SetActive(false);
            isPartyMask = false;
            DataManager.Instance.SelectPartyIndex--;

        }
    }
}