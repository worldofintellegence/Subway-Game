using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSizeDelta : MonoBehaviour {

    public GameObject objFollow;
    private float oldWith = 0;

    void LateUpdate()
    {
        RectTransform rect = objFollow.GetComponent<RectTransform>();
        if (rect.sizeDelta.x != oldWith)
        {
            oldWith = rect.sizeDelta.x;
            GetComponent<RectTransform>().sizeDelta = new Vector2(oldWith + 3, GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}
