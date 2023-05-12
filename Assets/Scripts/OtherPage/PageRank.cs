using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageRank : MonoBehaviour {

    public Text textKey, textCoin, textHighScore;
    public GameObject parentLegendary, parentDiamond, parentGold, parentSilver;
    public Color colorLightLegendary, colorLightDiamond, colorLightGold, colorLightSilver;
    public GameObject panelLoading, panelList;

    public void CallStart()
    {
        //Modules.FreeMemoryNow();
        ChangeAllLanguage();
        UpdateCoins();
        UpdateKeys();
        textHighScore.GetComponent<EffectUpScore>().StartEffect(Modules.totalScore);
        Modules.PlayAudioClipLoop(Modules.audioBGMenu, Camera.main.transform);
        statusGet = 0;
        panelLoading.SetActive(true);
        panelList.SetActive(false);
        panelLoading.transform.GetComponent<TextLoading>().CallStart();
        CancelInvoke("CheckShowPanelList");
        Invoke("CheckShowPanelList", 1);
        StartCoroutine(GetScoreLegendary());
        StartCoroutine(GetScoreDiamond());
        StartCoroutine(GetScoreGold());
        StartCoroutine(GetScoreSilver());
    }

    void CheckShowPanelList()
    {
        if (statusGet >= 4)
        {
            panelLoading.SetActive(false);
            panelList.SetActive(true);
        }
        else Invoke("CheckShowPanelList", 1);
    }

    public void UpdateCoins()
    {
        textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
    }

    public void UpdateKeys()
    {
        textKey.text = Mathf.RoundToInt(Modules.totalKey).ToString();
    }

    public void ButtonPlayClick()
    {
        Modules.PlayAudioClipFree(Modules.audioTapPlay);
        Modules.autoTapPlay = true;
        Modules.containMainGame.SetActive(true);
        Modules.containRank.SetActive(false);
        if (Modules.statusGame == StatusGame.over)
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
        else
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().CheckTapNow();
    }

    public void ButtonGoHomeClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containRank.SetActive(false);
        Modules.containMainGame.SetActive(true);
        if (Modules.statusGame == StatusGame.over)
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
    }

    public void ButtonRankClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containRank.SetActive(false);
        Modules.containAchievement.SetActive(true);
        Modules.containAchievement.transform.Find("MainCamera").GetComponent<PageAchievement>().CallStart();
    }

    private int statusGet = 0;
    //LOAD LEGENDARY MEDAL RANK
    List<Texture2D> listAvatarLegendary = new List<Texture2D>();
    IEnumerator GetScoreLegendary()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", Modules.maxListRank);
        form.AddField("order", "Score");
        form.AddField("minScore", "10000000");
        WWW _resuilt = new WWW(Modules.linkGetRank, form);
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
            listAvatarLegendary = new List<Texture2D>();
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            for (int i = 2; i < parentLegendary.transform.childCount; i++)
                Destroy(parentLegendary.transform.GetChild(i).gameObject);
            parentLegendary.transform.GetChild(1).gameObject.SetActive(true);
            Transform panelItem = parentLegendary.transform.GetChild(1);
            //xu ly cac doi tuong con lai
            for (int i = 0; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                GameObject newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(parentLegendary.transform, false);
                if (i % 2 != 0) newItem.GetComponent<Image>().color = colorLightLegendary;
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
                listAvatarLegendary.Add(null);
                if (Modules.containRank.activeSelf) StartCoroutine(LoadImageLegendary(data[1], i, fbAvatar));
                fbScore.text = data[2];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbIndex.text = (i + 1).ToString();
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                Modules.SetBadges(newItem, int.Parse(data[2]));
            }
            parentLegendary.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            parentLegendary.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        yield break;
    }

    IEnumerator LoadImageLegendary(string url, int index, Image avatar)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null && avatar != null)
        {
            listAvatarLegendary[index] = www.texture;
            int width = listAvatarLegendary[index].width;
            int height = listAvatarLegendary[index].height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            avatar.sprite = Sprite.Create(listAvatarLegendary[index], new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    //LOAD DIAMOND MEDAL RANK
    List<Texture2D> listAvatarDiamond = new List<Texture2D>();
    IEnumerator GetScoreDiamond()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", Modules.maxListRank);
        form.AddField("order", "Score");
        form.AddField("minScore", "1000000");
        form.AddField("maxScore", "10000000");
        WWW _resuilt = new WWW(Modules.linkGetRank, form);
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
            listAvatarDiamond = new List<Texture2D>();
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            for (int i = 2; i < parentDiamond.transform.childCount; i++)
                Destroy(parentDiamond.transform.GetChild(i).gameObject);
            parentDiamond.transform.GetChild(1).gameObject.SetActive(true);
            Transform panelItem = parentDiamond.transform.GetChild(1);
            //xu ly cac doi tuong con lai
            for (int i = 0; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                GameObject newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(parentDiamond.transform, false);
                if (i % 2 != 0) newItem.GetComponent<Image>().color = colorLightDiamond;
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
                listAvatarDiamond.Add(null);
                if (Modules.containRank.activeSelf) StartCoroutine(LoadImageDiamond(data[1], i, fbAvatar));
                fbScore.text = data[2];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbIndex.text = (i + 1).ToString();
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                Modules.SetBadges(newItem, int.Parse(data[2]));
            }
            parentDiamond.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            parentDiamond.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        yield break;
    }

    IEnumerator LoadImageDiamond(string url, int index, Image avatar)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null && avatar != null)
        {
            listAvatarDiamond[index] = www.texture;
            int width = listAvatarDiamond[index].width;
            int height = listAvatarDiamond[index].height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            avatar.sprite = Sprite.Create(listAvatarDiamond[index], new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    //LOAD GOLD MEDAL RANK
    List<Texture2D> listAvatarGold = new List<Texture2D>();
    IEnumerator GetScoreGold()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", Modules.maxListRank);
        form.AddField("order", "Score");
        form.AddField("minScore", "500000");
        form.AddField("maxScore", "1000000");
        WWW _resuilt = new WWW(Modules.linkGetRank, form);
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
            listAvatarGold = new List<Texture2D>();
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            for (int i = 2; i < parentGold.transform.childCount; i++)
                Destroy(parentGold.transform.GetChild(i).gameObject);
            parentGold.transform.GetChild(1).gameObject.SetActive(true);
            Transform panelItem = parentGold.transform.GetChild(1);
            //xu ly cac doi tuong con lai
            for (int i = 0; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                GameObject newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(parentGold.transform, false);
                if (i % 2 != 0) newItem.GetComponent<Image>().color = colorLightGold;
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
                listAvatarGold.Add(null);
                if (Modules.containRank.activeSelf) StartCoroutine(LoadImageGold(data[1], i, fbAvatar));
                fbScore.text = data[2];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbIndex.text = (i + 1).ToString();
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                Modules.SetBadges(newItem, int.Parse(data[2]));
            }
            parentGold.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            parentGold.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        yield break;
    }

    IEnumerator LoadImageGold(string url, int index, Image avatar)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null && avatar != null)
        {
            listAvatarGold[index] = www.texture;
            int width = listAvatarGold[index].width;
            int height = listAvatarGold[index].height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            avatar.sprite = Sprite.Create(listAvatarGold[index], new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    //LOAD SILVER MEDAL RANK
    List<Texture2D> listAvatarSilver = new List<Texture2D>();
    IEnumerator GetScoreSilver()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("limit", Modules.maxListRank);
        form.AddField("order", "Score");
        form.AddField("minScore", "100000");
        form.AddField("maxScore", "500000");
        WWW _resuilt = new WWW(Modules.linkGetRank, form);
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
            listAvatarSilver = new List<Texture2D>();
            string[] dataLine = _resuilt.text.TrimEnd('\n').Split('\n');
            for (int i = 2; i < parentSilver.transform.childCount; i++)
                Destroy(parentSilver.transform.GetChild(i).gameObject);
            parentSilver.transform.GetChild(1).gameObject.SetActive(true);
            Transform panelItem = parentSilver.transform.GetChild(1);
            //xu ly cac doi tuong con lai
            for (int i = 0; i < dataLine.Length; i++)
            {
                if (dataLine[i] == "") continue;
                GameObject newItem = Instantiate(panelItem.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(parentSilver.transform, false);
                if (i % 2 != 0) newItem.GetComponent<Image>().color = colorLightSilver;
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
                listAvatarSilver.Add(null);
                if (Modules.containRank.activeSelf) StartCoroutine(LoadImageSilver(data[1], i, fbAvatar));
                fbScore.text = data[2];
                fbLike.idLike = data[6];
                fbLike.SetValue(data[7]);
                fbIndex.text = (i + 1).ToString();
                fbFlag.sprite = Modules.GetIconFlag(data[8]);
                Modules.SetBadges(newItem, int.Parse(data[2]));
            }
            parentSilver.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        else
        { //qua lau, khong mang, cau lenh loi
            parentSilver.transform.GetChild(1).gameObject.SetActive(false);
            statusGet++;
        }
        yield break;
    }

    IEnumerator LoadImageSilver(string url, int index, Image avatar)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        WWW www = new WWW(url);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
            yield return new WaitForSeconds(0.1f);
        if (string.IsNullOrEmpty(www.error) && url != "Null" && www.texture != null && avatar != null)
        {
            listAvatarSilver[index] = www.texture;
            int width = listAvatarSilver[index].width;
            int height = listAvatarSilver[index].height;
            if (width > 128) width = 128;
            if (height > 128) height = 128;
            avatar.sprite = Sprite.Create(listAvatarSilver[index], new Rect(0, 0, width, height), new Vector2(0, 0));
        }
        www.Dispose();
        //yield return Resources.UnloadUnusedAssets();
        yield break;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonGoHomeClick();
        }
    }

    //xu ly ngon ngu
    public Text textLegendary, textDiamond, textGold, textSilver;
    public Text textPlay;

    public void ChangeAllLanguage()
    {
        int iLang = Modules.indexLanguage;
        textLegendary.font = AllLanguages.listFontLangA[iLang];
        textLegendary.text = AllLanguages.rankLegendary[iLang];
        textDiamond.font = AllLanguages.listFontLangA[iLang];
        textDiamond.text = AllLanguages.rankDiamond[iLang];
        textGold.font = AllLanguages.listFontLangA[iLang];
        textGold.text = AllLanguages.rankGold[iLang];
        textSilver.font = AllLanguages.listFontLangA[iLang];
        textSilver.text = AllLanguages.rankSilver[iLang];
        textPlay.font = AllLanguages.listFontLangA[iLang];
        textPlay.text = AllLanguages.menuPlay[iLang];
    }
}
