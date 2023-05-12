using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonItemBuy : MonoBehaviour {

    public string codeItem = "";
    public void ClickButton()
    {
        if (Modules.statusGame != StatusGame.play)
            return;
        if (codeItem == "headStart" && Modules.allowUseHoverbike)
        {
            //neu la item head start thi thuc hien an luon rocket
            if (Modules.gameGuide == "YES" && Modules.stepGuide != 6) return; //check xem co su dung trong luc huong dan
            if (Modules.gameGuide == "YES" && Modules.stepGuide == 6)
            {
                Modules.stepGuide++;
                //Transform textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
                //textGuide.GetComponent<Text>().text = AllLanguages.playBeginMove[Modules.indexLanguage];
                Modules.mainCharacter.GetComponent<HeroController>().UseDoubleCoin();
                Transform iconItemBuy = Modules.panelGameGuide.transform.Find("IconItemBuy");
                iconItemBuy.GetComponent<Image>().enabled = false;
                Modules.gameGuide = "NO";
                Modules.SaveGameGuide();
                Modules.panelGameGuide.SetActive(false);
                Invoke("RemoveGuide", 1f);
            }
            if (Modules.totalHeadStart <= 0)
                return;
            Modules.totalHeadStart--;
            Modules.SaveHeadStart();
            Transform number = transform.Find("Number");
            Text txtNumber = number.GetComponent<Text>();
            txtNumber.text = Modules.totalHeadStart.ToString();
            Modules.PlayAudioClipFree(Modules.audioUpSkis);
            //thuc hien chuc nang button
            Modules.mainCharacter.GetComponent<HeroController>().RunFunctionItem(TypeItems.hoverbike, Modules.mainCharacter.transform.position.x, true);
            //thuc hien dong button
            if (Modules.totalHeadStart <= 0)
            {
                Modules.totalHeadStart = 0;
                Animator aniPanel = transform.GetComponent<Animator>();
                aniPanel.SetTrigger("TriClose");
            }
        }
        else if (codeItem == "scoreBooster" && Modules.gameGuide != "YES")
        {
            //neu la item scoreBooster thi thuc hien cong diem nhan score
            if (Modules.totalScoreBooster <= 0)
            {
                if (transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PanelItemBuyShow"))
                    Camera.main.GetComponent<PageMainGame>().BuyScoreBooster();
                return;
            }
            if (Modules.countScoreUse > Modules.maxUseScorebooster)
            {
                transform.GetComponent<Animator>().SetTrigger("TriClose");
                return;
            }
            TaskData.HandleTask(26, 1, 7);
            TaskData.HandleTask(39, 1, 4);
            Modules.totalScoreBooster--;
            Modules.SaveScoreBooster();
            Transform number = transform.Find("Number");
            Text txtNumber = number.GetComponent<Text>();
            txtNumber.text = Modules.totalScoreBooster.ToString();
            txtNumber.alignment = TextAnchor.MiddleRight;
            Modules.PlayAudioClipFree(Modules.audioUpSkis);
            //thuc hien chuc nang button
            Modules.mainCharacter.GetComponent<HeroController>().RunFunctionItem(TypeItems.scoreBooster, Modules.mainCharacter.transform.position.x, true);
            //thuc hien effect meter
            Camera.main.GetComponent<PageMainGame>().RunEffectScoreBooster();
            //thuc hien dong button
            if (Modules.totalScoreBooster <= 0)
            {
                Modules.totalScoreBooster = 0;
                txtNumber.text = AllLanguages.shopButtonBuy[Modules.indexLanguage];
                txtNumber.alignment = TextAnchor.MiddleCenter;
                AutoHide();
            }
        }
    }

    public void AutoHide()
    {
        Invoke("HideButton", 10f);
    }

    void HideButton()
    {
        if (Modules.totalScoreBooster > 0) return;
        transform.GetComponent<Animator>().SetTrigger("TriClose");
    }

    public void AddForeDown()
    {
        foreach (Transform tran in Modules.containButtonBuy.transform)
        {
            if (tran.GetComponent<ButtonItemBuy>().codeItem != codeItem)
            {
                tran.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, -7000, 1));
            }
        }
        Destroy(gameObject);
    }

    void RemoveGuide()
    {
        //Modules.panelGameGuide.SetActive(false);
        Camera.main.GetComponent<PageMainGame>().ShowMissionsChallenge();
        Invoke("ShowTextBegin", 10f);
    }

    void ShowTextBegin()
    {
        foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
        GameObject effect = Instantiate(Modules.textStartMove[Modules.indexLanguage], Modules.parentTextEffect.transform);
        effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
    }
}
