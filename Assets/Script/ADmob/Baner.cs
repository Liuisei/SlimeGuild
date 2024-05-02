using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class Baner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdmobLibrary.RequestBanner(AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Bottom, true);
    }
    
}
