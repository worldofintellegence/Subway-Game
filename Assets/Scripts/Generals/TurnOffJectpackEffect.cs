using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffJectpackEffect : MonoBehaviour {

    public List<GameObject> listEffect;
	void Start () {
        if (!Modules.containMainGame.activeSelf)
            foreach (GameObject go in listEffect)
                go.SetActive(false);
	}
}
