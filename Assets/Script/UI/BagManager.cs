using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    [SerializeField]
    private Transform bagTransform;
    [SerializeField]
    private GameObject bagCharacterViewPrefab;
    
    private List<BagCharacterView> _bagCharacterViews = new List<BagCharacterView>();


    void Start()
    {
        ViewCharactorWithID();
    }

    public void ViewCharactorWithID()
    {
        ClearBagCharacterView();
        
        for (int i = 0; i < DataManager.Instance.CharacterDatabase.characters.Count; i++)
        {
            if (DataManager.Instance.HaveCharacterList[i] > 0)
            {
                BagCharacterView(i);
            }
        }
    }

    void BagCharacterView(int characterNumber)
    {
        var bagCharacterView = Instantiate(bagCharacterViewPrefab, bagTransform).GetComponent<BagCharacterView>();
        bagCharacterView.SetrawImage(DataManager.Instance.CharacterDatabase.characters[characterNumber].characterIcon);
        bagCharacterView.SetText(DataManager.Instance.HaveCharacterList[characterNumber]);
        _bagCharacterViews.Add(bagCharacterView);
    }
    
    void ClearBagCharacterView()
    {
        foreach (var bagCharacterView in _bagCharacterViews)
        {
            Destroy(bagCharacterView.gameObject);
        }
        _bagCharacterViews.Clear();
    }
    
    
}
