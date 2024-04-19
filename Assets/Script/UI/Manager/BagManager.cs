using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BagManager : UIListManager<CharacterView>
{
    protected override bool HasItem(int id)
    {
        return DataManager.Instance.HasCharacter(id);
    }

    protected override List<int> GetOrderedIDList()
    {
        return DataManager.Instance.CharacterDatabase.characters.Select(x => x.characterId).ToList();
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
        Debug.Log("UpdateItem"+index+" "+id);
        ItemList[index].CharacterId = id;
    }
}