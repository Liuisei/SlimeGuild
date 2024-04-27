using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartySelectManager : UIListManager<PartySelectContent>
{
    protected override bool HasItem(int id)
    {
        return DataManager.Instance.HasCharacter(id);
    }

    protected override List<int> GetOrderedIDList()
    {
        return DataManager.Instance.CharacterDatabase.characters.Where(e => DataManager.Instance.HasCharacter(e.characterId)).
            Select(x => x.characterId).OrderBy(e => e).ToList();
        
    }

    protected override List<int> GetOrderedIDByHaveCountList()
    {
        throw new System.NotImplementedException();
    }

    protected override List<int> GetOrderedIDByRerity()
    {
        throw new System.NotImplementedException();
    }


    protected override void UpdateItem(int index, int id)
    {
        Debug.Log("UpdateItem" + index + " " + id);
        ItemList[index].UpdatePartySelectContent(id);
    }
}