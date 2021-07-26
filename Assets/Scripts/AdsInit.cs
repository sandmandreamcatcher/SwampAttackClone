using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    private string gameId = "4233387";
    private bool testMode = true;
    
    void Start()
    {
        Advertisement.Initialize(gameId,testMode);
        StartCoroutine(ShowBannerWhenReady());
    }
    
 IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("Banner_Android"))
        {
            yield return new WaitForSeconds(0.5f);
        }
    //    Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_RIGHT);
        Advertisement.Banner.Show("Banner_Android");
        
    }
}