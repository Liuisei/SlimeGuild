using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPartyChara : MyButton
{
    private int _index;
    public int index
    {
        set { _index = value; }
    }

    protected override void OnButtonUp()
    {
    }
}

