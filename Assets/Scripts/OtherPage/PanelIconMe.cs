using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelIconMe : MonoBehaviour {

    public AudioClip audioChange;
    public void ChangeBadge()
    {
        Modules.SetBadges(transform.gameObject, Mathf.RoundToInt(Modules.totalScore));
        Modules.PlayAudioClipFree(audioChange);
    }
}
