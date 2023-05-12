using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using ChartboostSDK;

public class CooldownSkis : MonoBehaviour {

    public int secondsCooldown = 15;
    public Image runProgress;
    public Text textNumMenu;
    public GameObject messageBox;
    private bool allowClick = false;
    //xu ly ngon ngu
    public Text textTitle, textInfo, textStatus;

    public void ShowMessageBox()
    {
        //xu ly ngon ngu
        int iLang = Modules.indexLanguage;
        textTitle.font = AllLanguages.listFontLangA[iLang];
        textTitle.text = AllLanguages.menuGetHoverboard[iLang];
        textInfo.font = AllLanguages.listFontLangB[iLang];
        textInfo.text = AllLanguages.menuNoteHoverboard[iLang];
        textStatus.font = AllLanguages.listFontLangA[iLang];
        if (runProgress.fillAmount >= 1)
            textStatus.text = AllLanguages.menuClickView[Modules.indexLanguage];
        else
            textStatus.text = AllLanguages.menuPleaseWait[Modules.indexLanguage];
        //xu ly khac
        InvokeRepeating("UpdateTime", 0, 1);
    }

    void UpdateTime()
    {
        DateTime dateTimeNow = DateTime.Now;
        DateTime dateTimeOld = Modules.LoadOldDateTime("GetSkis");
        double totalSeconds = (dateTimeNow - dateTimeOld).TotalSeconds;
        if (totalSeconds < 0)//neu thoi gian am, chung to nguoi dung doi gio nguoc lai.
        {
            //thuc hien xoa sach skis hien co
            Modules.totalSkis = 0;
            Modules.SaveSkis();
            textNumMenu.text = Modules.totalSkis.ToString();
            Modules.SaveNewDateTime("GetSkis");
            ButtonCloseClick();
            return;
        }
        float percent = (float)totalSeconds / (float)secondsCooldown;
        if (percent >= 1)
        {
            percent = 1;
            allowClick = true;
            textStatus.text = AllLanguages.menuClickView[Modules.indexLanguage];
        }
        else
        {
            allowClick = false;
            textStatus.text = AllLanguages.menuPleaseWait[Modules.indexLanguage];
        }
        runProgress.fillAmount = percent;
    }

    public void ButtonCloseClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        CancelInvoke("UpdateTime");
        messageBox.GetComponent<Animator>().SetTrigger("TriClose");
    }

    public void ButtonViewAdsClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        if (!allowClick) return;
        Modules.SaveNewDateTime("GetSkis");
        Modules.itemBonusViewAds = "Skis";
#if (UNITY_IOS || UNITY_ANDROID || UNITY_WEBGL) && !UNITY_EDITOR
        if (Modules.admobAds)
            ADSController.Instance.RequestRewardBasedVideo(true, CallReward);
        else
        {
            if (Application.isMobilePlatform)
            {
                if (Chartboost.hasRewardedVideo(CBLocation.Default))
                {
                    Chartboost.showRewardedVideo(CBLocation.Default);
                    Chartboost.cacheRewardedVideo(CBLocation.Default);
                }
            }
        }
#elif (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0) && !UNITY_EDITOR
        if (Modules.adsInter.HaveVideoAds())
            Modules.adsInter.ShowVideoAds("rewardSkis");
        else Modules.adsInter.RequestVideoAds();
#endif
    }

    private void didCompleteRewardedVideo(CBLocation location, int reward)
    {
        Modules.RewardKeysSkis();
    }

    void OnEnable()
    {
        Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
    }

    void OnDisable()
    {
        Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
    }

    private void CallReward(bool obj)
    {
        if (obj) Modules.RewardKeysSkis();
    }
}
