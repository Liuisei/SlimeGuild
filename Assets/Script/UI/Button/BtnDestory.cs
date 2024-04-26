using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDestory : MyButton
{
    [SerializeField] GameObject _target;
    // Start is called before the first frame update

    protected override void OnButtonUp()
    {
        Destroy(_target);
        DataManager.Instance.PartySetUp();
    }
}
