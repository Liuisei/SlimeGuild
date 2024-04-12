using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ImageView : MonoBehaviour
{
    //set image serialized field
    [SerializeField]
    private RawImage _rawimage;
    
    private void Start()
    {
        int id = DataManager.Instance.GetCharacterList[0];
        
        DataManager.Instance.GetCharacterList.RemoveAt(0);
        
        DrawImage(id);
    }
    
    //画像の描画
    public void DrawImage(int id)
    {
        //キャラクターデータベースからキャラクターの情報を取得
        
        GachaCharacter data = DataManager.Instance.CharacterDatabase.characters[id];
        
        //キャラクターの画像をセット
        _rawimage.texture = data.characterIcon;
    }
    
}
