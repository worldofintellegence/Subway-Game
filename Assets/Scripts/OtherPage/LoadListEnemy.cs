using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
using Facebook.Unity;
#endif*/

public class LoadListEnemy : MonoBehaviour {

    //private FacebookController fbController;
    private bool statusPost = false;
    public void CallStart()
    {
        statusPost = false;
        Modules.fbAvatarEnemy = new List<string>();
        Modules.fbNameEnemy = new List<string>();
        Modules.fbHighScore = new List<float>();
        StartCoroutine(GetWeekReward());
        StartCoroutine(PostScore());
        PostScoreTop();
        if (Modules.countryEnemy == 1)
        {
            PostScoreWorld();
        }
        else
        {
/*#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0 || UNITY_STANDALONE_OSX)
            if (fbController == null) fbController = Modules.facebookController.GetComponent<FacebookController>();
            fbController.isPostDone = false;
            fbController.isGetDone = false;
            fbController.getEnemy = true;
            PostScoreFBNew();
            GetScoreFBNew();
#endif*/
        }
    }

  /*  void PostScoreFBNew()
    {
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
        if (FB.IsLoggedIn)
        {
            fbController.PostScore();
        }
        else Invoke("PostScoreFBNew", 1f);
#endif
    }*/

  /*  void GetScoreFBNew()
    {
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
        if (fbController.isPostDone)
        {
            fbController.GetScores();
            fbController.isPostDone = false;
        }
        else Invoke("GetScoreFBNew", 1f);
#endif
    }
*/
    void PostScoreWorld()
    {
        if (statusPost)
        {
            StartCoroutine(GetScoreCountry());
        }
        else Invoke("PostScoreWorld", 1f);
    }

    void PostScoreTop()
    {
        if (statusPost)
        {
            StartCoroutine(GetScoreTop());
        }
        else Invoke("PostScoreTop", 1f);
    }

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
        while (!_resuilt.isDone && runTime < Modules.maxTime)
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
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            for (int i = 0; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                string[] data = dataLine[i].Split(';');
                int scoreNow = int.Parse(data[3]);
                if (scoreNow >= Modules.totalScore)
                {
                    Modules.fbNameEnemy.Add(data[0]);
                    Modules.fbHighScore.Add(scoreNow);
                    Modules.fbAvatarEnemy.Add(data[1]);
                    //print(data[0] + "=>" + scoreNow.ToString() + ";" + data[1]);
                }
            }
            //statusGet = true;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            //statusGet = false;
        }
        yield break;
    }

    IEnumerator GetScoreTop()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", "3");
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
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            if (dataLine.Length > 1 && dataLine[0] != "")
            {
                string[] data = dataLine[0].Split(';');
                Modules.scoreTop = int.Parse(data[3]);
                Modules.linkIconTop = data[1];
                Modules.codeCountryTop = data[8];
            }
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
        }
        yield break;
    }

    IEnumerator GetWeekReward()
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
        WWWForm form = new WWWForm();
        form.AddField("table", "WeeklyReward");
        form.AddField("myID", idDevice);
        WWW _resuilt = new WWW(Modules.linkGetTop, form);
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
            for (int i = 0; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                string[] data = dataLine[i].Split(';');
                Modules.lastWeek = data[0];
                Modules.idGetReward = data[1];
                Modules.statusGetReward = data[2];
                Modules.myIDDB = data[3];
                //kiem tra xem co trung cai veo gi khong
                string[] idReward = Modules.idGetReward.Split(',');
                string[] stReward = Modules.statusGetReward.Split(',');
                Modules.typeWeekReward = 0;
                for (int j = 0; j < idReward.Length; j++)
                {
                    if (idReward[j] == Modules.myIDDB && stReward[j] == "0")
                    {
                        Modules.typeWeekReward = j + 1;
                        break;
                    }
                }
                if (Modules.typeWeekReward != 0)//neu trong danh sach thuong thi update lai tren database
                {
                    stReward[Modules.typeWeekReward - 1] = "1";
                    string temp = "";
                    for (int j = 0; j < stReward.Length; j++)
                    {
                        temp += stReward[j];
                        if (j < stReward.Length - 1) temp += ",";
                    }
                    Modules.statusGetReward = temp;
                    StartCoroutine(Modules.PostUpdateTopper(Modules.lastWeek, "", Modules.statusGetReward));
                }
            }
            //statusGet = true;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            //statusGet = false;
        }
        yield break;
    }
}
