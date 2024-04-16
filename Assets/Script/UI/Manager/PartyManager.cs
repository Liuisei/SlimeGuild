using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    List<PartyCharacter> partyList = new List<PartyCharacter>();


    private void Start()
    {
        UpdatePartyList();
        DataManager.Instance.OnPartyChanged += UpdatePartyList;
    }

    private void OnEnable()
    {
        
    }
    
    private void OnDisable()
    {
        DataManager.Instance.OnPartyChanged -= UpdatePartyList;
    }
    

    void UpdatePartyList()
    {
        for (int i = 0; i < partyList.Count; i++)
        {
            partyList[i].ViewId = DataManager.Instance.PartyList[i];
        }
    }
}