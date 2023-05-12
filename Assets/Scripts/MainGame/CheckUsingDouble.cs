using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUsingDouble : MonoBehaviour {

    private bool oldStatus = false;

    void Start()
    {
#if (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0) && !UNITY_EDITOR
        ChangeMat();
#endif
    }

    void FixedUpdate()
    {
        if (oldStatus == Modules.useDouble) return;
        oldStatus = Modules.useDouble;
        ChangeMat();
    }

    void ChangeMat()
    {
        //thuc hien doi mat
        Mesh mesNow = Modules.mesCoinNormal;
        Material matNow = Modules.matCoinNormal;
        if (oldStatus == true)
        {
            mesNow = Modules.mesCoinDouble;
            matNow = Modules.matCoinDouble;
        }
        transform.GetComponent<MeshFilter>().mesh = mesNow;
        transform.GetComponent<Renderer>().material = matNow;
    }
}
