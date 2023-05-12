using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySparksBoat : MonoBehaviour {

    public GameObject containSparks;
    public void ShowHideSparks(bool valueShow)
    {
        if (valueShow)
        {
            containSparks.SetActive(true);
            foreach (Transform tran in containSparks.transform)
            {
                tran.GetComponent<ParticleSystem>().Stop();
                tran.GetComponent<ParticleSystem>().Play();
            }
        }
        else
        {
            containSparks.SetActive(false);
        }
    }
}
