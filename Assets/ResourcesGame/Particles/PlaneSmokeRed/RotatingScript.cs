using UnityEngine;
using System.Collections;

public class RotatingScript : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;

    private float SpeedRotation = 700f;

    void Update()
    {
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation), SpeedRotation * Time.deltaTime);
    }
}
