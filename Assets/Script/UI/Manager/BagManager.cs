using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BagManager : UIListManager<BagView>
{
    
    protected override bool HasItem(int id)
    {
        return DataManager.Instance.HasCharacter(id);
    }

    private void OnEnable()
    {
        DataManager.Instance.OnPlayerCharacterListChanged += Updateitems;
    }
    
    public void Updateitems()
    {
        UpdateItems(GetOrderedIDList());
    }
    
    

    protected override List<int> GetOrderedIDList()
    {
        return DataManager.Instance.CharacterDatabase.characters.Where(e => DataManager.Instance.HasCharacter(e.characterId)).
            Select(x => x.characterId).OrderBy(e => e).ToList();
    }

    protected override List<int> GetOrderedIDByHaveCountList()
    {
        throw new NotImplementedException();
    }

    protected override List<int> GetOrderedIDByRerity()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateItem(int index, int id)
    {
        Debug.Log("UpdateItem" + index + " " + id);
        ItemList[index].SetBagData(id);
    }
}