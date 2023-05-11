using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Hiep_AdManager : SingletonMono<Hiep_AdManager>
{
    public string appID = "ca-app-pub-5366914889955115~8768911034";
    public string banner_ID = "ca-app-pub-3940256099942544/6300978111";
    public string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
    public string reward_ID = "ca-app-pub-3940256099942544/5224354917";

    private BannerView bannerAd;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    public event Action OnInterstitialClosed = delegate { };

    public event Action OnRewarded = delegate { };
    public event Action OnRewardFail = delegate { };
    public event Action OnRewardClosed = delegate { };

    private void Awake()
    {
        MobileAds.Initialize(initStatus =>
        {
        });

        RequestBanner();
        RequestInterstitialAd();
        RequesRewardAd();
    }

    private void OnEnable()
    {
        HandleBannerAdEvents(true);
        HandleInterstitialAdEvents(true);
        HandleRewardAdEvents(true);
    }

    private void OnDisable()
    {
        HandleBannerAdEvents(false);
        HandleInterstitialAdEvents(false);
        HandleRewardAdEvents(false);
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()            
            .AddKeyword("game")            
            .Build();
    }

    #region Banner
    private void RequestBanner()
    {
        bannerAd = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerAd.LoadAd(CreateAdRequest());
    }

    public void ShowBanner()
    {
        if (bannerAd != null)
        {
            bannerAd.Show();
        }
    }

    public void HideBanner()
    {
        if (bannerAd != null)
        {
            bannerAd.Hide();
        }
    }

    private void HandleBannerAdEvents(bool subcribe)
    {
        if (subcribe)
        {
            bannerAd.OnAdLoaded += HandleOnAdLoaded;
            bannerAd.OnAdClosed += HandleOnAdClosed;
            bannerAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            bannerAd.OnAdOpening += HandleOnAdOpening;
        }
        else
        {
            bannerAd.OnAdLoaded -= HandleOnAdLoaded;
            bannerAd.OnAdClosed -= HandleOnAdClosed;
            bannerAd.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            bannerAd.OnAdOpening -= HandleOnAdOpening;
        }
    }

    private void HandleOnAdOpening(object sender, EventArgs e)
    {
        Debug.Log("HandleOnAdOpening");
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdLoaded");
    }

    public void HandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdFailedToLoad");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdClosed");
    }
    #endregion

    #region Interstitial
    public void DisplayInterstitialAd()
    {
        ShowInterstitialAd();
        RequestInterstitialAd();
    }

    public void RequestInterstitialAd()
    {
        interstitialAd = new InterstitialAd(interstitial_ID);

        this.interstitialAd.OnAdClosed -= HandleOnInterstitialAdClosed;
        this.interstitialAd.OnAdClosed += HandleOnInterstitialAdClosed;

        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            OnInterstitialClosed.Invoke();
        }
        else
        {
            if (interstitialAd.IsLoaded())
            {
                interstitialAd.Show();
            }
            else
            {
                OnInterstitialClosed.Invoke();
            }
        }            
    }

    private void HandleInterstitialAdEvents(bool subcribe)
    {
        if (subcribe)
        {
            interstitialAd.OnAdLoaded += HandleOnInterstitialAdLoaded;
            interstitialAd.OnAdClosed += HandleOnInterstitialAdClosed;
            interstitialAd.OnAdFailedToLoad += HandleOnIntertitialAdFailedToLoad;
            interstitialAd.OnAdOpening += HandleOnInterstitialAdOpening;
            interstitialAd.OnPaidEvent += HandleOnInterstitialAdPaid;
        }
        else
        {
            interstitialAd.OnAdLoaded -= HandleOnInterstitialAdLoaded;
            interstitialAd.OnAdClosed -= HandleOnInterstitialAdClosed;
            interstitialAd.OnAdFailedToLoad -= HandleOnIntertitialAdFailedToLoad;
            interstitialAd.OnAdOpening -= HandleOnInterstitialAdOpening;
            interstitialAd.OnPaidEvent -= HandleOnInterstitialAdPaid;
        }
    }

    private void HandleOnInterstitialAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("HandleOnInterstitialAdLoaded");
    }

    private void HandleOnInterstitialAdPaid(object sender, AdValueEventArgs e)
    {
        Debug.Log("HandleOnInterstitialAdPaid");
    }

    private void HandleOnInterstitialAdOpening(object sender, EventArgs e)
    {
        Debug.Log("HandleOnInterstitialAdOpening");
    }

    private void HandleOnIntertitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.Log("HandleOnIntertitialAdFailedToLoad");
    }

    private void HandleOnInterstitialAdClosed(object sender, EventArgs e)
    {
        Time.timeScale = 1;        
        OnInterstitialClosed?.Invoke();
    }
    #endregion

    #region Reward
    public void DisplayRewardAd()
    {
        ShowRewardAd();
        RequesRewardAd();
    }

    public void ShowRewardAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void RequesRewardAd()
    {
        rewardedAd = new RewardedAd(reward_ID);

        this.rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed -= HandleRewardAdClosed;
        this.rewardedAd.OnAdClosed += HandleRewardAdClosed;

        AdRequest adRequest = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(CreateAdRequest());
    }

    private void HandleRewardAdEvents(bool subcribe)
    {
        if (subcribe)
        {
            rewardedAd.OnAdLoaded += HandleRewardAdLoaded;
            rewardedAd.OnAdFailedToLoad += HandlRewardAdFailedToLoad;
            rewardedAd.OnAdFailedToShow += HandleRewardAdFailedToShow;
            rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            rewardedAd.OnAdClosed += HandleRewardAdClosed;
        }
        else
        {
            rewardedAd.OnAdLoaded -= HandleRewardAdLoaded;
            rewardedAd.OnAdFailedToLoad -= HandlRewardAdFailedToLoad;
            rewardedAd.OnAdFailedToShow -= HandleRewardAdFailedToShow;
            rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
            rewardedAd.OnAdClosed -= HandleRewardAdClosed;
        }
    }

    private void HandleRewardAdClosed(object sender, EventArgs e)
    {
        Time.timeScale = 1;
        OnRewardClosed?.Invoke();
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        OnRewarded?.Invoke();
    }

    private void HandleRewardAdFailedToShow(object sender, AdErrorEventArgs e)
    {
        Debug.Log("HandleRewardAdFailedToShow");
    }

    private void HandlRewardAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.Log("HandlRewardAdFailedToLoad");
    }

    private void HandleRewardAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("HandleRewardAdLoaded");
    }
    #endregion
}
