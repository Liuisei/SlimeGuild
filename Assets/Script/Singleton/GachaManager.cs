using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GachaManager : Singleton<GachaManager>
{
    public override void AwakeFunction()
    {      
    }
    
    public void DrawGacha()
    {
       
        int index = Random.Range(0, DataManager.Instance.CharacterDatabase.characters.Count); // ランダムなインデックスを取得
        
        DataManager.Instance.HaveCharacterList[index]++; // ゲットしたキャラクターのインデックスをリストに追加

        DataManager.Instance.GetCharacterList.Add(index); // ゲットしたキャラクターのインデックスをリストに追加
        Debug.Log("ADD" + index);
    }
}