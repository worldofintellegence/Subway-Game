using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public List<GameObject> listPlane = new List<GameObject>();
    public float timeCheck = 10f;//tinh theo giay
    [Range(0, 100)]
    public int percentShow = 100;//tu 0 den 100

    //void Start()
    //{
    //    CallPlaneStart();
    //}
    public void RemoveCallPlane()
    {
        CancelInvoke("CallPlane");
    }

    public void CallPlaneStart()
    {
        CancelInvoke("CallPlane");
        Invoke("CallPlane", timeCheck);
    }

    public void RemoveAllPlane()
    {
        for (int i = 0; i < listPlane.Count; i++)
            listPlane[i].SetActive(false);
    }

    void CallPlane()
    {
        if (!Modules.containMainGame.activeSelf || Modules.useTemple)
        {
            Invoke("CallPlane", timeCheck);
            return;
        }
        int ran = Random.Range(0, 100);
        if (ran < percentShow)//neu trong ty le hien thi
        {
            List<int> listTemp = new List<int>();
            for (int i = 0; i < listPlane.Count; i++)
            {
                if (!listPlane[i].activeSelf) listTemp.Add(i);
            }
            if (listTemp.Count > 0)
            {
                int indexRan = Random.Range(0, listTemp.Count);
                listPlane[listTemp[indexRan]].SetActive(true);
                listPlane[listTemp[indexRan]].GetComponent<PlaneFly>().CallStart();
            }
        }
        Invoke("CallPlane", timeCheck);
    }
}
