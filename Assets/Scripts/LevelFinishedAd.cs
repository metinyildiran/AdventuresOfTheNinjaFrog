using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishedAd : MonoBehaviour
{
    private RewardedAd rewardedAd;
    // private string adUnitId = "ca-app-pub-3940256099942544/5224354917";  // test id
    private string adUnitId = "ca-app-pub-8024686626348837/3572953894";

    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        
        rewardedAd = new RewardedAd(adUnitId);
        
        var request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);

        rewardedAd.OnAdClosed += HandleRewardedAdLoaded;
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded()) {
            rewardedAd.Show();
        }
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}