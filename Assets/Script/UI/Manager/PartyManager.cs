using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> partyList = new List<GameObject> ();
    
    //patylist update bu datamanager partylist
    private void Start() 
    {
        UpdateParty();
    }

    private void UpdateParty()
    {
        for (int i = 0; i < DataManager.Instance.PartyList.Count; i++)
        {
            partyList[i].GetComponent<UGCharactorIcon>().ViewId = DataManager.Instance.PartyList[i];
            
        }
    }
    
    
}