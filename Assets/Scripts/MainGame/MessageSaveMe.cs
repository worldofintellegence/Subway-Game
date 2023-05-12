using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ChartboostSDK;

public class MessageSaveMe : MonoBehaviour {

    public Image iconCooldown;
    public Text textKey, totalTextKey;
    public int timeCooldown = 3;//tinh bang giay
    private bool mesShow = false;
    private int totalTime = 0;
    private int tunTime = 0;
    private bool clickReborn = false;
    //xu ly ngon ngu
    public Text textSaveMe, textSaveMeAds;
    
    public void StartShowMessage()
    {
        int iLang = Modules.indexLanguage;
        textSaveMe.font = AllLanguages.listFontLangA[iLang];
        textSaveMe.text = AllLanguages.playSaveMe[iLang];
        if (textSaveMeAds != null)
        {
            textSaveMeAds.font = AllLanguages.listFontLangA[iLang];
            textSaveMeAds.text = AllLanguages.playSaveMeAds[iLang];
        }
        totalTextKey.font = AllLanguages.listFontLangA[iLang];
        totalTextKey.text = Modules.totalKey.ToString();
        textKey.text = Mathf.Pow(2, Modules.timeSaveMe).ToString();
        iconCooldown.fillAmount = 1f;
        totalTime = Modules.SecondsToTimePerFrame(timeCooldown);
        tunTime = 0;
        mesShow = true;
        clickReborn = false;
    }

    public void ButtonSaveMeClick()
    {
        if (tunTime >= totalTime) return;
        clickReborn = true;
        Modules.PlayAudioClipFree(Modules.audioButton);
        //xu ly kiem tra du key chua, neu du thi thuc thi hoi sinh, khong thi hien bang mua
        if (!Modules.HandleReborn())//neu khong du thi hien thi bang mua key
        {
            Modules.mesNotEnoughKey.SetActive(true);
            Modules.mesNotEnoughKey.GetComponent<MessageBuyKeys>().StartShowMessage();
        }
        transform.gameObject.GetComponent<Animator>().SetTrigger("TriClose");
        tunTime = 0;
        mesShow = false;
    }

    public void ButtonSaveMeAdsClick()
    {
        if (tunTime >= totalTime || !mesShow) return;
        tunTime = 0;
        mesShow = false;
        clickReborn = true;
        Modules.PlayAudioClipFree(Modules.audioButton);
#if (UNITY_IOS || UNITY_ANDROID || UNITY_WEBGL) && !UNITY_EDITOR
        if (Modules.admobAds)
        {
            ADSController.Instance.RequestRewardBasedVideo(true, CallReward);
        }
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
            Modules.adsInter.ShowVideoAds("rewardReborn");
        else Modules.adsInter.RequestVideoAds();
#endif
    }

    private void didCompleteRewardedVideo(CBLocation location, int reward)
    {
        HandleClickAdsDone();
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
        if (obj)
        {
            tunTime = 0;
            mesShow = false;
            Invoke("HandleClickAdsDone", 0.5f);
        }
    }

    public void HandleClickAdsDone()
    {
        Modules.RebornNow();
        transform.gameObject.GetComponent<Animator>().SetTrigger("TriClose");
        tunTime = 0;
        mesShow = false;
    }

    public void PanelOutsideClick(bool check = true)
    {
        if (check) if (clickReborn) return;
        if (Modules.bonusFirst > 0)
        {
            if (Modules.winRunning != 0)
                Modules.ShowMessageWinRunning();
            else Modules.HandleGameOver();
        }
        else Modules.ShowBonusFirst();
        transform.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (mesShow)
        {
            if (tunTime >= totalTime)
            {
                mesShow = false;
                if (Modules.bonusFirst > 0)
                {
                    if (Modules.winRunning != 0)
                        Modules.ShowMessageWinRunning();
                    else Modules.HandleGameOver();
                }
                else Modules.ShowBonusFirst();
                transform.gameObject.SetActive(false);
            }
            else
            {
                tunTime++;
                iconCooldown.fillAmount = 1f - (float)tunTime / (float)totalTime;
            }
        }
    }
}
