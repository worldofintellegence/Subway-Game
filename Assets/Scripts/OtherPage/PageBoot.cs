using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PageBoot : MonoBehaviour {

    public string nameSceneLoad = "LoadData";
    public GameObject contentSplash, contentShow, contentLoad;
    public float timeSplash = 2f;
    public RawImage mySplashImage;
    public Text textContent, textLoading, textButNext;
    public List<Font> listFontLangA = new List<Font>();
    public List<Font> listFontLangB = new List<Font>();
    public bool showVideo = false;

    void Start()
    {
#if (UNITY_IOS || UNITY_ANDROID)
        if (Screen.width > 720 && Screen.height > 720)
        {
            float percent = 0.5f;
            Screen.SetResolution(Mathf.RoundToInt(Screen.width * percent), Mathf.RoundToInt(Screen.height * percent), true);
        }
#endif
        if (showVideo)
        {
            string dataSaveVolumeBG = PlayerPrefs.GetString("SaveSetVolumeBG", "");
            if (dataSaveVolumeBG == "0")
                transform.GetComponent<VideoPlayer>().audioOutputMode = VideoAudioOutputMode.None;
            contentSplash.SetActive(true);
            mySplashImage.color = new Color(1, 1, 1, 1);
            transform.GetComponent<VideoPlayer>().frame = 0;
            transform.GetComponent<VideoPlayer>().Play();
            Invoke("RunExtraContent", timeSplash);
        }
        else RunExtraContent();
    }

    void RunExtraContent()
    {
        contentSplash.SetActive(false);
        int iLang = 0;
        string codeLang = GetCountryPlayer.ToCountryCode(Application.systemLanguage);
        string dataSaveLang = PlayerPrefs.GetString("SaveSetLanguage", "");
        if (dataSaveLang != "") codeLang = dataSaveLang;
        if (AllLanguages.listLangShort.Contains(codeLang))
        {
            int indexLangTemp = AllLanguages.listLangShort.IndexOf(codeLang);
            if (AllLanguages.listSupport[indexLangTemp])
            {
                iLang = indexLangTemp;
            }
        }
        textContent.font = listFontLangB[iLang];
        textContent.text = AllLanguages.notifiPermission[iLang];
        textButNext.font = listFontLangA[iLang];
        textButNext.text = AllLanguages.notifiButNext[iLang];
        textLoading.font = listFontLangB[iLang];
        textLoading.text = AllLanguages.menuWaitMoment[iLang];
#if UNITY_ANDROID && !UNITY_EDITOR
        int bootGame = PlayerPrefs.GetInt("SaveBootGame", 0);
        if (bootGame == 0)//lan dau tien
        {
            contentShow.SetActive(true);
            contentLoad.SetActive(false);
        }
        else//neu da boot roi thi tu dong chuyen trang
        {
            contentShow.SetActive(false);
            contentLoad.SetActive(true);
            NextPageClick();
        }
#else
        contentShow.SetActive(false);
        contentLoad.SetActive(true);
        NextPageClick();
#endif
    }

    private const string STORAGE_PERMISSION = "android.permission.READ_EXTERNAL_STORAGE";
    private const string LOCATION_PERMISSION = "android.permission.ACCESS_FINE_LOCATION";
    private const string STATE_PERMISSION = "android.permission.READ_PHONE_STATE";
    private List<string> listPermission = new List<string>();
    private int timePermission = 0;
    private int countPermission = 0;
    private int totalPermission = 0;
  /*  void RequestPermissions()
    {
        if (!AndroidPermissionsManager.IsPermissionGranted(STORAGE_PERMISSION))
            listPermission.Add(STORAGE_PERMISSION);
        if (!AndroidPermissionsManager.IsPermissionGranted(LOCATION_PERMISSION))
            listPermission.Add(LOCATION_PERMISSION);
        if (!AndroidPermissionsManager.IsPermissionGranted(STATE_PERMISSION))
            listPermission.Add(STATE_PERMISSION);
        totalPermission = listPermission.Count;
        if (totalPermission > 0)
        {
            string[] arrayPermis = listPermission.ToArray();
            AndroidPermissionsManager.RequestPermission(arrayPermis, new AndroidPermissionCallback(
                grantedPermission =>//cap quyen
                {
                    timePermission++;
                    countPermission++;
                    CheckPermissionDone();
                },
                deniedPermission =>//huy quyen
                {
                    timePermission++;
                    CheckPermissionDone();
                }));
        }
        else
        {
            PlayerPrefs.SetInt("SaveBootGame", 1);
            PlayerPrefs.Save();
            contentLoad.SetActive(true);
            NextPageClick();
        }
    }

    private void CheckPermissionDone()
    {
        if (timePermission >= totalPermission)//neu hoan thanh click
        {
            if (countPermission >= timePermission)//neu dong y het
            {
                PlayerPrefs.SetInt("SaveBootGame", 1);
                PlayerPrefs.Save();
            }
            contentLoad.SetActive(true);
            NextPageClick();
        }
    }*/

    public void NextButtonClick()
    {
        contentShow.SetActive(false);
      //  RequestPermissions();
    }

    void NextPageClick()
    {
        SceneManager.LoadSceneAsync(nameSceneLoad, LoadSceneMode.Single);
    }
}
