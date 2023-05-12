using UnityEngine;
using System.Collections;

public class RotateModels : MonoBehaviour {

    public float speedRotate = 100f;
    public bool startStatus = false;
    public Vector3 originAngle = Vector3.zero;
    public AxisRotate axisRotate = AxisRotate.axisX;

    public void StartRotate()
    {
        startStatus = true;
    }

    public void StopRotate()
    {
        startStatus = false;
        transform.eulerAngles = originAngle;
    }

    void FixedUpdate()
    {
        if (!startStatus) return;
        if (axisRotate == AxisRotate.axisX)
            transform.Rotate(speedRotate * Time.fixedDeltaTime, 0, 0);
        else if (axisRotate == AxisRotate.axisY)
            transform.Rotate(0, speedRotate * Time.fixedDeltaTime, 0);
        else if (axisRotate == AxisRotate.axisZ)
            transform.Rotate(0, 0, speedRotate * Time.fixedDeltaTime);
    }
}

public enum AxisRotate
{
    axisX,
    axisY,
    axisZ
}
