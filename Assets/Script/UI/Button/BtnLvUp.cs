using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BtnLvUp : MyButton
{
    // Start is called before the first frame update
 
    [SerializeField] DetailsView _targetSF;
    
     
    protected override void OnButtonUp()
    {
        if (DataManager.Instance.GetCharacterQuantity(_targetSF.ID) >= DataManager.Instance.GetCharacterLevel(_targetSF.ID)*10)
        {
            DataManager.Instance.LevelUp(_targetSF.ID);
            _targetSF.OpenDetails();
        }
    }
    

}
