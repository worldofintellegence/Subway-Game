using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskData : MonoBehaviour {

    public static int pageTask = 0;//danh dau trang nhiem vu hien tai
    public static int pageTaskShow = 0;//danh dau page task dang xem
    public static List<int> listTask = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//danh dau trang thai cac nhiem vu trong page task
    public static int maxPage = 15;//neu thay doi so page task thi phai thay doi ca o day
    private static float[] countVar = new float[160];
    public static float countTimeStay = 0;
    public static float countTimeRun = 0;
    public static float countScoreNoDiamond = 0;
    public static float countScoreNoJump = 0;
    public static float countScoreNoItem = 0;
    public static int diamondSkip = 5000;

    public static void LoadDataTask()
    {
        //load data task
        string dataPageTask = SaveLoadData.LoadData("SaveTaskPage", true);
        if (dataPageTask == "") dataPageTask = "0";
        pageTask = Modules.IntParseFast(dataPageTask);
        string dataListTask = SaveLoadData.LoadData("SaveTaskList", true);
        if (dataListTask == "") dataListTask = "0;0;0;0;0;0;0;0;0;0";
        string[] dataSplitTask = dataListTask.Split(';');
        for (int i = 0; i < dataSplitTask.Length; i++)
            listTask[i] = Modules.IntParseFast(dataSplitTask[i]);
        //loai lai cac task co nhu cau luu tru
        string task114 = SaveLoadData.LoadData("SaveTask114", true);
        if (task114 == "") task114 = "0";
        countVar[114] = Modules.IntParseFast(task114);
    }

    public static void SaveTaskData()
    {
        SaveLoadData.SaveData("SaveTaskPage", pageTask.ToString(), true);
        string dataList = "";
        for (int i = 0; i < listTask.Count; i++)
        {
            dataList += listTask[i].ToString();
            if (i < listTask.Count - 1) dataList += ";";
        }
        SaveLoadData.SaveData("SaveTaskList", dataList, true);
    }

    public static void ResetOneRun()
    {
        countTimeRun = 0;
        if (pageTask == 0)
        {
            countVar[1] = 0;
            countVar[7] = 0;
            countVar[8] = 0;
        }
        else if (pageTask == 1)
        {
            countVar[12] = 0;
            countVar[16] = 0;
            countVar[18] = 0;
            countVar[19] = 0;
        }
        else if (pageTask == 2)
        {
            countVar[25] = 0;
            countVar[26] = 0;
            countVar[27] = 0;
        }
        else if (pageTask == 4)
        {
            countVar[42] = 0;
            countVar[43] = 0;
            countVar[44] = 0;
            countVar[45] = 0;
            countVar[49] = 0;
        }
        else if (pageTask == 5)
        {
            countVar[50] = 0;
            countVar[52] = 0;
            countVar[55] = 0;
        }
        else if (pageTask == 6)
        {
            countVar[65] = 0;
        }
        else if (pageTask == 7)
        {
            countVar[74] = 0;
            countVar[76] = 0;
            countVar[78] = 0;
        }
        else if (pageTask == 8)
        {
            countVar[85] = 0;
        }
        else if (pageTask == 9)
        {
            countVar[99] = 0;
        }
        else if (pageTask == 10)
        {
            countVar[107] = 0;
            countVar[109] = 0;
        }
        else if (pageTask == 11)
        {
            countVar[119] = 0;
        }
        else if (pageTask == 12)
        {
            countVar[120] = 0;
            countVar[122] = 0;
            countVar[123] = 0;
            countVar[125] = 0;
        }
        else if (pageTask == 13)
        {
            countVar[130] = 0;
            countVar[136] = 0;
        }
        else if (pageTask == 14)
        {
            countVar[140] = 0;
            countVar[148] = 0;
            countVar[149] = 0;
        }
        else if (pageTask == 15)
        {
            countVar[151] = 0;
            countVar[152] = 0;
            countVar[155] = 0;
            countVar[157] = 0;
        }
    }

    public static bool CheckTaskDone(int index)
    {
        bool result = true;
        int numPage = index / listTask.Count;
        if (numPage == pageTask)
        {
            int indexInPage = index % listTask.Count;
            if (listTask[indexInPage] == 0)
                result = false;
        }
        return result;
    }

    public static int newTaskDone = -1;
    public static bool newTaskPage = false;
    public static void UpdateTaskDone(int indexTask)
    {
        int indexInPage = indexTask % listTask.Count;
        listTask[indexInPage] = 1;
        Modules.PlayAudioClipFree(Modules.audioTaskDone);
        //xu ly hien thi message task done
        if (Modules.containMainGame.activeSelf && Camera.main.GetComponent<PageMainGame>().containUIPlay.activeSelf)
            Modules.containMainGame.GetComponent<MessageTaskController>().ShowMessageTask(indexTask);
        else
            newTaskDone = indexTask;
        foreach (int var in listTask)
        {
            if (var == 0)
            {
                SaveTaskData();
                return;
            }
        }
        pageTask++;
        if (pageTask > maxPage)
            pageTask = maxPage;
        for (int i = 0; i < listTask.Count; i++)
            listTask[i] = 0;
        SaveTaskData();
        //xu ly hieu ung va thuong khi hoanh thanh page task
        if (Modules.containMainGame.activeSelf)
        {
            //thuc hien hieu ung thuong 1 scratch card sau khi hoan thanh 1 page task
            Modules.BonusMissionsChallenge(6, LanguageTask.taskTitleBonus[Modules.indexLanguage], 1, Vector3.zero, true);
        }
        else
            newTaskPage = true;
    }

    public static void HandleTask(int indexTask, float numX, float maxValue, float minValue = 0)
    {
        if (!CheckTaskDone(indexTask))
        {
            countVar[indexTask] += numX;
            if (countVar[indexTask] < minValue)
                countVar[indexTask] = minValue;
            if (countVar[indexTask] >= maxValue)
                UpdateTaskDone(indexTask);
        }
    }

    public static void HandleTaskSave(int indexTask, float numX, float maxValue, float minValue = 0)
    {
        if (!CheckTaskDone(indexTask))
        {
            countVar[indexTask] += numX;
            if (countVar[indexTask] < minValue)
                countVar[indexTask] = minValue;
            if (countVar[indexTask] >= maxValue)
                UpdateTaskDone(indexTask);
            SaveTaskValue(indexTask);
        }
    }

    public static void HandleTaskStay(int indexTask, float numX, float maxValue)
    {
        if (!CheckTaskDone(indexTask))
        {
            if (numX >= maxValue)
                UpdateTaskDone(indexTask);
        }
    }

    public static void HandleTaskLess(int indexTask, float numX, float minValue)
    {
        if (!CheckTaskDone(indexTask))
        {
            if (numX <= minValue)
                UpdateTaskDone(indexTask);
        }
    }

    public static void SaveTaskValue(int indexTask)//luu lai cac task co nhu cau luu tru
    {
        SaveLoadData.SaveData("SaveTask" + indexTask.ToString(), countVar[indexTask].ToString(), true);
    }
}
