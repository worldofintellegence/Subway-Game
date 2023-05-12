using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PageHighScore : MonoBehaviour {

    public Text textHighScore;
    public Vector3 pointBeginHero, pointShowHero;
    public Vector3 angleBeginHero;
    public Vector3 scaleHero;
    public float speedMove = 3f;
    private GameObject myHero;

    public void CallStart()
    {
        //Modules.FreeMemoryNow();
        TaskData.HandleTask(24, 1, 1);
        ChangeAllLanguage();
        textHighScore.GetComponent<EffectUpScore>().StartEffect(Modules.totalScore);
        if (myHero != null)
        {
            myHero.GetComponent<ShadowFixed>().RemoveShadow();
            Destroy(myHero); 
        }
        foreach (GameObject go in Modules.listHeroUse)
        {
            HeroController heroCon = go.GetComponent<HeroController>();
            if (heroCon.idHero == Modules.codeHeroUse)
            {
                myHero = Instantiate(go, pointBeginHero, Quaternion.Euler(angleBeginHero)) as GameObject;
                myHero.transform.parent = Modules.containHighScore.transform;
                myHero.transform.localScale = scaleHero;
                HeroController heroNow = myHero.GetComponent<HeroController>();
                heroNow.SetupShowMenu(1);
                heroNow.CallAniMenu(heroNow.aniRunNormal, 1f);
                break;
            }
        }
        Modules.PlayAudioClipLoop(Modules.audioBGOpenBox, Camera.main.transform);
    }

    void Update()
    {
        float step = speedMove * Time.deltaTime;
       // myHero.transform.position = Vector3.MoveTowards(myHero.transform.position, pointShowHero, step);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TapToContinue();
        }
    }

    public void TapToContinue()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        Modules.CheckNextPageGameOver(Modules.containHighScore);
    }

    //xu ly ngon ngu
    public Text textTitleHighScore, textTapToContinue;
    public void ChangeAllLanguage()
    {
        int iLang = Modules.indexLanguage;
        textTitleHighScore.font = AllLanguages.listFontLangA[iLang];
        textTitleHighScore.text = AllLanguages.otherNewHighScore[iLang];
        textTapToContinue.font = AllLanguages.listFontLangA[iLang];
        textTapToContinue.text = AllLanguages.otherTapContinue[iLang];
    }
}
