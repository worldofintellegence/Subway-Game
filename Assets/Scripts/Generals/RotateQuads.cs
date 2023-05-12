using UnityEngine;
using System.Collections;

public class RotateQuads : MonoBehaviour {

    public float speedRotate = 100f;
    public bool scaleEffect = true;
    private float speedScale = 10f;
    private float numScale = 0;
    private bool grow = true;
    private Vector3 originScale = new Vector3(1, 1, 1);

    void Start()
    {
        originScale = transform.localScale;
    }

    void Update()
    {
        transform.Rotate(0, 0, speedRotate * Time.deltaTime);
        if (!scaleEffect) return;
        int dau = -1;
        if (grow) dau = 1;
        numScale += speedScale * dau * Time.deltaTime;
        if (numScale >= 2) grow = false;
        else if (numScale <= -2) grow = true;
        transform.localScale = new Vector3(originScale.x + numScale, originScale.y + numScale, originScale.z + numScale);
    }
}
