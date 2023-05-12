using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSpinWheel : MonoBehaviour {

    public Text textKey, textCoin, textWheel, textStatus;
    public GameObject borderWheel;
    public GameObject contentWheel;
    public GameObject containResult;
    public Image imgResult;
    public AudioClip audioEffect;
    public GameObject particleEffect;
    public Sprite defaultSprite;
    public List<Image> listSkisIcon = new List<Image>();
    private bool openDone = false;
    private bool allowTap = true;

    public void CallStart()
    {
        openDone = false;
        allowTap = true;
        mesReward = false;
        textKey.text = Mathf.RoundToInt(Modules.totalKey).ToString();
        textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        textWheel.text = Mathf.RoundToInt(Modules.totalWheelSpin - 1).ToString();
        textStatus.color = new Color(1, 1, 1);
        textStatus.font = AllLanguages.listFontLangA[Modules.indexLanguage];
        textStatus.text = AllLanguages.otherTapSpin[Modules.indexLanguage];
        Sprite skisIcon = Modules.ChangeIconHoverboard();
        foreach (Image img in listSkisIcon)
            img.sprite = skisIcon;
        imgResult.gameObject.SetActive(true);
        imgResult.sprite = defaultSprite;
        containResult.SetActive(false);
        borderWheel.GetComponent<BlinkLightWheel>().CallStart();
        spinning = false;
        anglePerItem = 360 / prize.Count;
        Modules.PlayAudioClipLoop(Modules.audioBGWheelSpin, Camera.main.transform);
        CancelInvoke("PlayAnimationShow");
    }

    public void TapScene()
    {
        if (!allowTap) return;
        if (openDone)//neu hoan thanh thi chuyen trang
        {
            Modules.PlayAudioClipFree(Modules.audioButton);
            if (Modules.totalWheelSpin > 0)
            {
                CallStart();
            }
            else
            {
                ButtonHomeClick();
            }
        }
        else//neu khong thi spin wheel
        {
            allowTap = false;
            Modules.PlayAudioClipFree(Modules.audioOpenBox);
            containResult.SetActive(true);
            imgResult.gameObject.SetActive(false);
            //thuc hien spin
            ClickSpin(Mathf.RoundToInt(timeStay * 5));
        }
    }

    public bool AllowCollider()
    {
        return !allowTap;
    }

    private float timeStay = 0;
    private bool mesReward = false;
    private int codeResult = 0;
    void Update()
    {
        //check reward
        if (mesReward)
        {
            HandleBonus(codeResult);
            mesReward = false;
        }
        //xu ly tap va back
        if (startEffect)
        {
            ButtonStay();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonHomeClick();
        }
    }

    private bool startEffect = false;
    public void ButtonDown()
    {
        startEffect = true;
        timeStay = 0;
    }

    public void ButtonStay()
    {
        if (!allowTap || openDone) return;
        timeStay += Time.deltaTime;
        if (timeStay > 1) timeStay = 1;
        float numR = textStatus.color.r;
        float numG = textStatus.color.g - Time.deltaTime;
        float numB = textStatus.color.b - Time.deltaTime;
        if (numG < 0) numG = 0;
        if (numB < 0) numB = 0;
        textStatus.color = new Color(numR, numG, numB);
    }

    public void ButtonUp()
    {
        startEffect = false;
        TapScene();
    }

    //handle spin object
    public List<int> prize;
    public List<AnimationCurve> animationCurves;

    private bool spinning;
    private float anglePerItem;
    private int randomTime;
    private int itemNumber;

    void ClickSpin(int timeSpin)
    {
        if (!spinning)
        {
            TaskData.HandleTask(103, 1, 10);
            randomTime = Random.Range(1 + timeSpin, 2 + timeSpin);
            //bool check50Coins = false;
            //int numCheck = 2;
            //int runCheck = 0;
            //while (!check50Coins)
            //{
            //    itemNumber = Random.Range(1, prize.Count);
            //    if (itemNumber == 1)
            //    {
            //        runCheck++;
            //        if (runCheck >= numCheck)
            //            check50Coins = true;
            //    }
            //    else check50Coins = true;
            //}
            itemNumber = Random.Range(0, prize.Count);
            float maxAngle = 360 * randomTime + (itemNumber * anglePerItem);
            StartCoroutine(SpinTheWheel(5 * randomTime, maxAngle));
        }
    }

    IEnumerator SpinTheWheel(float time, float maxAngle)
    {
        spinning = true;

        float timer = 0.0f;
        float startAngle = contentWheel.transform.eulerAngles.z;
        maxAngle = maxAngle - startAngle;

        int animationCurveNumber = Random.Range(0, animationCurves.Count);
        //Debug.Log("Animation Curve No : " + animationCurveNumber);

        while (timer < time)
        {
            //to calculate rotation
            float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            contentWheel.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;

            float numR = textStatus.color.r;
            float numG = textStatus.color.g + Time.deltaTime * 2;
            float numB = textStatus.color.b + Time.deltaTime * 2;
            if (numG > 1) numG = 1;
            if (numB > 1) numB = 1;
            textStatus.color = new Color(numR, numG, numB);

            yield return 0;
        }

        contentWheel.transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
        spinning = false;
        //ket thuc spin
        Modules.totalWheelSpin--;
        if (Modules.totalWheelSpin < 0) Modules.totalWheelSpin = 0;
        Modules.SaveSpinWheel();
        textStatus.color = new Color(1, 1, 1);
        textStatus.text = AllLanguages.otherTapContinue[Modules.indexLanguage];
        codeResult = prize[itemNumber];
        mesReward = true;
        particleEffect.GetComponent<ParticleSystem>().Play();
        Modules.PlayAudioClipFree(audioEffect);
        Invoke("PlayAnimationShow", 1.5f);
        //Debug.Log("Prize: " + prize[itemNumber]);//use prize[itemNumnber] as per requirement
        yield break;
    }

    private void PlayAnimationShow()
    {
        containResult.GetComponent<Animator>().SetTrigger("TriPlay");
    }

    private void HandleBonus(int codeResult)
    {
        if (codeResult == 0)//thuong 5 scorebooster
        {
            Modules.totalScoreBooster += 5;
            if (Modules.totalScoreBooster > Modules.maxScorebooster)
                Modules.totalScoreBooster = Modules.maxScorebooster;
            Modules.SaveScoreBooster();
        }
        else if (codeResult == 1)//thuong 5 keys
        {
            Modules.totalKey += 5;
            Modules.SaveKey();
            textKey.text = Mathf.RoundToInt(Modules.totalKey).ToString();
        }
        else if (codeResult == 2)//thuong 15 hoverboard
        {
            Modules.totalSkis += 15;
            Modules.SaveSkis();
        }
        else if (codeResult == 3)//thuong 1 scorebooster
        {
            Modules.totalScoreBooster += 1;
            if (Modules.totalScoreBooster > Modules.maxScorebooster)
                Modules.totalScoreBooster = Modules.maxScorebooster;
            Modules.SaveScoreBooster();
        }
        else if (codeResult == 4)//thuong 2500 diamonds
        {
            Modules.totalCoin += 2500;
            Modules.SaveCoin();
            textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        }
        else if (codeResult == 5)//thuong 10 hoverboads
        {
            Modules.totalSkis += 10;
            Modules.SaveSkis();
        }
        else if (codeResult == 6)//thuong 3 safebox
        {
            Modules.totalMysteryBox += 3;
            Modules.nextPageOpenBoxOld = Modules.nextPageOpenBox;
            Modules.nextPageOpenBox = "WheelSpin";
            Modules.containWheelSpin.SetActive(false);
            Modules.containOpenBox.SetActive(true);
            Modules.containOpenBox.transform.Find("MainCamera").GetComponent<PageOpenMysteryBox>().CallStart();
        }
        else if (codeResult == 7)//thuong 1 scratch card
        {
            Modules.totalScratchCard += 1;
            Modules.nextPageScratchCardOld = Modules.nextPageScratchCard;
            Modules.nextPageScratchCard = "WheelSpin";
            Modules.containWheelSpin.SetActive(false);
            Modules.containScratchCard.SetActive(true);
            Modules.containScratchCard.transform.Find("MainCamera").GetComponent<PageScratchCard>().CallStart();
        }
        else if (codeResult == 8)//thuong 1000 diamonds
        {
            Modules.totalCoin += 1000;
            Modules.SaveCoin();
            textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        }
        else if (codeResult == 9)//thuong 1 safebox
        {
            Modules.totalMysteryBox += 1;
            Modules.nextPageOpenBoxOld = Modules.nextPageOpenBox;
            Modules.nextPageOpenBox = "WheelSpin";
            Modules.containWheelSpin.SetActive(false);
            Modules.containOpenBox.SetActive(true);
            Modules.containOpenBox.transform.Find("MainCamera").GetComponent<PageOpenMysteryBox>().CallStart();
        }
        else if (codeResult == 10)//thuong 5 hoverboards
        {
            Modules.totalSkis += 5;
            Modules.SaveSkis();
        }
        else if (codeResult == 11)//thuong 5000 diamonds
        {
            Modules.totalCoin += 5000;
            Modules.SaveCoin();
            textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        }
        allowTap = true;
        openDone = true;
    }

    public void ButtonHomeClick()
    {
        if (!allowTap) return;
        Modules.containWheelSpin.SetActive(false);
        if (Modules.nextPageWheelSpin == "ShowOpenBox")
        {
            Modules.nextPageOpenBox = "ShowAchievement";
            Modules.containOpenBox.SetActive(true);
            Modules.containOpenBox.transform.Find("MainCamera").GetComponent<PageOpenMysteryBox>().CallStart();
        }
        else if (Modules.nextPageWheelSpin == "ShowAchievement")
        {
            Modules.containAchievement.SetActive(true);
            Modules.containAchievement.transform.Find("MainCamera").GetComponent<PageAchievement>().CallStart();
        }
        else if (Modules.nextPageWheelSpin == "ShopItems")
        {
            Modules.containShopItem.SetActive(true);
            Modules.containShopItem.transform.Find("MainCamera").GetComponent<PageShopItems>().CallStart();
        }
        else if (Modules.nextPageWheelSpin == "MenuGame")
        {
            Modules.containMainGame.SetActive(true);
            if (Modules.statusGame == StatusGame.over)
                Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
        }
    }
}
