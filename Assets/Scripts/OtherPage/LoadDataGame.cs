using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadDataGame : MonoBehaviour {

    public GameObject listResources;
    public Sprite iconAvatarNull;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        Time.timeScale = 1;
        Modules.totalUseGame = PlayerPrefs.GetInt("SaveTotalUseGame", 0);
        Modules.iconAvatarNull = iconAvatarNull;
        if (Modules.totalUseGame == 0)//neu la lan dau tien thi thiet lap thoi gian
        {
            Modules.SaveNewDateTime("GetSkis");
            Modules.SaveNewDateTime("GetKey");
        }
        Modules.totalUseGame++;
        if (Modules.totalUseGame > 1000) Modules.totalUseGame = 1000;
        PlayerPrefs.SetInt("SaveTotalUseGame", Modules.totalUseGame);
        PlayerPrefs.Save();
        Modules.LoadDataSave();
        Modules.listResources = listResources;
    }
}
