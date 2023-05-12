using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ListResourcesGame : MonoBehaviour {

    public List<Sprite> listIconLang = new List<Sprite>();
    public List<Font> listFontLangA = new List<Font>();
    public List<Font> listFontLangB = new List<Font>();
    public List<Sprite> listIconItem = new List<Sprite>();//0 skis, 1 giay, 2 magnet, 3 rocket, 4 2X, 5 cable
    public List<Sprite> listIconBonus = new List<Sprite>();//0 coin, 1 keys, 2 skis, 3 headStart, 4 scoreBooster
    public List<ListMissionsClass> listMissions = new List<ListMissionsClass>();//chua cac icon, model de suu tap item
    public List<ListChallengeClass> listChallenge = new List<ListChallengeClass>();//chua cac gia tri, model de suu tap chu
    public Sprite iconHeadStart, iconScoreBooster, iconWorld;
    public Text textWaitAMoment;
    public Mesh mesCoinNormal, mesCoinDouble;
    public Material matCoinNormal, matCoinDouble;
    //them cac audios
    public List<AudioSource> audioSource;
    public AudioClip audioBackgrond, audioRoadBonus, audioTempleRun, audioBGMenu, audioBGOpenBox, audioBGWheelSpin;
    public AudioClip audioButton, audioTapPlay, audioOpenBox, audioSwipeMove, audioSwipeUp, audioSwipeDown, audioUpSkis, audioBoatSwipeMove, audioBoatRun;
    public AudioClip audioCollider, audioColliderDie, audioSurprise, audioShowMessage, audioRocket, audioCable, audioJetBall, audioTrapoline, audioBrokenGlass;
    public AudioClip audioParReborn, audioParColSkis, audioBonusText, audioEatBonusBox, audioTrapClose;
    public AudioClip audioSneakerLeft, audioSneakerRight, audioSneakerJump, audioPickSpinWheel, audioChallMissDone, audioTaskDone, audioBuyCoin;
    public AudioClip audioSkisJumpStart, audioSkisJumpLanding, audioJetpackStart, audioBoatSpeedUp, audioBoatDown, audioBoatJump;
    public AudioClip audioUpgrade, audioKeyReborn;
    public List<AudioClip> audioPoStart, audioPoNear, audioPoFar;
    public List<AudioClip> audioMissCatchMale, audioMissCatchFemale;
    public AudioClip audioDiamondFrenzy;
    public List<AudioClip> audioDeliveryBag;
    public GameObject parUnlockA, parUnlockB, parWaterDown;
    public GameObject mesDiamondDeduction, mesDiamondIncrease, effectCatchFlyCam;
    public GameObject mesX2Diamonds, mesX4Diamonds, mesMultiplyX12, mesMultiplyX18, mesMultiplyX30, mesMultiplyX50, mesMultiplyX80, mesMultiplyX100, mesMultiplyX150, mesYouRock, mesBikerPride;
    public GameObject hoverSecretBox1, hoverSecretBox2;//cac hoverboard khi an secretbox
    public Material skyNormal, skyBonus, skyTemple;
    public List<Sprite> listBadge = new List<Sprite>();
    public List<Material> listMaterTrain = new List<Material>();

    void Start()
    {
        StartCoroutine(GetLinkStore());
        //StartCoroutine(LoadImage(Modules.linkAvatarNull + Modules.codeHeroUse + ".jpg"));
        if (Modules.fbLinkAvatar == "Null") Modules.fbLinkAvatar = Modules.linkAvatarNull + Modules.codeHeroUse + ".jpg";
        AllLanguages.listIconLang = listIconLang;
        AllLanguages.listFontLangA = listFontLangA;
        AllLanguages.listFontLangB = listFontLangB;
        Modules.listIconItem = listIconItem;
        Modules.listIconBonus = listIconBonus;
        Modules.listMissions = listMissions;
        Modules.listChallenge = listChallenge;
        Modules.iconHeadStart = iconHeadStart;
        Modules.iconScoreBooster = iconScoreBooster;
        Modules.iconWorld = iconWorld;
        Modules.audioSource = audioSource;
        Modules.audioBackgrond = audioBackgrond;
        Modules.audioRoadBonus = audioRoadBonus;
        Modules.audioTempleRun = audioTempleRun;
        Modules.audioBGMenu = audioBGMenu;
        Modules.audioBGOpenBox = audioBGOpenBox;
        Modules.audioBGWheelSpin = audioBGWheelSpin;
        Modules.audioButton = audioButton;
        Modules.audioTapPlay = audioTapPlay;
        Modules.audioOpenBox = audioOpenBox;
        Modules.audioSwipeMove = audioSwipeMove;
        Modules.audioSwipeUp = audioSwipeUp;
        Modules.audioSwipeDown = audioSwipeDown;
        Modules.audioBoatSwipeMove = audioBoatSwipeMove;
        Modules.audioBoatRun = audioBoatRun;
        Modules.audioSneakerLeft = audioSneakerLeft;
        Modules.audioSneakerRight = audioSneakerRight;
        Modules.audioSneakerJump = audioSneakerJump;
        Modules.audioSkisJumpStart = audioSkisJumpStart;
        Modules.audioSkisJumpLanding = audioSkisJumpLanding;
        Modules.audioJetpackStart = audioJetpackStart;
        Modules.audioBoatSpeedUp = audioBoatSpeedUp;
        Modules.audioBoatDown = audioBoatDown;
        Modules.audioBoatJump = audioBoatJump;
        Modules.audioUpgrade = audioUpgrade;
        Modules.audioKeyReborn = audioKeyReborn;
        Modules.audioPickSpinWheel = audioPickSpinWheel;
        Modules.audioChallMissDone = audioChallMissDone;
        Modules.audioTaskDone = audioTaskDone;
        Modules.audioBuyCoin = audioBuyCoin;
        Modules.audioUpSkis = audioUpSkis;
        Modules.audioCollider = audioCollider;
        Modules.audioSurprise = audioSurprise;
        Modules.audioColliderDie = audioColliderDie;
        Modules.audioShowMessage = audioShowMessage;
        Modules.audioRocket = audioRocket;
        Modules.audioCable = audioCable;
        Modules.audioJetBall = audioJetBall;
        Modules.audioTrapoline = audioTrapoline;
        Modules.audioBrokenGlass = audioBrokenGlass;
        Modules.audioParReborn = audioParReborn;
        Modules.audioParColSkis = audioParColSkis;
        Modules.audioBonusText = audioBonusText;
        Modules.audioEatBonusBox = audioEatBonusBox;
        Modules.audioTrapClose = audioTrapClose;
        Modules.audioPoStart = audioPoStart;
        Modules.audioPoNear = audioPoNear;
        Modules.audioPoFar = audioPoFar;
        Modules.audioMissCatchMale = audioMissCatchMale;
        Modules.audioMissCatchFemale = audioMissCatchFemale;
        Modules.parUnlockA = parUnlockA;
        Modules.parUnlockB = parUnlockB;
        Modules.parWaterDown = parWaterDown;
        Modules.mesCoinNormal = mesCoinNormal;
        Modules.mesCoinDouble = mesCoinDouble;
        Modules.matCoinNormal = matCoinNormal;
        Modules.matCoinDouble = matCoinDouble;
        Modules.skyNormal = skyNormal;
        Modules.skyTemple = skyTemple;
        Modules.skyBonus = skyBonus;
        Modules.listBadge = listBadge;
        Modules.listMaterTrain = listMaterTrain;
        Modules.audioDiamondFrenzy = audioDiamondFrenzy;
        Modules.audioDeliveryBag = audioDeliveryBag;
        Modules.mesDiamondDeduction = mesDiamondDeduction;
        Modules.mesDiamondIncrease = mesDiamondIncrease;
        Modules.effectCatchFlyCam = effectCatchFlyCam;
        Modules.mesX2Diamonds = mesX2Diamonds;
        Modules.mesX4Diamonds = mesX4Diamonds;
        Modules.mesMultiplyX12 = mesMultiplyX12;
        Modules.mesMultiplyX18 = mesMultiplyX18;
        Modules.mesMultiplyX30 = mesMultiplyX30;
        Modules.mesMultiplyX50 = mesMultiplyX50;
        Modules.mesMultiplyX80 = mesMultiplyX80;
        Modules.mesMultiplyX100 = mesMultiplyX100;
        Modules.mesMultiplyX150 = mesMultiplyX150;
        Modules.mesYouRock = mesYouRock;
        Modules.mesBikerPride = mesBikerPride;
        Modules.hoverSecretBox1 = hoverSecretBox1;
        Modules.hoverSecretBox2 = hoverSecretBox2;
        textWaitAMoment.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        textWaitAMoment.text = AllLanguages.menuWaitMoment[Modules.indexLanguage];
        //AudioSource[] audioSource = transform.GetComponents<AudioSource>();
        //foreach (AudioSource audio in audioSource)
        //    Modules.audioSource.Add(audio);
        //InvokeRepeating("FreeUpRam", 20f, 20f);
#if !UNITY_EDITOR
        Application.targetFrameRate = 60;
        //QualitySettings.vSyncCount = 0;
#endif
    }

    private IEnumerator GetLinkStore()
    {
        WWWForm form = new WWWForm();
        form.AddField("index", Modules.linkStoreGame);
        WWW _resuilt = new WWW(Modules.linkChange, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text != "")
        { //hoan thanh
            Modules.linkStoreNow = _resuilt.text;
            //print(Modules.linkStoreNow);
        }
        else
        { //qua lau, khong mang, cau lenh loi
        }
        yield break;
    }

    IEnumerator LoadImage(string url)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null)
        {
            int width = www.texture.width;
            int height = www.texture.height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            Modules.iconAvatarNull = Sprite.Create(www.texture, new Rect(0, 0, width, height), new Vector2(0, 0));
            if (Modules.fbLinkAvatar == "Null") Modules.fbLinkAvatar = url;
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    void FreeUpRam()
    {
        System.GC.Collect();
        Modules.textDebug.text += "\nFree ram ";
    }

    void Update()
    {
//#if (UNITY_STANDALONE || UNITY_WEBGL)
//        if (Time.frameCount % 1000 == 0)
//        {
//            Modules.FreeMemoryNow(false);
//        }
//#endif
        //thuc hien check callback reward doi voi uwp
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0) && !UNITY_EDITOR
        if (Time.frameCount % 50 == 0)
        {
            if (Modules.adsInter.GetCallbackVideo() == "rewardSkis")
            {
                Modules.itemBonusViewAds = "Skis";
                Modules.RewardKeysSkis();
                Modules.adsInter.ResetCallbackVideo();
            }
            else if (Modules.adsInter.GetCallbackVideo() == "rewardKeys")
            {
                Modules.itemBonusViewAds = "Key";
                Modules.RewardKeysSkis();
                Modules.adsInter.ResetCallbackVideo();
            }
            else if (Modules.adsInter.GetCallbackVideo() == "rewardCoin")
            {
                Modules.itemBonusViewAds = "DoubleCoins";
                Modules.RewardDoubleCoin();
                Modules.adsInter.ResetCallbackVideo();
            }
            else if (Modules.adsInter.GetCallbackVideo() == "rewardReborn")
            {
                Modules.RewardReborn();
                Modules.adsInter.ResetCallbackVideo();
            }
        }
#endif
    }
}
