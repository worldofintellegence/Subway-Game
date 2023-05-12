using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFly : MonoBehaviour {

    public List<PointStartEnd> listPath = new List<PointStartEnd>();
    public AudioClip audioComming;
    public float rangeAudioComming = 10f;
    public float speedStandar = 20;
    private int indexPath = 0;
    private bool startFly = false;
    private bool checkPlayAudio = false;
    private bool playedAudio = false;

    public void CallStart()
    {
        indexPath = Random.Range(0, listPath.Count);
        transform.position = listPath[indexPath].pointStart;
        transform.LookAt(listPath[indexPath].pointEnd);
        checkPlayAudio = false;
        playedAudio = false;
        if (audioComming != null)
            checkPlayAudio = true;
        startFly = true;
    }

    void Update()
    {
        if (!startFly) return;
        float speedNow = speedStandar;
        if (listPath[indexPath].speedFollow && Modules.statusGame != StatusGame.menu)
            speedNow += Modules.speedGameNow * 10f;
        transform.Translate(Vector3.forward * Time.deltaTime * speedNow);
        //xu ly am thanh
        if (checkPlayAudio)
        {
            bool checkAudio = false;
            if (!playedAudio)
            {
                if (listPath[indexPath].speedFollow)
                {
                    if (transform.position.z <= rangeAudioComming)
                        checkAudio = true;
                }
                else
                {
                    if (transform.position.z > 0)
                        checkAudio = true;
                }
            }
            if (checkAudio)
            {
                Modules.PlayAudioClipFree(audioComming);
                //AudioSource.PlayClipAtPoint(audioComming, Camera.main.transform.position, 1);
                playedAudio = true;
            }
        }
        if (Vector3.Distance(transform.position, listPath[indexPath].pointEnd) <= 1f)
            transform.gameObject.SetActive(false);
    }
}
[System.Serializable]//de show ra phan input cua unity editor
public class PointStartEnd
{
    public Vector3 pointStart;
    public Vector3 pointEnd;
    public bool speedFollow;
    public PointStartEnd(Vector3 pointStartInput, Vector3 pointEndInput, bool speedFollowInput)
    {
        this.pointStart = pointStartInput;
        this.pointEnd = pointEndInput;
        this.speedFollow = speedFollowInput;
    }
}