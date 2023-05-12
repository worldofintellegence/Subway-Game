using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningHoverboard : MonoBehaviour {

    public float timeShow = 3f;
    public Text textNumber;
    public void ShowWarning()
    {
        textNumber.text = Modules.totalSkis.ToString();
        CancelInvoke();
        Invoke("DisableMe", timeShow);
    }

    void DisableMe()
    {
        transform.gameObject.SetActive(false);
    }
}
