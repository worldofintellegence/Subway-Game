using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamController : MonoBehaviour {

    public float distaceBack = -20f, distaceFront = 20f, distaceMoveSlow = -5f, distaceComeBack = -5f, distaceHeight = 8f, distaceHeightGoOut = 5f;
    public float speedComeIn = 30f, speedMove = 10f, speedSlow = 5f, speedGoOut = 5f, speedComeBack = 10f;
    public int timeMoveLane = 7;
    public int timeMoveSlow = 3;
    private int countMoveLane = 0, countMoveSlow = 0;
    public Animator myAnimator;
    public AudioClip audioComeIn, audioGoOut, audioDropTrap;
    public float distaneLane = 5;
    public Vector2 timeStay = new Vector2(5f, 10f);
    [Range(0, 100)]
    public int percentDropTrap = 50;
    public bool catchPlayer = false;
    private bool mesStart = false;
    [HideInInspector]
    public int laneNow = 0;
    private int laneOld = 0;
    private int directLane = 1;
    private StateFlyCam stateFlyCam = StateFlyCam.comeIn;
    private float timeStayNow = 5f;
    private float countTimeStay = 0;
    private float heightFly = 0;
    private float distanceFlyBack;
    private bool comeBack = true;

    public void StartFlyCam(int timeMove, int timeSlow)
    {
        if (Modules.mainCharacter == null) return;
        if (Modules.statusGame == StatusGame.over) return;
        transform.parent = Modules.containFlyCam.transform;
        timeMoveLane = timeMove;
        timeMoveSlow = timeSlow;
        countMoveLane = 0;
        countMoveSlow = 0;
        laneNow = RandomLane();
        heightFly = distaceHeight;
        Modules.PlayAudioClipFree(audioComeIn);
        transform.position = new Vector3(laneNow * distaneLane, Modules.mainCharacter.transform.position.y + distaceHeight, distaceBack);
        stateFlyCam = StateFlyCam.comeIn;
        Modules.flyCamGoOut = false;
        Modules.flyCamNow = gameObject;
        myAnimator.SetTrigger("TriIdle");
        if (Modules.useTemple)
        {
            distanceFlyBack = distaceBack;
            comeBack = false;
        }
        else
        {
            distanceFlyBack = distaceComeBack;
            comeBack = true;
        }
        mesStart = true;
    }

    int RandomLane()
    {
        int result = 0;
        int laneHero = Mathf.RoundToInt(Modules.mainCharacter.transform.position.x);
        if (laneHero == 0)//neu nhan vat o lane giua
        {
            int ran = Random.Range(0, 3);
            if (ran == 0) result = 0;
            else if (ran == 1) result = -1;
            else result = 1;
        }
        else if (laneHero == 5)
        {
            int ran = Random.Range(0, 3);
            if (ran == 0) result = 1;
            else if (ran == 1) result = 0;
            else result = 2;
        }
        else if (laneHero == -5)
        {
            int ran = Random.Range(0, 3);
            if (ran == 0) result = -1;
            else if (ran == 1) result = -2;
            else result = 0;
        }
        else if (laneHero == 10)
        {
            int ran = Random.Range(0, 2);
            if (ran == 0) result = 1;
            else if (ran == 1) result = 2;
        }
        else if (laneHero == -10)
        {
            int ran = Random.Range(0, 2);
            if (ran == 0) result = -1;
            else if (ran == 1) result = -2;
        }
        //ban raycast de kiem tra
        RaycastHit hit;
        if (!Physics.Raycast(new Vector3(distaneLane * result, transform.position.y, transform.position.z), Vector3.down, out hit))
            result = Mathf.RoundToInt(laneHero / distaneLane);
        return result;
    }

    void Update()
    {
        if (Modules.mainCharacter == null) return;
        if (Modules.flyCamCatch && Modules.flyCamNow == gameObject)//neu bi bat thi bay ve phia tay nhan vat
            return;
        if (Modules.statusGame == StatusGame.over)
        {
            if (stateFlyCam != StateFlyCam.goOut)
                FlyAway();
        }
        if (mesStart)
        {
            if (stateFlyCam == StateFlyCam.comeIn)
            {
                if (transform.position.z < distaceFront)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speedComeIn * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, distaceFront);
                    HandleDropTrap();
                    timeStayNow = Random.Range(timeStay.x, timeStay.y);
                    countTimeStay = 0;
                    stateFlyCam = StateFlyCam.stayHere;
                }
            }
            else if (stateFlyCam == StateFlyCam.stayHere)
            {
                if (countTimeStay >= timeStayNow)//het thoi gian dung nghi
                {
                    //khi het thoi gian nghi thi co the chuyen sang move slow hoac move lane
                    //tinh toan ti le phan tram move slow theo move lane
                    int percentMoveSlow = Mathf.RoundToInt(((float)timeMoveSlow / ((float)timeMoveSlow + (float)timeMoveLane)) * 100);
                    int XRan = Random.Range(0, 100);
                    if (XRan < percentMoveSlow)//move slow
                    {
                        if (countMoveSlow >= timeMoveSlow && Modules.gameGuide != "YES")
                        {
                            if (Modules.useTemple || Modules.useRocket || Modules.useCable || Modules.useJetBall || Modules.useJumper)
                                distanceFlyBack = distaceBack;
                            Modules.PlayAudioClipFree(audioGoOut);
                            heightFly = distaceHeightGoOut;
                            stateFlyCam = StateFlyCam.goOut;
                            Modules.flyCamGoOut = true;
                        }
                        else
                        {
                            Modules.PlayAudioClipFree(audioGoOut);
                            heightFly = distaceHeightGoOut;
                            stateFlyCam = StateFlyCam.moveSlow;
                            Modules.flyCamGoOut = true;
                        }
                    }
                    else//move lane
                    {
                        if (countMoveLane >= timeMoveLane && Modules.gameGuide != "YES")
                        {
                            if (Modules.useTemple || Modules.useRocket || Modules.useCable || Modules.useJetBall || Modules.useJumper)
                                distanceFlyBack = distaceBack;
                            Modules.PlayAudioClipFree(audioGoOut);
                            heightFly = distaceHeightGoOut;
                            stateFlyCam = StateFlyCam.goOut;
                            Modules.flyCamGoOut = true;
                        }
                        else
                        {
                            //tinh toan kiem tra de di chuyen sang trai hay sang phai
                            laneOld = laneNow;
                            laneNow = RandomLane();
                            if ((laneNow - laneOld) > 0)
                            {
                                directLane = 1;
                                myAnimator.SetTrigger("TriRight");
                            }
                            else if ((laneNow - laneOld) < 0)
                            {
                                directLane = -1;
                                myAnimator.SetTrigger("TriLeft");
                            }
                            else directLane = 0;
                            if (directLane == 0)
                            {
                                HandleDropTrap();
                                timeStayNow = Random.Range(timeStay.x, timeStay.y);
                                countTimeStay = 0;
                                stateFlyCam = StateFlyCam.stayHere;
                            }
                            else
                                stateFlyCam = StateFlyCam.moveLane;
                        }
                    }
                }
                else
                {
                    countTimeStay += Time.deltaTime;
                }
            }
            else if (stateFlyCam == StateFlyCam.moveLane)
            {
                if (transform.position.x * directLane < laneNow * distaneLane * directLane)
                {
                    transform.position = new Vector3(transform.position.x + speedMove * directLane * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(laneNow * distaneLane, transform.position.y, transform.position.z);
                    countMoveLane++;
                    HandleDropTrap();
                    timeStayNow = Random.Range(timeStay.x, timeStay.y);
                    countTimeStay = 0;
                    stateFlyCam = StateFlyCam.stayHere;
                }
            }
            else if (stateFlyCam == StateFlyCam.moveSlow)
            {
                if (transform.position.z > distaceMoveSlow)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speedSlow * Time.deltaTime);
                    Modules.mainCharacter.GetComponent<HeroController>().ShowRemindCatchFlyCam();
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, distaceMoveSlow);
                    countMoveSlow++;
                    heightFly = distaceHeight;
                    Modules.PlayAudioClipFree(audioComeIn);
                    stateFlyCam = StateFlyCam.comeIn;
                    Modules.flyCamGoOut = false;
                    Modules.mainCharacter.GetComponent<HeroController>().HideRemindCatchFlyCam();
                }
            }
            else if (stateFlyCam == StateFlyCam.goOut)
            {
                if (transform.position.z > distanceFlyBack)
                {
                    float speedMore = 1;
                    if (!comeBack) speedMore = 2;
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speedGoOut * speedMore * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, distanceFlyBack);
                    //xu ly khi da thoat thanh cong va quay lai cap nhan vat
                    if (comeBack && !Modules.useTemple && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall && !Modules.useJumper && !Modules.useTakeBag  && catchPlayer)
                    {
                        Modules.PlayAudioClipFree(audioComeIn);
                        Modules.flyCamGoOut = false;
                        Modules.flyCamCatch = false;
                        stateFlyCam = StateFlyCam.comeBack;
                        distanceFlyBack = distaceBack;
                        comeBack = false;
                    }
                    else
                    {
                        mesStart = false;
                        gameObject.SetActive(false);
                    }
                }
            }
            else if (stateFlyCam == StateFlyCam.comeBack)
            {
                float step = speedComeBack * Time.deltaTime;
                Vector3 pointTarget = Modules.mainCharacter.GetComponent<HeroController>().boneFlyCam.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, pointTarget, step);
                if (Vector3.Distance(transform.position, pointTarget) <= 0.25f)
                {
                    mesStart = false;
                    Modules.mainCharacter.GetComponent<HeroController>().UseFlyCam(gameObject);
                }
                return;
            }
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, Modules.mainCharacter.transform.position.y + heightFly, transform.position.z), ref velocityPoint, 2f);
        }
    }

    public void FlyAway()
    {
        distanceFlyBack = distaceBack;
        comeBack = false;
        mesStart = true;
        Modules.PlayAudioClipFree(audioGoOut);
        heightFly = distaceHeightGoOut;
        stateFlyCam = StateFlyCam.goOut;
        Modules.flyCamGoOut = false;
    }

    private Vector3 velocityPoint = Vector3.zero;
    void HandleDropTrap()
    {
        if (Modules.useTakeBag) return;
        int ran = Random.Range(0, 100);
        if (ran >= percentDropTrap) return;
        List<GameObject> listTrap = Modules.listTrap;
        GameObject containTrap = Modules.containTraps;
        //kiem tra xem ban loai mine nao
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.tag == "WaterSurface")
            {
                listTrap = Modules.listSeaTrap;
                containTrap = Modules.containSeaTraps;
            }
        }
        foreach (GameObject go in listTrap)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                go.GetComponent<TrapController>().SetTrapDrop(transform.position, containTrap);
                Modules.PlayAudioClipFree(audioDropTrap);
                myAnimator.SetTrigger("TriDrop");
                break;
            }
        }
    }
}
public enum StateFlyCam
{
    comeIn,
    stayHere,
    moveLane,
    moveSlow,
    goOut,
    comeBack
}