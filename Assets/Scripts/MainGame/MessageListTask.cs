using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageListTask : MonoBehaviour {

    public Text textTitle, textNote;
    public GameObject containNote, containIcon;
    private List<GameObject> listLockIcon = new List<GameObject>();
    private List<GameObject> listTickIcon = new List<GameObject>();
    public GameObject containTask, bgFront;
    private List<GameObject> listTextIndex = new List<GameObject>();
    private List<GameObject> listTickIndex = new List<GameObject>();
    private List<Text> listTextContent = new List<Text>();
    private bool firstTime = true;

    void GetObjectStart()
    {
        if (!firstTime) return;
        firstTime = false;
        foreach (Transform tran in containIcon.transform)
        {
            listLockIcon.Add(tran.GetChild(1).gameObject);
            listTickIcon.Add(tran.GetChild(2).gameObject);
        }
        foreach (Transform tran in containTask.transform)
        {
            listTextIndex.Add(tran.GetChild(0).GetChild(0).gameObject);
            listTickIndex.Add(tran.GetChild(0).GetChild(1).gameObject);
            listTextContent.Add(tran.GetChild(1).GetComponent<Text>());
        }
    }

    public void StartShowMessage()
    {
        GetObjectStart();
        int iLang = Modules.indexLanguage;
        textTitle.font = AllLanguages.listFontLangA[iLang];
        textTitle.text = LanguageTask.taskTitle[iLang];
        textNote.font = AllLanguages.listFontLangB[iLang];
        textNote.text = LanguageTask.taskNote[iLang];
        ResetActive();
        UpdateStatePage();
    }

    private void UpdateStatePage()
    {
        listLockIcon[TaskData.pageTask].SetActive(false);
        listTickIcon[TaskData.pageTask].SetActive(false);
        for (int i = 0; i < TaskData.pageTask; i++)
        {
            listLockIcon[i].SetActive(false);
            listTickIcon[i].SetActive(true);
        }
        for (int i = TaskData.pageTask + 1; i < containIcon.transform.childCount; i++)
        {
            listLockIcon[i].SetActive(true);
            listTickIcon[i].SetActive(false);
        }
    }

    public void ClickShowList(int index)
    {
        if (index > TaskData.pageTask) return;
        //xu ly 10 task cuoi khong cho skip
        string textSkip = " (" + TaskData.diamondSkip.ToString() + " " + LanguageTask.taskSkipNote[Modules.indexLanguage] + ")";
        if (index >= TaskData.maxPage)
            textSkip = " (" + LanguageTask.taskCantSkip[Modules.indexLanguage] + ")";
        //xu ly noi dung chinh
        TaskData.pageTaskShow = index;
        int iLang = Modules.indexLanguage;
        int indexText = index * TaskData.listTask.Count;
        if (index == TaskData.pageTask)
        {
            int numTaskInPage = TaskData.listTask.Count;
            if (index >= containIcon.transform.childCount - 1)
            {
                int numMore = LanguageTask.taskContent.Count % containIcon.transform.childCount;
                if (numMore != 0) numTaskInPage = numMore;
            }
            for (int i = 0; i < numTaskInPage; i++)
            {
                listTextContent[i].font = AllLanguages.listFontLangB[iLang];
                if (TaskData.listTask[i] == 1)
                {
                    listTextIndex[i].SetActive(false);
                    listTickIndex[i].SetActive(true);
                    listTextContent[i].text = LanguageTask.taskContent[indexText + i][iLang];
                }
                else
                {
                    listTextIndex[i].SetActive(true);
                    listTickIndex[i].SetActive(false);
                    listTextContent[i].text = LanguageTask.taskContent[indexText + i][iLang] + textSkip;
                }
            }
        }
        else if (index < TaskData.pageTask)
        {
            for (int i = 0; i < TaskData.listTask.Count; i++)
            {
                listTextIndex[i].SetActive(false);
                listTickIndex[i].SetActive(true);
                listTextContent[i].font = AllLanguages.listFontLangB[iLang];
                listTextContent[i].text = LanguageTask.taskContent[indexText + i][iLang];
            }
        }
        containNote.SetActive(false);
        bgFront.SetActive(false);
        containIcon.SetActive(false);
        containTask.SetActive(true);
    }

    public void ButtonCloseMessage()
    {
        Modules.PlayAudioClipFree(Modules.audioButton);
        if (containTask.activeSelf)
        {
            ResetActive();
            UpdateStatePage();
        }
        else transform.gameObject.GetComponent<Animator>().SetTrigger("TriClose");
    }

    void ResetActive()
    {
        containNote.SetActive(true);
        bgFront.SetActive(true);
        containIcon.SetActive(true);
        containTask.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (transform.gameObject.activeSelf)
                ButtonCloseMessage();
        }
    }
}
