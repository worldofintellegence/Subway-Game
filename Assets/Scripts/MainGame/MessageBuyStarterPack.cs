using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBuyStarterPack : MonoBehaviour {

    public Text textCancel;
    public Image iconSkis;

    public void StartShowMessage()
    {
        int lang = Modules.indexLanguage;
        //xu ly ngon ngu
        textCancel.font = AllLanguages.listFontLangA[lang];
        textCancel.text = AllLanguages.menuCancel[lang];
        iconSkis.sprite = Modules.ChangeIconHoverboard();
    }

    public void ButtonCancel()
    {
        transform.gameObject.GetComponent<Animator>().SetTrigger("TriClose");
        Modules.PlayAudioClipFree(Modules.audioButton);
    }
}
