using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using ChartboostSDK;

public class PageMainGame : MonoBehaviour {

    public GameObject containMainGame, containHeroConstruct, containAchievement, containShopItem, containHighScore, containOpenBox, containWheelSpin, containScratchCard, containRank;
    public GameObject containUIMenu, containUIPlay;
    public Text textTotalSkis, textTotalKeys, textCoinPlay, textScorePlay, textXPointPlay, textHighScore, textWorldScore;
    public GameObject containMesItems, containButtonBuy, containEffectAddPoint, containMesBoom;
    public GameObject panelShowEatItemsLeft, panelShowEatItemsRight, panelShowBuyItems, panelEffectAddPoint, panelHighScoreNow, panelGameGuide;
    public GameObject panelMissions, panelChallenge, panelBonus, panelCrackGlass, panelFakeCity, panelFakeTemple;
    public GameObject enemyLeft;
    public GameObject itemShoeLeft, itemShoeRight, itemMagnet, itemRocket, itemCable, itemJetBall;
    public Vector3 pointStartEnemyLeft = Vector3.zero;
    public GameObject mesSaveMeBox, mesSaveMeFullBox, mesPauseGame, mesCountTime,
        mesNotEnoughKey, mesSetting, getSkisBox,
        getKeysBox, missionsBox, challengeBox,
        listLanguageBox, rateBox, shareFBBox,
        inviteFBBox, bonusFirstBox, resultOnlineBox, listTaskBox, mesBuyHoverMore, mesBuyScoreMore;
    public GameObject panelBGEffectBonus, panelTextEffectBonus, panelTextEffectWinLose;
    public GameObject parSpeedFly, parReborn, parSkisCollider;
    public GameObject parentResultOnline;
    //xu ly intro game
    public GameObject parentCam;
    public GameObject policeCar;
    public Vector3 pointPoliceCar = Vector3.zero;
    //xu ly hieu ung tang thuong skis va keys
    public GameObject parentSkis, parentKey;
    public Text textSkis, textKey, textNeedKeys, textTotalKeySave;
    public GameObject butWheelSpin;
    //xu ly online mode
    public GameObject buttonHoverboard;
    //xu ly text effect
    public List<GameObject> textGood, textAwesome, textPerfect, textExcellent, textDiamond, textStartMove, textRoadBonus, textDelivery;
    public GameObject parentTextEffect, parentShowHide;
    public GameObject containFlyCam, containTraps, containSeaTraps;
    public GameObject panelChangeSky;
    public Material matBGChangeMap;
    public Color colorBGChangeMap = Color.white;
    public Color colorFogNormal = Color.white;
    public Color colorFogTemple = Color.white;
    //xu ly effect scorebooster
    public GameObject backgroundMeter;
    public GameObject frameScorebooster;
    public Image avatarTop, flagTop;
    //xu ly dia hinh nen o bien
    public GameObject seaPath;
    private GameObject seaPathUse;
    public GameObject buttonShareFB, buttonInviteFB;
    //xu ly thong bao nhan thuong weekly reward
    public GameObject mesWeekReward;
    public GameObject panelIconMe;
    public Image myAvatar, myFlag, myBadge;
    public GameObject mesPlayDogeMode;
    //xu ly bag controller
    public GameObject bagController;

    void Awake()
    {
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        buttonShareFB.SetActive(false);
        buttonInviteFB.SetActive(false);
#endif
        timeRunJump = curveJump.length;
        System.GC.Collect();
        Resources.UnloadUnusedAssets();
        originSwipeDistX = minSwipeDistX;
        originSwipeDistY = minSwipeDistY;
        Modules.UpdateValueSensitivity();
        //gan lai cac thiet lap vao modules
        Modules.containMainGame = containMainGame;
        Modules.containHeroConstruct = containHeroConstruct;
        Modules.containAchievement = containAchievement;
        Modules.containShopItem = containShopItem;
        Modules.containHighScore = containHighScore;
        Modules.containOpenBox = containOpenBox;
        Modules.containWheelSpin = containWheelSpin;
        Modules.containScratchCard = containScratchCard;
        Modules.containRank = containRank;
        Modules.textCoinPlay = textCoinPlay;
        Modules.textScorePlay = textScorePlay;
        Modules.textXPointPlay = textXPointPlay;
        Modules.textHighScore = textHighScore;
        Modules.textWorldScore = textWorldScore;
        Modules.containMesItems = containMesItems;
        Modules.containButtonBuy = containButtonBuy;
        Modules.containEffectAddPoint = containEffectAddPoint;
        Modules.containMesBoom = containMesBoom;
        Modules.containFlyCam = containFlyCam;
        Modules.containTraps = containTraps;
        Modules.containSeaTraps = containSeaTraps;
        Modules.panelChangeSky = panelChangeSky;
        Modules.matBGChangeMap = matBGChangeMap;
        Modules.colorBGChangeMap = colorBGChangeMap;
        Modules.colorFogNormal = colorFogNormal;
        Modules.colorFogTemple = colorFogTemple;
        Modules.panelShowEatItemsLeft = panelShowEatItemsLeft;
        Modules.panelShowEatItemsRight = panelShowEatItemsRight;
        Modules.panelEffectAddPoint = panelEffectAddPoint;
        Modules.panelHighScoreNow = panelHighScoreNow;
        Modules.panelGameGuide = panelGameGuide;
        Modules.panelMissions = panelMissions;
        Modules.panelChallenge = panelChallenge;
        Modules.panelBonus = panelBonus;
        Modules.panelCrackGlass = panelCrackGlass;
        Modules.panelBGEffectBonus = panelBGEffectBonus;
        Modules.panelTextEffectBonus = panelTextEffectBonus;
        Modules.panelTextEffectWinLose = panelTextEffectWinLose;
        Modules.parSpeedFly = parSpeedFly;
        Modules.parReborn = parReborn;
        Modules.parSkisCollider = parSkisCollider;
        Modules.mesSaveMeBox = mesSaveMeBox;
        Modules.mesSaveMeFullBox = mesSaveMeFullBox;
        Modules.mesNotEnoughKey = mesNotEnoughKey;
        Modules.itemShoeLeft = itemShoeLeft;
        Modules.itemShoeRight = itemShoeRight;
        Modules.itemMagnet = itemMagnet;
        Modules.itemRocket = itemRocket;
        Modules.itemCable = itemCable;
        Modules.itemJetBall = itemJetBall;
        Modules.bonusFirstBox = bonusFirstBox;
        Modules.resultOnlineBox = resultOnlineBox;
        Modules.parentResultOnline = parentResultOnline;
        Modules.panelFakeCity = panelFakeCity;
        Modules.panelFakeTemple = panelFakeTemple;
        Modules.buttonHoverboard = buttonHoverboard;
        Modules.parentTextEffect = parentTextEffect;
        Modules.parentShowHide = parentShowHide;
        Modules.textGood = textGood;
        Modules.textAwesome = textAwesome;
        Modules.textPerfect = textPerfect;
        Modules.textExcellent = textExcellent;
        Modules.textDiamond = textDiamond;
        Modules.textStartMove = textStartMove;
        Modules.textRoadBonus = textRoadBonus;
        Modules.textDelivery = textDelivery;
        Modules.avatarTop = avatarTop;
        Modules.flagTop = flagTop;
        ChangeAllLanguage();
    }

    void Start()
    {
        InvokeRepeating("EffectAddSkisKeys", 2, 2);
        ResetGame();
    }

    public void ResetGame()
    {
#if (UNITY_IOS || UNITY_ANDROID || UNITY_WEBGL) && !UNITY_EDITOR
        if (Modules.admobAds)
            ADSController.Instance.RequestInterstitial(false);
        else
        {
            Chartboost.cacheInterstitial(CBLocation.Default);
            Chartboost.cacheRewardedVideo(CBLocation.Default);
        }
#endif
        Modules.parSpeedFly.GetComponent<ParticleSystem>().Stop();
        rateBox.SetActive(false);
        containUIMenu.SetActive(true);
        containUIPlay.SetActive(false);
        Modules.textCoinPlay.text = "0";
        Modules.PlayAudioClipLoop(Modules.audioBGMenu, Camera.main.transform);
        //chinh lai camera
        Animator ani = transform.GetComponent<Animator>();
        ani.SetTrigger("TriReset");
        ani.enabled = true;
        //xu ly an hien cac page trong game main
        Modules.containMainGame.SetActive(true);
        Modules.containHeroConstruct.SetActive(false);
        Modules.containAchievement.SetActive(false);
        Modules.containShopItem.SetActive(false);
        Modules.containHighScore.SetActive(false);
        Modules.containOpenBox.SetActive(false);
        Modules.containWheelSpin.SetActive(false);
        Modules.containScratchCard.SetActive(false);
        Modules.containRank.SetActive(false);
        transform.GetComponent<MissionsController>().StartShowMessage(false);
        transform.GetComponent<ChallengeController>().StartShowMessage(false);
        //dieu khien trang thai trong man game
        textTotalSkis.text = Modules.totalSkis.ToString();
        textTotalKeys.text = Modules.totalKey.ToString();
        backgroundMeter.SetActive(false);
        backgroundMeter.transform.GetChild(2).rotation = Quaternion.Euler(Vector3.zero);
        frameScorebooster.SetActive(false);
        Modules.ResetGame();
        transform.GetComponent<CallFlyCam>().ResetFlyCam();
        Camera.main.GetComponent<TerrainController>().ResetTerrain();
        Camera.main.GetComponent<CameraController>().CallStart();
        //Camera.main.GetComponent<ChangeHeightFog>().ResetValue(true);
        Camera.main.GetComponent<ChangeHeightFog>().enabled = false;
        CreateCharacters();
        UpdateMyInfo();
        CheckTapNow();
    }

    bool firstChangeBadge = true;
    private void UpdateMyInfo()
    {
        //myAvatar.sprite = Modules.iconAvatarNull;
        StartCoroutine(LoadAvatar(Modules.fbLinkAvatar));
        string dataCountry = SaveLoadData.LoadData("CodeCountry", true);
        if (dataCountry == "") dataCountry = "Null";
        myFlag.sprite = Modules.GetIconFlag(dataCountry);
        bool checkSetTri = false;
        if (firstChangeBadge)
        {
            Modules.SetBadges(panelIconMe, Mathf.RoundToInt(Modules.totalScore));
            firstChangeBadge = false;
        }
        else
        {
            Sprite temp = Modules.GetBadgesSprite(Mathf.RoundToInt(Modules.totalScore));
            if (myBadge.sprite != temp)
            {
                panelIconMe.GetComponent<Animator>().SetTrigger("TriPlay");
                checkSetTri = true;
            }
        }
        if (!checkSetTri) panelIconMe.GetComponent<Animator>().SetTrigger("TriIdle");
    }

    public void CheckTapNow()
    {
        if (Modules.autoTapPlay)
        {
            Modules.autoTapPlay = false;
            ClickPlayGame(false);
        }
        //else
        //{
        //    if (Modules.totalUseGame >= 3 && Modules.clickRate == 0)
        //        Invoke("ShowRateBox", 1);
        //}
    }

    void ShowRateBox()
    {
        if (Modules.statusGame == StatusGame.menu
             && Modules.containMainGame.activeSelf
             && containUIMenu.activeSelf
             && CheckNoMessageShow())
            ButtonRateClick();
    }

    private Vector2 startPos;
    public float minSwipeDistY = 50f;
    public float minSwipeDistX = 50f;
    [HideInInspector]
    public float originSwipeDistY = 50f;
    [HideInInspector]
    public float originSwipeDistX = 50f;
    private bool firstSwipe = false;
    private int pressDown = 0;
    private float oldTimeTap = 0;
    public void InputButtonDown()
    {
        //xu ly click hoverboard
        pressDown++;
        if (pressDown <= 1)
            oldTimeTap = Time.time;
        else
        {
            if (Time.time - oldTimeTap <= 0.25f)
                UseHoverboard();
            pressDown = 0;
        }
        //xu ly swipe
        startPos = Input.mousePosition;
        firstSwipe = true;
    }

    public void UseHoverboard()
    {
        if (Modules.totalSkis <= 0 && !Modules.useSkis)
        {
            Modules.PlayAudioClipFree(Modules.audioButton);
            mesBuyHoverMore.SetActive(true);
            mesBuyHoverMore.GetComponent<Animator>().SetTrigger("TriOpen");
            MessageBuyHoverMore mesBuyHover = mesBuyHoverMore.GetComponent<MessageBuyHoverMore>();
            mesBuyHover.StartShowMessage();
            return;
        }
        Modules.mainCharacter.GetComponent<HeroController>().UseSkis();
    }

    public void BuyScoreBooster()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        mesBuyScoreMore.SetActive(true);
        mesBuyScoreMore.GetComponent<Animator>().SetTrigger("TriOpen");
        MessageBuyScoreMore mesBuyScore = mesBuyScoreMore.GetComponent<MessageBuyScoreMore>();
        mesBuyScore.StartShowMessage();
        return;
    }

    private float angleArrowMeter = 0;
    public void RunEffectScoreBooster()
    {
        if (!backgroundMeter.activeSelf)
        {
            backgroundMeter.SetActive(true);
            frameScorebooster.SetActive(true);
        }
        for (int i = 0; i < 7; i++)
        {
            if (i < Modules.countScoreUse - 1)//nhung cai can phai kiem tra va chay effect
            {
                if (!backgroundMeter.transform.GetChild(0).GetChild(i).gameObject.activeSelf)
                {
                    backgroundMeter.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
                    backgroundMeter.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                    backgroundMeter.transform.GetChild(0).GetChild(i).GetComponent<Animator>().Play("MeterEffectChangeRun", 0, 0);
                }
            }
            else//nhung cai chua chay den
            {
                backgroundMeter.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                backgroundMeter.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
            }
        }
        angleArrowMeter = -26.6f * (Modules.countScoreUse - 2);
        Modules.UpdateSpeedScoreBooster();
        CancelInvoke("HideBackgroundMeter");
        Invoke("HideBackgroundMeter", 5f);
    }

    void HideBackgroundMeter()
    {
        backgroundMeter.SetActive(false);
    }

    public void InputButtonUp()
    {
        oldSwipe = "";
        firstSwipe = false;
    }

    private string oldSwipe = "";
    public void InputButtonStay()
    {
        if (!firstSwipe) return;
        float swipeDistHorizontal = Mathf.Abs(Input.mousePosition.x - startPos.x);
        float swipeDistVertical = Mathf.Abs(Input.mousePosition.y - startPos.y);
        if (swipeDistHorizontal > swipeDistVertical)//vuot ngang
        {
            if (swipeDistHorizontal > minSwipeDistX * (float)Screen.width / Modules.KTCScenes.x)
            {
                float swipeValue = Input.mousePosition.x - startPos.x;
                if (swipeValue > 0)
                {
                    bool checkMoreMove = false;
                    if (oldSwipe == "") checkMoreMove = true;
                    oldSwipe = "right";
                    Modules.mainCharacter.GetComponent<HeroController>().MoveRight(checkMoreMove);
                    firstSwipe = false;
                    pressDown = 0;
                }
                else if (swipeValue < 0)
                {
                    bool checkMoreMove = false;
                    if (oldSwipe == "") checkMoreMove = true;
                    oldSwipe = "left";
                    Modules.mainCharacter.GetComponent<HeroController>().MoveLeft(checkMoreMove);
                    firstSwipe = false;
                    pressDown = 0;
                }
            }
        }
        else//vuot doc
        {
            if (swipeDistVertical > minSwipeDistY * (float)Screen.height / Modules.KTCScenes.y)
            {
                float swipeValue = Input.mousePosition.y - startPos.y;
                if (swipeValue > 0)
                {
                    bool checkMoreMove = false;
                    if (oldSwipe == "") checkMoreMove = true;
                    oldSwipe = "up";
                    Modules.mainCharacter.GetComponent<HeroController>().MoveUp(checkMoreMove);
                    firstSwipe = false;
                    pressDown = 0;
                }
                else if (swipeValue < 0)
                {
                    bool checkMoreMove = false;
                    if (oldSwipe == "") checkMoreMove = true;
                    oldSwipe = "down";
                    Modules.mainCharacter.GetComponent<HeroController>().MoveDown(checkMoreMove);
                    firstSwipe = false;
                    pressDown = 0;
                }
            }
        }
    }

    private bool CheckNoMessageShow()
    {
        bool result = true;
        if (mesSetting.activeSelf || mesPauseGame.activeSelf || mesSaveMeBox.activeSelf || mesSaveMeFullBox.activeSelf || mesNotEnoughKey.activeSelf
               || getSkisBox.activeSelf || getKeysBox.activeSelf || missionsBox.activeSelf || challengeBox.activeSelf
               || listLanguageBox.activeSelf || mesCountTime.activeSelf || rateBox.activeSelf || shareFBBox.activeSelf
               || inviteFBBox.activeSelf || bonusFirstBox.activeSelf | resultOnlineBox.activeSelf || listTaskBox.activeSelf || mesBuyHoverMore.activeSelf || mesBuyScoreMore.activeSelf) result = false;
        return result;
    }

    private float oldTime = 0;
    private float timeShowWarning = 25f;
    void Update()
    {
        if (Time.timeScale == 0) { InputButtonUp(); return; }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!CheckNoMessageShow())
                return;
            if (Modules.statusGame == StatusGame.play)
                ButtonPauseGameClick();
            else if (Modules.statusGame == StatusGame.menu)
                ButtonSettingClick();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Modules.mainCharacter.GetComponent<HeroController>().MoveUp(true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Modules.mainCharacter.GetComponent<HeroController>().MoveDown(true);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Modules.mainCharacter.GetComponent<HeroController>().MoveLeft(true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Modules.mainCharacter.GetComponent<HeroController>().MoveRight(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            UseHoverboard();
        }
        //xu ly su kien hieu ung play menu
        if (mesAniStart)
        {
            if (runTimeAniStart >= timeAniStart)
            {
                GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GameAnalyticsSDK.GAProgressionStatus.Start, "game");
                Modules.containMainGame.GetComponent<MessageTaskController>().AutoShowRemidTask();
                //hoan thanh viec nhay;
                mesAniStart = false;
                Modules.mainCharacter.transform.position = pointHeroTarget;
                //createEnemyLeft.transform.position = pointEnemyLeftTarget;
                //if (!Modules.versionExpress) createEnemyRight.transform.position = pointEnemyRightTarget;
                //khoi tao cac nhan vat trong game o day
                Modules.PlayAudioClipLoop(Modules.audioBackgrond, Camera.main.transform);
                Modules.statusGame = StatusGame.play;
                containUIPlay.SetActive(true);
                //#if (UNITY_IOS || UNITY_ANDROID)
                //      ADSController.Instance.RequestBanner();
                //#endif
                CreateButtonItemBuys();
                SetupCharacterPlay();
                Invoke("CheckAvatarEnemy", 1f);
                UpdateAvatarTop();
                panelMissions.SetActive(false);
                panelChallenge.SetActive(false);
                transform.GetComponent<CallFlyCam>().StartFlyCam();
                if (Modules.playDogecoinMode)
                {
                    mesPlayDogeMode.SetActive(true);
                    mesPlayDogeMode.GetComponent<Animator>().Play("PanelPlayDogecoinPlay");
                }
                else mesPlayDogeMode.SetActive(false);
                //xu ly guide
                if (Modules.gameGuide == "YES")
                {
                    Modules.SetAllowHoverbike(false);
                    Modules.panelGameGuide.SetActive(true);
                    Transform textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
                    textGuide.GetComponent<Text>().text = AllLanguages.playSwipeLeft[Modules.indexLanguage];
                    Transform arrowGuide = Modules.panelGameGuide.transform.Find("ArrowGuide");
                    Transform keyUp = Modules.panelGameGuide.transform.Find("KeyUp");
                    Transform keyDown = Modules.panelGameGuide.transform.Find("KeyDown");
                    Transform keyLeft = Modules.panelGameGuide.transform.Find("KeyLeft");
                    Transform keyRight = Modules.panelGameGuide.transform.Find("KeyRight");
                    Transform keySpace = Modules.panelGameGuide.transform.Find("KeySpace");
                    if (Application.isMobilePlatform)
                    {
                        arrowGuide.gameObject.SetActive(true);
                        keyUp.gameObject.SetActive(false);
                        keyDown.gameObject.SetActive(false);
                        keyLeft.gameObject.SetActive(false);
                        keyRight.gameObject.SetActive(false);
                        keySpace.gameObject.SetActive(false);
                    }
                    else
                    {
                        arrowGuide.gameObject.SetActive(false);
                        keyUp.gameObject.SetActive(true);
                        keyDown.gameObject.SetActive(true);
                        keyLeft.gameObject.SetActive(true);
                        keyRight.gameObject.SetActive(true);
                        keySpace.gameObject.SetActive(false);
                        keyLeft.GetComponent<Animator>().SetTrigger("TriPlay");
                    }
                    Modules.distanceEnemy = 2;
                }
                else
                {
                    ShowMissionsChallenge();
                }
            }
            else
            {
                Modules.mainCharacter.transform.position = Vector3.MoveTowards(Modules.mainCharacter.transform.position, pointHeroTarget, 7.5f * Time.deltaTime);
                createEnemyLeft.transform.position = Vector3.MoveTowards(createEnemyLeft.transform.position, pointEnemyLeftTarget, 7.5f * Time.deltaTime);
                runTimeAniStart += Time.deltaTime;
            }
        }
        if (Time.time - oldTime >= timeShowWarning)
        {
            timeShowWarning = UnityEngine.Random.Range(10, 30);
            oldTime = Time.time;
            if (!Modules.useSkis && Modules.totalSkis < 4)
            {
                Modules.buttonHoverboard.SetActive(true);
                Modules.buttonHoverboard.GetComponent<WarningHoverboard>().ShowWarning();
            }
        }
        //xu ly hieu ung nhay ngau nhien o menu
        if (containUIMenu.activeSelf)
        {
            HeroController heroNow = Modules.mainCharacter.GetComponent<HeroController>();
            if (timeRunJump < curveJump.length)
            {
                heroNow.transform.position = new Vector3(heroNow.transform.position.x, originPointJump + curveJump.Evaluate(timeRunJump), heroNow.transform.position.z);
                timeRunJump += Time.deltaTime;
            }
            if (mesFakeJump)
            {
                if (!heroNow.aniHero.isPlaying)
                {
                    mesFakeJump = false;
                    if (heroNow.mySkis.GetComponent<SkisController>().isHoverbike)
                        heroNow.CallAniMenu(heroNow.aniRunCable, 1f);
                    else
                        heroNow.CallAniMenu(heroNow.aniRunSkis, 1f);
                    Invoke("RunJumpIdleMenu", UnityEngine.Random.Range(timeRanJump.x, timeRanJump.y));
                }
            }
        }
        //chay hieu ung kim cua meter
        if (backgroundMeter.activeSelf)
        {
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angleArrowMeter));
            backgroundMeter.transform.GetChild(2).transform.rotation = Quaternion.Slerp(backgroundMeter.transform.GetChild(2).transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
        //xu ly hien thi bang thuong top world weekly
        if (Modules.typeWeekReward != 0)
        {
            int diamondsReward = 0;
            string textIndex = "1";
            if (Modules.typeWeekReward == 1)
            {
                textIndex = "1";
                diamondsReward = 250000;
            }
            else if (Modules.typeWeekReward == 2)
            {
                textIndex = "2";
                diamondsReward = 150000;
            }
            else if (Modules.typeWeekReward == 3)
            {
                textIndex = "3";
                diamondsReward = 50000;
            }
            Modules.totalCoin += diamondsReward;
            Modules.SaveCoin();
            mesWeekReward.SetActive(true);
            mesWeekReward.transform.GetChild(1).GetComponent<Text>().text = textIndex;
            mesWeekReward.transform.GetChild(2).GetComponent<Text>().font = AllLanguages.listFontLangA[Modules.indexLanguage];
            mesWeekReward.transform.GetChild(2).GetComponent<Text>().text = AllLanguages.menuTitleWeekReward[Modules.indexLanguage];
            mesWeekReward.transform.GetChild(3).GetComponent<Text>().font = AllLanguages.listFontLangA[Modules.indexLanguage];
            mesWeekReward.transform.GetChild(3).GetComponent<Text>().text = AllLanguages.menuDetailWeekReward[Modules.indexLanguage].Replace("?", diamondsReward.ToString());
            Invoke("HideMesWeekReward", 10);
            Modules.typeWeekReward = 0;
        }
    }

    void HideMesWeekReward()
    {
        mesWeekReward.SetActive(false);
    }

    public void ShowMissionsChallenge()
    {
        //xu ly nhiem vu ca thu thach
        if (Modules.dataMissionsUse != "")
        {
            Modules.UpdateValueMissions();
            Modules.panelMissions.SetActive(true);
        }
        if (Modules.dataChallengeUse != "")
        {
            Modules.UpdateValueChallenge();
            Modules.panelChallenge.SetActive(true);
            Invoke("AudoHideChallenge", 2f);
        }
    }

    private int oldValueSkis = 0;
    private int oldValueKeys = 0;
    void EffectAddSkisKeys()
    {
        if (Modules.statusGame != StatusGame.menu) return;
        if (Modules.totalSkis != oldValueSkis)
        {
            int pointBonus = Modules.totalSkis - oldValueSkis;
            Modules.ShowPanelEffectAddPoint(pointBonus, Vector3.zero, parentSkis, 0.3f);
            Invoke("UpdateNewTotalSkis", 0.3f);
            oldValueSkis = Modules.totalSkis;
        }
        if (Modules.totalKey != oldValueKeys)
        {
            int pointBonus = Modules.totalKey - oldValueKeys;
            Modules.ShowPanelEffectAddPoint(pointBonus, Vector3.zero, parentKey, 0.3f);
            Invoke("UpdateNewTotalKey", 0.3f);
            oldValueKeys = Modules.totalKey;
        }
    }

    void UpdateNewTotalSkis()
    {
        textSkis.text = Modules.totalSkis.ToString();
    }

    void UpdateNewTotalKey()
    {
        textKey.text = Modules.totalKey.ToString();
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
            Transform tranAvatar = Modules.panelHighScoreNow.transform.Find("Avatar");
            Image fbAvatar = tranAvatar.GetComponent<Image>();
            fbAvatar.sprite = Sprite.Create(www.texture, new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    IEnumerator LoadAvatar(string url)
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
            myAvatar.sprite = Sprite.Create(www.texture, new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    private int maxTime = 5, Runtime = 0;
  /*  void CheckAvatarEnemy()
    {
        if (Modules.fbHighScore.Count <= 0)
        {
            Runtime++; Ali Hassan
            if (Runtime > maxTime)
            {
                Runtime = 0;
                UpdateAvatarEnemy();
                return;
            }
            Invoke("CheckAvatarEnemy", 1f);
            return;
        }
        Runtime = 0;
        UpdateAvatarEnemy();
    }
*/
    private int timeWaitTop = 5, runTimeWait = 0;
    void UpdateAvatarTop()
    {
        if (Modules.linkIconTop != "")
        {
            StartCoroutine(Modules.LoadImageTop(Modules.linkIconTop));
            Modules.flagTop.sprite = Modules.GetIconFlag(Modules.codeCountryTop);
        }
        else
        {
            if (runTimeWait < timeWaitTop)
            {
                runTimeWait++;
                Invoke("UpdateAvatarTop", 1);
                return;
            }
            runTimeWait = 0;
            Modules.avatarTop.sprite = Modules.fbMyAvatar;
            if (Modules.fbMyAvatar == null) Modules.avatarTop.sprite = Modules.iconAvatarNull;
            string dataCountry = SaveLoadData.LoadData("CodeCountry", true);
            if (dataCountry == "") dataCountry = "Null";
            Modules.flagTop.sprite = Modules.GetIconFlag(dataCountry);
        }
    }

    /*  void UpdateAvatarEnemy()
      { Ali Hassan
          Modules.panelHighScoreNow.SetActive(false);
          //cap nhat avatar cho panel high score
          Modules.totalScoreNow = Modules.totalScore;
          Transform tranAvatar = Modules.panelHighScoreNow.transform.Find("Avatar");
          Image fbAvatar = tranAvatar.GetComponent<Image>();
          Transform tranName = Modules.panelHighScoreNow.transform.Find("TextHighScore");
          Text fbName = tranName.GetComponent<Text>();
          if (Modules.fbHighScore.Count > 0)//neu co doi thu thi lay thang cuoi cung
          {
              StartCoroutine(LoadImage(Modules.fbAvatarEnemy[Modules.fbAvatarEnemy.Count - 1]));
              fbName.text = Modules.fbNameEnemy[Modules.fbNameEnemy.Count - 1].ToUpper();
              Modules.totalScoreNow = Modules.fbHighScore[Modules.fbHighScore.Count - 1];
          }
          else
          {
              if (Modules.fbMyAvatar != null)
              {
                  fbAvatar.sprite = Modules.fbMyAvatar;
                  fbName.text = Modules.fbName.ToUpper();
              }
              else
              {
                  fbAvatar.sprite = Modules.iconAvatarNull;
                  fbName.text = AllLanguages.playHighScore[Modules.indexLanguage];
              }
          }
      }*/

    void AudoHideChallenge()
    {
        Modules.panelChallenge.SetActive(false);
    }

    public void ClickPlayGame(bool playAudio = true)
    {
        //thuc hien chay xu ly start
        if (playAudio) Modules.PlayAudioClipFree(Modules.audioTapPlay);
        Modules.PlayAudioClipFree(Modules.audioPoStart[Modules.indexLanguage]);
        transform.GetComponent<Animator>().SetTrigger("TriPlay");
        rateBox.SetActive(false);
        containUIMenu.SetActive(false);
        EnemyController enemyConLeft = createEnemyLeft.GetComponent<EnemyController>();
        enemyConLeft.CallAniMenu(enemyConLeft.aniRunStart, 1.35f);
    }

    public void ClickPlayGameDogecoin(bool playAudio = true)
    {
        ClickPlayGame(playAudio);
        Modules.playDogecoinMode = true;
    }

    public void StartMainGame()
    {
        Modules.statusGame = StatusGame.start;
        SetupCharacterStart();
    }

    //xu ly random nhay o menu
    private Vector2 timeRanJump = new Vector2(5f, 15f);
    public AnimationCurve curveJump;
    private bool mesFakeJump = false;
    private float originPointJump = 0;
    private float timeRunJump = 0;
    void RunJumpIdleMenu()
    {
        if (!containUIMenu.activeSelf || mesFakeJump) return;
        HeroController heroNow = Modules.mainCharacter.GetComponent<HeroController>();
        if (heroNow.mySkis.GetComponent<SkisController>().isHoverbike)
        {
            heroNow.CallAniMenu(heroNow.aniJumpCable[UnityEngine.Random.Range(0, heroNow.aniJumpCable.Count)], 1.75f, false);
        }
        else
        {
            heroNow.CallAniMenu(heroNow.aniJumpSkis[UnityEngine.Random.Range(0, heroNow.aniJumpSkis.Count)], 1.75f, false);
            Modules.PlayAudioClipFree(Modules.audioSkisJumpStart);
        }
        timeRunJump = 0;
        originPointJump = heroNow.transform.position.y;
        mesFakeJump = true;
    }

    bool CheckExistHero(string codeHero)
    {
        bool result = false;
        foreach (GameObject go in Modules.listHeroUse)
        {
            HeroController heroCon = go.GetComponent<HeroController>();
            if (heroCon.idHero == codeHero)
            {
                result = true;
                break;
            }
        }
        return result;
    }

    void CreateCharacters()
    {
        parentCam.transform.position = new Vector3(0, Modules.pointHeroTerrain, 0);
        //tao nhan vat chinh va thiet lap ban dau cho nhan vat
        Vector3 pointHero = new Vector3(0, Modules.pointHeroTerrain + 0.3f, 0);
        if (Modules.mainCharacter != null)
        {
            Modules.mainCharacter.GetComponent<ShadowFixed>().RemoveShadow();
            Destroy(Modules.mainCharacter.gameObject);
        }
        bool checkExistHero = CheckExistHero(Modules.codeHeroUse);
        bool checkExistHeroTry = true;
        if (Modules.codeHeroTrying != "") checkExistHeroTry = CheckExistHero(Modules.codeHeroTrying);
        if (!checkExistHero)
            Modules.codeHeroUse = Modules.listHeroUse[0].GetComponent<HeroController>().idHero;
        if (!checkExistHeroTry)
            Modules.codeHeroTrying = "";
        foreach (GameObject go in Modules.listHeroUse)
        {
            HeroController heroCon = go.GetComponent<HeroController>();
            string codeNow = Modules.codeHeroUse;
            if (Modules.codeHeroTrying != "") codeNow = Modules.codeHeroTrying;
            if (heroCon.idHero == codeNow)
            {
                Modules.mainCharacter = Instantiate(go, Modules.containMainGame.transform) as GameObject;
                Modules.mainCharacter.transform.position = pointHero;
                Modules.mainCharacter.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                HeroController heroNow = Modules.mainCharacter.GetComponent<HeroController>();
                Modules.speedPercentHero = heroNow.speedPercent;
                string codeNowSkis = Modules.codeSkisUse;
                if (Modules.codeSkisTrying != "") codeNowSkis = Modules.codeSkisTrying;
                if (Modules.listIDSkisHover.Contains(codeNowSkis))
                    heroNow.CallAniMenu(heroNow.aniRunCable, 1f);
                else heroNow.CallAniMenu(heroNow.aniRunSkis, 1f);
                Invoke("RunJumpIdleMenu", UnityEngine.Random.Range(timeRanJump.x, timeRanJump.y));
                break;
            }
        }
        //tao van truot cho hero da luu
        Modules.mainCharacter.GetComponent<HeroController>().mySkis = Modules.listSkisUse[0];
        foreach (GameObject go in Modules.listSkisUse)
        {
            SkisController skisCon = go.GetComponent<SkisController>();
            string codeNow = Modules.codeSkisUse;
            if (Modules.codeSkisTrying != "") codeNow = Modules.codeSkisTrying;
            if (skisCon.idSkis == codeNow)
            {
                Modules.mainCharacter.GetComponent<HeroController>().mySkis = go;
                break;
            }
        }
        //tao jetpack cho hero da luu
        Modules.mainCharacter.GetComponent<HeroController>().myJetpack = Modules.listJetpackUse[0];
        foreach (GameObject go in Modules.listJetpackUse)
        {
            JetpackController jetCon = go.GetComponent<JetpackController>();
            string codeNow = Modules.codeJetpackUse;
            if (Modules.codeJetpackTrying != "") codeNow = Modules.codeJetpackTrying;
            if (jetCon.idJetpack == codeNow)
            {
                Modules.mainCharacter.GetComponent<HeroController>().myJetpack = go;
                break;
            }
        }
        //tao boat cho hero da luu
        Modules.mainCharacter.GetComponent<HeroController>().myBoat = Modules.listBoatUse[0];
        foreach (GameObject go in Modules.listBoatUse)
        {
            BoatController boatCon = go.GetComponent<BoatController>();
            string codeNow = Modules.codeBoatUse;
            if (Modules.codeBoatTrying != "") codeNow = Modules.codeBoatTrying;
            if (boatCon.idBoat == codeNow)
            {
                Modules.mainCharacter.GetComponent<HeroController>().myBoat = go;
                break;
            }
        }
        //tao xe canh sat, van truot
        Vector3 pointPoliceCarNew = new Vector3(pointPoliceCar.x, pointPoliceCar.y + Modules.pointHeroTerrain, pointPoliceCar.z);
        CancelInvoke("HideCarPolice");
        if (policeCar != null)
        {
            if (carPolice == null) carPolice = Instantiate(policeCar);
            else carPolice.SetActive(true);
            carPolice.transform.parent = GetComponent<TerrainController>().listShowTerrain[1].transform;
            carPolice.transform.position = pointPoliceCarNew;
        }
        HeroController heroControl = Modules.mainCharacter.GetComponent<HeroController>();
        Modules.SetModelUseItem(Modules.mainCharacter.transform, heroControl.codeBody, heroControl.mySkis, "Skis");
        //tao dia hinh seapath neu dang dung o giua bien
        RaycastHit hit;
        if (Physics.Raycast(Modules.mainCharacter.transform.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "WaterSurface")
            {
                if (seaPathUse == null) seaPathUse = Instantiate(seaPath);
                else seaPathUse.SetActive(true);
                seaPathUse.transform.parent = GetComponent<TerrainController>().listShowTerrain[1].transform;
                seaPathUse.transform.position = Vector3.zero;
            }
        }
        //tao cac nhan vat enemy va thiet lap ban dau
        Vector3 pointStartEnemyLeftNew = new Vector3(pointStartEnemyLeft.x, pointStartEnemyLeft.y + Modules.pointHeroTerrain, pointStartEnemyLeft.z);
        if (createEnemyLeft) Destroy(createEnemyLeft);
        createEnemyLeft = Instantiate(enemyLeft, pointStartEnemyLeftNew, Quaternion.identity) as GameObject;
        createEnemyLeft.transform.parent = Modules.containMainGame.transform;
        EnemyController enemyConLeft = createEnemyLeft.GetComponent<EnemyController>();
        enemyConLeft.CallAniMenu(enemyConLeft.aniIdleStart, 1f);
    }

    void DisableMessageBox()
    {
        mesSetting.SetActive(false);
        getSkisBox.SetActive(false);
        getKeysBox.SetActive(false);
        missionsBox.SetActive(false);
        challengeBox.SetActive(false);
        listLanguageBox.SetActive(false);
        rateBox.SetActive(false);
        shareFBBox.SetActive(false);
        inviteFBBox.SetActive(false);
        listTaskBox.SetActive(false);
    }

    public Image iconButSkis, iconMesSkis;
    void OnEnable()
    {
        Runtime = 0;
        runTimeWait = 0;
        iconButSkis.sprite = Modules.ChangeIconHoverboard();
        iconMesSkis.sprite = iconButSkis.sprite;
        DisableMessageBox();
        if (Modules.mainCharacter != null)
        {
            HeroController heroNow = Modules.mainCharacter.GetComponent<HeroController>();
            string codeNow = Modules.codeSkisUse;
            if (Modules.codeSkisTrying != "") codeNow = Modules.codeSkisTrying;
            if (Modules.listIDSkisHover.Contains(codeNow))
                heroNow.CallAniMenu(heroNow.aniRunCable, 1f);
            else heroNow.CallAniMenu(heroNow.aniRunSkis, 1f);
            Vector3 pointHero = new Vector3(0, Modules.pointHeroTerrain + 0.3f, 0);
            heroNow.transform.position = pointHero;
            timeRunJump = curveJump.length;
            originPointJump = heroNow.transform.position.y;
            mesFakeJump = false;
            CancelInvoke("RunJumpIdleMenu");
            Invoke("RunJumpIdleMenu", UnityEngine.Random.Range(timeRanJump.x, timeRanJump.y));
        }
        if (createEnemyLeft != null)
        {
            EnemyController enemyConLeft = createEnemyLeft.GetComponent<EnemyController>();
            enemyConLeft.CallAniMenu(enemyConLeft.aniIdleStart, 1f);
        }
        //Modules.containMainGame.GetComponent<MessageTaskController>().AutoShowRemidTask();
        if (TaskData.newTaskDone != -1 && containUIPlay.activeSelf)
        {
            Modules.containMainGame.GetComponent<MessageTaskController>().ShowMessageTask(TaskData.newTaskDone);
            TaskData.newTaskDone = -1;
        }
        if (TaskData.newTaskPage)
        {
            //thuc hien hieu ung thuong 1 scratch card khi hoan thanh 1 page task
            Modules.BonusMissionsChallenge(6, LanguageTask.taskTitleBonus[Modules.indexLanguage], 1, Vector3.zero, true);
            TaskData.newTaskPage = false;
        }
        Modules.SetStatusButWheelSpin(butWheelSpin);
        transform.GetComponent<PlaneController>().CallPlaneStart();
        Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
    }

    void OnDisable()
    {
        Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
    }

    private bool mesAniStart = false;
    private float timeAniStart = 1f;
    private float runTimeAniStart = 0f;
    [HideInInspector]
    public GameObject createEnemyLeft, carPolice;
    private Vector3 pointHeroTarget = Vector3.zero;
    private Vector3 pointEnemyLeftTarget = Vector3.zero;
    void SetupCharacterStart()
    {
        Modules.PlayAudioClipFree(Modules.audioSurprise);
        //xoa van truot
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Skis");
        //setup main character
        pointHeroTarget = Modules.mainCharacter.transform.position;
        Vector3 pointCreate = Modules.mainCharacter.GetComponent<HeroController>().pointShowHero.transform.position;
        Vector3 pointCreateNew = new Vector3(pointCreate.x, Modules.pointHeroTerrain, pointCreate.z);
        Modules.mainCharacter.transform.position = pointCreateNew;
        Modules.mainCharacter.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        HeroController heroNow = Modules.mainCharacter.GetComponent<HeroController>();
        //an cac object hide
        foreach (GameObject go in heroNow.listObjectHide) go.gameObject.SetActive(false);
        timeAniStart = heroNow.CallAniMenu(heroNow.aniOhNoMenu, 1f, false);
        runTimeAniStart = 0;
        mesAniStart = true;
        //setup enemy characters
        EnemyController enemyConLeft = createEnemyLeft.GetComponent<EnemyController>();
        createEnemyLeft.transform.position = new Vector3(enemyConLeft.pointShow.transform.position.x, createEnemyLeft.transform.position.y, enemyConLeft.pointShow.transform.position.z);
        enemyConLeft.CallAniMenu(enemyConLeft.aniRun, 0.8f);
        pointEnemyLeftTarget = new Vector3(enemyConLeft.pointX, enemyConLeft.transform.position.y, enemyConLeft.pointZNear);
        //hen gio de an xe canh sat
        Invoke("HideCarPolice", 5f);
    }

    void HideCarPolice()
    {
        carPolice.SetActive(false);
        if (seaPathUse != null) seaPathUse.SetActive(false);
    }

    void SetupCharacterPlay()
    {
        //thiet lap nhan vat khi choi
        HeroController heroNow = Modules.mainCharacter.GetComponent<HeroController>();
        heroNow.SetupShowMenu(0);
        heroNow.ReStart(0);
        //thiet lap enemy duoi theo
        EnemyController enemyConLeft = createEnemyLeft.GetComponent<EnemyController>();
        enemyConLeft.ReStart();
    }

    void CreateButtonItemBuys()//tao cac nut item mua truoc do
    {
        float pointX = 0;
        float heightHeadStart = 0;
        float heightScoreBooster = 0f;
        if (Modules.totalHeadStart > 0 && Modules.totalScoreBooster > 0)
        {
            heightScoreBooster = 0;
            heightHeadStart = 120f;
        }
        if (Modules.totalHeadStart > 0)//neu co item headStart
            CallButtonItemBuy(pointX, heightHeadStart, Modules.iconHeadStart, Modules.totalHeadStart, "headStart");
        //if (Modules.totalScoreBooster > 0)//neu co item scoreBooster
            CallButtonItemBuy(pointX, heightScoreBooster, Modules.iconScoreBooster, Modules.totalScoreBooster, "scoreBooster");
        Modules.SetAllowHoverbike(false);
    }

    public void ReCreateButtonItemBuys()
    {
        foreach (Transform tran in Modules.containButtonBuy.transform) Destroy(tran.gameObject);
        CreateButtonItemBuys();
    }

    void CallButtonItemBuy(float pointX, float pointY, Sprite iconButton, int totalTime, string codeItem)
    {
        GameObject button = Instantiate(panelShowBuyItems, new Vector3(pointX, pointY, 0), Quaternion.identity) as GameObject;
        button.transform.SetParent(Modules.containButtonBuy.transform, false);
        ButtonItemBuy buttonClick = button.GetComponent<ButtonItemBuy>();
        buttonClick.codeItem = codeItem;
        buttonClick.AutoHide();
        Transform icon = button.transform.Find("Icon");
        Transform number = button.transform.Find("Number");
        Image imgIcon = icon.GetComponent<Image>();
        Text txtNumber = number.GetComponent<Text>();
        imgIcon.sprite = iconButton;
        if (totalTime <= 0)
        {
            txtNumber.text = AllLanguages.shopButtonBuy[Modules.indexLanguage];
            txtNumber.alignment = TextAnchor.MiddleCenter;
        }
        else
        {
            txtNumber.text = totalTime.ToString();
            txtNumber.alignment = TextAnchor.MiddleRight;
        }
        Animator aniPanel = button.GetComponent<Animator>();
        aniPanel.SetTrigger("TriOpen");
    }

    public void ButtonPauseGameClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        mesPauseGame.SetActive(true);
        mesPauseGame.GetComponent<Animator>().SetTrigger("TriOpen");
        MessagePauseGame mesPause = mesPauseGame.GetComponent<MessagePauseGame>();
        mesPause.ShowMessageBox();
    }

    public void ButtonRankingClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containMainGame.SetActive(false);
        Modules.containAchievement.SetActive(true);
        Modules.containAchievement.transform.Find("MainCamera").GetComponent<PageAchievement>().CallStart();
    }

    public void ButtonHeroClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containMainGame.SetActive(false);
        Modules.containHeroConstruct.SetActive(true);
        Modules.containHeroConstruct.transform.Find("MainCamera").GetComponent<PageConstructHero>().CallStart();
    }

    public void ButtonShopClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containMainGame.SetActive(false);
        Modules.containShopItem.SetActive(true);
        Modules.containShopItem.transform.Find("MainCamera").GetComponent<PageShopItems>().CallStart();
    }

    public void ButtonRankClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containMainGame.SetActive(false);
        Modules.containRank.SetActive(true);
        Modules.containRank.transform.Find("MainCamera").GetComponent<PageRank>().CallStart();
    }

    public void ButtonSettingClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        mesSetting.SetActive(true);
        mesSetting.GetComponent<MessageSetting>().StartShowMessage();
        mesSetting.GetComponent<Animator>().SetTrigger("TriOpen");
    }

    public void ButtonSkisMenuClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        getSkisBox.GetComponent<CooldownSkis>().ShowMessageBox();
        getSkisBox.SetActive(true);
        getSkisBox.GetComponent<Animator>().SetTrigger("TriOpen");
    }

    public void ButtonKeyMenuClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        getKeysBox.GetComponent<CooldownKey>().ShowMessageBox();
        getKeysBox.SetActive(true);
        getKeysBox.GetComponent<Animator>().SetTrigger("TriOpen");
    }

    public void ButtonViewAdsClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.itemBonusViewAds = "Key";
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
            Modules.adsInter.ShowVideoAds("rewardKeys");
        else Modules.adsInter.RequestVideoAds();
#endif
    }

    private void didCompleteRewardedVideo(CBLocation location, int reward)
    {
        Modules.RewardKeysSkis();
    }

    private void CallReward(bool obj)
    {
        if (obj) Modules.RewardKeysSkis();
    }

    public void ButtonMissionsClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        transform.GetComponent<MissionsController>().UpdateLanguage();
        missionsBox.SetActive(true);
        missionsBox.GetComponent<Animator>().SetTrigger("TriOpen");
    }

    public void ButtonChallengeClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        transform.GetComponent<ChallengeController>().UpdateLanguage();
        challengeBox.SetActive(true);
        challengeBox.GetComponent<Animator>().SetTrigger("TriOpen");
    }

    public void ButtonTaskClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        listTaskBox.GetComponent<MessageListTask>().StartShowMessage();
        listTaskBox.SetActive(true);
        listTaskBox.GetComponent<Animator>().SetTrigger("TriOpen");
    }

    public void ButtonRateClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        rateBox.GetComponent<MessageRate>().StartShowMessage();
        rateBox.SetActive(true);
        rateBox.GetComponent<Animator>().SetTrigger("TriOpen");
    }

    /*public void ButtonShareFacebook()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        if (Modules.CheckReceivedFB())
        {
            Modules.ClickShareFB();
        }
        else
        {
            shareFBBox.GetComponent<MessageShareFB>().StartShowMessage();
            shareFBBox.SetActive(true);
            shareFBBox.GetComponent<Animator>().SetTrigger("TriOpen");
        }
    }
*/
    public void ButtonSpinWheel()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.nextPageWheelSpin = "MenuGame";
        Modules.containMainGame.SetActive(false);
        Modules.containWheelSpin.SetActive(true);
        Modules.containWheelSpin.transform.Find("MainCamera").GetComponent<PageSpinWheel>().CallStart();
    }

    /*public void ButtonInviteFacebook()
    {
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
        Modules.PlayAudioClipFree(Modules.audioButton);
        if (Modules.coinMaxInvite <= 0)//neu da moi nhan thuong roi thi cho moi luon, khong thuong
        {
            Facebook.Unity.FB.AppRequest(
                AllLanguages.menuMessageInvite[Modules.indexLanguage],
                null, null, null, 100, string.Empty, AllLanguages.menuTitleInvite[Modules.indexLanguage], null);
        }
        else
        {
            inviteFBBox.GetComponent<MessageInviteFB>().StartShowMessage();
            inviteFBBox.SetActive(true);
            inviteFBBox.GetComponent<Animator>().SetTrigger("TriOpen");
        }
#endif
    }*/

    public void UpdateKeys()
    {
        textTotalKeySave.text = Mathf.RoundToInt(Modules.totalKey).ToString();
    }

    public void UpdateNeedKeys(int total)
    {
        textNeedKeys.text = AllLanguages.playKeyNeed[Modules.indexLanguage] + " " + Mathf.RoundToInt(total).ToString();
    }

    public void UpdateScoreNow()
    {
        if (Modules.playDogecoinMode)
        {
            //gui diem doge trong tuan len server ngay keo ngoi
            if (Modules.scorePlayer > Modules.totalScoreDoge)
            {
                Modules.totalScoreDoge = Modules.scorePlayer;
                StartCoroutine(PostScoreDC());
            }
        }
        else
        {
            //gui diem trong tuan len server ngay keo ngoi
            if (Modules.scorePlayer > Modules.totalScoreWeek)
            {
                Modules.totalScoreWeek = Modules.scorePlayer;
                StartCoroutine(PostScore());
            }
        }
    }

    //private bool statusPost = false;
    //private bool statusGet = false; 
    IEnumerator PostScore()
    {
#if UNITY_WEBGL
        string idDevice = Modules.fbID;
#else
        string idDevice = SystemInfo.deviceUniqueIdentifier;
#endif
        if (idDevice == "Null")
        {
            //statusPost = true;
            yield break;
        }
        //string nameDevice = SystemInfo.deviceName;
        string dataCountry = SaveLoadData.LoadData("CodeCountry", true);
        if (dataCountry == "") dataCountry = "Null";
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("idUser", idDevice);
        form.AddField("name", Modules.fbName);
        form.AddField("avatar", Modules.fbLinkAvatar == "" ? "Null" : Modules.fbLinkAvatar);
        form.AddField("score", Mathf.RoundToInt(Modules.totalScore));
        form.AddField("scoreWeek", Mathf.RoundToInt(Modules.totalScoreWeek));
        form.AddField("country", dataCountry);
        form.AddField("win", 0);
        form.AddField("lose", 0);
        form.AddField("fail", 0);
        WWW _resuilt = new WWW(Modules.linkPost, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text == "Done")
        { //hoan thanh
            //statusPost = true;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            //statusPost = false;
        }
        yield break;
    }

    IEnumerator PostScoreDC()
    {
#if UNITY_WEBGL
        string idDevice = Modules.fbID;
#else
        string idDevice = SystemInfo.deviceUniqueIdentifier;
#endif
        if (idDevice == "Null")
        {
            yield break;
        }
        //string nameDevice = SystemInfo.deviceName;
        string dataCountry = SaveLoadData.LoadData("CodeCountry", true);
        if (dataCountry == "") dataCountry = "Null";
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("idUser", idDevice);
        form.AddField("name", Modules.fbName);
        form.AddField("avatar", Modules.fbLinkAvatar == "" ? "Null" : Modules.fbLinkAvatar);
        form.AddField("score", Mathf.RoundToInt(Modules.totalScore));
        form.AddField("scoreDoge", Mathf.RoundToInt(Modules.totalScoreDoge));
        form.AddField("country", dataCountry);
        form.AddField("win", 0);
        form.AddField("lose", 0);
        form.AddField("fail", 0);
        WWW _resuilt = new WWW(Modules.linkPostDCScore, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text == "Done")
        { //hoan thanh
        }
        else
        { //qua lau, khong mang, cau lenh loi
        }
        yield break;
    }

    //xu ly ngon ngu
    public Text textTapToPlay;
    public Text textButMission, textButChallenge, textButTask;
    public Text textButTopRun, textButHero, textButShop, textButHighScore, textButSpin;
    public Text textButApply, textButCancel;
    public Text textTitleBonusFirst, textContentBonusFirst, textButtonBonusFirst;
    public Text textNoteGetFree;

    public void ChangeAllLanguage()
    {
        int iLang = Modules.indexLanguage;
        textTapToPlay.font = AllLanguages.listFontLangA[iLang];
        textTapToPlay.text = AllLanguages.menuTapToPlay[iLang];
        textButMission.font = AllLanguages.listFontLangA[iLang];
        textButMission.text = AllLanguages.menuMissions[iLang];
        textButChallenge.font = AllLanguages.listFontLangA[iLang];
        textButChallenge.text = AllLanguages.menuChallenge[iLang];
        textButTask.font = AllLanguages.listFontLangA[iLang];
        textButTask.text = LanguageTask.taskTitle[iLang];
        textButTopRun.font = AllLanguages.listFontLangA[iLang];
        textButTopRun.text = AllLanguages.menuTopRun[iLang];
        textButHero.font = AllLanguages.listFontLangA[iLang];
        textButHero.text = AllLanguages.menuHero[iLang];
        textButShop.font = AllLanguages.listFontLangA[iLang];
        textButShop.text = AllLanguages.menuShop[iLang];
        textButHighScore.font = AllLanguages.listFontLangA[iLang];
        textButHighScore.text = AllLanguages.menuHighScore[iLang];
        textButApply.font = AllLanguages.listFontLangA[iLang];
        textButApply.text = AllLanguages.menuApply[iLang];
        textButCancel.font = AllLanguages.listFontLangA[iLang];
        textButCancel.text = AllLanguages.menuCancel[iLang];
        textButSpin.font = AllLanguages.listFontLangA[iLang];
        textButSpin.text = AllLanguages.menuSpin[iLang];
        textTitleBonusFirst.font = AllLanguages.listFontLangA[iLang];
        textTitleBonusFirst.text = AllLanguages.playBonusTitle[iLang];
        textContentBonusFirst.font = AllLanguages.listFontLangB[iLang];
        textContentBonusFirst.text = AllLanguages.playBonusContent[iLang];
        textButtonBonusFirst.font = AllLanguages.listFontLangA[iLang];
        textButtonBonusFirst.text = AllLanguages.playBonusButton[iLang];
        textNoteGetFree.font = AllLanguages.listFontLangB[iLang];
        textNoteGetFree.text = AllLanguages.menuGetFree[iLang];
        //update font text khac
        textNeedKeys.font = AllLanguages.listFontLangA[Modules.indexLanguage];
        Transform textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
        textGuide.GetComponent<Text>().font = AllLanguages.listFontLangA[iLang];
        //Transform tranName = Modules.panelHighScoreNow.transform.Find("TextHighScore");
        //tranName.GetComponent<Text>().font = AllLanguages.listFontLangA[iLang];
    }
}
