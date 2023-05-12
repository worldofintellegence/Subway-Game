/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
using Facebook.Unity;
using Facebook.MiniJSON;
#endif

public class FacebookController : MonoBehaviour {

    public GameObject panelListFriend;//mau panel nhap vao
    [HideInInspector]
    public GameObject panelGetInfo;//panel duoc lay thong tin facebook
    [HideInInspector]
    public bool isPostDone = false;
    [HideInInspector]
    public bool isGetDone = false;
    [HideInInspector]
    public bool getEnemy = true;

#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            SetInit();
        }
        else
        {
            //Handle FB.Init
            FB.Init(() =>
           {
               FB.ActivateApp();
               SetInit();
           });
        }
        //FB.Init(SetInit, OnHideUnity);
        Modules.facebookController = transform.gameObject;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        // Check the pauseStatus to see if we are in the foreground
        // or background
        if (!pauseStatus)
        {
            //app resume
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
            }
            else
            {
                //Handle FB.Init
                FB.Init(() =>
                {
                    FB.ActivateApp();
                });
            }
        }
    }

    void SetInit()
    {
        DealWithFBMenus(FB.IsLoggedIn);
    }

    //void OnHideUnity(bool isGameShown)
    //{
    //    if (!isGameShown)
    //    {
    //        Time.timeScale = 0;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1;
    //    }
    //}

    public void FBlogin()
    {
        List<string> perms = new List<string>() { "user_friends", "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, LoginReadCallback);
    }

    void LoginReadCallback(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("FB is logged in");
                //List<string> perms = new List<string>() { "publish_actions" };
                //FB.LogInWithPublishPermissions(perms, LoginPublishCallback);
                if (Modules.bonusFacebook == "No")//thuc hien thuong
                {
                    Modules.totalCoin += 10000;
                    Modules.SaveCoin();
                    if (Modules.containAchievement.activeSelf)
                        Camera.main.GetComponent<PageAchievement>().textCoin.text = Modules.totalCoin.ToString();
                    Modules.bonusFacebook = "Yes";
                    Modules.SaveBonusFacebook();
                }
            }
            else
            {
                Debug.Log("FB is not logged in");
            }
            DealWithFBMenus(FB.IsLoggedIn);
        }
    }

    void LoginPublishCallback(ILoginResult result)
    {
        //You also granted the asked publish_actions permission.
    }

    void DealWithFBMenus(bool isLoggedIn)
    {
        if (isLoggedIn)//dang nhap thanh cong
        {
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
            Modules.fbID = AccessToken.CurrentAccessToken.UserId;
        }
        else
        {
            //dang nhap that bai
        }
    }

    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
           Modules.fbName = result.ResultDictionary["first_name"].ToString();
           //print(Modules.fbName);
           //Modules.textDebug.text += "\nName[Okay]: " + Modules.fbName;
        }
        else
        {
            Debug.Log(result.Error);
            //Modules.textDebug.text += "\nName[Error]: " + Modules.fbName;
        }
    }

    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Modules.fbMyAvatar = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
            Modules.fbLinkAvatar = "https" + "://graph.facebook.com/" + AccessToken.CurrentAccessToken.UserId.ToString() + "/picture?g&width=128&height=128";
            print(Modules.fbLinkAvatar);
        }
    }

    public void ShareWithFriends()
    {
        FB.FeedShare("", null, "Name", "CAP", "DES", null, "", null);
    }

    public void InviteFriends()
    {
        FB.AppRequest(
            message: "This game is awesome, join me. now.",
            title: "Invite your friends to join you"
            );
    }

    private IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();

        var width = Screen.width;
        var height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] screenshot = tex.EncodeToPNG();

        var wwwForm = new WWWForm();
        wwwForm.AddBinaryData("image", screenshot, "Screenshot.png");

        FB.API("me/photos", HttpMethod.POST, OnPostScreenShot, wwwForm);
    }

    private void OnPostScreenShot(IGraphResult result)
    {
        print("Post image OK");
    }

    public void PostScore()
    {
        StartCoroutine(PostFBScore());
    }

    IEnumerator PostFBScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "FriendScore");
        form.AddField("idFace", AccessToken.CurrentAccessToken.UserId.ToString());
        form.AddField("score", Mathf.RoundToInt(Modules.totalScore));
        WWW _resuilt = new WWW(Modules.linkPostFBScore, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text == "Done")
        { //hoan thanh
            isPostDone = true;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            isPostDone = false;
        }
        yield break;
    }

    IEnumerator GetFBScore(string idFace, int index)
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "FriendScore");
        form.AddField("idFace", idFace);
        WWW _resuilt = new WWW(Modules.linkGetFBScore, form);
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
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            if (dataLine.Length > 0 && dataLine[0].Length > 1)
            {
                string[] data = dataLine[0].Split(';');
                listScoreFriend[index] = int.Parse(data[1]);
            }
            if (listScoreFriend.Count == totalFriend + 1)
                UpdateList();
        }
        else
        { //qua lau, khong mang, cau lenh loi
        }
        yield break;
    }

    public void GetScores()
    {
        string strGetScore = "/me/friends?limit=30";
        FB.API(strGetScore, HttpMethod.GET, OnGetScore);
    }

    private List<object> scoresList = null;
    private List<string> listNameFriend;
    private List<string> listIDFriend;
    private List<int> listScoreFriend;
    private int totalFriend = 0;
    private void OnGetScore(IGraphResult result)
    {
        print("Get score " + result.RawResult);
        //khoi tao lai list doi thu score
        if (getEnemy && Modules.countryEnemy != 1)
        {
            Modules.fbAvatarEnemy = new List<string>();
            Modules.fbNameEnemy = new List<string>();
            Modules.fbHighScore = new List<float>();
            Modules.fbHighFriend = new List<float>();
        }
        //thuc hien khac
        scoresList = DeserializeScores(result.RawResult);
        totalFriend = scoresList.Count;
        //thuc hien lay danh sach thong tin ban be (ten, avatar, diem so)
        listNameFriend = new List<string>();
        listIDFriend = new List<string>();
        listScoreFriend = new List<int>();
        int indexData = 0;
        foreach (object score in scoresList)
        {
            var entry = (Dictionary<string, object>)score;
            listNameFriend.Add(entry["name"].ToString().Split(' ')[0]);
            string idF = entry["id"].ToString();
            listIDFriend.Add(idF);
            listScoreFriend.Add(0);
            StartCoroutine(GetFBScore(idF, indexData));
            indexData++;
        }
        //add them chinh minh vao danh sach
        listNameFriend.Add(Modules.fbName);
        string myID = AccessToken.CurrentAccessToken.UserId.ToString();
        listIDFriend.Add(myID);
        listScoreFriend.Add(0);
        StartCoroutine(GetFBScore(myID, indexData));
        indexData++;
    }

    private void UpdateList()
    {
        //sap xep cac danh sach theo diem so thap dan
        for (int i = 0; i < listScoreFriend.Count - 1; i++)
        {
            for (int j = i; j < listScoreFriend.Count; j++)
            {
                if (listScoreFriend[j] > listScoreFriend[i])
                {
                    int scoreTemp = listScoreFriend[i];
                    listScoreFriend[i] = listScoreFriend[j];
                    listScoreFriend[j] = scoreTemp;

                    string nameTemp = listNameFriend[i];
                    listNameFriend[i] = listNameFriend[j];
                    listNameFriend[j] = nameTemp;

                    string idTemp = listIDFriend[i];
                    listIDFriend[i] = listIDFriend[j];
                    listIDFriend[j] = idTemp;
                }
            }
        }
        //thuc hien export bang xep hang
        if (panelGetInfo != null) Destroy(panelGetInfo);
        panelGetInfo = Instantiate(panelListFriend, Vector3.zero, Quaternion.identity) as GameObject;
        Transform panelContent = panelGetInfo.transform.Find("Content");
        Transform panelItem = panelContent.transform.Find("Item");
        //Modules.textDebug.text += "\nGET: " + result.RawResult;
        //Modules.textDebug.text += "\nGET: ScoresList: " + scoresList.Count;
        for (int i = 0; i < listScoreFriend.Count; i++)
        {
            GameObject newItem = panelItem.gameObject;
            if (i > 0)
            {
                newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(panelContent, false);
            }
            if (i % 2 != 0) newItem.GetComponent<Image>().color = Modules.colorListLine;
            Transform tranAvatar = newItem.transform.Find("Avatar");
            Transform tranName = newItem.transform.Find("Name");
            Transform tranScore = newItem.transform.Find("Score");
            Transform tranIndex = newItem.transform.Find("Index");

            Image fbAvatar = tranAvatar.GetComponent<Image>();
            Text fbName = tranName.GetComponent<Text>();
            Text fbScore = tranScore.GetComponent<Text>();
            Text fbIndex = tranIndex.GetComponent<Text>();

            fbName.text = listNameFriend[i];
            int scoreNow = listScoreFriend[i];
            if (getEnemy && Modules.countryEnemy != 1 && scoreNow >= Modules.totalScore)
            {
                Modules.fbNameEnemy.Add(fbName.text);
                Modules.fbHighScore.Add(scoreNow);
                Modules.fbHighFriend.Add(scoreNow);
                Modules.fbAvatarEnemy.Add("https" + "://graph.facebook.com/" + listIDFriend[i] + "/picture?g&width=128&height=128");
                //Modules.textDebug.text += "\nADD: " + fbName.text;
            }
            fbScore.text = scoreNow.ToString();
            fbIndex.text = (i + 1).ToString();
            FB.API(GetPictureURL(listIDFriend[i], 128, 128), HttpMethod.GET, delegate(IGraphResult pictureResult)
            {
                if (pictureResult.Error != null) // if there was an error
                {
                    Debug.Log(pictureResult.Error);
                }
                else // if everything was fine
                {
                    if (fbAvatar) fbAvatar.sprite = Sprite.Create(pictureResult.Texture, new Rect(0, 0, 128, 128), new Vector2(0, 0));
                }
            });
        }
        isGetDone = true;
        getEnemy = false;
    }

    public static List<object> DeserializeScores(string response)
    {

        var responseObject = Json.Deserialize(response) as Dictionary<string, object>;
        object scoresh;
        var scores = new List<object>();
        if (responseObject.TryGetValue("data", out scoresh))
        {
            scores = (List<object>)scoresh;
        }

        return scores;
    }

    public static string GetPictureURL(string facebookID, int? width = null, int? height = null, string type = null)
    {
        string url = string.Format("/{0}/picture", facebookID);
        string query = width != null ? "&width=" + width.ToString() : "";
        query += height != null ? "&height=" + height.ToString() : "";
        query += type != null ? "&type=" + type : "";
        if (query != "") url += ("?g" + query);
        return url;
    }
#endif
}
*/