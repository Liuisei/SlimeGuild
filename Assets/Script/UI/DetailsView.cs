using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailsView : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    CharacterView _characterViewSF;

    [SerializeField]
    TextMeshProUGUI _levelTextSF;

    [SerializeField]
    TextMeshProUGUI _countTextSF;

    [SerializeField]
    TextMeshProUGUI _datailsTextSF;

    public void OpenDaetails(int id)
    {
        _characterViewSF.CharacterId = id;
        _levelTextSF.text            = "Lv:" + DataManager.Instance.GetCharacterLevel(id);
        _countTextSF.text            = "X"   + DataManager.Instance.GetCharacterQuantity(id);
        _datailsTextSF.text          = DataManager.Instance.GetCharacterDetails(id);
    }
}