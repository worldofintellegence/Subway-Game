using UnityEngine;
using System.Collections;

public class PlayParticle : MonoBehaviour {

    public AudioClip audioPlay;
    public GameObject hideObjects;
    public float timeParticle = 3f;

    public bool IsPlay()
    {
        bool result = false;
        if (transform.GetComponent<ParticleSystem>() != null)
            result = transform.GetComponent<ParticleSystem>().isPlaying;
        else result = transform.GetChild(0).GetComponent<ParticleSystem>().isPlaying;
        return result;
    }

    public void Play(bool isCoins = false, bool playAudio = true)
    {
        if (playAudio) Modules.PlayAudioClipFree(audioPlay, isCoins);
        if (transform.GetComponent<ParticleSystem>() != null)
            transform.GetComponent<ParticleSystem>().Play();
        foreach(Transform tran in transform)
            tran.GetComponent<ParticleSystem>().Play();
        if (hideObjects != null)
        {
            hideObjects.GetComponent<Animator>().SetTrigger("TriHide");
            Invoke("ShowPanelHide", timeParticle);
        }
    }

    void ShowPanelHide()
    {
        hideObjects.GetComponent<Animator>().SetTrigger("TriShow");
    }
}
