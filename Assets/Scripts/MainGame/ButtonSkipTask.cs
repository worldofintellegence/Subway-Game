using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkipTask : MonoBehaviour {

    public int indexBut;
    public Text textDetails;
    public GameObject tickText, tickIcon;
    public Color colorTextOrigin;
    public Color colorNotEnough;
    public Color colorButDisable;
    public Color colorButEnable;
    private int indexTask = 0;

    void OnEnable()
    {
        CancelInvoke("SetNormalText");
        textDetails.color = colorTextOrigin;
        transform.GetChild(0).GetComponent<Text>().font = AllLanguages.listFontLangA[Modules.indexLanguage];
        transform.GetChild(0).GetComponent<Text>().text = LanguageTask.taskButSkip[Modules.indexLanguage];
        indexTask = TaskData.pageTask * TaskData.listTask.Count + indexBut;
        if (TaskData.pageTaskShow == TaskData.pageTask)
        {
            if (TaskData.listTask[indexBut] == 0)//neu chua hoan thanh
            {
                transform.GetComponent<Image>().color = colorButEnable;
                transform.GetComponent<Button>().interactable = true;
            }
            else//neu hoan thanh roi
            {
                transform.GetComponent<Image>().color = colorButDisable;
                transform.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            transform.GetComponent<Image>().color = colorButDisable;
            transform.GetComponent<Button>().interactable = false;
        }
        if (TaskData.pageTaskShow >= TaskData.maxPage)
        {
            transform.GetComponent<Image>().color = colorButDisable;
            transform.GetComponent<Button>().interactable = false;
        }
    }

    public void ClickSkipTask()
    {
        if (Modules.totalCoin >= TaskData.diamondSkip)//neu du tien
        {
            TaskData.HandleTask(53, TaskData.diamondSkip, 50000);
            TaskData.HandleTask(64, TaskData.diamondSkip, 80000);
            TaskData.HandleTask(94, TaskData.diamondSkip, 2000000);
            TaskData.HandleTask(124, TaskData.diamondSkip, 400000);
            TaskData.HandleTask(135, TaskData.diamondSkip, 800000);
            TaskData.HandleTask(156, TaskData.diamondSkip, 900000);
            Modules.totalCoin -= TaskData.diamondSkip;
            Modules.SaveCoin();
            TaskData.UpdateTaskDone(indexTask);
            tickText.SetActive(false);
            tickIcon.SetActive(true);
            transform.GetComponent<Image>().color = colorButDisable;
            transform.GetComponent<Button>().interactable = false;
        }
        else//neu khong du tien
        {
            textDetails.text = LanguageTask.taskNotEnough[Modules.indexLanguage];
            textDetails.color = colorNotEnough;
            Invoke("SetNormalText", 2f);
        }
    }

    void SetNormalText()
    {
        textDetails.text = LanguageTask.taskContent[indexTask][Modules.indexLanguage] + " (" + TaskData.diamondSkip.ToString() + " " + LanguageTask.taskSkipNote[Modules.indexLanguage] + ")";
        textDetails.color = colorTextOrigin;
    }
}
