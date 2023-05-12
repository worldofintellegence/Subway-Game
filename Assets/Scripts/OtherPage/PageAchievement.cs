using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
/*#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
using Facebook.Unity;
#endif*/
using ChartboostSDK;

public class PageAchievement : MonoBehaviour
{

    public Text textKey, textCoin, textHighScore, textHighCoin;
    public Vector3 pointShowHero, scaleShowHero;
    public Image fbAvatar;
    public Text fbName, fbScore, fbIndex;
    public Button doubleCoin;
    public GameObject listTempFriend, listTempCountry, listTempWorld, listTempDogecoin;//prefab mau list player score
    public GameObject parentListFriend, parentListCountry, parentListWorld, parentListDogecoin;
    public GameObject panelFBLogin;
    public GameObject panelLoadingA, panelLoadingB, panelLoadingC, panelLoadingD;
    public Vector3 pointListFriend = Vector3.zero;
    public Vector3 pointListCountry = Vector3.zero;
    public Vector3 pointListWorld = Vector3.zero;
    public Vector3 pointListDogecoin = Vector3.zero;
    public GameObject messageStarterPack;
    //private FacebookController fbController;
    private GameObject panelTopCountry;//list hien thi xep hang dat nuoc
    private GameObject panelTopWorld;//list hien thi xep hang the gioi
    private GameObject panelTopDogecoin;//list hien thi xep hang dogecoin
    private GameObject mainCharacter;
    //xu ly week va time left
    private int weekNow = -1;
    private int timeLeft = -1;

    public void CallStart()
    {
        weekNow = -1;
        timeLeft = -1;
        //Modules.FreeMemoryNow();
        ChangeAllLanguage();
        float scoreNow = Modules.totalScore;
        float coinNow = Modules.totalCoin;
        CancelInvoke("BlinkDoubleCoin");
        CancelInvoke("UpdateTimeLeft");
        if (Modules.showScorePlay)
        {
            scoreNow = Modules.scorePlayer;
            coinNow = Modules.coinPlayer;
            doubleCoin.interactable = true;
            Invoke("BlinkDoubleCoin", 0f);
            GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GameAnalyticsSDK.GAProgressionStatus.Complete, "game", Mathf.RoundToInt(scoreNow));
        }
        else
        {
            doubleCoin.transform.GetComponent<Image>().color = colorBlinkCoinA;
            doubleCoin.transform.GetComponentInChildren<Text>().color = colorBlinkTextA;
            doubleCoin.interactable = false;
        }
        UpdateBuyStarterPack();
        textHighScore.GetComponent<EffectUpScore>().StartEffect(scoreNow);
        textHighCoin.GetComponent<EffectUpScore>().StartEffect(coinNow);
        fbScore.text = Mathf.RoundToInt(Modules.totalScore).ToString();
        if (mainCharacter != null) Destroy(mainCharacter);
        foreach (GameObject go in Modules.listHeroUse)
        {
            HeroController heroCon = go.GetComponent<HeroController>();
            if (heroCon.idHero == Modules.codeHeroUse)
            {
                if (Modules.showScorePlay) mainCharacter = Instantiate(heroCon.modelIdelStun, pointShowHero, Quaternion.identity) as GameObject;
                else mainCharacter = Instantiate(heroCon.modelIdelShow, pointShowHero, Quaternion.identity) as GameObject;
                mainCharacter.transform.parent = Modules.containAchievement.transform;
                mainCharacter.transform.localScale = scaleShowHero;
                mainCharacter.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            }
        }
        Modules.showScorePlay = false;
        if (panelTopCountry == null)
        {
            panelLoadingB.SetActive(true);
            panelLoadingB.transform.GetComponent<TextLoading>().CallStart();
        }
        else panelLoadingB.SetActive(false);
        if (panelTopWorld == null)
        {
            panelLoadingC.SetActive(true);
            panelLoadingC.transform.GetComponent<TextLoading>().CallStart();
        }
        else panelLoadingC.SetActive(false);
        if (panelTopDogecoin == null)
        {
            panelLoadingD.SetActive(true);
            panelLoadingD.transform.GetComponent<TextLoading>().CallStart();
        }
        else panelLoadingD.SetActive(false);
/*#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        ButtonTopCountryClick();
        panelFBLogin.SetActive(false);
        panelLoadingA.SetActive(false);
#else
        //xu ly xep hang facebook
        if (fbController == null) fbController = Modules.facebookController.GetComponent<FacebookController>();
        fbController.isPostDone = false;
        fbController.isGetDone = false;
        fbController.getEnemy = false;
        if (fbController.panelGetInfo != null)
            Destroy(fbController.panelGetInfo);
        if (FB.IsLoggedIn)
        {
            panelFBLogin.SetActive(false);
            panelLoadingA.SetActive(true);
            panelLoadingA.transform.GetComponent<TextLoading>().CallStart();
        }
        else
        {
            panelFBLogin.SetActive(true);
            panelLoadingA.SetActive(false);
        }
        PostScoreFacebook();
        GetScoreFacebook();
        InvokeRepeating("GetBoardScoreFacebook", 0f, 1f);
#endif*/
        //xu ly xep hang quoc gia va the gioi
        if (Modules.containAchievement.activeSelf) StartCoroutine(PostScore());
        PostScoreWorld();
        Modules.PlayAudioClipLoop(Modules.audioBGMenu, Camera.main.transform);

        //hien thi bang mua starter pack
        messageStarterPack.SetActive(false);
        if (Modules.buyStarterPack != 2)
        {
            Modules.countShowBuyStarter++;
            if (Modules.countShowBuyStarter >= Modules.timeShowBuyStarter)
            {
                Modules.countShowBuyStarter = 0;
                messageStarterPack.SetActive(true);
                messageStarterPack.GetComponent<MessageBuyStarterPack>().StartShowMessage();
                messageStarterPack.GetComponent<Animator>().SetTrigger("TriOpen");
            }
        }
    }

    void UpdateTimeLeft()
    {
        if (timeLeft <= 0)
        {
            if (Modules.containAchievement.activeSelf)
            {
                StartCoroutine(GetScoreCountry());
                StartCoroutine(GetScore());
                StartCoroutine(GetScoreDogecoin());
            }
            CancelInvoke("UpdateTimeLeft");
            return;
        }
        timeLeft--;
    }

    public string GetInfoWeek()
    {
        string week = "?";
        if (weekNow != -1) week = weekNow.ToString();
        return AllLanguages.topWeek[Modules.indexLanguage] + ": " + week;
    }

    public string GetInfoTimeLeft()
    {
        string result = AllLanguages.topTimeLeft[Modules.indexLanguage] + ": ";
        if (timeLeft == -1) return result + "???:??:??";
        int hour = timeLeft / 3600;
        int minute = timeLeft % 3600 / 60;
        int second = timeLeft % 3600 % 60;
        string txtHour = hour.ToString();
        if (txtHour.Length == 1) txtHour = "00" + txtHour;
        else if (txtHour.Length == 2) txtHour = "0" + txtHour;
        string txtMinute = minute.ToString();
        if (txtMinute.Length == 1) txtMinute = "0" + txtMinute;
        string txtSecond = second.ToString();
        if (txtSecond.Length == 1) txtSecond = "0" + txtSecond;
        return result + txtHour + ":" + txtMinute + ":" + txtSecond;
    }

	public void DoubleCoins () {
		Modules.itemBonusViewAds = "DoubleCoins";
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
            Modules.adsInter.ShowVideoAds("rewardCoin");
        else Modules.adsInter.RequestVideoAds();
#endif
    }

    public void UpdateItemSupport()
    {
        messageStarterPack.GetComponent<MessageBuyStarterPack>().ButtonCancel();
    }

    public void UpdateBuyStarterPack()
    {
        textKey.text = Mathf.RoundToInt(Modules.totalKey).ToString();
        textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
    }

    private void didCompleteRewardedVideo(CBLocation location, int reward)
    {
        Modules.RewardDoubleCoin();
    }

    void OnEnable()
    {
        Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
    }

    void OnDisable()
    {
        Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
        CancelInvoke();
    }

    private void CallReward(bool obj)
    {
        if (obj)
        {
            Modules.RewardDoubleCoin();
        }
    }

    public void HandleReward()
    {
        if (!Modules.containAchievement.activeSelf) return;
        float coinNow = Modules.coinPlayer * 2;
        if (Modules.showScorePlay)
            coinNow = Modules.coinPlayer * 2;
        Modules.totalCoin += Modules.coinPlayer;
        textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        textHighCoin.GetComponent<EffectUpScore>().StartEffect(coinNow);

        doubleCoin.transform.GetComponent<Image>().color = colorBlinkCoinA;
        doubleCoin.transform.GetComponentInChildren<Text>().color = colorBlinkTextA;
        doubleCoin.interactable = false;
        CancelInvoke("BlinkDoubleCoin");
    }

    public Color colorBlinkCoinA = Color.white;
    public Color colorBlinkCoinB = Color.green;
    public Color colorBlinkTextA = Color.black;
    public Color colorBlinkTextB = Color.white;
    void BlinkDoubleCoin()
    {
        Image img = doubleCoin.transform.GetComponent<Image>();
        Text txt = doubleCoin.transform.GetComponentInChildren<Text>();
        if (img.color == colorBlinkCoinA)
        {
            img.color = colorBlinkCoinB;
            txt.color = colorBlinkTextB;
        }
        else
        {
            img.color = colorBlinkCoinA;
            txt.color = colorBlinkTextA;
        }
        Invoke("BlinkDoubleCoin", 0.5f);
    }

    /*void PostScoreFacebook()
    {
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        if (FB.IsLoggedIn)
        {
			fbAvatar.sprite = Modules.fbMyAvatar;
            fbName.text = Modules.fbName;
            fbScore.text = Mathf.RoundToInt(Modules.totalScore).ToString();
            fbIndex.text = "1";
            fbController.PostScore();
        }
        else Invoke("PostScoreFacebook", 1f);
#endif
    }*/

   /* void GetScoreFacebook()
    {
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        if (fbController.isPostDone)
        {
            fbController.GetScores();
            fbController.isPostDone = false;
        }
        else Invoke("GetScoreFacebook", 1f);
#endif
    }*/

  /*  void GetBoardScoreFacebook()
    {
        if (fbController.panelGetInfo == null || !fbController.isGetDone) return;
        GameObject listFriend = fbController.panelGetInfo;
        listFriend.transform.position = pointListFriend;
        listFriend.transform.SetParent(parentListFriend.transform, false);
        panelFBLogin.SetActive(false);
        panelLoadingA.SetActive(false);
        fbController.isGetDone = false;
    }
*/
    void PostScoreWorld()
    {
        if (statusPost)
        {
            if (Modules.containAchievement.activeSelf)
            {
                StartCoroutine(GetScoreCountry());
                StartCoroutine(GetScore());
                StartCoroutine(GetScoreDogecoin());
            }
        }
        else Invoke("PostScoreWorld", 1f);
    }

    //XU LY GET POST DIEM LEN SERVER
    List<Texture2D> listAvatarCountry = new List<Texture2D>();
    List<Texture2D> listAvatarWorld = new List<Texture2D>();
    List<Texture2D> listAvatarDogecoin = new List<Texture2D>();
    IEnumerator LoadImageCountry(string url, int index, Image avatar)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null && avatar != null)
        {
            listAvatarCountry[index] = www.texture;
            int width = listAvatarCountry[index].width;
            int height = listAvatarCountry[index].height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            avatar.sprite = Sprite.Create(listAvatarCountry[index], new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    IEnumerator LoadImageWorld(string url, int index, Image avatar)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null && avatar != null)
        {
            listAvatarWorld[index] = www.texture;
            int width = listAvatarWorld[index].width;
            int height = listAvatarWorld[index].height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            avatar.sprite = Sprite.Create(listAvatarWorld[index], new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    IEnumerator LoadImageDogecoin(string url, int index, Image avatar)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null && avatar != null)
        {
            listAvatarDogecoin[index] = www.texture;
            int width = listAvatarDogecoin[index].width;
            int height = listAvatarDogecoin[index].height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            avatar.sprite = Sprite.Create(listAvatarDogecoin[index], new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    private bool statusPost = false;
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
            statusPost = true;
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
        while (!_resuilt.isDone && runTime < Modules. maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text == "Done")
        { //hoan thanh
            statusPost = true;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            statusPost = false;
        }
        yield break;
    }

    IEnumerator GetScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", Modules.maxListRank);
        form.AddField("order", "ScoreWeek");
        WWW _resuilt = new WWW(Modules.linkGet, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text != "null" && _resuilt.text != "")
        { //hoan thanh
            //print(_resuilt.text);
            listAvatarWorld = new List<Texture2D>();
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            if (panelTopWorld != null) Destroy(panelTopWorld);
            panelTopWorld = Instantiate(listTempWorld, Vector3.zero, Quaternion.identity) as GameObject;
            Transform panelContent = panelTopWorld.transform.Find("Content");
            Transform panelItem = panelContent.transform.Find("Item");
            Transform panelTop = panelContent.transform.Find("TopThreeIndex");
            //xu ly 3 doi tuong dac biet
            int maxIndex = 3;
            if (dataLine.Length < 3) maxIndex = dataLine.Length;
            for (int i = 0; i < maxIndex; i++)
            {
                if (dataLine[i] == "") continue;
                Transform tranAvatar = panelTop.GetChild(i + 3).GetChild(1);
                Transform tranName = panelTop.GetChild(i + 3).GetChild(2).GetChild(0);
                Transform tranScore = panelTop.GetChild(i + 3).GetChild(2).GetChild(1);
                Transform tranLike = panelTop.GetChild(i + 3).GetChild(3);
                Transform tranFlag = panelTop.GetChild(i + 3).GetChild(4);
                Image fbAvatar = tranAvatar.GetComponent<Image>();
                Text fbName = tranName.GetComponent<Text>();
                Text fbScore = tranScore.GetComponent<Text>();
                ButtonLike fbLike = tranLike.GetComponent<ButtonLike>();
                Image fbFlag = tranFlag.GetChild(0).GetComponent<Image>();

                string[] data = dataLine[i].Split(';');
                fbName.text = data[0];
                listAvatarWorld.Add(null);
                if (Modules.containAchievement.activeSelf) StartCoroutine(LoadImageWorld(data[1], i, fbAvatar));
                fbScore.text = data[3];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                //lay week va time left
                if (weekNow == -1) weekNow = Modules.IntParseFast(data[4]);
                if (timeLeft == -1)
                {
                    timeLeft = Modules.IntParseFast(data[5]);
                    CancelInvoke("UpdateTimeLeft");
                    InvokeRepeating("UpdateTimeLeft", 1, 1);
                }
                Modules.SetBadges(panelTop.GetChild(i + 3).gameObject, int.Parse(data[2]));
            }
            for (int i = maxIndex; i < 3; i++)
                panelTop.GetChild(i + 3).gameObject.SetActive(false);
            //xu ly cac doi tuong con lai
            if (dataLine.Length < 4) panelItem.gameObject.SetActive(false);
            for (int i = 3; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                GameObject newItem = panelItem.gameObject;
                if (i > 3)
                {
                    newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                    newItem.transform.SetParent(panelContent, false);
                }
                if (i % 2 == 0) newItem.GetComponent<Image>().color = Modules.colorListLine;
                Transform tranAvatar = newItem.transform.Find("Avatar");
                Transform tranName = newItem.transform.Find("Name");
                Transform tranScore = newItem.transform.Find("Score");
                Transform tranIndex = newItem.transform.Find("Index");
                Transform tranLike = newItem.transform.Find("BGLike");
                Transform tranFlag = newItem.transform.Find("Flag");

                Image fbAvatar = tranAvatar.GetComponent<Image>();
                Text fbName = tranName.GetComponent<Text>();
                Text fbScore = tranScore.GetComponent<Text>();
                Text fbIndex = tranIndex.GetComponent<Text>();
                ButtonLike fbLike = tranLike.GetComponent<ButtonLike>();
                Image fbFlag = tranFlag.GetChild(0).GetComponent<Image>();

                string[] data = dataLine[i].Split(';');
                fbName.text = data[0];
                listAvatarWorld.Add(null);
                if (Modules.containAchievement.activeSelf) StartCoroutine(LoadImageWorld(data[1], i, fbAvatar));
                fbScore.text = data[3];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbIndex.text = (i + 1).ToString();
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                Modules.SetBadges(newItem, int.Parse(data[2]));
            }
            panelTopWorld.transform.position = pointListWorld;
            panelTopWorld.transform.SetParent(parentListWorld.transform, false);
            panelLoadingC.SetActive(false);
            //statusGet = true;
            //xu ly update 3 thang top
            string idTopers = "";
            for (int i = 0; i < 3; i++)
            {
                if (i < dataLine.Length)
                {
                    if (dataLine[i] == "") { idTopers += "-1"; }
                    else
                    {
                        string[] data = dataLine[i].Split(';');
                        idTopers += data[6];
                    }
                }
                else { idTopers += "-1"; }
                if (i < 2) idTopers += ",";
            }
            StartCoroutine(Modules.PostUpdateTopper("", idTopers, ""));
        }
        else
        { //qua lau, khong mang, cau lenh loi
            //statusGet = false;
            panelLoadingC.SetActive(true);
            panelLoadingC.transform.GetComponent<TextLoading>().CallStart();
        }
        yield break;
    }

    IEnumerator GetScoreCountry()
    {
        string dataCountry = SaveLoadData.LoadData("CodeCountry", true);
        if (dataCountry == "") dataCountry = "Null";
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", Modules.maxListRank);
        form.AddField("country", dataCountry);
        form.AddField("order", "ScoreWeek");
        WWW _resuilt = new WWW(Modules.linkGetCountry, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text != "null" && _resuilt.text != "")
        { //hoan thanh
            //print(_resuilt.text);
            listAvatarCountry = new List<Texture2D>();
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            if (panelTopCountry != null) Destroy(panelTopCountry);
            panelTopCountry = Instantiate(listTempCountry, Vector3.zero, Quaternion.identity) as GameObject;
            Transform panelContent = panelTopCountry.transform.Find("Content");
            Transform panelItem = panelContent.transform.Find("Item");
            Transform panelTop = panelContent.transform.Find("TopThreeIndex");
            panelTop.GetChild(2).GetChild(2).GetComponent<Image>().sprite = Modules.GetIconFlag(dataCountry);
            //xu ly 3 doi tuong dac biet
            int maxIndex = 3;
            if (dataLine.Length < 3) maxIndex = dataLine.Length;
            for (int i = 0; i < maxIndex; i++)
            {
                if (dataLine[i] == "") continue;
                Transform tranAvatar = panelTop.GetChild(i + 3).GetChild(1);
                Transform tranName = panelTop.GetChild(i + 3).GetChild(2).GetChild(0);
                Transform tranScore = panelTop.GetChild(i + 3).GetChild(2).GetChild(1);
                Transform tranLike = panelTop.GetChild(i + 3).GetChild(3);
                Image fbAvatar = tranAvatar.GetComponent<Image>();
                Text fbName = tranName.GetComponent<Text>();
                Text fbScore = tranScore.GetComponent<Text>();
                ButtonLike fbLike = tranLike.GetComponent<ButtonLike>();

                string[] data = dataLine[i].Split(';');
                fbName.text = data[0];
                listAvatarCountry.Add(null);
                if (Modules.containAchievement.activeSelf) StartCoroutine(LoadImageCountry(data[1], i, fbAvatar));
                fbScore.text = data[3];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                //lay week va time left
                if (weekNow == -1) weekNow = Modules.IntParseFast(data[4]);
                if (timeLeft == -1)
                {
                    timeLeft = Modules.IntParseFast(data[5]);
                    CancelInvoke("UpdateTimeLeft");
                    InvokeRepeating("UpdateTimeLeft", 1, 1);
                }
                Modules.SetBadges(panelTop.GetChild(i + 3).gameObject, int.Parse(data[2]));
            }
            for (int i = maxIndex; i < 3; i++)
                panelTop.GetChild(i + 3).gameObject.SetActive(false);
            //xu ly cac doi tuong con lai
            if (dataLine.Length < 4) panelItem.gameObject.SetActive(false);
            for (int i = 3; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                GameObject newItem = panelItem.gameObject;
                if (i > 3)
                {
                    newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                    newItem.transform.SetParent(panelContent, false);
                }
                if (i % 2 == 0) newItem.GetComponent<Image>().color = Modules.colorListLine;
                Transform tranAvatar = newItem.transform.Find("Avatar");
                Transform tranName = newItem.transform.Find("Name");
                Transform tranScore = newItem.transform.Find("Score");
                Transform tranIndex = newItem.transform.Find("Index");
                Transform tranLike = newItem.transform.Find("BGLike");

                Image fbAvatar = tranAvatar.GetComponent<Image>();
                Text fbName = tranName.GetComponent<Text>();
                Text fbScore = tranScore.GetComponent<Text>();
                Text fbIndex = tranIndex.GetComponent<Text>();
                ButtonLike fbLike = tranLike.GetComponent<ButtonLike>();

                string[] data = dataLine[i].Split(';');
                fbName.text = data[0];
                listAvatarCountry.Add(null);
                if (Modules.containAchievement.activeSelf) StartCoroutine(LoadImageCountry(data[1], i, fbAvatar));
                fbScore.text = data[3];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbIndex.text = (i + 1).ToString();
                Modules.SetBadges(newItem, int.Parse(data[2]));
            }
            panelTopCountry.transform.position = pointListCountry;
            panelTopCountry.transform.SetParent(parentListCountry.transform, false);
            panelLoadingB.SetActive(false);
            //statusGet = true;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            //statusGet = false;
            panelLoadingB.SetActive(true);
            panelLoadingB.transform.GetComponent<TextLoading>().CallStart();
        }
        yield break;
    }

    IEnumerator GetScoreDogecoin()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", Modules.maxListRank);
        form.AddField("order", "ScoreDoge");
        WWW _resuilt = new WWW(Modules.linkGetDCScore, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text != "null" && _resuilt.text != "")
        { //hoan thanh
            //print(_resuilt.text);
            listAvatarDogecoin = new List<Texture2D>();
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            if (panelTopDogecoin != null) Destroy(panelTopDogecoin);
            panelTopDogecoin = Instantiate(listTempDogecoin, Vector3.zero, Quaternion.identity) as GameObject;
            Transform panelContent = panelTopDogecoin.transform.Find("Content");
            Transform panelItem = panelContent.transform.Find("Item");
            Transform panelTop = panelContent.transform.Find("TopThreeIndex");
            //xu ly 3 doi tuong dac biet
            int maxIndex = 3;
            if (dataLine.Length < 3) maxIndex = dataLine.Length;
            for (int i = 0; i < maxIndex; i++)
            {
                if (dataLine[i] == "") continue;
                Transform tranAvatar = panelTop.GetChild(i + 3).GetChild(1);
                Transform tranName = panelTop.GetChild(i + 3).GetChild(2).GetChild(0);
                Transform tranScore = panelTop.GetChild(i + 3).GetChild(2).GetChild(1);
                Transform tranLike = panelTop.GetChild(i + 3).GetChild(3);
                Transform tranFlag = panelTop.GetChild(i + 3).GetChild(4);
                Image fbAvatar = tranAvatar.GetComponent<Image>();
                Text fbName = tranName.GetComponent<Text>();
                Text fbScore = tranScore.GetComponent<Text>();
                ButtonLike fbLike = tranLike.GetComponent<ButtonLike>();
                Image fbFlag = tranFlag.GetChild(0).GetComponent<Image>();

                string[] data = dataLine[i].Split(';');
                fbName.text = data[0];
                listAvatarDogecoin.Add(null);
                if (Modules.containAchievement.activeSelf) StartCoroutine(LoadImageDogecoin(data[1], i, fbAvatar));
                fbScore.text = data[3];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                //lay week va time left
                if (weekNow == -1) weekNow = Modules.IntParseFast(data[4]);
                if (timeLeft == -1)
                {
                    timeLeft = Modules.IntParseFast(data[5]);
                    CancelInvoke("UpdateTimeLeft");
                    InvokeRepeating("UpdateTimeLeft", 1, 1);
                }
                Modules.SetBadges(panelTop.GetChild(i + 3).gameObject, int.Parse(data[2]));
            }
            for (int i = maxIndex; i < 3; i++)
                panelTop.GetChild(i + 3).gameObject.SetActive(false);
            //xu ly cac doi tuong con lai
            if (dataLine.Length < 4) panelItem.gameObject.SetActive(false);
            for (int i = 3; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                GameObject newItem = panelItem.gameObject;
                if (i > 3)
                {
                    newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                    newItem.transform.SetParent(panelContent, false);
                }
                if (i % 2 == 0) newItem.GetComponent<Image>().color = Modules.colorListLine;
                Transform tranAvatar = newItem.transform.Find("Avatar");
                Transform tranName = newItem.transform.Find("Name");
                Transform tranScore = newItem.transform.Find("Score");
                Transform tranIndex = newItem.transform.Find("Index");
                Transform tranLike = newItem.transform.Find("BGLike");
                Transform tranFlag = newItem.transform.Find("Flag");

                Image fbAvatar = tranAvatar.GetComponent<Image>();
                Text fbName = tranName.GetComponent<Text>();
                Text fbScore = tranScore.GetComponent<Text>();
                Text fbIndex = tranIndex.GetComponent<Text>();
                ButtonLike fbLike = tranLike.GetComponent<ButtonLike>();
                Image fbFlag = tranFlag.GetChild(0).GetComponent<Image>();

                string[] data = dataLine[i].Split(';');
                fbName.text = data[0];
                listAvatarDogecoin.Add(null);
                if (Modules.containAchievement.activeSelf) StartCoroutine(LoadImageDogecoin(data[1], i, fbAvatar));
                fbScore.text = data[3];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbIndex.text = (i + 1).ToString();
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                Modules.SetBadges(newItem, int.Parse(data[2]));
            }
            panelTopDogecoin.transform.position = pointListDogecoin;
            panelTopDogecoin.transform.SetParent(parentListDogecoin.transform, false);
            panelLoadingD.SetActive(false);
            //statusGet = true;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            //statusGet = false;
            panelLoadingD.SetActive(true);
            panelLoadingD.transform.GetComponent<TextLoading>().CallStart();
        }
        yield break;
    }

  /*  public void ButtonLoginFacebook()
    {
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        Modules.PlayAudioClipFree(Modules.audioButton);
        fbController.FBlogin();
#endif
    }*/

  /*  public void ButtonTopFacebookClick()
    {
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        return;
#endif
        Modules.PlayAudioClipFree(Modules.audioButton);
        parentListFriend.SetActive(true);
        parentListCountry.SetActive(false);
        parentListWorld.SetActive(false);
        parentListDogecoin.SetActive(false);
    }
*/
    public void ButtonTopCountryClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        parentListFriend.SetActive(false);
        parentListCountry.SetActive(true);
        parentListWorld.SetActive(false);
        parentListDogecoin.SetActive(false);
    }

    public void ButtonTopWorldClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        parentListFriend.SetActive(false);
        parentListCountry.SetActive(false);
        parentListWorld.SetActive(true);
        parentListDogecoin.SetActive(false);
    }

    public void ButtonTopDogecoinClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        parentListFriend.SetActive(false);
        parentListCountry.SetActive(false);
        parentListWorld.SetActive(false);
        parentListDogecoin.SetActive(true);
    }

    public void ButtonPlayClick()
    {
        Modules.PlayAudioClipFree(Modules.audioTapPlay);
        Modules.autoTapPlay = true;
        Modules.containMainGame.SetActive(true);
        Modules.containAchievement.SetActive(false);
        if (Modules.statusGame == StatusGame.over)
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
        else
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().CheckTapNow();
    }

    public void ButtonGoHomeClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containMainGame.SetActive(true);
        Modules.containAchievement.SetActive(false);
        if (Modules.statusGame == StatusGame.over)
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
    }

    public void ButtonShopClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containAchievement.SetActive(false);
        Modules.containShopItem.SetActive(true);
        Modules.containShopItem.transform.Find("MainCamera").GetComponent<PageShopItems>().CallStart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonGoHomeClick();
        }
    }

    //xu ly ngon ngu
    public Text textPlay, textScore, textDoubleCoin, textNoName;
    public Text textTopFriendA, textTopFriendB, textTopFriendC, textTopFriendD;
    public Text textTopCountryA, textTopCountryB, textTopCountryC, textTopCountryD;
    public Text textTopWorldA, textTopWorldB, textTopWorldC, textTopWorldD;
    public Text textTopDogecoinA, textTopDogecoinB, textTopDogecoinC, textTopDogecoinD;
    public Text textLoginFB, textNoteBonus, textLoadingA, textLoadingB, textLoadingC, textLoadingD;
    public void ChangeAllLanguage()
    {
        int iLang = Modules.indexLanguage;
        textPlay.font = AllLanguages.listFontLangA[iLang];
        textPlay.text = AllLanguages.menuPlay[iLang];
        textScore.font = AllLanguages.listFontLangA[iLang];
        textScore.text = AllLanguages.topScore[iLang];
        textDoubleCoin.font = AllLanguages.listFontLangA[iLang];
        textDoubleCoin.text = AllLanguages.topDoubleCoin[iLang];
        textNoName.font = AllLanguages.listFontLangA[iLang];
        textNoName.text = AllLanguages.topNoName[iLang];

        textTopFriendA.font = AllLanguages.listFontLangA[iLang];
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        textTopFriendA.text = "";
#else
        textTopFriendA.text = AllLanguages.topTopFriend[iLang];
#endif
        textTopCountryA.font = AllLanguages.listFontLangA[iLang];
        textTopCountryA.text = AllLanguages.topTopCountry[iLang];
        textTopWorldA.font = AllLanguages.listFontLangA[iLang];
        textTopWorldA.text = AllLanguages.topTopWorld[iLang];
        textTopDogecoinA.font = AllLanguages.listFontLangA[iLang];
        textTopDogecoinA.text = AllLanguages.topTopDogecoin[iLang];

        textTopFriendB.font = AllLanguages.listFontLangA[iLang];
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        textTopFriendB.text = "";
#else
        textTopFriendB.text = AllLanguages.topTopFriend[iLang];
#endif
        textTopCountryB.font = AllLanguages.listFontLangA[iLang];
        textTopCountryB.text = AllLanguages.topTopCountry[iLang];
        textTopWorldB.font = AllLanguages.listFontLangA[iLang];
        textTopWorldB.text = AllLanguages.topTopWorld[iLang];
        textTopDogecoinB.font = AllLanguages.listFontLangA[iLang];
        textTopDogecoinB.text = AllLanguages.topTopDogecoin[iLang];

        textTopFriendC.font = AllLanguages.listFontLangA[iLang];
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        textTopFriendC.text = "";
#else
        textTopFriendC.text = AllLanguages.topTopFriend[iLang];
#endif
        textTopCountryC.font = AllLanguages.listFontLangA[iLang];
        textTopCountryC.text = AllLanguages.topTopCountry[iLang];
        textTopWorldC.font = AllLanguages.listFontLangA[iLang];
        textTopWorldC.text = AllLanguages.topTopWorld[iLang];
        textTopDogecoinC.font = AllLanguages.listFontLangA[iLang];
        textTopDogecoinC.text = AllLanguages.topTopDogecoin[iLang];

        textTopFriendD.font = AllLanguages.listFontLangA[iLang];
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
        textTopFriendD.text = "";
#else
        textTopFriendD.text = AllLanguages.topTopFriend[iLang];
#endif
        textTopCountryD.font = AllLanguages.listFontLangA[iLang];
        textTopCountryD.text = AllLanguages.topTopCountry[iLang];
        textTopWorldD.font = AllLanguages.listFontLangA[iLang];
        textTopWorldD.text = AllLanguages.topTopWorld[iLang];
        textTopDogecoinD.font = AllLanguages.listFontLangA[iLang];
        textTopDogecoinD.text = AllLanguages.topTopDogecoin[iLang];

        textLoadingA.font = AllLanguages.listFontLangA[iLang];
        textLoadingA.text = AllLanguages.topLoading[iLang];
        textLoadingB.font = AllLanguages.listFontLangA[iLang];
        textLoadingB.text = AllLanguages.topLoading[iLang];
        textLoadingC.font = AllLanguages.listFontLangA[iLang];
        textLoadingC.text = AllLanguages.topLoading[iLang];
        textLoadingD.font = AllLanguages.listFontLangA[iLang];
        textLoadingD.text = AllLanguages.topLoading[iLang];

        textLoginFB.font = AllLanguages.listFontLangA[iLang];
        textLoginFB.text = AllLanguages.topLoginFacebook[iLang];
        textNoteBonus.font = AllLanguages.listFontLangA[iLang];
        textNoteBonus.text = AllLanguages.topNoteGetStart[iLang] + " 10000 " + AllLanguages.topNoteGetEnd[iLang];
    }
}
