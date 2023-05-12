using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowSpinCollider : MonoBehaviour {

    public AudioClip audioPlay;
    public Text textResult;
    public Image imgResult;
    public GameObject mainPage;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (audioPlay != null) Modules.PlayAudioClipFree(audioPlay);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!mainPage.GetComponent<PageSpinWheel>().AllowCollider()) return;
        Text textCom = other.gameObject.transform.GetChild(1).GetComponent<Text>();
        //Gradient graCom = other.gameObject.transform.GetChild(1).GetComponent<Gradient>();
        textResult.text = textCom.text;
        textResult.color = textCom.color;
        //textResult.GetComponent<Gradient>().StartColor = graCom.StartColor;
        //textResult.GetComponent<Gradient>().EndColor = graCom.EndColor;
        imgResult.sprite = other.gameObject.transform.GetChild(2).GetComponent<Image>().sprite;
    }
}
