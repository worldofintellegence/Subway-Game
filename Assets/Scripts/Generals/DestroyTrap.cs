using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrap : MonoBehaviour {

    public GameObject effectDestroy;
    public GameObject parentTrap;

    public void DestroyMyTrap()
    {
        int numDeduction = Random.Range(10, 30);
        Modules.ExploTrapBoom(numDeduction);
        Instantiate(effectDestroy, parentTrap.transform.parent.transform);
        parentTrap.SetActive(false);
    }
}
