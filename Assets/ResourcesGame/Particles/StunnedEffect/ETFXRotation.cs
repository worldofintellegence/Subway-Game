using UnityEngine;
using System.Collections;

public class ETFXRotation : MonoBehaviour
{
    [Header("Rotate axises by degrees per second")]
    public Vector3 rotateVector = Vector3.zero;

    public enum spaceEnum { Local, World };
    public spaceEnum rotateSpace;
    public float timeDisable = 3f;

    void Update()
    {
        if (rotateSpace == spaceEnum.Local)
            transform.Rotate(rotateVector * Time.deltaTime);
        if (rotateSpace == spaceEnum.World)
            transform.Rotate(rotateVector * Time.deltaTime, Space.World);
    }

    public void StartEffect()
    {
        CancelInvoke("DeactiveMe");
        Invoke("DeactiveMe", timeDisable);
    }

    void DeactiveMe()
    {
        transform.gameObject.SetActive(false);
    }
}