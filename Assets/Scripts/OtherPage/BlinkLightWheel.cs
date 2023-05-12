using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLightWheel : MonoBehaviour {

    public GameObject containLight;
    public float timeBlink = 0.1f;
    private List<GameObject> lightOn = new List<GameObject>();
    //xu ly hieu ung chay blink
    private int codeType = 0;//kieu chay 0, 1, 2, 3...
    private int runBlink = 0;
    private int timeEvenOdd = 0;

    void Start()
    {
        foreach (Transform tran in containLight.transform)
        {
            lightOn.Add(tran.GetChild(1).gameObject);
        }
        //CallStart();
    }

    public void CallStart()
    {
        foreach (GameObject go in lightOn) go.SetActive(false);
        codeType = 0;
        runBlink = 0;
        timeEvenOdd = 0;
        CancelInvoke("BlinkStepLight");
        Invoke("BlinkStepLight", timeBlink);
    }

    void BlinkStepLight()
    {
        if (codeType == 0)//kieu bat lan luot
        {
            if (runBlink < lightOn.Count)
            {
                lightOn[runBlink].SetActive(true);
                runBlink++;
            }
            else
            {
                codeType++;
                runBlink = 0;
            }
        }
        else if (codeType == 1)//kieu tat lan luot
        {
            if (runBlink < lightOn.Count)
            {
                lightOn[runBlink].SetActive(false);
                runBlink++;
            }
            else
            {
                codeType++;
                runBlink = 0;
            }
        }
        else if (codeType == 2)//kieu nhap nhay xen ke chan
        {
            if (runBlink < 1)
            {
                for (int i = 0; i < lightOn.Count; i++)
                {
                    if (i % 2 == 0)
                        lightOn[i].SetActive(true);
                    else lightOn[i].SetActive(false);
                }
                runBlink++;
            }
            else
            {
                codeType++;
                runBlink = 0;
            }
        }
        else if (codeType == 3)//kieu nhap nhay xen ke le
        {
            if (runBlink < 1)
            {
                for (int i = 0; i < lightOn.Count; i++)
                {
                    if (i % 2 == 0)
                        lightOn[i].SetActive(false);
                    else lightOn[i].SetActive(true);
                }
                runBlink++;
            }
            else
            {
                if (timeEvenOdd < 10)
                {
                    codeType = 2;
                    timeEvenOdd++;
                }
                else
                {
                    codeType = 0;
                    timeEvenOdd = 0;
                }
                runBlink = 0;
            }
        }
        Invoke("BlinkStepLight", timeBlink);
	}
}
