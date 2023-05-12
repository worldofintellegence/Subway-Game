using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFlyCam : MonoBehaviour {

    public List<GameObject> listFlyCam = new List<GameObject>();
    public List<GameObject> listTrap = new List<GameObject>();
    public List<GameObject> listSeaTrap = new List<GameObject>();
    [Range(0, 100)]
    public int percentCall = 10;
    public float timeCall = 10f;//10 giay goi thu 1 lan
    public int minTrap = 3;
    public int maxTrap = 5;
    public int minSlow = 3;
    public int maxSlow = 5;

    void Start()
    {
        Modules.listFlyCam = listFlyCam;
        Modules.listTrap = listTrap;
        Modules.listSeaTrap = listSeaTrap;
    }

    void CallFly()
    {
        if (Modules.statusGame != StatusGame.play || (Modules.gameGuide == "YES" && Modules.stepGuide <= 3) || Modules.useBonus || Modules.useTemple || Modules.useTakeBag)
        {
            Invoke("CallFly", timeCall);
            return;
        }
        int ran = Random.Range(0, 100);
        if (ran >= percentCall)
        {
            Invoke("CallFly", timeCall);
            return;
        }
        CallFlyNow();
    }

    void CallFlyNow()
    {
        foreach (GameObject go in Modules.listFlyCam)
        {
            if (go.activeSelf)
            {
                Invoke("CallFly", timeCall);
                return;
            }
        }
        int count = 0;
        while (count < 5)
        {
            int index = Random.Range(0, Modules.listFlyCam.Count);
            if (!Modules.listFlyCam[index].activeSelf)
            {
                Modules.listFlyCam[index].SetActive(true);
                Modules.listFlyCam[index].GetComponent<FlyCamController>().StartFlyCam(Random.Range(minTrap, maxTrap), Random.Range(minSlow, maxSlow));
                break;
            }
            count++;
        }
        Invoke("CallFly", timeCall);
    }

    public void StartFlyCam()
    {
        CancelInvoke("CallFly");
        Invoke("CallFly", timeCall);
    }

    public void StartFlyCamNow()
    {
        CancelInvoke("CallFly");
        CallFlyNow();
    }

    public void ResetFlyCam()
    {
        CancelInvoke("CallFly");
        foreach (GameObject go in Modules.listFlyCam)
        {
            go.transform.parent = Modules.containFlyCam.transform;
            go.SetActive(false);
        }
        foreach (GameObject go in Modules.listTrap)
        {
            go.transform.parent = Modules.containTraps.transform;
            go.SetActive(false);
        }
        foreach (GameObject go in Modules.listSeaTrap)
        {
            go.transform.parent = Modules.containSeaTraps.transform;
            go.SetActive(false);
        }
    }
}
