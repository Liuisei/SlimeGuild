using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TipView : MonoBehaviour
{
    // Start is called before the first frame update

    int _id ;


    public int ID
    {
        get => _id;
        set
        {
            _id = value;
            OpenDetails();
        }
    }

    [SerializeField]
    CharacterView _characterViewSF;
    
    [SerializeField]
    TextMeshProUGUI _tipTextSF;


    public void OpenDetails()
    {
        _characterViewSF.CharacterId = _id;
        _tipTextSF.text              = DataManager.Instance.GetCharacterTip(_id);
    }
}