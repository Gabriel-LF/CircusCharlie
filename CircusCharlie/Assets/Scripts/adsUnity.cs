using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsUnity : MonoBehaviour, IUnityAdsListener
{
    string GooglePlay_ID = "4226975";
    bool TestMode = false;

    string video = "Rewarded_Android";
    string banner = "Banner_Android";

    public PlayerProgress pp;
    public MainMenu mm;
    public Lootbox lb;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, TestMode);

        while (!Advertisement.IsReady(banner))
            yield return null;
        ShowBanner();
    }

    public void ShowBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(banner);
    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public void DisplayInterstitialAD()
    {
        Advertisement.Show();
    }

    public void DisplayVideoAD()
    {
        Advertisement.Show(video);
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(video))
        {
            Advertisement.Show(video);
        }
        else
        {
            Debug.LogWarning("O vídeo não está pronto no momento, tente novamente mais tarde!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            if (pp.deathCount <= 0)
                lb.WatchAd();
            if (pp.deathCount == 1)
                pp.Revive();
            if (pp.deathCount >= 2)
                mm.DoubleReward();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.

            Debug.Log(" Você pulou o vídeo ");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("O vídeo não foi concluído devido a um erro");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == video)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
