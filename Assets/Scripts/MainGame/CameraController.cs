using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float timeFollow = 0.25f;//xu ly truong hop theo Y hoac khong theo Y, cang lon cang muot
    private float originTimeFollow = 0.25f;
    private Vector3 originDeltaPoint = Vector3.zero;
    private Vector3 originDeltaAngle = Vector3.zero;
    public Vector3 originPoint = Vector3.zero;
    public Vector3 originAngle = Vector3.zero;
    private Vector3 deltaPoint = Vector3.zero;
    private Vector3 deltaAngle = Vector3.zero;
    private bool mesStartFollow = false;
    private GameObject objectFollow;
    //xu ly xa gan camera
    private float heightBasic = -1;//do cao cua dia hinh binh thuong
    private float heightUnder = -20.7f;//do sau cua dia hinh duong ngam
    private float numConver = 3.5f;//chi so chuyen doi do xa gan
    private float heightMaxAllow = 15f;//do cao toi da cho phep su dung xa gan cam, tinh theo do cao dia hinh

    void Start()
    {
        originTimeFollow = timeFollow;
        StartAllowFollow();
    }

    public void CallStart()
    {
        CancelInvoke();
        deltaPoint = Vector3.zero;
        deltaAngle = Vector3.zero;
        StartAllowFollow();
        ResetPointAngle();
        ResetTimeFollow();
        Invoke("CheckDoneAnimation", 0.1f);
    }

    public void ResetTimeFollow()
    {
        timeFollow = originTimeFollow;
    }
    
    public float GetOriginTimeFollow()
    {
        return originTimeFollow;
    }

    public void ResetDeltaPoint()
    {
        deltaPoint = originDeltaPoint;
        deltaAngle = originDeltaAngle;
    }

    public void UpdateDeltaPoint(Vector3 addPoint, Vector3 addAngle)
    {
        deltaPoint += addPoint;
        deltaAngle += addAngle;
        //if (deltaAngle.x < 0) deltaAngle.x = 0;
        //if (deltaAngle.y < 0) deltaAngle.y = 0;
        //if (deltaAngle.z < 0) deltaAngle.z = 0;
    }

    public void SetObjectFollow(GameObject newObject)
    {
        objectFollow = newObject;
    }

    public void ResetPointAngle()
    {
        transform.position = originPoint;
        transform.eulerAngles = originAngle;
    }

    bool allowFollow = true;
    public void SetPointAngle(Vector3 newPoint, Vector3 newAngle, float timeStay, float newTimeFollow)
    {
        timeFollow = newTimeFollow;
        allowFollow = false;
        transform.position = newPoint;
        transform.eulerAngles = newAngle;
        Invoke("StartAllowFollow", timeStay);
    }

    public void StartAllowFollow()
    {
        allowFollow = true;
    }

    public void StopAllowFollow()
    {
        allowFollow = false;
    }

    void OnEnable()
    {
        CancelInvoke();
        Invoke("CheckDoneAnimation", 0.1f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void CheckDoneAnimation()
    {
        if (transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CameraMenuRun"))
        {
            //objectFollow = Modules.GetChildGameObject(Modules.mainCharacter, "PointShow");
            objectFollow = Modules.mainCharacter;
            transform.GetComponent<Animator>().enabled = false;
            deltaPoint = originPoint;
            originDeltaPoint = deltaPoint;
            deltaAngle = originAngle;
            originDeltaAngle = deltaAngle;
            mesStartFollow = true;
        }
        else Invoke("CheckDoneAnimation", 0.1f);
    }

    void LateUpdate()
    {
        if (!mesStartFollow || objectFollow == null || !allowFollow) return;
        //xu ly xa gan thi thay doi do cao
        Vector3 deltaPointHeight = deltaPoint;
        Vector3 deltaAngleHeight = deltaAngle;
        if (!Modules.useJumper && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall && Modules.statusGame != StatusGame.flyScene && (objectFollow.GetComponent<HeroController>() != null && !objectFollow.GetComponent<HeroController>().hideMeshBonus) && !Modules.allowUseHoverbike)
        {
            float heightCheck = GetHeightBasicNow();
            if (objectFollow.transform.position.y < heightMaxAllow + heightCheck)//kiem tra dieu kien do cao toi da cho phep
            {
                float numHeight = (objectFollow.transform.position.y - heightCheck) / numConver;
                deltaPointHeight.y = deltaPoint.y - numHeight;
                //deltaPointHeight.z = deltaPoint.z + numHeight;
                deltaAngleHeight.x = deltaAngleHeight.x * deltaPointHeight.z / deltaPoint.z;
            }
        }
        float speedNow = (1 / timeFollow) * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, objectFollow.transform.position + deltaPointHeight, speedNow);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(objectFollow.transform.eulerAngles + deltaAngleHeight), speedNow);
    }

    public float GetHeightBasicNow()
    {
        float heightCheck = heightBasic;
        if (objectFollow.transform.position.y < heightBasic) heightCheck = heightUnder;//xac dinh do cao hien tai cua dia hinh
        return heightCheck;
    }
}
