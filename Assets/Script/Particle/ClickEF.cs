using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ClickEf : MonoBehaviour
{
    [FormerlySerializedAs("clickEffect")]
    public GameObject _clickEffectSF;
    [FormerlySerializedAs("cam")]
    public Camera     _camSF;
    
    void OnEnable()
    {
        DataManager.Instance.OnClicked += SpawnEffect;
    }
    
    void SpawnEffect()
    {
        // Get the position of the main camera
        Vector3 cameraPos = Camera.main.transform.position;

        // Instantiate the clickEffect at the camera's position
        var effect = Instantiate(_clickEffectSF, cameraPos, Quaternion.identity);

    }
    
}