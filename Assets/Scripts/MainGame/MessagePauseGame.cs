using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessagePauseGame : MonoBehaviour {

    public GameObject countTimeResume;
    public GameObject effectCount;
    //xu ly ngon ngu
    public Text textSetting, textGoHome;

    public void UpdateLanguages()
    {
        int iLang = Modules.indexLanguage;
        textSetting.font = AllLanguages.listFontLangA[iLang];
        textSetting.text = AllLanguages.playSetting[iLang];
        textGoHome.font = AllLanguages.listFontLangA[iLang];
        textGoHome.text = AllLanguages.playGoHome[iLang];
    }
    public void ShowMessageBox()
    {
        UpdateLanguages();
        Time.timeScale = 0;
        Modules.StopAudioClipLoop(Modules.containMainGame.transform);
    }
    public void ButtonCloseClick()
    {
        transform.gameObject.GetComponent<Animator>().SetTrigger("TriClose");
        countTimeResume.SetActive(true);
        MessageTimeCount mesCountTime = countTimeResume.GetComponent<MessageTimeCount>();
        mesCountTime.effectTimeShow = effectCount;
        mesCountTime.StartCount();
        Modules.PlayAudioClipFree(Modules.audioButton);
        //Modules.FreeMemoryNow();
    }

    public void ButtonHomeClick()
    {
        Modules.CheckShowAds();
		Time.timeScale = 1;
        Modules.UpdateIndexRunTerrain();
		if (Modules.scorePlayer > Modules.totalScore)
		{
			Modules.totalScore = Modules.scorePlayer;
			Modules.SaveScore();
		}
        Modules.totalCoin += Modules.coinPlayer;
        Modules.SaveCoin();
        transform.gameObject.SetActive(false);
        Modules.autoTapPlay = false;
        Camera.main.GetComponent<PageMainGame>().UpdateScoreNow();
        Camera.main.GetComponent<PageMainGame>().ResetGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (transform.gameObject.activeSelf) ButtonCloseClick();
        }
    }
}
