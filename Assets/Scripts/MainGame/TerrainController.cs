using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TerrainController : MonoBehaviour
{
    public int indexScenesNow = 0;
    public List<int> listIndexScenesNormal = new List<int>();
    public List<int> listIndexScenesBonus = new List<int>();
    public List<int> listIndexScenesTemple = new List<int>();
    public int maxShowTerrainFront = 4;//ap dung chay xuoi map
    public int maxShowTerrainBack = 4;//ap dung chay lui map
    private int originMaxShowFront = 4, originMaxShowBack = 4;
    private int runFront = 1;//neu -1 la run back
    [HideInInspector]
    public List<GameObject> listShowTerrain = new List<GameObject>();
    private int runCodeTerrain = 0;//thay dia hinh trong canh
    private float pointCodeTerrain = 0;//toa do z luc bat dau tao dia hinh
    [HideInInspector]
    public string listCodeTerrain = "";//luu lai ma cua cac terrain
    public float numEditSpeed = 0.75f;//so lieu dieu chinh toc do speed
    public float pointBySpeed = 1f;//nhan theo toc do chay cua map
    public float timeChangeSpeed = 3;//so giay de thay doi speed
    public float stepSpeedMove = 0.001f;//toc do gia tang speed
    public float destanShowMore = 15f;//khoang cach them de destroy terrain da di qua
    //xu ly hieu ung avatar
    public GameObject effectAvatar;
    public GameObject containEffectAvatar;
    private CreatePoolTerrains poolTerrains;
    //xu ly hieu ung gia fog mat nuoc
    public GameObject fakeFogWater;

    public void Start()
    {
        poolTerrains = Modules.poolTerrains.GetComponent<CreatePoolTerrains>();
        originMaxShowFront = maxShowTerrainFront;
        originMaxShowBack = maxShowTerrainBack;
    }

    //khi xep map nho chu y khong nen su dung cac map khong ho tro Menu de lam random (thang khac goi den hoac goi den thang khac)
    public Vector4 GetPointRunTerrain()
    {
        Vector4 result = Vector4.zero;
        if (listIndexScenesNormal.Contains(indexScenesNow))
        {
            result.x = indexScenesNow;
            bool terSupport = true;
            result.y = runCodeTerrain - maxShowTerrainFront;
            result.z = 0;
            result.w = Modules.mainCharacter.GetComponent<HeroController>().GetGroundNear();
            listCodeTerrain = "";
            if (result.y < 0)
            {
                if (Modules.gameGuide == "YES")//neu dang huong dan
                    result.y = maxShowTerrainFront + result.y;
                else
                    result.y = poolTerrains.listUseTerrain[indexScenesNow].listTerrain.Count + result.y;
            }
            if (listShowTerrain.Count > 1)
            {
                int indexTemp = Mathf.RoundToInt(result.y);
                if (!listShowTerrain[0].GetComponent<TerrainInformation>().supportMenu
                    || (!listShowTerrain[1].GetComponent<TerrainInformation>().supportMenu
                    && listShowTerrain[1].transform.position.z < listShowTerrain[1].GetComponent<TerrainInformation>().lengthTerrain / 2f + destanShowMore))
                {
                    result.y = -1;
                    result.w = 0;
                    terSupport = false;
                    if (listShowTerrain[0].GetComponent<TerrainInformation>().supportMenu)
                    {
                        result.y = indexTemp;
                        GetListCodeTerrainNow();
                    }
                    else
                    {
                        for (int i = indexTemp - 1; i >= 0; i--)
                        {
                            if (poolTerrains.listUseTerrain[indexScenesNow].listTerrain[i].GetComponent<TerrainInformation>().supportMenu)
                            {
                                result.y = i;
                                break;
                            }
                        }
                    }
                }
            }
            if (terSupport && listShowTerrain.Count > 0)
            {
                result.z = listShowTerrain[0].transform.position.z;
                GetListCodeTerrainNow();
            }
        }
        return result;
    }

    void GetListCodeTerrainNow()
    {
        for (int i = 0; i < listShowTerrain.Count; i++)
        {
            listCodeTerrain += listShowTerrain[i].GetComponent<TerrainInformation>().codeTerrain;
            if (i < listShowTerrain.Count - 1) listCodeTerrain += ";";
        }
    }

    private void SetSkyBox(Material newSkybox)
    {
        transform.GetComponent<Skybox>().material = newSkybox;
        transform.GetComponent<RotateSkyBox>().myMatSky = newSkybox;
    }

    public void ResetTerrain()
    {
        CancelInvoke("UpdateSpeedBack");
        CancelInvoke("UpdateSpeedMap");
        oldIndexScenesNow = -1;
        Modules.panelFakeCity.SetActive(true);
        Modules.panelFakeTemple.SetActive(false);
        SetSkyBox(Modules.skyNormal);
        RenderSettings.fogColor = Modules.colorFogNormal;
        Modules.distanceFogTempleX = 0;
        Modules.distanceFogTempleY = 0;
        Camera.main.GetComponent<ChangeHeightFog>().ResetValue(true);
        maxShowTerrainFront = originMaxShowFront;
        maxShowTerrainBack = originMaxShowBack;
        indexScenesNow = Modules.indexTypeTerrain;
        runCodeTerrain = Modules.indexRunTerrain;
        pointCodeTerrain = Modules.pointRunTerrain;
        listCodeTerrain = Modules.listCodeTerrain;
        runFront = 1;
        foreach (GameObject go in listShowTerrain)
            go.SetActive(false);
        listShowTerrain = new List<GameObject>();
        if (listShowTerrain.Count < maxShowTerrainFront)
        {
            for (int i = listShowTerrain.Count; i < maxShowTerrainFront; i++)
                AddNewTerrain(false);
        }
        Invoke("UpdateSpeedMap", timeChangeSpeed);
        changeScoreTop = false;
        //xu ly tang toc doi toi da
        indexMarkPoint = 0;
        Modules.textWorldScore.transform.parent.gameObject.SetActive(true);
    }

    public void SetNewScene(int indexScene)//neu nho hoac lon hon range thi random
    {
        Modules.panelFakeCity.SetActive(true);
        Modules.panelFakeTemple.SetActive(false);
        SetSkyBox(Modules.skyNormal);
        RenderSettings.fogColor = Modules.colorFogNormal;
        Modules.distanceFogTempleX = 0;
        Modules.distanceFogTempleY = 0;
        Camera.main.GetComponent<ChangeHeightFog>().ResetValue();
        maxShowTerrainFront = originMaxShowFront;
        maxShowTerrainBack = originMaxShowBack;
        runFront = 1;
        //xoa het cac terrain cu
        foreach (GameObject go in listShowTerrain)
            go.SetActive(false);
        listShowTerrain = new List<GameObject>();
        int oldIndexScene = indexScenesNow;
        if (oldIndexScenesNow != -1)
        {
            indexScenesNow = oldIndexScenesNow;
            oldIndexScenesNow = -1;
        }
        else indexScenesNow = indexScene;
        if (indexScenesNow < 0)
        {
            int newMap = oldIndexScene;
            while (newMap == oldIndexScene)
                newMap = listIndexScenesNormal[Random.Range(0, listIndexScenesNormal.Count)];
            indexScenesNow = newMap;
        }
        pointCodeTerrain = 0;
        listCodeTerrain = "";
        //thuc hien create terrain moi
        for (int i = 0; i < maxShowTerrainFront; i++)
            AddNewTerrain(false);
        //Modules.FreeMemoryNow();
    }

    private float oldSpeedGame = 1f;//luu lai speed game
    private int oldIndexScenesNow = -1;
    public void SetBonusScene()
    {
        Modules.scoreBonusRoadRun = 0;
        Modules.mesBonusTextAwesome = false;
        Modules.mesBonusTextPerfect = false;
        Modules.panelFakeCity.SetActive(false);
        Modules.panelFakeTemple.SetActive(false);
        SetSkyBox(Modules.skyBonus);
        RenderSettings.fogColor = Modules.colorFogNormal;
        Modules.distanceFogTempleX = 0;
        Modules.distanceFogTempleY = 0;
        Camera.main.GetComponent<ChangeHeightFog>().ResetValue();
        maxShowTerrainFront = originMaxShowFront + 1;
        maxShowTerrainBack = originMaxShowBack + 1;
        oldSpeedGame = Modules.speedGame;
        Modules.speedGame = 0;
        runFront = -1;
        //xoa het cac terrain cu
        foreach (GameObject go in listShowTerrain)
            go.SetActive(false);
        listShowTerrain = new List<GameObject>();
        oldIndexScenesNow = indexScenesNow;
        int indexRan = Random.Range(0, listIndexScenesBonus.Count);
        indexScenesNow = listIndexScenesBonus[indexRan];
        runCodeTerrain = poolTerrains.listSceneTerrain[indexScenesNow].listTerrain.Count - 1;
        pointCodeTerrain = 0;
        listCodeTerrain = "";
        //thuc hien create terrain moi
        for (int i = 0; i < maxShowTerrainBack; i++)
            AddNewTerrain(false);
        //tang toc do speed chay ve dau
        Invoke("UpdateSpeedBack", Modules.timeShowChest);
        //Modules.FreeMemoryNow();
    }

    public void SetTempleScene()
    {
        Modules.panelFakeCity.SetActive(false);
        Modules.panelFakeTemple.SetActive(true);
        SetSkyBox(Modules.skyTemple);
        RenderSettings.fogColor = Modules.colorFogTemple;
        Modules.distanceFogTempleX = Modules.distanceFoxMaxX;
        Modules.distanceFogTempleY = Modules.distanceFoxMaxY;
        Camera.main.GetComponent<ChangeHeightFog>().ResetValue();
        maxShowTerrainFront = originMaxShowFront;
        maxShowTerrainBack = originMaxShowBack;
        Modules.speedTempleRunBefore = Modules.speedGame;
        Modules.speedGame = Modules.speedTempleRun;
        runFront = 1;
        //xoa het cac terrain cu
        foreach (GameObject go in listShowTerrain)
            go.SetActive(false);
        listShowTerrain = new List<GameObject>();
        oldIndexScenesNow = indexScenesNow;
        int indexRan = Random.Range(0, listIndexScenesTemple.Count);
        indexScenesNow = listIndexScenesTemple[indexRan];
        runCodeTerrain = 0;
        pointCodeTerrain = 0;
        listCodeTerrain = "";
        //thuc hien create terrain moi
        for (int i = 0; i < maxShowTerrainFront; i++)
            AddNewTerrain(false);
        //Modules.FreeMemoryNow();
    }

    void UpdateSpeedBack()
    {
        Modules.speedGame += 0.75f;
        if (Modules.speedGame < 10f)
            Invoke("UpdateSpeedBack", 0.25f);
    }

    void UpdateSpeedMap()
    {
        if (Modules.statusGame != StatusGame.play)
        {
            Invoke("UpdateSpeedMap", timeChangeSpeed);
            return;
        }
        //xu ly gia tang speed
        if (Modules.speedGame > Modules.maxSpeedGame)
            Modules.speedGame = Modules.maxSpeedGame;
        else
        {
            Modules.speedGame += stepSpeedMove;
            Invoke("UpdateSpeedMap", timeChangeSpeed);
        }
    }

    IEnumerator LoadImage(string url)
    {
#if UNITY_WEBGL
        url = url.Replace(Modules.linkOldWGL, Modules.linkNewWGL);
#endif
        if (Time.time - oldTimeLoad < 0.2f) yield break;
        oldTimeLoad = Time.time;
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

    //private IEnumerator coroutine;
    //void OnDisable()
    //{
    //    if (coroutine != null)
    //        StopCoroutine(coroutine);
    //}

    private float pointFirst = 0;
    private float distanEffect = 3f;
    private float speedEffect = 0.25f;
    private int indexMarkPoint = 0;
    void LateUpdate()
    {
        if (Modules.statusGame == StatusGame.over && !Modules.runGameOverEffect)
        {
            if (!Modules.getPointFirst)
            {
                Modules.getPointFirst = true;
                pointFirst = listShowTerrain[0].transform.position.z;
            }
            foreach (GameObject go in listShowTerrain)
                go.transform.Translate(Vector3.forward * speedEffect);
            if (listShowTerrain[0].transform.position.z > pointFirst + distanEffect)//ket thuc hieu ung
                Modules.runGameOverEffect = true;
        }
        if (Modules.statusGame != StatusGame.play && Modules.statusGame != StatusGame.bonusEffect) return;
        if (Modules.panelBGEffectBonus.activeSelf && !Modules.runAffterDownBonus) return;
        if (listShowTerrain.Count <= 0) return;
        //xu ly crossroads
        if (Modules.runCrossroads)
        {
            if (Modules.moveCrossroads)//neu giai doan 1 di chuyen ve toa do goc
            {
                float step = Modules.speedCrossroads / 5f * Time.deltaTime;
                Modules.terrainCrossroads.transform.position = Vector3.MoveTowards(Modules.terrainCrossroads.transform.position, Vector3.zero, step);
                if (Vector3.Distance(Modules.terrainCrossroads.transform.position, Vector3.zero) <= 0.15f)
                {
                    Modules.terrainCrossroads.transform.position = Vector3.zero;
                    //thuc hien can chinh lai cac dia hinh phia sau
                    foreach (GameObject go in listShowTerrain)
                    {
                        if (go != Modules.terrainCrossroads.gameObject)
                            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z - Modules.detalTerrain);
                    }
                    Modules.moveCrossroads = false;
                }
            }
            else//giai doan 2 xoay
            {
                float step = Modules.speedCrossroads * Time.deltaTime;
                if (Modules.leftCrossroads)
                {
                    Modules.rotateCrossroads.transform.Rotate(Vector3.up, step);
                    float angle = Modules.rotateCrossroads.transform.eulerAngles.y;
                    if (angle >= 90)
                    {
                        Modules.rotateCrossroads.transform.eulerAngles = new Vector3(0, 90, 0);
                        Modules.runCrossroads = false;
                    }
                }
                else
                {
                    Modules.rotateCrossroads.transform.Rotate(Vector3.up, -step);
                    float angle = Modules.rotateCrossroads.transform.eulerAngles.y;
                    if (angle == 0) angle = 360;
                    if (angle <= 270)
                    {
                        Modules.rotateCrossroads.transform.eulerAngles = new Vector3(0, 270, 0);
                        Modules.runCrossroads = false;
                    }
                }
            }
            return;
        }
        //xu ly terrain
        //float deltaTime = Time.deltaTime;
        //if (deltaTime > Time.fixedDeltaTime) deltaTime = Time.fixedDeltaTime;
        Modules.speedGameNow = Modules.speedGame;
        if (runFront > 0)
        {
            float speedHero = 0;
            float speedSkis = 0;
            float speedJetpack = 0;
            float speedBoatUp = 0;
            float speedSneakerJump = 0;
            float speedBlueArrow = 0;
            float speedSkisFixed = 0;
            if (Modules.useSkis) speedSkisFixed = 0.18f * Modules.speedGameNow;
            speedHero = Modules.speedPercentHero * Modules.speedGameNow;
            speedSkis = Modules.speedPercentSkis * Modules.speedGameNow + speedSkisFixed;
            speedJetpack = Modules.speedPercentJetpack * Modules.speedGameNow;
            speedBoatUp = Modules.speedBoatUp * Modules.speedGameNow;
            speedSneakerJump = Modules.speedSneakerJump * Modules.speedGameNow;
            speedBlueArrow = Modules.speedBuleArrow * Modules.speedGameNow;
            Modules.speedGameNow += speedHero + speedSkis + speedJetpack + speedBoatUp + speedSneakerJump + speedBlueArrow;
            if (Modules.speedGameNow > Modules.maxSpeedGame) Modules.speedGameNow = Modules.maxSpeedGame;
        }
        float speedNow = numEditSpeed * Modules.speedGameNow * Modules.speedAddMoreUse * Time.deltaTime;// deltaTime;
        foreach (GameObject go in listShowTerrain)
            go.transform.Translate(Vector3.back * runFront * speedNow);
        bool checkRun = false;
        if (runFront > 0)
        {
            if (listShowTerrain[0].transform.position.z <= -listShowTerrain[0].GetComponent<TerrainInformation>().lengthTerrain / 2f - destanShowMore)
                checkRun = true;
        }
        else
        {
            if (listShowTerrain[listShowTerrain.Count - 1].transform.position.z >= -destanShowMore)
                checkRun = true;
        }
        if (checkRun)
        {
            listShowTerrain[0].SetActive(false);
            listShowTerrain.RemoveAt(0);
            AddNewTerrain(true);
        }
        //xu ly cong diem theo toc do chay cua map
        if (Modules.gameGuide == "YES" || runFront < 0) return;//neu dang huong dan hoac dang chay lui thi khong cong diem ky luc
        float pointAdd = pointBySpeed * Modules.xPointPlayer * speedNow;
        Modules.scorePlayer += pointAdd;
        //xu ly nang cap toc do toi da
        if (indexMarkPoint == 0 && Modules.scorePlayer >= 100000)
        {
            indexMarkPoint = 1;
            Modules.maxSpeedGame += Modules.maxSpeedGame * 0.1f;
        }
        else if (indexMarkPoint == 1 && Modules.scorePlayer >= 250000)
        {
            indexMarkPoint = 2;
            Modules.maxSpeedGame += Modules.maxSpeedGame * 0.1f;
        }
        else if (indexMarkPoint == 2 && Modules.scorePlayer >= 500000)
        {
            indexMarkPoint = 3;
            Modules.maxSpeedGame += Modules.maxSpeedGame * 0.05f;
        }
        TaskData.HandleTask(1, pointAdd, 1000);
        TaskData.HandleTask(8, pointAdd, 2000);
        TaskData.HandleTask(16, pointAdd, 6000);
        TaskData.HandleTask(47, pointAdd, 100000);
        TaskData.HandleTask(52, pointAdd, 50000);
        TaskData.HandleTask(58, pointAdd, 250000);
        TaskData.HandleTask(71, pointAdd, 500000);
        TaskData.HandleTask(78, pointAdd, 250000);
        TaskData.HandleTask(85, pointAdd, 50000);
        TaskData.HandleTask(109, pointAdd, 80000);
        TaskData.HandleTask(123, pointAdd, 50000);
        TaskData.HandleTask(140, pointAdd, 120000);
        TaskData.HandleTask(142, pointAdd, 500000);
        TaskData.HandleTask(148, pointAdd, 1500000);
        TaskData.HandleTask(157, pointAdd, 2000000);
        if (Modules.useBoat)
            TaskData.HandleTask(98, pointAdd, 60000);
        TaskData.countScoreNoDiamond += pointAdd;
        TaskData.HandleTaskStay(13, TaskData.countScoreNoDiamond, 500);
        TaskData.HandleTaskStay(36, TaskData.countScoreNoDiamond, 1000);
        TaskData.HandleTaskStay(72, TaskData.countScoreNoDiamond, 1500);
        TaskData.HandleTaskStay(81, TaskData.countScoreNoDiamond, 2000);
        TaskData.HandleTaskStay(111, TaskData.countScoreNoDiamond, 4000);
        TaskData.HandleTaskStay(143, TaskData.countScoreNoDiamond, 12000);
        TaskData.countScoreNoJump += pointAdd;
        TaskData.HandleTaskStay(82, TaskData.countScoreNoJump, 5000);
        TaskData.HandleTaskStay(102, TaskData.countScoreNoJump, 10000);
        TaskData.HandleTaskStay(134, TaskData.countScoreNoJump, 15000);
        TaskData.HandleTaskStay(158, TaskData.countScoreNoJump, 25000);
        TaskData.countScoreNoItem += pointAdd;
        TaskData.HandleTaskStay(153, TaskData.countScoreNoItem, 120000);
        //xu ly hieu ung text
        if (Modules.useBonus)
        {
            Modules.scoreBonusRoadRun += pointAdd;
            if (!Modules.mesBonusTextAwesome)
            {
                if (Modules.scoreBonusRoadRun >= Modules.scoreBonusTextAwesome)
                {
                    foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
                    GameObject effect = Instantiate(Modules.textAwesome[Modules.indexLanguage], Modules.parentTextEffect.transform);
                    effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
                    Modules.mesBonusTextAwesome = true;
                }
            }
            else if (!Modules.mesBonusTextPerfect)
            {
                if (Modules.scoreBonusRoadRun >= Modules.scoreBonusTextPerfect)
                {
                    foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
                    GameObject effect = Instantiate(Modules.textPerfect[Modules.indexLanguage], Modules.parentTextEffect.transform);
                    effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
                    Modules.mesBonusTextPerfect = true;
                }
            }
        }
        else
        {
            if (!Modules.mesNormalTextGood)
            {
                if (Modules.scorePlayer >= Modules.scoreNormalTextGood)
                {
                    foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
                    GameObject effect = Instantiate(Modules.textGood[Modules.indexLanguage], Modules.parentTextEffect.transform);
                    effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
                    Modules.mesNormalTextGood = true;
                }
            }
            else if (!Modules.mesNormalTextAwesome)
            {
                if (Modules.scorePlayer >= Modules.scoreNormalTextAwesome)
                {
                    foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
                    GameObject effect = Instantiate(Modules.textAwesome[Modules.indexLanguage], Modules.parentTextEffect.transform);
                    effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
                    Modules.mesNormalTextAwesome = true;
                }
            }
            else if (!Modules.mesNormalTextPerfect)
            {
                if (Modules.scorePlayer >= Modules.scoreNormalTextPerfect)
                {
                    foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
                    GameObject effect = Instantiate(Modules.textPerfect[Modules.indexLanguage], Modules.parentTextEffect.transform);
                    effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
                    Modules.mesNormalTextPerfect = true;
                }
            }
            else if (!Modules.mesNormalTextExellent)
            {
                if (Modules.scorePlayer >= Modules.scoreNormalTextExellent)
                {
                    foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
                    GameObject effect = Instantiate(Modules.textExcellent[Modules.indexLanguage], Modules.parentTextEffect.transform);
                    effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
                    Modules.mesNormalTextExellent = true;
                }
            }
        }
        string scoreShow = Mathf.RoundToInt(Modules.scorePlayer).ToString();
        string numberZero = "";
        for (int i = scoreShow.Length; i < 8; i++) numberZero += "0";
        Modules.textScorePlay.text = numberZero + scoreShow;
        //xu ly avatar top
        if (Modules.scorePlayer > Modules.scoreTop)
        {
            if (!changeScoreTop)
            {
                StartCoroutine(Modules.LoadImageTop(Modules.fbLinkAvatar));
                string dataCountry = SaveLoadData.LoadData("CodeCountry", true);
                if (dataCountry == "") dataCountry = "Null";
                Modules.flagTop.sprite = Modules.GetIconFlag(dataCountry);
                changeScoreTop = true;
                if (Modules.scoreTop > 0) Modules.winRunning = 4;//world
                Modules.textWorldScore.transform.parent.gameObject.SetActive(false);
            }
        }
        else
        {
            int leftScore = Mathf.RoundToInt(Modules.scoreTop - Modules.scorePlayer);
            if (leftScore >= 0)
                Modules.textWorldScore.text = leftScore.ToString();
        }
        //xu ly chay lui diem ky luc hien tai
        if (!Modules.panelHighScoreNow.activeSelf) return;
        if (Modules.fbHighFriend.Count > 0)
        {
            if (Modules.scorePlayer >= Modules.fbHighFriend[Modules.fbHighFriend.Count - 1])
            {
                Modules.fbHighFriend.RemoveAt(Modules.fbHighFriend.Count - 1);
                TaskData.HandleTask(80, 1, 1);
                TaskData.HandleTask(105, 1, 2);
            }
        }
        if (Modules.fbHighScore.Count > 0)//co the la top friend hoac top country
        {
            if (Modules.scorePlayer >= Modules.totalScoreNow)
            {
                Transform tranAvatar = Modules.panelHighScoreNow.transform.Find("Avatar");
                Transform tranName = Modules.panelHighScoreNow.transform.Find("TextHighScore");
                Image fbAvatar = tranAvatar.GetComponent<Image>();
                Text fbName = tranName.GetComponent<Text>();
                CreateEffectAvatar(fbAvatar.sprite, fbName.text);
                if (Modules.fbHighScore.Count > 1)
                {
                    fbAvatar.sprite = Modules.iconAvatarNull;
                    StartCoroutine(LoadImage(Modules.fbAvatarEnemy[Modules.fbAvatarEnemy.Count - 2]));
                    fbName.text = Modules.fbNameEnemy[Modules.fbNameEnemy.Count - 2].ToUpper();
                    Modules.totalScoreNow = Modules.fbHighScore[Modules.fbHighScore.Count - 2];
                }
                else
                {
                    Modules.panelHighScoreNow.SetActive(false);
                    if (Modules.countryEnemy == 1)
                        Modules.winRunning = 3;//country
                    else Modules.winRunning = 2;//friends
                }
                Modules.fbAvatarEnemy.RemoveAt(Modules.fbAvatarEnemy.Count - 1);
                Modules.fbNameEnemy.RemoveAt(Modules.fbNameEnemy.Count - 1);
                Modules.fbHighScore.RemoveAt(Modules.fbHighScore.Count - 1);
            }
            else
            {
                Modules.textHighScore.text = Mathf.RoundToInt(Modules.totalScoreNow - Modules.scorePlayer).ToString();
            }
        }
        else
        {
            if (Modules.scorePlayer >= Modules.totalScoreNow)
            {
                Transform tranAvatar = Modules.panelHighScoreNow.transform.Find("Avatar");
                Image fbAvatar = tranAvatar.GetComponent<Image>();
                CreateEffectAvatar(fbAvatar.sprite, AllLanguages.playHighScore[Modules.indexLanguage]);
                Modules.panelHighScoreNow.SetActive(false);
                Modules.winRunning = 1;//myself (for offline)
            }
            else
            {
                Modules.textHighScore.text = Mathf.RoundToInt(Modules.totalScoreNow - Modules.scorePlayer).ToString();
            }
        }
    }

    private bool changeScoreTop = false;
    private float oldTimeEffect = 0;
    private float oldTimeLoad = -0.2f;
    void CreateEffectAvatar(Sprite newSprite, string newName)
    {
        if (Time.time - oldTimeEffect < 0.2f) return;
        oldTimeEffect = Time.time;
        GameObject effectA = Instantiate(effectAvatar, Vector3.zero, Quaternion.identity) as GameObject;
        effectA.transform.SetParent(containEffectAvatar.transform, false);
        Transform tranAE = effectA.transform.Find("Avatar");
        Transform tranNE = effectA.transform.Find("TextHighScore");
        Image fbAE = tranAE.GetComponent<Image>();
        Text fbNE = tranNE.GetComponent<Text>();
        fbAE.sprite = newSprite;
        fbNE.text = newName;
        Destroy(effectA, 1f);
    }

    void AddNewTerrain(bool handleSafe)
    {
        if (runCodeTerrain >= poolTerrains.listSceneTerrain[indexScenesNow].listTerrain.Count)
        {
            if (Modules.useBonus || Modules.useTemple) return;
            else runCodeTerrain = 0;
        }
        else if (runCodeTerrain < 0)
        {
            runCodeTerrain = listShowTerrain.Count;
            listShowTerrain.Reverse();
            CancelInvoke("UpdateSpeedBack");
            Modules.speedGame = oldSpeedGame;
            Modules.startBonusRoad = true;
            //xu ly hieu ung UI va toc do o day
            runFront = 1;
            AddNewTerrain(handleSafe);
            //Modules.ShowMessageBonusRoad(2);
            foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
            GameObject effect = Instantiate(Modules.textRoadBonus[Modules.indexLanguage], Modules.parentTextEffect.transform);
            effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
            return;
        }
        if (Modules.gameGuide == "YES")//neu dang huong dan
            if (runCodeTerrain >= maxShowTerrainFront) runCodeTerrain = 0;
        //thuc hien them moi terrain
        float pointZCreate = pointCodeTerrain;
        int indexType = indexScenesNow;
        int indexTerr = runCodeTerrain;
        if (runFront > 0)//chi thuc hien random terrain khi chay xuoi duong
        {
            int index = -1;
            List<string> codeTerRan = poolTerrains.listUseTerrain[indexType].listTerrain[indexTerr].GetComponent<TerrainInformation>().listTerrainRan;
            if (listCodeTerrain != "")//chi dinh index neu nhu co list code save
            {
                string[] codeTer = listCodeTerrain.Split(';');
                if (codeTerRan != null && codeTerRan.Count > 0)
                {
                    int indexTemp = codeTerRan.IndexOf(codeTer[0]);
                    if (indexTemp >= 0 && indexTemp < codeTerRan.Count) index = indexTemp;
                }
                listCodeTerrain = "";
                for (int i = 1; i < codeTer.Length; i++)
                {
                    listCodeTerrain += codeTer[i];
                    if (i < codeTer.Length - 1) listCodeTerrain += ";";
                }
            }
            else//thuc hien ngau nhien dia hinh
            {
                int ran = Random.Range(0, 100);
                if (ran < poolTerrains.listUseTerrain[indexType].listTerrain[indexTerr].GetComponent<TerrainInformation>().percentRan)
                {
                    if (codeTerRan != null && codeTerRan.Count > 0)
                        index = Random.Range(0, codeTerRan.Count);
                }
            }
            if (codeTerRan != null && codeTerRan.Count > 0 && index > -1)
            {
                bool findStart = false;
                for (int i = 0; i < indexTerr; i++)
                {
                    if (poolTerrains.listUseTerrain[indexType].listTerrain[i].GetComponent<TerrainInformation>().codeTerrain == codeTerRan[index])
                    {
                        if (!poolTerrains.listUseTerrain[indexType].listTerrain[i].activeSelf)
                        {
                            indexTerr = i;
                            findStart = true;
                            break;
                        }
                    }
                }
                if (!findStart)
                {
                    for (int i = indexTerr + maxShowTerrainFront; i < poolTerrains.listUseTerrain[indexType].listTerrain.Count; i++)
                    {
                        if (poolTerrains.listUseTerrain[indexType].listTerrain[i].GetComponent<TerrainInformation>().codeTerrain == codeTerRan[index])
                        {
                            if (!poolTerrains.listUseTerrain[indexType].listTerrain[i].activeSelf)
                            {
                                indexTerr = i;
                                break;
                            }
                        }
                    }
                }
            }
        }
        GameObject terrainNew = poolTerrains.listUseTerrain[indexType].listTerrain[indexTerr];
        if (listShowTerrain.Count > 0)
        {
            pointZCreate = listShowTerrain[listShowTerrain.Count - 1].transform.position.z
               + runFront * 0.5f * listShowTerrain[listShowTerrain.Count - 1].GetComponent<TerrainInformation>().lengthTerrain
               + runFront * 0.5f * terrainNew.GetComponent<TerrainInformation>().lengthTerrain;
        }
        terrainNew.transform.position = new Vector3(0, 0, pointZCreate);
        terrainNew.SetActive(true);
        TerrainInformation terrInfo = terrainNew.GetComponent<TerrainInformation>();
        if (Modules.reducedEffect > 0)
        {
            if (fakeFogWater.activeSelf)
                fakeFogWater.SetActive(false);
        }
        else
        {
            if (terrInfo.fakeFogWater)
            {
                fakeFogWater.transform.position = new Vector3(fakeFogWater.transform.position.x, terrInfo.highFogWater, fakeFogWater.transform.position.z);
                fakeFogWater.SetActive(true);
                checkFakeWaterBefore = true;
            }
            else
            {
                if (checkFakeWaterBefore)
                    checkFakeWaterBefore = false;
                else
                    fakeFogWater.SetActive(false);
            }
        }
        terrInfo.Restart(handleSafe);
        listShowTerrain.Add(terrainNew);
        Modules.waterTerrain = terrInfo.isWaterTerrain;
        if (runFront > 0) runCodeTerrain++;
        else runCodeTerrain--;
    }
    bool checkFakeWaterBefore = false;
}
