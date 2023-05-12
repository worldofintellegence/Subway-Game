using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBuyItem : MonoBehaviour {

    public int codeItem = 0;//0 coin, 1 key, 2 skis, 3 mystery, 4 headStart, 5 scoreBooster
    public Text textCost, textNote, textCoin;
    public Color colorNotCoin = Color.red;
    private Color originColorNote = Color.white;

    void Start()
    {
        originColorNote = textNote.color;
    }

    public void ButtonClick()
    {
        textNote.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        bool playAudioCoin = false;
        if (codeItem == 0)//coin (xu ly in app purchase)
        {
            //print("Buy coin");
            //Purchaser.Instance.BuyProductID(Modules.listProductID[0]);
        }
        else if (codeItem == 1)//key (xu ly in app purchase)
        {
            //print("Buy key");
            //Purchaser.Instance.BuyProductID(Modules.listProductID[1]);
        }
        else if (codeItem == 2)//neu la skis
        {
            int cost = Modules.IntParseFast(textCost.text);
            if (Modules.totalCoin >= cost)//neu du tien
            {
                if (Modules.totalSkis < Modules.maxHoverboard)
                {
                    playAudioCoin = true;
                    TaskData.HandleTask(53, cost, 50000);
                    TaskData.HandleTask(64, cost, 80000);
                    TaskData.HandleTask(94, cost, 2000000);
                    TaskData.HandleTask(124, cost, 400000);
                    TaskData.HandleTask(135, cost, 800000);
                    TaskData.HandleTask(156, cost, 900000);
                    Modules.totalSkis++;
                    Modules.totalCoin -= cost;
                    Modules.SaveCoin();
                    textCoin.text = Modules.totalCoin.ToString();
                    Modules.SaveSkis();
                    textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalSkis.ToString();
                }
                else
                {
                    textNote.text = AllLanguages.shopMaxNumber[Modules.indexLanguage];
                    textNote.color = colorNotCoin;
                    Invoke("ReturnValueTotal", 1f);
                }
            }
            else//neu khong du tien
            {
                textNote.text = AllLanguages.shopNotEnough[Modules.indexLanguage];
                textNote.color = colorNotCoin;
                Invoke("ReturnValueTotal", 1f);
            }
        }
        else if (codeItem == 3)//neu la mystery
        {
            int cost = Modules.IntParseFast(textCost.text);
            if (Modules.totalCoin >= cost)//neu du tien
            {
                playAudioCoin = true;
                TaskData.HandleTask(20, 1, 1);
                TaskData.HandleTask(53, cost, 50000);
                TaskData.HandleTask(61, 1, 3);
                TaskData.HandleTask(64, cost, 80000);
                TaskData.HandleTask(94, cost, 2000000);
                TaskData.HandleTask(124, cost, 400000);
                TaskData.HandleTask(135, cost, 800000);
                TaskData.HandleTask(156, cost, 900000);
                TaskData.HandleTask(73, 1, 6);
                TaskData.HandleTask(131, 1, 3);
                TaskData.HandleTask(145, 1, 6);
                Modules.totalCoin -= cost;
                Modules.SaveCoin();
                textCoin.text = Modules.totalCoin.ToString();
                Modules.totalMysteryBox += 1;
                Modules.nextPageOpenBox = "ShopItems";
                Modules.containShopItem.SetActive(false);
                Modules.containOpenBox.SetActive(true);
                Modules.containOpenBox.transform.Find("MainCamera").GetComponent<PageOpenMysteryBox>().CallStart();
            }
            else//neu khong du tien
            {
                textNote.text = AllLanguages.shopNotEnough[Modules.indexLanguage];
                textNote.color = colorNotCoin;
                Invoke("ReturnValueTotal", 1f);
            }
        }
        else if (codeItem == 4)//neu la headStart
        {
            int cost = Modules.IntParseFast(textCost.text);
            if (Modules.totalCoin >= cost)//neu du tien
            {
                if (Modules.totalHeadStart < Modules.maxHeadstart)
                {
                    playAudioCoin = true;
                    TaskData.HandleTask(53, cost, 50000);
                    TaskData.HandleTask(64, cost, 80000);
                    TaskData.HandleTask(94, cost, 2000000);
                    TaskData.HandleTask(124, cost, 400000);
                    TaskData.HandleTask(135, cost, 800000);
                    TaskData.HandleTask(156, cost, 900000);
                    Modules.totalHeadStart++;
                    Modules.totalCoin -= cost;
                    Modules.SaveCoin();
                    textCoin.text = Modules.totalCoin.ToString();
                    Modules.SaveHeadStart();
                    textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalHeadStart.ToString();
                }
                else
                {
                    textNote.text = AllLanguages.shopMaxNumber[Modules.indexLanguage];
                    textNote.color = colorNotCoin;
                    Invoke("ReturnValueTotal", 1f);
                }
            }
            else//neu khong du tien
            {
                textNote.text = AllLanguages.shopNotEnough[Modules.indexLanguage];
                textNote.color = colorNotCoin;
                Invoke("ReturnValueTotal", 1f);
            }
        }
        else if (codeItem == 5)//neu la scoreBooster
        {
            int cost = Modules.IntParseFast(textCost.text);
            if (Modules.totalCoin >= cost)//neu du tien
            {
                if (Modules.totalScoreBooster < Modules.maxScorebooster)
                {
                    playAudioCoin = true;
                    TaskData.HandleTask(53, cost, 50000);
                    TaskData.HandleTask(64, cost, 80000);
                    TaskData.HandleTask(94, cost, 2000000);
                    TaskData.HandleTask(124, cost, 400000);
                    TaskData.HandleTask(135, cost, 800000);
                    TaskData.HandleTask(156, cost, 900000);
                    Modules.totalScoreBooster++;
                    Modules.totalCoin -= cost;
                    Modules.SaveCoin();
                    textCoin.text = Modules.totalCoin.ToString();
                    Modules.SaveScoreBooster();
                    textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalScoreBooster.ToString();
                }
                else
                {
                    textNote.text = AllLanguages.shopMaxNumber[Modules.indexLanguage];
                    textNote.color = colorNotCoin;
                    Invoke("ReturnValueTotal", 1f);
                }
            }
            else//neu khong du tien
            {
                textNote.text = AllLanguages.shopNotEnough[Modules.indexLanguage];
                textNote.color = colorNotCoin;
                Invoke("ReturnValueTotal", 1f);
            }
        }
        else if (codeItem == 6)//neu la wheel spin
        {
            int cost = Modules.IntParseFast(textCost.text);
            if (Modules.totalCoin >= cost)//neu du tien
            {
                playAudioCoin = true;
                TaskData.HandleTask(53, cost, 50000);
                TaskData.HandleTask(64, cost, 80000);
                TaskData.HandleTask(94, cost, 2000000);
                TaskData.HandleTask(124, cost, 400000);
                TaskData.HandleTask(135, cost, 800000);
                TaskData.HandleTask(156, cost, 900000);
                TaskData.HandleTask(100, 1, 1);
                TaskData.HandleTask(144, 1, 20);
                Modules.totalCoin -= cost;
                Modules.SaveCoin();
                textCoin.text = Modules.totalCoin.ToString();
                Modules.totalWheelSpin += 1;
                textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalWheelSpin.ToString();
                Modules.SaveSpinWheel();
                //Modules.nextPageWheelSpin = "ShopItems";
                //Modules.containShopItem.SetActive(false);
                //Modules.containWheelSpin.SetActive(true);
                //Modules.containWheelSpin.transform.Find("MainCamera").GetComponent<PageSpinWheel>().CallStart();
            }
            else//neu khong du tien
            {
                textNote.text = AllLanguages.shopNotEnough[Modules.indexLanguage];
                textNote.color = colorNotCoin;
                Invoke("ReturnValueTotal", 1f);
            }
        }
        if (playAudioCoin) Modules.PlayAudioClipFree(Modules.audioBuyCoin);
        else Modules.PlayAudioClipFree(Modules.audioButton);
    }

    void ReturnValueTotal()
    {
        if (codeItem == 0)//coin (xu ly in app purchase)
            textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalCoin.ToString();
        else if (codeItem == 1)//key (xu ly in app purchase)
            textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalKey.ToString();
        else if (codeItem == 2)//neu la skis
            textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalSkis.ToString();
        else if (codeItem == 3)//neu la mystery
            textNote.text = AllLanguages.shopUseRight[Modules.indexLanguage];
        else if (codeItem == 4)//neu la headStart
            textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalHeadStart.ToString();
        else if (codeItem == 5)//neu la scoreBooster
            textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalScoreBooster.ToString();
        else if (codeItem == 6)//neu la wheel spin
            textNote.text = AllLanguages.shopTotal[Modules.indexLanguage] + " " + Modules.totalWheelSpin.ToString();
        textNote.color = originColorNote;
    }
}
