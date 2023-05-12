using System;
using UnityEngine;
using System.Collections;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
using GoogleMobileAds;
using GoogleMobileAds.Api;
//using GoogleMobileAds.Api.Mediation.AppLovin;
#endif
#pragma warning disable 0219
#pragma warning disable 0414
#if UNITY_WEBGL
using System.Runtime.InteropServices;
#endif

public class ADSController : MonoBehaviour
{
    public string bannerAndroid, bannerIOS;
    public string interstitialAndroid, interstitialIOS;
    public string rewardAndroid, rewardIOS;
    private string bannerAdId, interstitialAdId, rewardVideoAdId;
    public bool useApplovin = true;
    public string SDK_KEY = "d6bXGyNUki3LU4NRya_m-3xp_E43TJl6QKehH1A_kDLCIieEId_Ghx4g98kcRTkspMX4Ni46xPID7ySPaRgGNm";
    [HideInInspector]
    public AdsState rewardState = AdsState.None;
    //NOTE BUILD ANDROID API LEVEL 14 (ANDROID 4.0) HOẶC CAO HƠN
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
#endif
    public static ADSController Instance;
    public bool blockAds = false;

    void Awake()
    {
        Instance = this;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        //AppLovin.Initialize();
#endif
    }

    public void Start()
    {
#if UNITY_ANDROID
        bannerAdId = bannerAndroid;
        interstitialAdId = interstitialAndroid;
        rewardVideoAdId = rewardAndroid;
#else
        bannerAdId = bannerIOS;
        interstitialAdId = interstitialIOS;
        rewardVideoAdId = rewardIOS;
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
        this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
        this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
        this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
        this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
        this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
        if (useApplovin)
        {
            AppLovin.SetSdkKey(SDK_KEY);
            AppLovin.InitializeSdk();
            AppLovin.SetUnityAdListener(transform.name);
        }
#elif UNITY_WEBGL && !UNITY_EDITOR
        jsCloseClick();
#endif
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    public void RequestRewardBasedVideo(bool autoShow, Action<bool> callBackW = null)
    {
        if (!autoShow) return;
        jsOpenRewardClick();
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(CountDown(10, callBackW));
    }

    Coroutine coroutine;
    IEnumerator CountDown(int i, Action<bool> callBack = null)
    {
        while (i >= 0)
        {
            jsCountDown(i);
            yield return new WaitForSeconds(1f);
            i--;
        }
        if (callBack != null) callBack(true);
        jsCloseClick();
        yield break;
    }
    //void CloseAds()
    //{
    //    if (this.callBackW != null) callBackW(true);
    //    jsCloseClick();
    //}

    public void RequestInterstitial(bool autoShow)
    {

    }

    public void ShowInterstitial()
    {
        jsOpenClick();
        //jsRefreshClick();
    }

    [DllImport("__Internal")]
    private static extern void jsOpenClick();

    [DllImport("__Internal")]
    private static extern void jsOpenRewardClick();

    [DllImport("__Internal")]
    private static extern void jsCloseClick();

    [DllImport("__Internal")]
    private static extern void jsRefreshClick();

    [DllImport("__Internal")]
    private static extern void jsCountDown(int i);
#endif

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    // Returns an ad request with custom ad targeting.
    private AdRequest adRequest = new AdRequest.Builder().Build();
    #region  Banner
    public void RequestBanner()
    {
        if (blockAds) return;
        if (useApplovin) return;
        // These ad units are configured to always serve test ads.
        this.bannerView = new BannerView(bannerAdId, AdSize.SmartBanner, AdPosition.Top);
        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;
        // Load a banner ad.
        this.bannerView.LoadAd(adRequest);
    }

    public void DestroyBanner()
    {
        if (blockAds) return;
        if (useApplovin) return;
        if (this.bannerView != null) this.bannerView.Destroy();
    }

    public void HideBanner()
    {
        if (blockAds) return;
        if (useApplovin) return;
        if (this.bannerView != null) this.bannerView.Hide();
    }

    public void ShowBanner()
    {
        if (blockAds) return;
        if (useApplovin)
        {
            AppLovin.ShowAd(AppLovin.AD_POSITION_CENTER, AppLovin.AD_POSITION_BOTTOM);
            return;
        }
        if (this.bannerView != null) this.bannerView.Show();
    }
    #endregion

    #region Interstitial
    bool interstitialAutoShow = false;
    AdsState interstitialState = AdsState.None;
    public void RequestInterstitial(bool autoShow)
    {
        if (blockAds) return;
        if (interstitialState == AdsState.Loaded && autoShow)
        {
            ShowInterstitial();
            return;
        }
        else if(interstitialState == AdsState.Loading)
        {
            interstitialAutoShow = autoShow;
            return;
        }
        if (useApplovin)
        {
            AppLovin.PreloadInterstitial();
            interstitialState = AdsState.Loading;
        }
        else
        {
            // These ad units are configured to always serve test ads.
            if (this.interstitial == null || !this.interstitial.IsLoaded())
            {
                // Create an interstitial.
                this.interstitial = new InterstitialAd(interstitialAdId);
                // Register for ad events.
                this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
                this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
                this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
                this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
                this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
                // Load an interstitial ad.
                this.interstitial.LoadAd(adRequest);
                interstitialState = AdsState.Loading;
            }
        }
        interstitialAutoShow = autoShow;
    }

    public void ShowInterstitial()
    {
        if (blockAds) return;
        if (useApplovin)
        {
            if (AppLovin.HasPreloadedInterstitial())
            {
                AppLovin.ShowInterstitial();
                interstitialAutoShow = false;
                interstitialState = AdsState.None;
            }
            else AppLovin.PreloadInterstitial();
            return;
        }
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            interstitialAutoShow = false;
            interstitialState = AdsState.None;
        }
    }

    public void DestroyInterstitial()
    {
        if (blockAds) return;
        if (useApplovin) return;
        if (this.interstitial != null) this.interstitial.Destroy();
    }
    #endregion

    #region Reward Based Video
    bool rewardVideoAutoShow = false;
    Action<bool> callBack;
    public void RequestRewardBasedVideo(bool autoShow, Action<bool> callBack = null)
    {
        if (blockAds) return;
        this.callBack = callBack;
        if (rewardState == AdsState.Loaded && autoShow)
        {
            ShowRewardBasedVideo();
            return;
        }
        else if (rewardState == AdsState.Loading)
        {
            rewardVideoAutoShow = autoShow;
            return;
        }
        if (useApplovin)
            AppLovin.LoadRewardedInterstitial();
        else
            this.rewardBasedVideo.LoadAd(adRequest, rewardVideoAdId);
        rewardVideoAutoShow = autoShow;
    }

    public void ShowRewardBasedVideo()
    {
        if (blockAds) return;
        if (useApplovin)
        {
            if (AppLovin.IsPreloadedInterstitialVideo())
            {
                Time.timeScale = 0;
                Camera.main.GetComponent<AudioListener>().enabled = false;
                AppLovin.ShowRewardedInterstitial();
                rewardState = AdsState.None;
                rewardVideoAutoShow = false;
            }
            return;
        }
        if (this.rewardBasedVideo.IsLoaded())
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            this.rewardBasedVideo.Show();
            rewardState = AdsState.None;
            rewardVideoAutoShow = false;
        }
    }
    #endregion

    #region Banner callback handlers
    public void HandleAdLoaded(object sender, EventArgs args)
    {
        print("Banner: load xong");
    }
    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("Banner: load loi");
    }
    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("Banner: da hien thi");
    }
    public void HandleAdClosed(object sender, EventArgs args)
    {
        print("Banner: da dong");
    }
    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("Banner: roi khoi ung dung");
    }
    #endregion

    #region Interstitial callback handlers
    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("Interstitial: load xong");
        interstitialState = AdsState.Loaded;
        if (interstitialAutoShow) ShowInterstitial();
    }
    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("Interstitial: load loi");
        interstitialState = AdsState.Error;
    }
    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("Interstitial: da hien thi");
    }
    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("Interstitial: da dong");
    }
    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("Interstitial: roi khoi ung dung");
    }
    #endregion

    #region Reward Based Video callback handlers
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        print("Reward Based Video: load xong");
        rewardState = AdsState.Loaded;
        if (this.callBack != null) this.callBack(false);
        if (rewardVideoAutoShow) ShowRewardBasedVideo();
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("Reward Based Video: load loi");
        rewardState = AdsState.Error;
        if (this.callBack != null) this.callBack(false);
    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        print("Reward Based Video: da hien thi");
    }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        print("Reward Based Video: da bat dau chay");
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        print("Reward Based Video: da dong");
        Time.timeScale = 1;
        Camera.main.GetComponent<AudioListener>().enabled = true;
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //string type = args.Type;
        //double amount = args.Amount;
        print("Reward Based Video: xem xong va tra thuong");
        if (this.callBack != null) this.callBack(true);
    }
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        print("Reward Based Video: roi khoi ung dung");
    }
    #endregion

    #region Applovin callback handlers
    //void onAppLovinEventReceived(string ev)
    //{
    //    if (ev.Contains("REWARDAPPROVEDINFO"))
    //    {
    //        if (this.callBack != null)
    //            this.callBack(true);
    //    }
    //    else if (ev.Contains("LOADEDREWARDED"))
    //    {
    //        rewardState = AdsState.Loaded;
    //        if (this.callBack != null)
    //            this.callBack(false);
    //        if (rewardVideoAutoShow) ShowRewardBasedVideo();
    //    }
    //    else if (ev.Contains("LOADREWARDEDFAILED"))
    //    {
    //        rewardState = AdsState.Error;
    //        if (this.callBack != null)
    //            this.callBack(false);
    //    }
    //    else if (ev.Contains("HIDDENREWARDED"))
    //    {
    //        RequestRewardBasedVideo(false);
    //    }

    //    if (ev.Contains("DISPLAYEDINTER"))
    //    {
    //        print("Interstitial: da hien thi");
    //        interstitialState = AdsState.None;
    //        Time.timeScale = 0;
    //        //RequestInterstitial(false);
    //    }
    //    else if (ev.Contains("HIDDENINTER"))
    //    {
    //        print("Interstitial: da dong");
    //        interstitialState = AdsState.None;
    //        Time.timeScale = 1;
    //        RequestInterstitial(false);
    //    }
    //    else if (ev.Contains("LOADEDINTER"))
    //    {
    //        // An interstitial ad was successfully loaded.
    //        print("Interstitial: load xong");
    //        interstitialState = AdsState.Loaded;
    //        if (interstitialAutoShow) ShowInterstitial();
    //    }
    //    else if (string.Equals(ev, "LOADINTERFAILED"))
    //    {
    //        print("Interstitial: load loi");
    //        interstitialState = AdsState.Error;
    //    }
    //}
    void onAppLovinEventReceived(string ev)
    {
        if (ev.Contains("DISPLAYEDINTER"))
        {
            // An ad was shown.  Pause the game.
        }
        else if (ev.Contains("HIDDENINTER"))
        {
            // Ad ad was closed.  Resume the game.
            // If you're using PreloadInterstitial/HasPreloadedInterstitial, make a preload call here.
            AppLovin.PreloadInterstitial();
        }
        else if (ev.Contains("LOADEDINTER"))
        {
            // An interstitial ad was successfully loaded.
            interstitialState = AdsState.Loaded;
            if (interstitialAutoShow) ShowInterstitial();
        }
        else if (string.Equals(ev, "LOADINTERFAILED"))
        {
            // An interstitial ad failed to load.
            interstitialState = AdsState.Error;
        }
        // The format would be "REWARDAPPROVEDINFO|AMOUNT|CURRENCY"
        if (ev.Contains("REWARDAPPROVEDINFO"))
        {
            // Process an event like REWARDAPPROVEDINFO:100:Credits
            //char[] delimiter = { '|' };
            //string[] split = ev.Split(delimiter);
            // Pull out the amount of virtual currency.
            //double amount = double.Parse(split[1]);
            // Pull out the name of the virtual currency
            //string currencyName = split[2];
            // Do something with this info - for example, grant coins to the user
            //print("Rewarded " + amount + " " + currencyName);
            if (this.callBack != null) this.callBack(true);
        }
        else if (ev.Contains("LOADEDREWARDED"))
        {
            // A rewarded video was successfully loaded.
            rewardState = AdsState.Loaded;
            if (this.callBack != null) this.callBack(false);
            if (rewardVideoAutoShow) ShowRewardBasedVideo();
        }
        else if (ev.Contains("LOADREWARDEDFAILED"))
        {
            // A rewarded video failed to load.
            rewardState = AdsState.Error;
            if (this.callBack != null) this.callBack(false);
        }
        else if (ev.Contains("HIDDENREWARDED"))
        {
            // A rewarded video has been closed.  Preload the next rewarded video.
            AppLovin.LoadRewardedInterstitial();
            Time.timeScale = 1;
            Camera.main.GetComponent<AudioListener>().enabled = true;
        }
    }
    #endregion
#endif
}

public enum AdsState
{
    None,
    Created,
    Loading,
    Loaded,
    Error
}