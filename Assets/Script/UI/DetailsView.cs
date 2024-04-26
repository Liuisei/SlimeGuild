using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DetailsView : MonoBehaviour
{
    // Start is called before the first frame update

    int id = 0;


    public int ID
    {
        get => id;
        set
        {
            id = value;
            OpenDetails();
        }
    }

    [SerializeField]
    CharacterView _characterViewSF;

    [SerializeField]
    TextMeshProUGUI _levelTextSF;

    [SerializeField]
    TextMeshProUGUI _countTextSF;

    [SerializeField]
    TextMeshProUGUI _detailsTextSF;

    [SerializeField]
    TextMeshProUGUI _updateTextSF;

    public void OpenDetails()
    {
        _characterViewSF.CharacterId = id;
        _levelTextSF.text            = "Lv:" + DataManager.Instance.GetCharacterLevel(id);
        _countTextSF.text            = "X"   + DataManager.Instance.GetCharacterQuantity(id);
        _detailsTextSF.text          = DataManager.Instance.GetCharacterDetails(id);
        _updateTextSF.text = $"{DataManager.Instance.GetCharacterQuantity(id)}/"    +
                             $"{DataManager.Instance.GetCharacterLevel(id) * 100 }\n" +
                             $"LvUp";
    }
}