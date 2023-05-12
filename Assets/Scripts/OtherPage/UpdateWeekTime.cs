using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeekTime : MonoBehaviour {

    public Text textWeek;
    public Text textTimeLeft;

    void OnEnable()
    {
        textWeek.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        textTimeLeft.font = AllLanguages.listFontLangB[Modules.indexLanguage];
        CancelInvoke("UpdateTimeLeft");
        InvokeRepeating("UpdateTimeLeft", 1, 1);
    }

    void UpdateTimeLeft()
    {
        if (Camera.main.GetComponent<PageAchievement>() == null) return;
        textWeek.text = Camera.main.GetComponent<PageAchievement>().GetInfoWeek();
        textTimeLeft.text = Camera.main.GetComponent<PageAchievement>().GetInfoTimeLeft();
    }
}
