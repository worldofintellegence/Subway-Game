using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateParticleSpeed : MonoBehaviour {

    private float numChange = 15f;
	void Update () {
        float num = (float)Screen.width / (float)Screen.height;
        float angle = (-140 - numChange) + ((1 / 0.6f) * num * numChange);
        if (angle < -145) angle = -145;
        if (angle > -110) angle = -110;
        //print(num + ";" +angle);
        transform.eulerAngles = new Vector3(0, angle, 0);
	}
}
