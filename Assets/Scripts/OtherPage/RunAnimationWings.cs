using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimationWings : MonoBehaviour {

    public List<AnimationClip> listAnimations;
    public List<int> listIndex;
    public float speedAni = 1f;
    private Animation myAnimation;
    private int indexRun = 0;
    private bool mesRun = false;

	void OnEnable () {
        if (!Modules.containMainGame.activeSelf) return;
        myAnimation = transform.GetComponent<Animation>();
        indexRun = 0;
        mesRun = true;
        PlayAni();
	}

    void OnDisable()
    {
        indexRun = 0;
        mesRun = false;
    }
	
	void Update () {
        if (mesRun)
        {
            if (!myAnimation.isPlaying)
            {
                indexRun++;
                if (indexRun >= listIndex.Count) 
                    indexRun = 0;
                PlayAni();
            }
        }
	}

    void PlayAni()
    {
        myAnimation[listAnimations[listIndex[indexRun]].name].wrapMode = WrapMode.Once;
        myAnimation[listAnimations[listIndex[indexRun]].name].speed = speedAni;
        myAnimation.Play(listAnimations[listIndex[indexRun]].name);
    }
}
