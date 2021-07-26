using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsForWeapon : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject watchAd;
    [SerializeField] private Player _player;

    private string gameId = "";
    private string myPlacementId = "";
    private bool testMode = true;
    private IUnityAdsListener _unityAdsListenerImplementation;


    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

        watchAd.GetComponent<Button>().onClick.AddListener(() =>
        {
            Advertisement.Show(myPlacementId);
        //   watchAd.SetActive(false);
        });
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            watchAd.SetActive(true);
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            _player.AddMoney(5);
        }
        else if (showResult == ShowResult.Skipped)
        {
        }
        else if (showResult == ShowResult.Failed)
        {
        }
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }
}
