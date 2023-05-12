using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageScratchCard : MonoBehaviour {

    public Text textKey, textCoin, textBox, textStatus, textTitleItem, textNoteItem;
    public Text textTitleCard, textDateCard, textProgress, textDetailsCard, textQuickScratch;
    public GameObject butQuickScratch, meshSurfaceCard;
    public Image iconShow;
    public Text valueShow;
    public List<Sprite> listIconBonus = new List<Sprite>();
    public Animator myAniCard;
    public AudioClip audioShowCard;
    private bool isDone = false;
    private int indexBonus = 0;
    private int valueBonus = 0;

    public void CallStart()
    {
        //Modules.FreeMemoryNow();
        isDone = false;
        textKey.text = Mathf.RoundToInt(Modules.totalKey).ToString();
        textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        textBox.text = Mathf.RoundToInt(Modules.totalScratchCard - 1).ToString();
        textTitleItem.font = AllLanguages.listFontLangA[Modules.indexLanguage];
        textTitleItem.text = AllLanguages.otherTitleItemCard[Modules.indexLanguage];
        textNoteItem.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        textNoteItem.text = AllLanguages.otherNoteItemCard[Modules.indexLanguage];
        textTitleCard.font = AllLanguages.listFontLangA[Modules.indexLanguage];
        textTitleCard.text = AllLanguages.otherTitleCard[Modules.indexLanguage];
        textDetailsCard.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        textDetailsCard.text = AllLanguages.otherDetailsCard[Modules.indexLanguage];
        textDateCard.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        textDateCard.text = System.DateTime.Now.ToString("yyyy/MM/dd");
        textProgress.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        textProgress.text = AllLanguages.otherProgressCard[Modules.indexLanguage];// +": 0%";
        textQuickScratch.font = AllLanguages.listFontLangA[Modules.indexLanguage];
        textQuickScratch.text = AllLanguages.otherQuickScratch[Modules.indexLanguage];
        textStatus.font = AllLanguages.listFontLangA[Modules.indexLanguage];
        textStatus.text = AllLanguages.otherTapContinue[Modules.indexLanguage];
        textStatus.gameObject.SetActive(isDone);
        butQuickScratch.SetActive(true);
        meshSurfaceCard.SetActive(true);
        Modules.PlayAudioClipLoop(Modules.audioBGOpenBox, Camera.main.transform);
        transform.GetComponent<ScratchDemoUI>().Restart();
        myAniCard.SetTrigger("TriPlay");
        Modules.PlayAudioClipFree(audioShowCard);
        //xu ly ngau nhien cac phan thuong
        indexBonus = Random.Range(0, listIconBonus.Count);
        if (indexBonus == 0)//thuong hoverboard
        {
            valueBonus = Random.Range(15, 19);
        }
        else if (indexBonus == 1)//thuong key
        {
            valueBonus = Random.Range(5, 11);
        }
        else if (indexBonus == 2)//thuong spin wheel
        {
            valueBonus = Random.Range(1, 4);
        }
        else if (indexBonus == 3)//thuong scorebooster
        {
            valueBonus = Random.Range(3, 8);
        }
        else if (indexBonus == 4)//thuong 5000 diamonds
        {
            valueBonus = 5000;
        }
        else if (indexBonus == 5)//thuong 10000 diamonds
        {
            valueBonus = 10000;
        }
        else if (indexBonus == 6)//thuong 15000 diamonds
        {
            valueBonus = 15000;
        }
        valueShow.text = "x" + valueBonus.ToString();
        if (indexBonus == 0) iconShow.sprite = Modules.ChangeIconHoverboard();
        else iconShow.sprite = listIconBonus[indexBonus];
    }

    public void ButtonQuickScratch()
    {
        meshSurfaceCard.SetActive(false);
        HandleBonus();
    }

    public void HandleBonus()
    {
        if (isDone) return;
        isDone = true;
        textStatus.gameObject.SetActive(isDone);
        butQuickScratch.SetActive(false);
        Modules.totalScratchCard--;
        //xu ly khi nhan cac phan thuong
        if (indexBonus == 0)//thuong hoverboard
        {
            Modules.totalSkis += valueBonus;
            if (Modules.totalSkis > Modules.maxHoverboard)
                Modules.totalSkis = Modules.maxHoverboard;
            Modules.SaveSkis();
        }
        else if (indexBonus == 1)//thuong key
        {
            Modules.totalKey += valueBonus;
            textKey.text = Mathf.RoundToInt(Modules.totalKey).ToString();
            Modules.SaveKey();
        }
        else if (indexBonus == 2)//thuong spin wheel
        {
            Modules.totalWheelSpin += valueBonus;
            Modules.SaveSpinWheel();
        }
        else if (indexBonus == 3)//thuong scorebooster
        {
            Modules.totalScoreBooster += valueBonus;
            if (Modules.totalScoreBooster > Modules.maxScorebooster)
                Modules.totalScoreBooster = Modules.maxScorebooster;
            Modules.SaveScoreBooster();
        }
        else if (indexBonus <= 6)//thuong 5000 diamonds
        {
            Modules.totalCoin += valueBonus;
            Modules.SaveCoin();
            textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
        {
            if (isDone)
            {
                Modules.PlayAudioClipFree(Modules.audioButton);
                if (Modules.totalScratchCard > 0)
                {
                    CallStart();
                }
                else
                {
                    Modules.containScratchCard.SetActive(false);
                    if (Modules.nextPageScratchCard == "ShowWheelSpin")
                    {
                        Modules.nextPageWheelSpin = "ShowAchievement";
                        if (Modules.totalMysteryBox > 0) Modules.nextPageWheelSpin = "ShowOpenBox";
                        Modules.containWheelSpin.SetActive(true);
                        Modules.containWheelSpin.transform.Find("MainCamera").GetComponent<PageSpinWheel>().CallStart();
                    }
                    else if (Modules.nextPageScratchCard == "ShowOpenBox")
                    {
                        Modules.nextPageOpenBox = "ShowAchievement";
                        Modules.containOpenBox.SetActive(true);
                        Modules.containOpenBox.transform.Find("MainCamera").GetComponent<PageOpenMysteryBox>().CallStart();
                    }
                    else if (Modules.nextPageScratchCard == "ShowAchievement")
                    {
                        Modules.containAchievement.SetActive(true);
                        Modules.containAchievement.transform.Find("MainCamera").GetComponent<PageAchievement>().CallStart();
                    }
                    else if (Modules.nextPageScratchCard == "MenuGame")
                    {
                        Modules.containMainGame.SetActive(true);
                        if (Modules.statusGame == StatusGame.over)
                            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
                    }
                    else if (Modules.nextPageScratchCard == "WheelSpin")
                    {
                        if (Modules.totalWheelSpin > 0)
                        {
                            Modules.containWheelSpin.SetActive(true);
                            Modules.containWheelSpin.transform.Find("MainCamera").GetComponent<PageSpinWheel>().CallStart();
                        }
                        else
                        {
                            if (Modules.nextPageScratchCardOld == "ShowOpenBox")
                            {
                                Modules.nextPageOpenBox = "ShowAchievement";
                                Modules.containOpenBox.SetActive(true);
                                Modules.containOpenBox.transform.Find("MainCamera").GetComponent<PageOpenMysteryBox>().CallStart();
                            }
                            else if (Modules.nextPageScratchCardOld == "ShowAchievement")
                            {
                                Modules.containAchievement.SetActive(true);
                                Modules.containAchievement.transform.Find("MainCamera").GetComponent<PageAchievement>().CallStart();
                            }
                            else
                            {
                                Modules.containMainGame.SetActive(true);
                                if (Modules.statusGame == StatusGame.over)
                                    Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
                            }
                        }
                    }
                }
            }
        }
    }
}
