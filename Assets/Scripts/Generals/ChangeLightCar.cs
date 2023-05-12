using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightCar : MonoBehaviour {

    public Material matRed, matBlue;
    public MeshRenderer meshA, meshB;
    public float timeBlink = 2f;
    private bool rightLight = true;

	void Start () {
        InvokeRepeating("ChangeMaterial", timeBlink, timeBlink);
	}

    void ChangeMaterial()
    {
        if (rightLight)
        {
            meshA.material = matRed;
            meshB.material = matBlue;
            rightLight = false;
        }
        else
        {
            meshA.material = matBlue;
            meshB.material = matRed;
            rightLight = true;
        }
    }
}
