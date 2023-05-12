using UnityEngine;
using System.Collections;

public class MessageBonusFirst : MonoBehaviour {

    public void ButtonCloseBox()
    {
        transform.gameObject.SetActive(false);
        Modules.PlayAudioClipFree(Modules.audioButton);
        if (Modules.winRunning != 0)
            Modules.ShowMessageWinRunning();
        else Modules.HandleGameOver();
    }
}
