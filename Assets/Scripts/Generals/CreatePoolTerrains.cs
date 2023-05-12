using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreatePoolTerrains : MonoBehaviour {

    public List<string> listNameTerrain = new List<string>();
    public List<GameObject> listTypeTerrain = new List<GameObject>();
    public List<ListCodeTerrain> listSceneTerrain = new List<ListCodeTerrain>();
    public List<ListUseTerrain> listUseTerrain = new List<ListUseTerrain>();
    private int totalObject = 0;
    private int runTime = 0;
    private bool mesStart = false;
    private int indexI = 0, indexJ = 0;
    private List<GameObject> listTerrainNow = new List<GameObject>();
    private int indexLoad = 0;//0 load online, 1 install
    private float processLoad = 0;
    public bool useLocalAsset = true;

    void Awake()
    {
        DontDestroyOnLoad(transform);
        //thiet lap du lieu load
        indexLoad = 0;//0 load online, 1 install
    }

    public void StartLoading()
    {
        if (useLocalAsset)
        {
            CallStart();
        }
        else
        {
            StartCoroutine(CheckVersionAsset(CallBack));
        }
    }

    void CallBack(int version)
    {
        print(version);
        int oldVersion = PlayerPrefs.GetInt("AssetVersion", 0);
        if (oldVersion != version)
        {
            Caching.ClearCache();
            PlayerPrefs.SetInt("AssetVersion", version);
            PlayerPrefs.Save();
        }
        StartLoadOnline();
    }

    private IEnumerator CheckVersionAsset(System.Action<int> callBack)
    {
        WWW _resuilt = new WWW(Modules.linkVersionData);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        int version = 0;
        print(_resuilt.text);
        if (_resuilt.text != "")
        { //hoan thanh
            if (_resuilt.text.Contains("version"))
            {
                string number = _resuilt.text.Replace("version: ", "");
                version = int.Parse(number);
            }
        }
        callBack(version);
        yield break;
    }

    public void CallStart()
    {
        indexLoad = 1;
        //load du lieu tu resource
        if (!useLocalAsset)
        {
            listTypeTerrain = new List<GameObject>();
            for (int i = 0; i < listNameTerrain.Count; i++)
            {
                GameObject myTerrain = null;
                string terrain = "Assets/ResourcesOnline/TerrainsData/Prefabs/" + listNameTerrain[i] + ".prefab";
                myTerrain = Modules.myAsset.LoadAsset(terrain, typeof(GameObject)) as GameObject;
                //string terrain = "TerrainsData/Prefabs/" + listNameTerrain[i];
                //myTerrain = Resources.Load(terrain) as GameObject;
                listTypeTerrain.Add(myTerrain);
            }
        }
        //thuc hien cai dat dia hinh san sang
        indexI = 0;
        indexJ = 0;
        runTime = 0;
        totalObject = 0;
        listTerrainNow = new List<GameObject>();
        for (int i = 0; i < listSceneTerrain.Count; i++)
            totalObject += listSceneTerrain[i].listTerrain.Count;
        mesStart = true;
    }

    public int GetIndexLoad()
    {
        return indexLoad;
    }

    public float GetPercent()
    {
        if (indexLoad == 0) return processLoad;
        else return (float)runTime / (float)totalObject;
    }

    void FixedUpdate()
    {
        if (!mesStart || runTime >= totalObject || listTypeTerrain.Count <= 0) return;
        GameObject terrainNow = null;
        for (int i = 0; i < listTypeTerrain.Count; i++)
        {
            if (listTypeTerrain[i].GetComponent<TerrainInformation>().codeTerrain == listSceneTerrain[indexI].listTerrain[indexJ])
            {
                terrainNow = Instantiate(listTypeTerrain[i], transform) as GameObject;
                terrainNow.GetComponent<TerrainInformation>().GetStart();
                terrainNow.SetActive(false);
                break;
            }
        }
        listTerrainNow.Add(terrainNow);
        runTime++;
        indexJ++;
        if (indexJ >= listSceneTerrain[indexI].listTerrain.Count)
        {
            listUseTerrain.Add(new ListUseTerrain(listTerrainNow));
            indexJ = 0;
            indexI++;
            listTerrainNow = new List<GameObject>();
        }
    }

    public void StartLoadOnline()
    {
        LoadBundle((process) =>
        {
            //print(process);
            processLoad = process - 0.1f;
        });
    }

    public void LoadBundle(System.Action<float> callProcess = null)
    {
        if (Modules.myAsset == null)
            StartCoroutine(IELoadBundle(callProcess));
        else
            if (callProcess != null) callProcess(1.1f);
    }

    IEnumerator IELoadBundle(System.Action<float> callProcess = null)
    {
        while (!Caching.ready)
            yield return null;
        string platform = "StandaloneWindows/";
#if UNITY_ANDROID && !UNITY_EDITOR
        platform = "Android/";
#elif UNITY_IOS && !UNITY_EDITOR
        platform = "IOS/";
#endif
        var www = WWW.LoadFromCacheOrDownload(Modules.linkLoadData + platform + "terrainsdata", 0);
        while (!www.isDone)
        {
            if (callProcess != null) callProcess(www.progress);
            yield return new WaitForSeconds(0.5f);
        }

        yield return www;
        if (!string.IsNullOrEmpty(www.error))
            yield break;
        Modules.myAsset = www.assetBundle;
        if (callProcess != null) callProcess(1.1f);
    }
}
