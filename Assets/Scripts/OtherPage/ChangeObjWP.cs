using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjWP : MonoBehaviour {

    public GameObject objDefault, objWP;
    void Start()
    {
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
        objDefault.SetActive(false);
        objWP.SetActive(true);
#endif
    }
}
