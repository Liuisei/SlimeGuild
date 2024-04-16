using UnityEngine;
using Random = UnityEngine.Random;

public class GachaManager : Singleton<GachaManager>
{
    public override void AwakeFunction()
    {      
    }
    
    public void DrawGacha()
    {
        int id = Random.Range(0, DataManager.Instance.CharacterDatabase.characters.Count); 
        DataManager.Instance.playerCharacters[id].quantity++;  
        DataManager.Instance.GetCharacterList.Add(id);
        Debug.Log("ADD" + id);
    }
}