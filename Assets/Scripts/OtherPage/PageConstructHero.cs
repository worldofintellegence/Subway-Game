using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PageConstructHero : MonoBehaviour {

    public Text textKey, textCoin, textHighScore;
    public GameObject backgroundContent;
    public GameObject panelBuyHero, panelBuySkis, panelBuyJetpack, panelBuyBoat;
    public GameObject panelBuyHeroList, panelBuySkisList, panelBuyJetpackList, panelBuyBoatList;
    public Text textValueHero, textValueSkis, textValueJetpack, textValueBoat, textNoteHero, textNoteSkis, textNoteJetpack, textNoteBoat;
    public GameObject contentHero, contentSkis, contentJetpack, contentBoat;
    public GameObject itemTempHero, itemTempSkis, itemTempJetpack, itemTempBoat;
    public Vector3 pointShowHero, pointShowSkis, pointShowHoverbike, pointShowJetpack, pointShowBoat, pointShowThumHero, pointShowThumSkis, pointShowThumJetpack, pointShowThumBoat;
    public Vector3 scaleShowHero, scaleIdleHero, scaleShowSkis, scaleShowHoverbike, scaleShowBoat, scaleShowJetpack, scaleShowThumHero, scaleShowThumSkis, scaleShowThumJetpack, scaleShowThumBoat;
    public Vector3 pointShowEffectHero, scaleShowEffectHero;
    public Vector3 pointShowEffectSkis, scaleShowEffectSkis;
    public Vector3 pointShowEffectJetpack, scaleShowEffectJetpack;
    public Vector3 pointShowEffectBoat, scaleShowEffectBoat;
    public Vector3 pointShowThumEffect, scaleShowThumEffect;
    public Color colorError = Color.red;
    public Image iconHeroSale, iconSkisSale, iconJetpackSale, iconBoatSale;
    private Color colorOriginButBuyHero = Color.white;
    private Color colorOriginButBuySkis = Color.white;
    private Color colorOriginButBuyJetpack = Color.white;
    private Color colorOriginButBuyBoat = Color.white;
    private string valueOriginButBuyHero = "10000";
    private string valueOriginButBuySkis = "10000";
    private string valueOriginButBuyJetpack = "10000";
    private string valueOriginButBuyBoat = "10000";
    //xu ly nhay gia (fake jump)
    public AnimationCurve curveJump;
    private bool mesFakeJump = false;
    private float originPointJump = 0;
    private float timeRunJump = 0;
    //xu ly dung thu nhan vat
    public GameObject butTrialHero, butTrialSkis, butTrialJetpack, butTrialBoat;

    public void CallStart()
    {
        //Modules.FreeMemoryNow();
        ChangeAllLanguage();
        colorOriginButBuyHero = textValueHero.color;
        colorOriginButBuySkis = textValueSkis.color;
        colorOriginButBuyJetpack = textValueJetpack.color;
        colorOriginButBuyBoat = textValueBoat.color;
        textKey.text = Mathf.RoundToInt(Modules.totalKey).ToString();
        textCoin.text = Mathf.RoundToInt(Modules.totalCoin).ToString();
        codeHeroChoose = Modules.codeHeroUse;
        codeSkisChoose = Modules.codeSkisUse;
        codeJetpackChoose = Modules.codeJetpackUse;
        codeBoatChoose = Modules.codeBoatUse;
        textHighScore.GetComponent<EffectUpScore>().StartEffect(Modules.totalScore);
        ButtonBuyHeroClick(false);
        backgroundContent.GetComponent<Animator>().SetTrigger("TriUnlockIdle");
        PlayBackgroundAudio();
    }

    void PlayBackgroundAudio()
    {
        Modules.PlayAudioClipLoop(Modules.audioBGMenu, Camera.main.transform);
    }

    private void StopAudioHero()
    {
        GetComponent<AudioSource>().Stop();
    }

    private GameObject heroChooseShow, heroChooseIdle;
    private string codeHeroChoose = "001", codeSkisChoose = "001", codeJetpackChoose = "001", codeBoatChoose = "001";
    void LoadHeroChoose()
    {
        if (heroChooseShow != null) Destroy(heroChooseShow);
        if (heroChooseIdle != null) Destroy(heroChooseIdle);
        for (int i = 0; i < Modules.listHeroUse.Count; i++)
        {
            if (Modules.listHeroUse[i].GetComponent<HeroController>().idHero == codeHeroChoose)
            {
                heroChooseShow = Instantiate(Modules.listHeroUse[i], pointShowHero, Quaternion.identity) as GameObject;
                Modules.SetLayer(heroChooseShow.gameObject, "MCG-Hero");
                heroChooseShow.transform.parent = Modules.containHeroConstruct.transform;
                heroChooseShow.transform.localScale = scaleShowHero;
                heroChooseShow.transform.eulerAngles = new Vector3(0, 180, 0);
                HeroController heroNow = heroChooseShow.GetComponent<HeroController>();
                heroChooseIdle = Instantiate(heroNow.modelIdelShow, pointShowHero, Quaternion.identity) as GameObject;
                heroChooseIdle.transform.parent = Modules.containHeroConstruct.transform;
                heroChooseIdle.transform.localScale = scaleIdleHero;
                heroChooseIdle.transform.eulerAngles = new Vector3(0, 180, 0);
                heroNow.SetupShowMenu(2);
                heroNow.CallAniMenu(heroNow.aniIdleMenu, 1f);
                heroNow.deactiveAfferInstan = true;
                if (heroNow.iconSale != null)
                {
                    iconHeroSale.sprite = heroNow.iconSale;
                    iconHeroSale.color = new Color(1, 1, 1, 1);
                }
                else iconHeroSale.color = new Color(1, 1, 1, 0);
                string textSpeedHero = "";
                if (heroNow.speedPercent > 0) textSpeedHero = "\n" + AllLanguages.heroSpeedSkis[Modules.indexLanguage] + " +" + (heroNow.speedPercent * 100).ToString() + "%";
                textNoteHero.text = AllLanguages.heroInfoHero[heroNow.noteHero][Modules.indexLanguage] + textSpeedHero;
                textValueHero.text = heroNow.costHero.ToString();
                bool checkContain = false;
                if (Modules.listHeroUnlock.Contains(codeHeroChoose)) checkContain = true;
                if (Modules.codeHeroTrying != codeHeroChoose)
                {
                    if (Modules.codeHeroUse == codeHeroChoose)
                        textValueHero.text = AllLanguages.heroSelected[Modules.indexLanguage];
                    else if (checkContain)
                        textValueHero.text = AllLanguages.heroUnlocked[Modules.indexLanguage];
                }
                valueOriginButBuyHero = textValueHero.text;
                if (!checkContain && Modules.listHeroTrial.Contains(codeHeroChoose) && Modules.codeHeroTrying != codeHeroChoose)
                    butTrialHero.SetActive(true);
                else butTrialHero.SetActive(false);
                break;
            }
        }
    }

    void LoadSkisChoose()
    {
        for (int i = 0; i < Modules.listSkisUse.Count; i++)
        {
            SkisController skisCon = Modules.listSkisUse[i].GetComponent<SkisController>();
            if (skisCon.idSkis == codeSkisChoose)
            {
                heroChooseShow.SetActive(true);
                heroChooseIdle.SetActive(false);
                heroChooseShow.transform.parent = Modules.containHeroConstruct.transform;
                heroChooseShow.transform.position = pointShowSkis;
                heroChooseShow.transform.localScale = scaleShowSkis;
                heroChooseShow.transform.eulerAngles = new Vector3(15, 180, 0);
                HeroController heroNow = heroChooseShow.GetComponent<HeroController>();
                heroNow.mySkis = Modules.listSkisUse[i];
                heroNow.SetupShowMenu(2);
                if (heroNow.mySkis.GetComponent<SkisController>().isHoverbike)
                {
                    heroChooseShow.transform.position = pointShowHoverbike;
                    heroChooseShow.transform.localScale = scaleShowHoverbike;
                    heroChooseShow.transform.eulerAngles = new Vector3(0, 200, 0);
                    //heroNow.CallAniMenu(heroNow.aniRunCable, 1f);
                    heroNow.CallAniMenu(heroNow.aniJumpCable[Random.Range(0, heroNow.aniJumpCable.Count)], 1.75f, false);
                }
                else
                {
                    //heroNow.CallAniMenu(heroNow.aniRunSkis, 1f);
                    heroNow.CallAniMenu(heroNow.aniJumpSkis[Random.Range(0, heroNow.aniJumpSkis.Count)], 1.75f, false);
                    Modules.PlayAudioClipFree(Modules.audioSkisJumpStart);
                }
                timeRunJump = 0;
                originPointJump = heroChooseShow.transform.position.y;
                mesFakeJump = true;
                if (skisCon.iconSale != null)
                {
                    iconSkisSale.sprite = skisCon.iconSale;
                    iconSkisSale.color = new Color(1, 1, 1, 1);
                }
                else iconSkisSale.color = new Color(1, 1, 1, 0);
                Modules.RemoveModelUseItem(heroChooseShow.transform, "Skis");
                Modules.RemoveModelUseItem(heroChooseShow.transform, "Rocket");
                Modules.SetModelUseItem(heroChooseShow.transform, heroNow.codeBody, heroNow.mySkis, "Skis");
                Modules.SetLayer(heroChooseShow.gameObject, "MCG-Hero");
                foreach (GameObject go in heroNow.listObjectHide) go.gameObject.SetActive(false);
                //skisCon.CallAniMenu(skisCon.aniRun, 1f);
                string textSpeedSkis = "";
                if (skisCon.speedPercent > 0) textSpeedSkis = "\n" + AllLanguages.heroSpeedSkis[Modules.indexLanguage] + " +" + (skisCon.speedPercent * 100).ToString() + "%";
                textNoteSkis.text = AllLanguages.heroInfoHoverboard[skisCon.noteSkis][Modules.indexLanguage] + textSpeedSkis;
                textValueSkis.text = skisCon.costSkis.ToString();
                bool checkContain = false;
                if (Modules.listSkisUnlock.Contains(codeSkisChoose)) checkContain = true;
                if (Modules.codeSkisTrying != codeSkisChoose)
                {
                    if (Modules.codeSkisUse == codeSkisChoose)
                        textValueSkis.text = AllLanguages.heroSelected[Modules.indexLanguage];
                    else if (checkContain)
                        textValueSkis.text = AllLanguages.heroUnlocked[Modules.indexLanguage];
                }
                valueOriginButBuySkis = textValueSkis.text;
                if (!checkContain && Modules.listSkisTrial.Contains(codeSkisChoose) && Modules.codeSkisTrying != codeSkisChoose)
                    butTrialSkis.SetActive(true);
                else butTrialSkis.SetActive(false);
                break;
            }
        }
    }

    void LoadJetpackChoose()
    {
        for (int i = 0; i < Modules.listJetpackUse.Count; i++)
        {
            JetpackController jetCon = Modules.listJetpackUse[i].GetComponent<JetpackController>();
            if (jetCon.idJetpack == codeJetpackChoose)
            {
                heroChooseShow.SetActive(true);
                heroChooseIdle.SetActive(false);
                heroChooseShow.transform.parent = Modules.containHeroConstruct.transform;
                heroChooseShow.transform.position = pointShowJetpack;
                heroChooseShow.transform.localScale = scaleShowJetpack;
                heroChooseShow.transform.eulerAngles = new Vector3(-45, 200, 0);
                HeroController heroNow = heroChooseShow.GetComponent<HeroController>();
                heroNow.myJetpack = Modules.listJetpackUse[i];
                heroNow.SetupShowMenu(2);
                if (jetCon.isBroom)
                {
                    heroNow.CallAniMenu(heroNow.aniRunBroom, 0.25f);
                    heroChooseShow.transform.position = new Vector3(-1.4f, -0.3f, 0);
                    heroChooseShow.transform.eulerAngles = new Vector3(0, -150, 0);
                }
                else heroNow.CallAniMenu(heroNow.aniRunRocket, 0.25f);
                if (jetCon.iconSale != null)
                {
                    iconJetpackSale.sprite = jetCon.iconSale;
                    iconJetpackSale.color = new Color(1, 1, 1, 1);
                }
                else iconJetpackSale.color = new Color(1, 1, 1, 0);
                Modules.RemoveModelUseItem(heroChooseShow.transform, "Skis");
                Modules.RemoveModelUseItem(heroChooseShow.transform, "Rocket");
                Modules.SetModelUseItem(heroChooseShow.transform, heroNow.codeBody, heroNow.myJetpack, "Rocket");
                Modules.SetLayer(heroChooseShow.gameObject, "MCG-Hero");
                foreach (GameObject go in heroNow.listObjectHide) go.gameObject.SetActive(false);
                string textSpeedJetpack = "";
                if (jetCon.speedPercent > 0) textSpeedJetpack = "\n" + AllLanguages.heroSpeedSkis[Modules.indexLanguage] + " +" + (jetCon.speedPercent * 100).ToString() + "%";
                textNoteJetpack.text = AllLanguages.heroInfoJetpack[jetCon.noteJetpack][Modules.indexLanguage] + textSpeedJetpack;
                textValueJetpack.text = jetCon.costJetpack.ToString();
                bool checkContain = false;
                if (Modules.listJetpackUnlock.Contains(codeJetpackChoose)) checkContain = true;
                if (Modules.codeJetpackTrying != codeJetpackChoose)
                {
                    if (Modules.codeJetpackUse == codeJetpackChoose)
                        textValueJetpack.text = AllLanguages.heroSelected[Modules.indexLanguage];
                    else if (checkContain)
                        textValueJetpack.text = AllLanguages.heroUnlocked[Modules.indexLanguage];
                }
                valueOriginButBuyJetpack = textValueJetpack.text;
                if (!checkContain && Modules.listJetpackTrial.Contains(codeJetpackChoose) && Modules.codeJetpackTrying != codeJetpackChoose)
                    butTrialJetpack.SetActive(true);
                else butTrialJetpack.SetActive(false);
                break;
            }
        }
    }

    void LoadBoatChoose()
    {
        for (int i = 0; i < Modules.listBoatUse.Count; i++)
        {
            BoatController boatCon = Modules.listBoatUse[i].GetComponent<BoatController>();
            if (boatCon.idBoat == codeBoatChoose)
            {
                heroChooseShow.SetActive(true);
                heroChooseIdle.SetActive(false);
                heroChooseShow.transform.parent = Modules.containHeroConstruct.transform;
                heroChooseShow.transform.position = pointShowBoat;
                heroChooseShow.transform.localScale = scaleShowBoat;
                heroChooseShow.transform.eulerAngles = new Vector3(0, 200, 0);
                HeroController heroNow = heroChooseShow.GetComponent<HeroController>();
                heroNow.myBoat = Modules.listBoatUse[i];
                heroNow.SetupShowMenu(2);
                //heroNow.CallAniMenu(heroNow.aniRunBoat, 1f);
                heroNow.CallAniMenu(heroNow.aniJumpBoat[Random.Range(0, heroNow.aniJumpBoat.Count)], 1.75f, false);
                timeRunJump = 0;
                originPointJump = heroChooseShow.transform.position.y;
                mesFakeJump = true;
                if (boatCon.iconSale != null)
                {
                    iconBoatSale.sprite = boatCon.iconSale;
                    iconBoatSale.color = new Color(1, 1, 1, 1);
                }
                else iconBoatSale.color = new Color(1, 1, 1, 0);
                Modules.RemoveModelUseItem(heroChooseShow.transform, "Skis");
                Modules.RemoveModelUseItem(heroChooseShow.transform, "Rocket");
                Modules.SetModelUseItem(heroChooseShow.transform, heroNow.codeBody, heroNow.myBoat, "Skis");
                Modules.SetLayer(heroChooseShow.gameObject, "MCG-Hero");
                foreach (GameObject go in heroNow.listObjectHide) go.gameObject.SetActive(false);
                string textSpeedBoat = "";
                if (boatCon.speedPercent > 0) textSpeedBoat = "\n" + AllLanguages.heroSpeedSkis[Modules.indexLanguage] + " +" + (boatCon.speedPercent * 100).ToString() + "%";
                textNoteBoat.text = AllLanguages.heroInfoBoat[boatCon.noteBoat][Modules.indexLanguage] + textSpeedBoat;
                textValueBoat.text = boatCon.costBoat.ToString();
                bool checkContain = false;
                if (Modules.listBoatUnlock.Contains(codeBoatChoose)) checkContain = true;
                if (Modules.codeBoatTrying != codeBoatChoose)
                {
                    if (Modules.codeBoatUse == codeBoatChoose)
                        textValueBoat.text = AllLanguages.heroSelected[Modules.indexLanguage];
                    else if (checkContain)
                        textValueBoat.text = AllLanguages.heroUnlocked[Modules.indexLanguage];
                }
                valueOriginButBuyBoat = textValueBoat.text;
                if (!checkContain && Modules.listBoatTrial.Contains(codeBoatChoose) && Modules.codeBoatTrying != codeBoatChoose)
                    butTrialBoat.SetActive(true);
                else butTrialBoat.SetActive(false);
                break;
            }
        }
    }

    void LoadListHero()
    {
        foreach (Transform tran in contentHero.transform) Destroy(tran.gameObject);
        mesLoadListHero = true;
        runLoadListHero = 0;
    }

    void LoadListSkis()
    {
        foreach (Transform tran in contentSkis.transform) Destroy(tran.gameObject);
        mesLoadListSkis = true;
        runLoadListSkis = 0;
    }

    void LoadListJetpack()
    {
        foreach (Transform tran in contentJetpack.transform) Destroy(tran.gameObject);
        mesLoadListJetpack = true;
        runLoadListJetpack = 0;
    }

    void LoadListBoat()
    {
        foreach (Transform tran in contentBoat.transform) Destroy(tran.gameObject);
        mesLoadListBoat = true;
        runLoadListBoat = 0;
    }

    private int indexChooseHero = 0;
    private bool mesLoadListHero = false;
    private int runLoadListHero = 0;
    private int indexChooseSkis = 0;
    private bool mesLoadListSkis = false;
    private int runLoadListSkis = 0;
    private int indexChooseJetpack = 0;
    private bool mesLoadListJetpack = false;
    private int runLoadListJetpack = 0;
    private int indexChooseBoat = 0;
    private bool mesLoadListBoat = false;
    private int runLoadListBoat = 0;
    void FixedUpdate()
    {
        //load list hero tuan tu
        if (mesLoadListHero)
        {
            if (runLoadListHero < Modules.listHeroUse.Count)
            {
                string idNow = Modules.listHeroUse[runLoadListHero].GetComponent<HeroController>().idHero;
                GameObject newItem = Instantiate(itemTempHero.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(contentHero.transform, false);
                newItem.GetComponent<ChangeImageClick>().codeObject = idNow;
                HeroController heroNow = Modules.listHeroUse[runLoadListHero].GetComponent<HeroController>();
                GameObject heroChoose = Instantiate(heroNow.modelIdelShow, pointShowThumHero, Quaternion.identity) as GameObject;
                heroChoose.transform.localScale = scaleShowThumHero;
                heroChoose.transform.eulerAngles = new Vector3(5, 180, 0);
                Image iconSaleSmall = newItem.transform.GetChild(0).GetComponent<Image>();
                if (heroNow.iconSale != null)
                {
                    iconSaleSmall.sprite = heroNow.iconSale;
                    iconSaleSmall.color = new Color(1, 1, 1, 1);
                }
                else iconSaleSmall.color = new Color(1, 1, 1, 0);
                if (Modules.listHeroUnlock.Contains(idNow) || Modules.codeHeroTrying == idNow) newItem.transform.GetChild(1).gameObject.SetActive(false);
                else newItem.transform.GetChild(1).gameObject.SetActive(true);
                heroChoose.transform.SetParent(newItem.transform, false);
                if (idNow == codeHeroChoose) { newItem.GetComponent<ChangeImageClick>().OpenImageFront(); indexChooseHero = runLoadListHero; }
                else newItem.GetComponent<ChangeImageClick>().CloseImageFront();
                runLoadListHero++;
            }
            else
            {
                mesLoadListHero = false;
                //dieu chinh scroll bar toi nhan vat
                Vector2 oldPoint = contentHero.GetComponent<RectTransform>().anchoredPosition;
                float indexScroll = 0;
                if (Modules.listHeroUse.Count > 3)
                {
                    if (indexChooseHero < Modules.listHeroUse.Count - 3) indexScroll = indexChooseHero * -140;
                    else indexScroll = (Modules.listHeroUse.Count - 3) * -140;
                }
                contentHero.GetComponent<RectTransform>().anchoredPosition = new Vector3(indexScroll, oldPoint.y);
            }
        }
        //load list skis tuan tu
        if (mesLoadListSkis)
        {
            if (runLoadListSkis < Modules.listSkisUse.Count)
            {
                string idNow = Modules.listSkisUse[runLoadListSkis].GetComponent<SkisController>().idSkis;
                GameObject newItem = Instantiate(itemTempSkis.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(contentSkis.transform, false);
                newItem.GetComponent<ChangeImageClick>().codeObject = idNow;
                GameObject skisChoose = Instantiate(Modules.listSkisUse[runLoadListSkis], pointShowThumSkis, Quaternion.identity) as GameObject;
                skisChoose.transform.localScale = scaleShowThumSkis;
                skisChoose.transform.eulerAngles = new Vector3(55, -215, -10);
                SkisController skisNow = skisChoose.GetComponent<SkisController>();
                RotateModels rotateZ = skisChoose.AddComponent<RotateModels>();
                rotateZ.originAngle = skisChoose.transform.eulerAngles;
                rotateZ.axisRotate = AxisRotate.axisZ;
                //skisNow.CallAniMenu(skisNow.aniRun, 1f);
                Image iconSaleSmall = newItem.transform.GetChild(0).GetComponent<Image>();
                if (skisNow.iconSale != null)
                {
                    iconSaleSmall.sprite = skisNow.iconSale;
                    iconSaleSmall.color = new Color(1, 1, 1, 1);
                }
                else iconSaleSmall.color = new Color(1, 1, 1, 0);
                if (Modules.listSkisUnlock.Contains(idNow) || Modules.codeSkisTrying == idNow) newItem.transform.GetChild(1).gameObject.SetActive(false);
                else newItem.transform.GetChild(1).gameObject.SetActive(true);
                skisNow.transform.SetParent(newItem.transform, false);
                if (idNow == codeSkisChoose) { newItem.GetComponent<ChangeImageClick>().OpenImageFront(); indexChooseSkis = runLoadListSkis; }
                else newItem.GetComponent<ChangeImageClick>().CloseImageFront();
                runLoadListSkis++;
            }
            else
            {
                mesLoadListSkis = false;
                //dieu chinh scroll bar toi hoverboard
                Vector2 oldPoint = contentSkis.GetComponent<RectTransform>().anchoredPosition;
                float indexScroll = 0;
                if (Modules.listSkisUse.Count > 3)
                {
                    if (indexChooseSkis < Modules.listSkisUse.Count - 3) indexScroll = indexChooseSkis * -140;
                    else indexScroll = (Modules.listSkisUse.Count - 3) * -140;
                }
                contentSkis.GetComponent<RectTransform>().anchoredPosition = new Vector3(indexScroll, oldPoint.y);
            }
        }
        //load list jetpack tuan tu
        if (mesLoadListJetpack)
        {
            if (runLoadListJetpack < Modules.listJetpackUse.Count)
            {
                string idNow = Modules.listJetpackUse[runLoadListJetpack].GetComponent<JetpackController>().idJetpack;
                GameObject newItem = Instantiate(itemTempJetpack.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(contentJetpack.transform, false);
                newItem.GetComponent<ChangeImageClick>().codeObject = idNow;
                GameObject jetChoose = Instantiate(Modules.listJetpackUse[runLoadListJetpack], pointShowThumJetpack, Quaternion.identity) as GameObject;
                jetChoose.transform.localScale = scaleShowThumJetpack;
                jetChoose.transform.eulerAngles = new Vector3(40, 0, -60);
                JetpackController jetNow = jetChoose.GetComponent<JetpackController>();
                //RotateModels rotateX = jetChoose.AddComponent<RotateModels>();
                //rotateX.originAngle = jetChoose.transform.eulerAngles;
                //rotateX.axisRotate = AxisRotate.axisX;
                Image iconSaleSmall = newItem.transform.GetChild(0).GetComponent<Image>();
                if (jetNow.iconSale != null)
                {
                    iconSaleSmall.sprite = jetNow.iconSale;
                    iconSaleSmall.color = new Color(1, 1, 1, 1);
                }
                else iconSaleSmall.color = new Color(1, 1, 1, 0);
                if (Modules.listJetpackUnlock.Contains(idNow) || Modules.codeJetpackTrying == idNow) newItem.transform.GetChild(1).gameObject.SetActive(false);
                else newItem.transform.GetChild(1).gameObject.SetActive(true);
                jetNow.transform.SetParent(newItem.transform, false);
                if (idNow == codeJetpackChoose) { newItem.GetComponent<ChangeImageClick>().OpenImageFront(); indexChooseJetpack = runLoadListJetpack; }
                else newItem.GetComponent<ChangeImageClick>().CloseImageFront();
                runLoadListJetpack++;
            }
            else
            {
                mesLoadListJetpack = false;
                //dieu chinh scroll bar toi hoverboard
                Vector2 oldPoint = contentJetpack.GetComponent<RectTransform>().anchoredPosition;
                float indexScroll = 0;
                if (Modules.listJetpackUse.Count > 3)
                {
                    if (indexChooseJetpack < Modules.listJetpackUse.Count - 3) indexScroll = indexChooseJetpack * -140;
                    else indexScroll = (Modules.listJetpackUse.Count - 3) * -140;
                }
                contentJetpack.GetComponent<RectTransform>().anchoredPosition = new Vector3(indexScroll, oldPoint.y);
            }
        }
        //load list boat tuan tu
        if (mesLoadListBoat)
        {
            if (runLoadListBoat < Modules.listBoatUse.Count)
            {
                string idNow = Modules.listBoatUse[runLoadListBoat].GetComponent<BoatController>().idBoat;
                GameObject newItem = Instantiate(itemTempBoat.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                newItem.transform.SetParent(contentBoat.transform, false);
                newItem.GetComponent<ChangeImageClick>().codeObject = idNow;
                GameObject boatChoose = Instantiate(Modules.listBoatUse[runLoadListBoat], pointShowThumBoat, Quaternion.identity) as GameObject;
                boatChoose.transform.localScale = scaleShowThumBoat;
                boatChoose.transform.eulerAngles = new Vector3(55, -215, -10);
                BoatController boatNow = boatChoose.GetComponent<BoatController>();
                RotateModels rotateZ = boatChoose.AddComponent<RotateModels>();
                rotateZ.originAngle = boatChoose.transform.eulerAngles;
                rotateZ.axisRotate = AxisRotate.axisZ;
                Image iconSaleSmall = newItem.transform.GetChild(0).GetComponent<Image>();
                if (boatNow.iconSale != null)
                {
                    iconSaleSmall.sprite = boatNow.iconSale;
                    iconSaleSmall.color = new Color(1, 1, 1, 1);
                }
                else iconSaleSmall.color = new Color(1, 1, 1, 0);
                if (Modules.listBoatUnlock.Contains(idNow) || Modules.codeBoatTrying == idNow) newItem.transform.GetChild(1).gameObject.SetActive(false);
                else newItem.transform.GetChild(1).gameObject.SetActive(true);
                boatNow.transform.SetParent(newItem.transform, false);
                if (idNow == codeBoatChoose) { newItem.GetComponent<ChangeImageClick>().OpenImageFront(); indexChooseBoat = runLoadListBoat; }
                else newItem.GetComponent<ChangeImageClick>().CloseImageFront();
                runLoadListBoat++;
            }
            else
            {
                mesLoadListBoat = false;
                //dieu chinh scroll bar toi hoverboard
                Vector2 oldPoint = contentBoat.GetComponent<RectTransform>().anchoredPosition;
                float indexScroll = 0;
                if (Modules.listBoatUse.Count > 3)
                {
                    if (indexChooseBoat < Modules.listBoatUse.Count - 3) indexScroll = indexChooseBoat * -140;
                    else indexScroll = (Modules.listBoatUse.Count - 3) * -140;
                }
                contentBoat.GetComponent<RectTransform>().anchoredPosition = new Vector3(indexScroll, oldPoint.y);
            }
        }
    }

    public void ButtonHeroClick(string codeHero)
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        codeHeroChoose = codeHero;
        LoadHeroChoose();
        ResetButtonListHero(codeHero);
    }

    public void ButtonSkisClick(string codeSkis)
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        codeSkisChoose = codeSkis;
        LoadSkisChoose();
        ResetButtonListSkis(codeSkis);
    }

    public void ButtonJetpackClick(string codeJetpack)
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        codeJetpackChoose = codeJetpack;
        LoadJetpackChoose();
        ResetButtonListJetpack(codeJetpack);
    }

    public void ButtonBoatClick(string codeBoat)
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        codeBoatChoose = codeBoat;
        LoadBoatChoose();
        ResetButtonListBoat(codeBoat);
    }

    private void ResetButtonListHero(string codeActive)
    {
        foreach (Transform tran in contentHero.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject != codeActive)
                tran.GetComponent<ChangeImageClick>().CloseImageFront();
        }
    }

    private void ResetButtonListSkis(string codeActive)
    {
        foreach (Transform tran in contentSkis.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject != codeActive)
                tran.GetComponent<ChangeImageClick>().CloseImageFront();
        }
    }

    private void ResetButtonListJetpack(string codeActive)
    {
        foreach (Transform tran in contentJetpack.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject != codeActive)
                tran.GetComponent<ChangeImageClick>().CloseImageFront();
        }
    }

    private void ResetButtonListBoat(string codeActive)
    {
        foreach (Transform tran in contentBoat.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject != codeActive)
                tran.GetComponent<ChangeImageClick>().CloseImageFront();
        }
    }

    private bool showErrorHero = false;
    void ShowMessageErrorHero(string textError)
    {
        showErrorHero = true;
        textValueHero.text = textError;
        textValueHero.color = colorError;
        Invoke("ResetValueOriginHero", 1f);
    }

    void ResetValueOriginHero()
    {
        showErrorHero = false;
        textValueHero.text = valueOriginButBuyHero;
        textValueHero.color = colorOriginButBuyHero;
    }

    private bool showErrorSkis = false;
    void ShowMessageErrorSkis(string textError)
    {
        showErrorSkis = true;
        textValueSkis.text = textError;
        textValueSkis.color = colorError;
        Invoke("ResetValueOriginSkis", 1f);
    }

    void ResetValueOriginSkis()
    {
        showErrorSkis = false;
        textValueSkis.text = valueOriginButBuySkis;
        textValueSkis.color = colorOriginButBuySkis;
    }

    private bool showErrorJetpack = false;
    void ShowMessageErrorJetpack(string textError)
    {
        showErrorJetpack = true;
        textValueJetpack.text = textError;
        textValueJetpack.color = colorError;
        Invoke("ResetValueOriginJetpack", 1f);
    }

    void ResetValueOriginJetpack()
    {
        showErrorJetpack = false;
        textValueJetpack.text = valueOriginButBuyJetpack;
        textValueJetpack.color = colorOriginButBuyJetpack;
    }

    private bool showErrorBoat = false;
    void ShowMessageErrorBoat(string textError)
    {
        showErrorBoat = true;
        textValueBoat.text = textError;
        textValueBoat.color = colorError;
        Invoke("ResetValueOriginBoat", 1f);
    }

    void ResetValueOriginBoat()
    {
        showErrorBoat = false;
        textValueBoat.text = valueOriginButBuyBoat;
        textValueBoat.color = colorOriginButBuyBoat;
    }

    public void ButtonCoinHeroClick()
    {
        if (showErrorHero) return;
        bool playAudioCoin = false;
        if (!Modules.listHeroUnlock.Contains(codeHeroChoose))
        {
            int cost = Modules.IntParseFast(textValueHero.text);
            if (Modules.totalCoin >= cost)//neu du tien mua
            {
                playAudioCoin = true;
                ApllyTaskSpend(cost);
                Modules.totalCoin -= cost;
                Modules.SaveCoin();
                textCoin.text = Modules.totalCoin.ToString();
                textValueHero.text = AllLanguages.heroSelected[Modules.indexLanguage];
                Modules.listHeroUnlock.Add(codeHeroChoose);
                Modules.SaveListHeroUnlock();
                Modules.codeHeroUse = codeHeroChoose;
                Modules.SaveBodyHero();
                Modules.statusGame = StatusGame.over;
                if (Modules.fbID == "Null")
                    Modules.fbLinkAvatar = Modules.linkAvatarNull + Modules.codeHeroUse + ".jpg";
                //xu ly hieu ung unlock
                //heroChooseIdle.GetComponent<CheckMatUnlock>().CheckNow();
                StopAudioHero();
                backgroundContent.GetComponent<Animator>().SetTrigger("TriUnlockHero");
                GameObject effectA = Instantiate(heroChooseShow.GetComponent<HeroController>().effectUnlock, transform.parent.transform) as GameObject;
                effectA.transform.localPosition = pointShowEffectHero;
                effectA.transform.localScale = scaleShowEffectHero;
                effectA.transform.localEulerAngles = new Vector3(0, 90, 0);
                foreach (Transform tran in contentHero.transform)
                {
                    if (tran.GetComponent<ChangeImageClick>().codeObject == codeHeroChoose)
                    {
                        tran.GetChild(1).gameObject.SetActive(false);
                        //tran.GetChild(2).GetComponent<CheckMatUnlock>().CheckNow();
                        GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                        effectB.transform.localPosition = pointShowThumEffect;
                        effectB.transform.localScale = scaleShowThumEffect;
                    }
                }
                Invoke("PlayBackgroundAudio", 3f);
                //xu ly xoa bo dung thu neu mua han
                if (Modules.listHeroTrial.Contains(codeHeroChoose))
                {
                    Modules.listHeroTrial.Remove(codeHeroChoose);
                    Modules.SaveListHeroTrial();
                }
                if (Modules.codeHeroTrying == codeHeroChoose)
                    Modules.codeHeroTrying = "";
                butTrialHero.SetActive(false);
            }
            else
                ShowMessageErrorHero(AllLanguages.heroNotEnough[Modules.indexLanguage]);
        }
        else
        {
            textValueHero.text = AllLanguages.heroSelected[Modules.indexLanguage];
            Modules.codeHeroUse = codeHeroChoose;
            Modules.SaveBodyHero();
            Modules.statusGame = StatusGame.over;
            if (Modules.fbID == "Null")
                Modules.fbLinkAvatar = Modules.linkAvatarNull + Modules.codeHeroUse + ".jpg";
        }
        if (playAudioCoin) Modules.PlayAudioClipFree(Modules.audioBuyCoin);
        else Modules.PlayAudioClipFree(Modules.audioButton);
    }

    public void ButtonCoinSkisClick()
    {
        if (showErrorSkis) return;
        bool playAudioCoin = false;
        if (!Modules.listSkisUnlock.Contains(codeSkisChoose))
        {
            int cost = Modules.IntParseFast(textValueSkis.text);
            if (Modules.totalCoin >= cost)//neu du tien mua
            {
                playAudioCoin = true;
                ApllyTaskSpend(cost);
                TaskData.HandleTask(66, 1, 1);
                Modules.totalCoin -= cost;
                Modules.SaveCoin();
                textCoin.text = Modules.totalCoin.ToString();
                textValueSkis.text = AllLanguages.heroSelected[Modules.indexLanguage];
                Modules.listSkisUnlock.Add(codeSkisChoose);
                Modules.SaveListSkisUnlock();
                Modules.codeSkisUse = codeSkisChoose;
                Modules.SaveSkisHero();
                Modules.statusGame = StatusGame.over;
                //xu ly hieu ung unlock
                StopAudioHero();
                backgroundContent.GetComponent<Animator>().SetTrigger("TriUnlockSkis");
                GameObject mySkisNow = Modules.GetModelUseItem(heroChooseShow.transform, "Skis");
                //if (mySkisNow != null)
                //mySkisNow.GetComponent<CheckMatUnlock>().CheckNow();
                GameObject effectA = Instantiate(mySkisNow.GetComponent<SkisController>().effectUnlock, transform.parent.transform) as GameObject;
                effectA.transform.localPosition = pointShowEffectSkis;
                effectA.transform.localScale = scaleShowEffectSkis;
                effectA.transform.localEulerAngles = new Vector3(0, 90, 0);
                foreach (Transform tran in contentSkis.transform)
                {
                    if (tran.GetComponent<ChangeImageClick>().codeObject == codeSkisChoose)
                    {
                        tran.GetChild(1).gameObject.SetActive(false);
                        //tran.GetChild(2).GetComponent<CheckMatUnlock>().CheckNow();
                        GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                        effectB.transform.localPosition = pointShowThumEffect;
                        effectB.transform.localScale = scaleShowThumEffect;
                    }
                }
                Invoke("PlayBackgroundAudio", 3f);
                //xu ly xoa bo dung thu neu mua han
                if (Modules.listSkisTrial.Contains(codeSkisChoose))
                {
                    Modules.listSkisTrial.Remove(codeSkisChoose);
                    Modules.SaveListSkisTrial();
                }
                if (Modules.codeSkisTrying == codeSkisChoose)
                    Modules.codeSkisTrying = "";
                butTrialSkis.SetActive(false);
            }
            else
                ShowMessageErrorSkis(AllLanguages.heroNotEnough[Modules.indexLanguage]);
        }
        else
        {
            textValueSkis.text = AllLanguages.heroSelected[Modules.indexLanguage];
            Modules.codeSkisUse = codeSkisChoose;
            Modules.SaveSkisHero();
            Modules.statusGame = StatusGame.over;
        }
        if (playAudioCoin) Modules.PlayAudioClipFree(Modules.audioBuyCoin);
        else Modules.PlayAudioClipFree(Modules.audioButton);
    }

    public void ButtonCoinJetpackClick()
    {
        if (showErrorJetpack) return;
        bool playAudioCoin = false;
        if (!Modules.listJetpackUnlock.Contains(codeJetpackChoose))
        {
            int cost = Modules.IntParseFast(textValueJetpack.text);
            if (Modules.totalCoin >= cost)//neu du tien mua
            {
                playAudioCoin = true;
                ApllyTaskSpend(cost);
                TaskData.HandleTask(59, 1, 1);
                Modules.totalCoin -= cost;
                Modules.SaveCoin();
                textCoin.text = Modules.totalCoin.ToString();
                textValueJetpack.text = AllLanguages.heroSelected[Modules.indexLanguage];
                Modules.listJetpackUnlock.Add(codeJetpackChoose);
                Modules.SaveListJetpackUnlock();
                Modules.codeJetpackUse = codeJetpackChoose;
                Modules.SaveJetpackHero();
                Modules.statusGame = StatusGame.over;
                //xu ly hieu ung unlock
                StopAudioHero();
                backgroundContent.GetComponent<Animator>().SetTrigger("TriUnlockJetpack");
                GameObject myJetpackNow = Modules.GetModelUseItem(heroChooseShow.transform, "Rocket");
                //if (myJetpackNow != null)
                //myJetpackNow.GetComponent<CheckMatUnlock>().CheckNow();
                GameObject effectA = Instantiate(myJetpackNow.GetComponent<JetpackController>().effectUnlock, transform.parent.transform) as GameObject;
                effectA.transform.localPosition = pointShowEffectJetpack;
                effectA.transform.localScale = scaleShowEffectJetpack;
                effectA.transform.localEulerAngles = new Vector3(0, 90, 0);
                foreach (Transform tran in contentJetpack.transform)
                {
                    if (tran.GetComponent<ChangeImageClick>().codeObject == codeJetpackChoose)
                    {
                        tran.GetChild(1).gameObject.SetActive(false);
                        //tran.GetChild(2).GetComponent<CheckMatUnlock>().CheckNow();
                        GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                        effectB.transform.localPosition = pointShowThumEffect;
                        effectB.transform.localScale = scaleShowThumEffect;
                    }
                }
                Invoke("PlayBackgroundAudio", 3f);
                //xu ly xoa bo dung thu neu mua han
                if (Modules.listJetpackTrial.Contains(codeJetpackChoose))
                {
                    Modules.listJetpackTrial.Remove(codeJetpackChoose);
                    Modules.SaveListJetpackTrial();
                }
                if (Modules.codeJetpackTrying == codeJetpackChoose)
                    Modules.codeJetpackTrying = "";
                butTrialJetpack.SetActive(false);
            }
            else
                ShowMessageErrorJetpack(AllLanguages.heroNotEnough[Modules.indexLanguage]);
        }
        else
        {
            textValueJetpack.text = AllLanguages.heroSelected[Modules.indexLanguage];
            Modules.codeJetpackUse = codeJetpackChoose;
            Modules.SaveJetpackHero();
            Modules.statusGame = StatusGame.over;
        }
        if (playAudioCoin) Modules.PlayAudioClipFree(Modules.audioBuyCoin);
        else Modules.PlayAudioClipFree(Modules.audioButton);
    }

    public void ButtonCoinBoatClick()
    {
        if (showErrorBoat) return;
        bool playAudioCoin = false;
        if (!Modules.listBoatUnlock.Contains(codeBoatChoose))
        {
            int cost = Modules.IntParseFast(textValueBoat.text);
            if (Modules.totalCoin >= cost)//neu du tien mua
            {
                playAudioCoin = true;
                ApllyTaskSpend(cost);
                TaskData.HandleTask(121, Modules.listBoatUnlock.Count, 6);
                Modules.totalCoin -= cost;
                Modules.SaveCoin();
                textCoin.text = Modules.totalCoin.ToString();
                textValueBoat.text = AllLanguages.heroSelected[Modules.indexLanguage];
                Modules.listBoatUnlock.Add(codeBoatChoose);
                Modules.SaveListBoatUnlock();
                Modules.codeBoatUse = codeBoatChoose;
                Modules.SaveBoatHero();
                Modules.statusGame = StatusGame.over;
                //xu ly hieu ung unlock
                StopAudioHero();
                backgroundContent.GetComponent<Animator>().SetTrigger("TriUnlockBoat");
                GameObject myBoatNow = Modules.GetModelUseItem(heroChooseShow.transform, "Skis");
                //if (myBoatNow != null)
                //myBoatNow.GetComponent<CheckMatUnlock>().CheckNow();
                GameObject effectA = Instantiate(myBoatNow.GetComponent<BoatController>().effectUnlock, transform.parent.transform) as GameObject;
                effectA.transform.localPosition = pointShowEffectBoat;
                effectA.transform.localScale = scaleShowEffectBoat;
                effectA.transform.localEulerAngles = new Vector3(0, 90, 0);
                foreach (Transform tran in contentBoat.transform)
                {
                    if (tran.GetComponent<ChangeImageClick>().codeObject == codeBoatChoose)
                    {
                        tran.GetChild(1).gameObject.SetActive(false);
                        //tran.GetChild(2).GetComponent<CheckMatUnlock>().CheckNow();
                        GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                        effectB.transform.localPosition = pointShowThumEffect;
                        effectB.transform.localScale = scaleShowThumEffect;
                    }
                }
                Invoke("PlayBackgroundAudio", 3f);
                //xu ly xoa bo dung thu neu mua han
                if (Modules.listBoatTrial.Contains(codeBoatChoose))
                {
                    Modules.listBoatTrial.Remove(codeBoatChoose);
                    Modules.SaveListBoatTrial();
                }
                if (Modules.codeBoatTrying == codeBoatChoose)
                    Modules.codeBoatTrying = "";
                butTrialBoat.SetActive(false);
            }
            else
                ShowMessageErrorBoat(AllLanguages.heroNotEnough[Modules.indexLanguage]);
        }
        else
        {
            textValueBoat.text = AllLanguages.heroSelected[Modules.indexLanguage];
            Modules.codeBoatUse = codeBoatChoose;
            Modules.SaveBoatHero();
            Modules.statusGame = StatusGame.over;
        }
        if (playAudioCoin) Modules.PlayAudioClipFree(Modules.audioBuyCoin);
        else Modules.PlayAudioClipFree(Modules.audioButton);
    }

    public void ButtonTrialHeroClick()
    {
        string oldCode = Modules.codeHeroTrying;
        Modules.codeHeroTrying = codeHeroChoose;
        Modules.statusGame = StatusGame.over;
        foreach (Transform tran in contentHero.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject == oldCode)
                tran.GetChild(1).gameObject.SetActive(true);
            else if (tran.GetComponent<ChangeImageClick>().codeObject == codeHeroChoose)
            {
                tran.GetChild(1).gameObject.SetActive(false);
                GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                effectB.transform.localPosition = pointShowThumEffect;
                effectB.transform.localScale = scaleShowThumEffect;
            }
        }
        butTrialHero.SetActive(false);
    }

    public void ButtonTrialSkisClick()
    {
        string oldCode = Modules.codeSkisTrying;
        Modules.codeSkisTrying = codeSkisChoose;
        Modules.statusGame = StatusGame.over;
        foreach (Transform tran in contentSkis.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject == oldCode)
                tran.GetChild(1).gameObject.SetActive(true);
            else if (tran.GetComponent<ChangeImageClick>().codeObject == codeSkisChoose)
            {
                tran.GetChild(1).gameObject.SetActive(false);
                GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                effectB.transform.localPosition = pointShowThumEffect;
                effectB.transform.localScale = scaleShowThumEffect;
            }
        }
        butTrialSkis.SetActive(false);
    }

    public void ButtonTrialJetpackClick()
    {
        string oldCode = Modules.codeJetpackTrying;
        Modules.codeJetpackTrying = codeJetpackChoose;
        Modules.statusGame = StatusGame.over;
        foreach (Transform tran in contentJetpack.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject == oldCode)
                tran.GetChild(1).gameObject.SetActive(true);
            else if (tran.GetComponent<ChangeImageClick>().codeObject == codeJetpackChoose)
            {
                tran.GetChild(1).gameObject.SetActive(false);
                GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                effectB.transform.localPosition = pointShowThumEffect;
                effectB.transform.localScale = scaleShowThumEffect;
            }
        }
        butTrialJetpack.SetActive(false);
    }

    public void ButtonTrialBoatClick()
    {
        string oldCode = Modules.codeBoatTrying;
        Modules.codeBoatTrying = codeBoatChoose;
        Modules.statusGame = StatusGame.over;
        foreach (Transform tran in contentBoat.transform)
        {
            if (tran.GetComponent<ChangeImageClick>().codeObject == oldCode)
                tran.GetChild(1).gameObject.SetActive(true);
            else if (tran.GetComponent<ChangeImageClick>().codeObject == codeBoatChoose)
            {
                tran.GetChild(1).gameObject.SetActive(false);
                GameObject effectB = Instantiate(Modules.parUnlockB, tran) as GameObject;
                effectB.transform.localPosition = pointShowThumEffect;
                effectB.transform.localScale = scaleShowThumEffect;
            }
        }
        butTrialBoat.SetActive(false);
    }

    void ApllyTaskSpend(int cost)
    {
        TaskData.HandleTask(53, cost, 50000);
        TaskData.HandleTask(64, cost, 80000);
        TaskData.HandleTask(94, cost, 2000000);
        TaskData.HandleTask(124, cost, 400000);
        TaskData.HandleTask(135, cost, 800000);
        TaskData.HandleTask(156, cost, 900000);
    }

    public void ButtonBuyHeroClick(bool playAudio = true)
    {
        if (playAudio) Modules.PlayAudioClipFree(Modules.audioButton);
        panelBuyHero.SetActive(true);
        panelBuyHeroList.SetActive(true);
        panelBuySkis.SetActive(false);
        panelBuySkisList.SetActive(false);
        panelBuyJetpack.SetActive(false);
        panelBuyJetpackList.SetActive(false);
        panelBuyBoat.SetActive(false);
        panelBuyBoatList.SetActive(false);
        LoadListHero();
        LoadHeroChoose();
        Modules.useRocket = false;
        Modules.useBoat = false;
    }

    public void ButtonBuySkisClick(bool playAudio = true)
    {
        if (playAudio) Modules.PlayAudioClipFree(Modules.audioButton);
        panelBuyHero.SetActive(false);
        panelBuyHeroList.SetActive(false);
        panelBuySkis.SetActive(true);
        panelBuySkisList.SetActive(true);
        panelBuyJetpack.SetActive(false);
        panelBuyJetpackList.SetActive(false);
        panelBuyBoat.SetActive(false);
        panelBuyBoatList.SetActive(false);
        LoadListSkis();
        LoadSkisChoose();
        Modules.useRocket = false;
        Modules.useBoat = false;
    }

    public void ButtonBuyJetpackClick(bool playAudio = true)
    {
        if (playAudio) Modules.PlayAudioClipFree(Modules.audioButton);
        panelBuyHero.SetActive(false);
        panelBuyHeroList.SetActive(false);
        panelBuySkis.SetActive(false);
        panelBuySkisList.SetActive(false);
        panelBuyJetpack.SetActive(true);
        panelBuyJetpackList.SetActive(true);
        panelBuyBoat.SetActive(false);
        panelBuyBoatList.SetActive(false);
        LoadListJetpack();
        LoadJetpackChoose();
        Modules.useRocket = true;
        Modules.useBoat = false;
    }

    public void ButtonBuyBoatClick(bool playAudio = true)
    {
        if (playAudio) Modules.PlayAudioClipFree(Modules.audioButton);
        panelBuyHero.SetActive(false);
        panelBuyHeroList.SetActive(false);
        panelBuySkis.SetActive(false);
        panelBuySkisList.SetActive(false);
        panelBuyJetpack.SetActive(false);
        panelBuyJetpackList.SetActive(false);
        panelBuyBoat.SetActive(true);
        panelBuyBoatList.SetActive(true);
        LoadListBoat();
        LoadBoatChoose();
        Modules.useRocket = false;
        Modules.useBoat = true;
    }

    public void ButtonPlayClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.autoTapPlay = true;
        Modules.containMainGame.SetActive(true);
        Modules.containHeroConstruct.SetActive(false);
        if (Modules.statusGame == StatusGame.over)
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
        else Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().CheckTapNow();
        Modules.useRocket = false;
    }

    public void ButtonGoHomeClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containMainGame.SetActive(true);
        Modules.containHeroConstruct.SetActive(false);
        if (Modules.statusGame == StatusGame.over)
            Modules.containMainGame.transform.Find("CamContent").GetComponentInChildren<PageMainGame>().ResetGame();
        Modules.useRocket = false;
    }

    public void ButtonRankClick()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.containHeroConstruct.SetActive(false);
        Modules.containAchievement.SetActive(true);
        Modules.containAchievement.transform.Find("MainCamera").GetComponent<PageAchievement>().CallStart();
        Modules.useRocket = false;
    }

    void Update()
    {
        if (panelBuySkis.activeSelf || panelBuyBoat.activeSelf)
        {
            if (timeRunJump < curveJump.length)
            {
                heroChooseShow.transform.position = new Vector3(heroChooseShow.transform.position.x, originPointJump + curveJump.Evaluate(timeRunJump), heroChooseShow.transform.position.z);
                timeRunJump += Time.deltaTime;
            }
            if (heroChooseShow != null && mesFakeJump)
            {
                HeroController heroNow = heroChooseShow.GetComponent<HeroController>();
                if (!heroNow.aniHero.isPlaying)
                {
                    mesFakeJump = false;
                    if (panelBuySkis.activeSelf)
                    {
                        if (heroNow.mySkis.GetComponent<SkisController>().isHoverbike)
                            heroNow.CallAniMenu(heroNow.aniRunCable, 1f);
                        else
                            heroNow.CallAniMenu(heroNow.aniRunSkis, 1f);
                    }
                    else
                        heroNow.CallAniMenu(heroNow.aniRunBoat, 1f);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            ButtonGoHomeClick();
    }

    //xu ly ngon ngu
    public Text textCharactersA, textCharactersB, textCharactersC, textCharactersD;
    public Text textHoverboardA, textHoverboardB, textHoverboardC, textHoverboardD;
    public Text textJetpackA, textJetpackB, textJetpackC, textJetpackD;
    public Text textBoatA, textBoatB, textBoatC, textBoatD;
    public Text textPlay, textTrialHero, textTrialSkis, textTrialJetpack, textTrialBoat;
    public void ChangeAllLanguage()
    {
        int iLang = Modules.indexLanguage;
        textPlay.font = AllLanguages.listFontLangA[iLang];
        textPlay.text = AllLanguages.menuPlay[iLang];
        textCharactersA.font = AllLanguages.listFontLangA[iLang];
        textCharactersA.text = AllLanguages.heroCharacters[iLang];
        textCharactersB.font = AllLanguages.listFontLangA[iLang];
        textCharactersB.text = AllLanguages.heroCharacters[iLang];
        textCharactersC.font = AllLanguages.listFontLangA[iLang];
        textCharactersC.text = AllLanguages.heroCharacters[iLang];
        textCharactersD.font = AllLanguages.listFontLangA[iLang];
        textCharactersD.text = AllLanguages.heroCharacters[iLang];
        textHoverboardA.font = AllLanguages.listFontLangA[iLang];
        textHoverboardA.text = AllLanguages.heroHoverboard[iLang];
        textHoverboardB.font = AllLanguages.listFontLangA[iLang];
        textHoverboardB.text = AllLanguages.heroHoverboard[iLang];
        textHoverboardC.font = AllLanguages.listFontLangA[iLang];
        textHoverboardC.text = AllLanguages.heroHoverboard[iLang];
        textHoverboardD.font = AllLanguages.listFontLangA[iLang];
        textHoverboardD.text = AllLanguages.heroHoverboard[iLang];
        textJetpackA.font = AllLanguages.listFontLangA[iLang];
        textJetpackA.text = AllLanguages.heroJetpack[iLang];
        textJetpackB.font = AllLanguages.listFontLangA[iLang];
        textJetpackB.text = AllLanguages.heroJetpack[iLang];
        textJetpackC.font = AllLanguages.listFontLangA[iLang];
        textJetpackC.text = AllLanguages.heroJetpack[iLang];
        textJetpackD.font = AllLanguages.listFontLangA[iLang];
        textJetpackD.text = AllLanguages.heroJetpack[iLang];
        textBoatA.font = AllLanguages.listFontLangA[iLang];
        textBoatA.text = AllLanguages.heroBoat[iLang];
        textBoatB.font = AllLanguages.listFontLangA[iLang];
        textBoatB.text = AllLanguages.heroBoat[iLang];
        textBoatC.font = AllLanguages.listFontLangA[iLang];
        textBoatC.text = AllLanguages.heroBoat[iLang];
        textBoatD.font = AllLanguages.listFontLangA[iLang];
        textBoatD.text = AllLanguages.heroBoat[iLang];
        textTrialHero.font = AllLanguages.listFontLangA[iLang];
        textTrialHero.text = AllLanguages.heroTrial[iLang];
        textTrialSkis.font = AllLanguages.listFontLangA[iLang];
        textTrialSkis.text = AllLanguages.heroTrial[iLang];
        textTrialJetpack.font = AllLanguages.listFontLangA[iLang];
        textTrialJetpack.text = AllLanguages.heroTrial[iLang];
        textTrialBoat.font = AllLanguages.listFontLangA[iLang];
        textTrialBoat.text = AllLanguages.heroTrial[iLang];
        //update font khac
        textNoteHero.font = AllLanguages.listFontLangB[iLang];
        textNoteSkis.font = AllLanguages.listFontLangB[iLang];
        textValueHero.font = AllLanguages.listFontLangA[iLang];
        textValueSkis.font = AllLanguages.listFontLangA[iLang];
    }
}
