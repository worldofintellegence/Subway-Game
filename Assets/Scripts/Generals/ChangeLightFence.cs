using UnityEngine;
using System.Collections;

public class ChangeLightFence : MonoBehaviour
{
    public Material lightRed, lightGreen, lightYellow;
    public Vector2 timeChange = new Vector2(5, 10);//tinh bang giay
    public bool lightRedNow = true;
    public int indexMat = 0;
    private bool lightYellowNow = false;
    private MeshRenderer myMesh;

    void Start()
    {
        lightRedNow = true;
        myMesh = transform.GetComponent<MeshRenderer>();
        Invoke("UpdateNewLight", Random.Range(timeChange.x, timeChange.y));
    }

    void UpdateNewLight()
    {
        if (lightRedNow)
        {
            myMesh.materials[indexMat].CopyPropertiesFromMaterial(lightGreen);
            lightRedNow = false;
            lightYellowNow = false;
        }
        else
        {
            if (lightYellow != null)
            {
                if (lightYellowNow)
                {
                    myMesh.materials[indexMat].CopyPropertiesFromMaterial(lightRed);
                    lightRedNow = true;
                }
                else
                {
                    myMesh.materials[indexMat].CopyPropertiesFromMaterial(lightYellow);
                    lightYellowNow = true;
                }
            }
            else
            {
                myMesh.materials[indexMat].CopyPropertiesFromMaterial(lightRed);
                lightRedNow = true;
            }
        }
        Invoke("UpdateNewLight", Random.Range(timeChange.x, timeChange.y));
    }
}
