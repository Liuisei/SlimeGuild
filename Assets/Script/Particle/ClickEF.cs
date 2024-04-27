using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ClickEf : MonoBehaviour
{
    public GameObject _clickEffectSF;

    Queue<GameObject> _clickEffectList = new Queue<GameObject>();
    
    void OnEnable()
    {
        DataManager.Instance.OnClicked += SpawnEffect;
    }
    void OnDisable()
    {
        DataManager.Instance.OnClicked -= SpawnEffect;
    }


    void SpawnEffect()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        
        if (_clickEffectList.Count < 30)
        {
           var a = Instantiate(_clickEffectSF, worldPos, Quaternion.identity);
            _clickEffectList.Enqueue(a);
            
        }
        else
        {
            var a = _clickEffectList.Dequeue();

            a.transform.position = worldPos;
            a.GetComponent<ParticleSystem>().Play();
            
            _clickEffectList.Enqueue(a);
        }
        
      
    }
    
}