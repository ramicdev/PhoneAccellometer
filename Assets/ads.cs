using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
public class ads : MonoBehaviour
{
    public static ads instance;

   // private string appID = "ca-app-pub-1577922149336120~6954330200";

    private BannerView bannerView;
    private string bannerID = "ca-app-pub-1577922149336120/7366939301";

    private InterstitialAd fullScreenAd;
    private string fullScreenAdID = "ca-app-pub-1577922149336120/8911777652";
    public float delay;
    public float hidedelay;
    public float counter;
   
    public GameObject gameovercanvas;
    public GameObject maincanvas;
    public GameObject continuebutton;
    private RewardedAd rewardedAd;
    private string rewardedid = "ca-app-pub-1577922149336120/9801530951";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
        RequestBanner();
    }

    private void Start()
    {
        if (((Input.touchCount > 0) || (Input.GetMouseButton(0))) && (maincanvas.activeSelf))
        {
            Time.timeScale = 1;
        }

        delay = 10.0f;
        hidedelay = 30.0f;
        MobileAds.Initialize(initStatus => { });
        RequestFullScreenAd();
        StartCoroutine(delayedShowBanner(delay));
        RequestRewarded();
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

    }


    public void RequestBanner()
    {if (PlayerPrefs.GetInt("buynoads", 0) == 0)
        {
            bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);

            AdRequest request = new AdRequest.Builder().Build();

            bannerView.LoadAd(request);

            bannerView.Show();
            StartCoroutine(delayedShowBanner(delay));
            StartCoroutine(hidedelayedShowBanner(hidedelay));
        }
    }

    public void HideBanner()
    {
        bannerView.Hide();
        StartCoroutine(delayedShowBanner(delay));
    }

    public void RequestFullScreenAd()
    {
        
            fullScreenAd = new InterstitialAd(fullScreenAdID);

            AdRequest request = new AdRequest.Builder().Build();

            fullScreenAd.LoadAd(request);
        

    }
    public void installlabyrinth()
    {
#if UNITY_ANDROID
Application.OpenURL("market://details?id=com.DevelopingbyRamic.LabyrinthRunner");

#endif
    }
    public void installZombie()
    {
#if UNITY_ANDROID
Application.OpenURL("market://details?id=com.Ramic.IQTestBrainTesting");

#endif
    }

    private IEnumerator delayedShowBanner(float delay)
    {
        yield return new WaitForSeconds(delay);
        RequestBanner();

    }
    private IEnumerator hidedelayedShowBanner(float hidedelay)
    {
        yield return new WaitForSeconds(hidedelay);
       HideBanner();

    }
    private IEnumerator countdown(float counter)
    {
        yield return new WaitForSeconds(counter);
        Time.timeScale = 1;

    }
    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        if ((fullScreenAd.IsLoaded())&& (PlayerPrefs.GetInt("buynoads", 0) == 0))
        {
            fullScreenAd.Show();
            RequestFullScreenAd();
        }
        else
        {
            Debug.Log("Full screen ad not loaded");
            RequestFullScreenAd();
        }
    }
    public void RateUs()
    {
#if UNITY_ANDROID
Application.OpenURL("market://details?id=com.Ramic.BallDestroyer");
PlayerPrefs.SetInt("rated", 1);
        Debug.Log("rated");
#endif


    }


    public void RequestRewarded()
    {
        rewardedAd = new RewardedAd(rewardedid);

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);

    }
    public void ShowADforunlock()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
            RequestRewarded();

        }
        else
        {
            Debug.Log("Full screen ad not loaded");
            RequestRewarded();
        }
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        continuebutton.SetActive(true);
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
        continuebutton.SetActive(false);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        RequestRewarded();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        maincanvas.SetActive(true);
        gameovercanvas.SetActive(false);
     
       
    }
    void Update()
    {

        if (((Input.touchCount > 0) || (Input.GetMouseButton(0)))&&(maincanvas.activeSelf))
        {
            Time.timeScale = 1;
        }
        
    }


}