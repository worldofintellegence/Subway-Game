using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFlameSkis : MonoBehaviour {

    public List<FlameSkisEffect> listFrames;
    public float timeReset = 3f;

    public void PlaySpeedFlame()
    {
        for (int i = 0; i < listFrames.Count; i++)
        {
            var main = listFrames[i].effect.GetComponent<ParticleSystem>().main;
            main.startSpeed = listFrames[i].speedValue;
        }
        Invoke("ResetStatus", timeReset);
    }

    void ResetStatus()
    {
        for (int i = 0; i < listFrames.Count; i++)
        {
            var main = listFrames[i].effect.GetComponent<ParticleSystem>().main;
            main.startSpeed = listFrames[i].normalValue;
        }
    }
}
[System.Serializable]//de show ra phan input cua unity editor
public class FlameSkisEffect
{
    public GameObject effect;
    public float normalValue;
    public float speedValue;
    public FlameSkisEffect(GameObject effectInput, float normalValueInput, float speedValueInput)
    {
        this.effect = effectInput;
        this.normalValue = normalValueInput;
        this.speedValue = speedValueInput;
    }
}
