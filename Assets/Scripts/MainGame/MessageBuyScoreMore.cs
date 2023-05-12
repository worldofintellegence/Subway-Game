using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBuyScoreMore : MonoBehaviour {

    public GameObject countTimeResume;
    public GameObject effectCount;
    public GameObject buttonBuy;
    public Text totalScore, totalCoins, playCoins;
    public Text textBuy, textCancel;
    private int allCoins = 0;//coins cua ca tong lan van dang choi

    public void StartShowMessage()
    {
        Time.timeScale = 0;
        int lang = Modules.indexLanguage;
        allCoins = Modules.coinPlayer + Modules.totalCoin;
        totalScore.font = AllLanguages.listFontLangA[lang];
        totalScore.text = AllLanguages.shopTotal[lang] + " " + Modules.totalScoreBooster.ToString();
        totalCoins.text = allCoins.ToString();
        textBuy.font = AllLanguages.listFontLangA[lang];
        textBuy.text = AllLanguages.shopButtonBuy[lang];
        textCancel.font = AllLanguages.listFontLangA[lang];
        textCancel.text = AllLanguages.menuCancel[lang];
        buttonBuy.GetComponent<ButtonStatus>().Enable();
        Modules.StopAudioClipLoop(Modules.containMainGame.transform);
    }

    public void ButtonCancel()
    {
        transform.gameObject.GetComponent<Animator>().SetTrigger("TriClose");
        countTimeResume.SetActive(true);
        MessageTimeCount mesCountTime = countTimeResume.GetComponent<MessageTimeCount>();
        mesCountTime.effectTimeShow = effectCount;
        mesCountTime.StartCount();
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.reloadItemBuy = true;
        //Modules.FreeMemoryNow();
    }

    public void ButtonBuy()
    {
        int cost = 2000;
        if (allCoins >= cost)//neu du tien
        {
            if (Modules.totalScoreBooster < Modules.maxScorebooster)
            {
                Modules.PlayAudioClipFree(Modules.audioBuyCoin);
                TaskData.HandleTask(53, cost, 50000);
                TaskData.HandleTask(64, cost, 80000);
                TaskData.HandleTask(94, cost, 2000000);
                TaskData.HandleTask(124, cost, 400000);
                TaskData.HandleTask(135, cost, 800000);
                TaskData.HandleTask(156, cost, 900000);
                Modules.totalScoreBooster++;
                Modules.totalCoin -= cost;
                if (Modules.totalCoin < 0)
                {
                    Modules.coinPlayer += Modules.totalCoin;
                    Modules.totalCoin = 0;
                    if (Modules.coinPlayer < 0)
                        Modules.coinPlayer = 0;
                }
                allCoins = Modules.coinPlayer + Modules.totalCoin;
                Modules.SaveCoin();
                totalCoins.text = (Modules.coinPlayer + Modules.totalCoin).ToString();
                playCoins.text = Modules.coinPlayer.ToString();
                Modules.SaveScoreBooster();
                totalScore.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalScoreBooster.ToString();
            }
            else
            {
                textBuy.text = AllLanguages.shopMaxNumber[Modules.indexLanguage];
                buttonBuy.GetComponent<ButtonStatus>().Disable();
            }
        }
        else//neu khong du tien
        {
            textBuy.text = AllLanguages.heroNotEnough[Modules.indexLanguage];
            buttonBuy.GetComponent<ButtonStatus>().Disable();
        }
    }
}
