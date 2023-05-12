using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffHoverbike : MonoBehaviour {

    void OnEnable()
    {
        if (!Modules.allowHoverbike)
            gameObject.SetActive(false);
    }
}
