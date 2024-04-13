using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    [SerializeField]
    GameObject bagprefab;
    [SerializeField]
    Transform bagParent;
    
    private List<GameObject> bagprefabs = new List<GameObject>();

    private void Start()
    {
        UpdateBag();
    }

    public void UpdateBag()
    {
        foreach (var e in bagprefabs)
        {
            Destroy(e);
        }
        bagprefabs.Clear();
        
        for (int i = 0; i < DataManager.Instance.CharacterDatabase.characters.Count; i++)
        {
            if (DataManager.Instance.HaveCharacterList[i] != 0)
            {
                Debug.Log("BagManager: " + i);
                var newBagprefab = Instantiate(bagprefab, bagParent);
                bagprefabs.Add(newBagprefab);
                var bagCharacterImage = newBagprefab.GetComponent<UGCharactorIcon>();
                bagCharacterImage.ViewId = i;
                var bagCharacterIndex = newBagprefab.GetComponent<UGCharactorIndex>();
                bagCharacterIndex.ViewId = i;
                
            }
        }
    }
}