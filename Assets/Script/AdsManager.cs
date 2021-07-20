using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static string rewardId = "Rewarded_Android";
    public static string intertitailAd = "Interstitial_Android";
#if UNITY_IOS
    static string gameId = "4211236";
#else
    static string gameId = "4211237";
#endif
    void Start()
    {
        Advertisement.Initialize(gameId,true);
    }

   public static void PlayIntertitailAds()
    {
        Debug.Log("INITTTTT");
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }
   
}
