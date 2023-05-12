using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoHideText : MonoBehaviour {

    private int minWidth = 70;
    void Update()
    {
        if (transform.GetComponent<RectTransform>().rect.width < minWidth)
            transform.GetComponent<Text>().enabled = false;
        else transform.GetComponent<Text>().enabled = true;
    }
}
