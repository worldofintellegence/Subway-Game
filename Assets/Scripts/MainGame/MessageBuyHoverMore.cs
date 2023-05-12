using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBuyHoverMore : MonoBehaviour {

    public GameObject countTimeResume;
    public GameObject effectCount;
    public GameObject buttonBuy;
    public Text totalSkis, totalCoins, playCoins;
    public Text textBuy, textCancel;
    public Image iconHover;
    private int allCoins = 0;//coins cua ca tong lan van dang choi

    public void StartShowMessage()
    {
        Time.timeScale = 0;
        int lang = Modules.indexLanguage;
        allCoins = Modules.coinPlayer + Modules.totalCoin;
        totalSkis.font = AllLanguages.listFontLangA[lang];
        totalSkis.text = AllLanguages.shopTotal[lang] + " " + Modules.totalSkis.ToString();
        totalCoins.text = allCoins.ToString();
        textBuy.font = AllLanguages.listFontLangA[lang];
        textBuy.text = AllLanguages.shopButtonBuy[lang];
        textCancel.font = AllLanguages.listFontLangA[lang];
        textCancel.text = AllLanguages.menuCancel[lang];
        iconHover.sprite = Modules.ChangeIconHoverboard();
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
        Modules.useSkisAfterBuy = true;
        //Modules.FreeMemoryNow();
    }

    public void ButtonBuy()
    {
        int cost = 300;
        if (allCoins >= cost)//neu du tien
        {
            if (Modules.totalSkis < Modules.maxHoverboard)
            {
                Modules.PlayAudioClipFree(Modules.audioBuyCoin);
                TaskData.HandleTask(53, cost, 50000);
                TaskData.HandleTask(64, cost, 80000);
                TaskData.HandleTask(94, cost, 2000000);
                TaskData.HandleTask(124, cost, 400000);
                TaskData.HandleTask(135, cost, 800000);
                TaskData.HandleTask(156, cost, 900000);
                Modules.totalSkis++;
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
                Modules.SaveSkis();
                totalSkis.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalSkis.ToString();
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
[System.Serializable]//de show ra phan input cua unity editor
public class IconHoverBuy
{
    public string code;
    public Sprite icon;
    public IconHoverBuy(string codeInput, Sprite imageInput)
    {
        this.code = codeInput;
        this.icon = imageInput;
    }
}