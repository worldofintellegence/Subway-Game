using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestTemple : MonoBehaviour {

    [Header("0 Skis, 1 ScoreBosster, 3 Key, 4 Spin Wheel")]
    public List<GameObject> listItemBonus = new List<GameObject>();
    public GameObject effectOpen, containModelBonus;
    public Animator myAnimator;
    public AudioClip audioOpen;
    public float timeBonus = 2f;//sau thoi gian nay thi thuc hien thuong
    private int indexBonus = 0;
    private GameObject modelBonus;

    public void StartOpen()
    {
        indexBonus = Random.Range(0, 2);
        modelBonus = Instantiate(listItemBonus[indexBonus], containModelBonus.transform);
        modelBonus.transform.localPosition = new Vector3(0, 0, 0);
        modelBonus.transform.localRotation = new Quaternion(0, 0, 0, 0);
        modelBonus.transform.localScale = new Vector3(1, 1, 1);
        myAnimator.SetTrigger("TriOpen");
        effectOpen.SetActive(true);
        effectOpen.GetComponent<ParticleSystem>().Play();
        Modules.PlayAudioClipFree(audioOpen);
        Invoke("HandleBonus", timeBonus);
    }

    void HandleBonus()
    {
        if (indexBonus == 0)//thuong hoverboard
        {
            int total = Random.Range(8, 19);
            Modules.BonusMissionsChallenge(2, "", total, Vector3.zero);
        }
        else if (indexBonus == 1)//thuong scorebosster
        {
            int total = Random.Range(3, 7);
            Modules.BonusMissionsChallenge(4, "", total, Vector3.zero);
        }
        else if (indexBonus == 2)//thuong key
        {
            int total = Random.Range(3, 9);
            Modules.BonusMissionsChallenge(1, "", total, Vector3.zero);
        }
        else//thuong spin wheel
        {
            int total = Random.Range(2, 4);
            Modules.BonusMissionsChallenge(5, "", total, Vector3.zero);
        }
    }

    public void ResetChest()
    {
        myAnimator.SetTrigger("TriIdle");
        effectOpen.SetActive(false);
        if (modelBonus != null) Destroy(modelBonus);
    }
}
