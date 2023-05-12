using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTaskController : MonoBehaviour {

	public GameObject messageBox;
    public GameObject messageRemid;
    public Text textDetails, textRemid;
    public Text textMessage;

    void Start()
    {
        messageBox.SetActive(false);
    }

    public void ShowMessageTask(int indexTask)
    {
        if (!Modules.containMainGame.activeSelf) return;
        int iLang = Modules.indexLanguage;
        messageBox.SetActive(true);
        messageBox.GetComponent<Animator>().SetTrigger("TriPlay");
        textDetails.font = AllLanguages.listFontLangA[iLang];
        textDetails.text = LanguageTask.taskContent[indexTask][iLang];
        textMessage.font = AllLanguages.listFontLangA[iLang];
        textMessage.text = LanguageTask.taskMessage[iLang];
        AutoShowRemidTask();
    }

    public void ShowMessageRemid(int indexRemid)
    {
        if (!Modules.containMainGame.activeSelf) return;
        int iLang = Modules.indexLanguage;
        messageRemid.SetActive(true);
        messageRemid.GetComponent<Animator>().SetTrigger("TriPlay");
        textRemid.font = AllLanguages.listFontLangA[iLang];
        textRemid.text = LanguageTask.taskContent[indexRemid][iLang];
    }

    public void AutoShowRemidTask()
    {
        CancelInvoke("ShowRemid");
        Invoke("ShowRemid", 5f);
    }

    private void ShowRemid()
    {
        for (int i = 0; i < TaskData.listTask.Count; i++)
        {
            if (TaskData.listTask[i] == 0)
            {
                ShowMessageRemid(TaskData.pageTask * TaskData.listTask.Count + i);
                break;
            }
        }
    }
}
