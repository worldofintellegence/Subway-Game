using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using ChartboostSDK;
using MoreMountains.NiceVibrations;

public class HeroController : MonoBehaviour
{

    public string idHero = "001";//ma nhan biet loai nhan vat
    public string codeBody = "N01";//the loai body cua nhan vat nay
    public float costHero = 10000f;//gia tien mua hero nay
    public int noteHero = 0;//index information
    public bool maleHero = true;//trai hay gai
    public float speedPercent = 0;//phan tram tang toc do
    public Sprite iconSale;//cac icon sale
    public AudioClip audioJumpJumper;
    public List<GameObject> listObjectHide = new List<GameObject>();//cac object can an di khi chay
    public GameObject modelIdelShow;
    public GameObject modelIdelStun;
    public GameObject modelIdelWin;
    public GameObject modelIdelLose;
    public GameObject effectUnlock;
    //khai bao cac bien ve nhan vat
    public Animation aniHero;
    public AnimationClip aniRunNormal, aniRunMagnet, aniRunSkis, aniRunSkisMagnet, aniRunRocket, aniRunRocketMagnet, aniRunCable, aniRunCableMagnet, aniRunJetBall, aniRunJetBallMagnet, aniRunBonus, aniRunSneaker, aniRunSneakerMagnet, aniRunBoat, aniRunBoatMagnet, aniRunBroom, aniRunBroomMagnet;
    public List<AnimationClip> aniJumpPower, aniJumpMagnetPower, aniRunJumper;
    public List<AnimationClip> aniJumpSkisPower, aniJumpSkisMagnetPower;
    public List<AnimationClip> aniJumpCablePower, aniJumpCableMagnetPower;
    public List<AnimationClip> aniJumpBoatPower, aniJumpBoatMagnetPower;
    public List<AnimationClip> aniJumpNormal, aniJumpMagnet;
    public List<AnimationClip> aniJumpSkis, aniJumpSkisMagnet;
    public List<AnimationClip> aniJumpCable, aniJumpCableMagnet;
    public List<AnimationClip> aniJumpBoat, aniJumpBoatMagnet;
    public List<AnimationClip> aniDownNormal, aniDownMagnet;
    public List<AnimationClip> aniDownSkis, aniDownSkisMagnet;
    public List<AnimationClip> aniDownCable, aniDownCableMagnet;
    public List<AnimationClip> aniStumble;
    public AnimationClip aniLeftNormal, aniRightNormal, aniLeftMagnet, aniRightMagnet;
    public AnimationClip aniLeftRocket, aniRightRocket, aniLeftRocketMagnet, aniRightRocketMagnet;
    public AnimationClip aniLeftBroom, aniRightBroom, aniLeftBroomMagnet, aniRightBroomMagnet;
    public AnimationClip aniLeftJetBall, aniRightJetBall, aniLeftJetBallMagnet, aniRightJetBallMagnet;
    public List<AnimationClip> aniLeftCable, aniRightCable, aniLeftCableMagnet, aniRightCableMagnet;
    public AnimationClip aniLeftSkis, aniRightSkis, aniLeftSkisMagnet, aniRightSkisMagnet;
    public AnimationClip aniLeftSkisWall, aniRightSkisWall, aniLeftSkisWallMagnet, aniRightSkisWallMagnet;
    public AnimationClip aniLeftCableWall, aniRightCableWall, aniLeftCableWallMagnet, aniRightCableWallMagnet;
    public AnimationClip aniFallNormal, aniFallMagnet, aniFallSkis, aniFallSkisMagnet, aniFallRocket, aniFallJumper, aniFallCable, aniFallJetBall;
    public AnimationClip aniDieFront, aniDieBack, aniDieBackScene, aniDieCatch;
    public AnimationClip aniMoveUp, aniMoveDown, aniDriver;
    public AnimationClip aniIdleMenu, aniActionMenu, aniActionMenuB, aniOhNoMenu;
    public AnimationClip aniSideLeft, aniSideRight, aniCallSkis;
    public AnimationClip aniFlyCamCatch, aniFlyCamMiss, aniFlyCamCatchSkis, aniFlyCamMissSkis, aniFlyCamCatchBoat, aniFlyCamMissBoat, aniFlyCamPickUp, aniFlyCamDrop;
    public List<AnimationClip> aniFlyCamSway;
    public float numSpeedAni = 3f;//he so toc do animation
    public float numSpeedAct = 2f;//he so toc do hoat dong
    private TypeAniRun mesAniRunNow = TypeAniRun.runNormal;//loai animation hien tai
    private TypeAniRun typeAniRun = TypeAniRun.runNormal;
    //xu ly lane chay, jump
    public GameObject pointCheckRay;//doi tuong de ban raycast
    public GameObject pointShowHero;//doi tuong luu giu toa do mesh cua nhan vat
    //public float distanceCheckColl = 10f;
    public float moveLeftRight = 5f;
    public float speedMoveLeftRight = 1;
    public float speedMoveBack = 1;
    public float jumpNormalHeight = 5f;
    public float speedJumpNormal = 1;
    public float jumpPowerHeight = 7f;
    public float speedJumpPower = 1;
    public float jumpRocketHeight = 20f;
    public float speedJumpRocket = 1;
    public float jumpJumperHeight = 20f;
    public float speedJumpJumper = 1;
    public float jumpCableHeight = 20f;
    public float speedJumpCable = 1;
    public float jumpJetBallHeight = 20f;
    public float speedJumpJetBall = 1;
    public float jumpBonusHeight = 10f;
    public float speedJumpBonus = 1;
    public float balloonHeight = 100f;
    public float speedBalloonFly = 1;
    public float flyHeight = 100f;
    public float speedFly = 1;
    //xu ly cac du lieu ve van truot
    public GameObject mySkis;//doi tuong van truot
    public GameObject myJetpack;//doi tuong jetpack
    public GameObject myBoat;//doi tuong boat
    //xu ly co keo collider khi thuc hien chui, fly
    public GameObject myCollider;
    private float originScaleY = 1f;
    private float originScaleX = 1f;
    private float originPointY = 0.5f;
    //bien dau ra de xu ly enemy duoi theo chay animation
    [HideInInspector]
    public StatusHero statusHero = StatusHero.run;
    private int onlyShowMenu = 0;//0 la day du, 1 la bo rigid nhung co shadow, 2 la bo het
    [HideInInspector]
    public bool deactiveAfferInstan = false;//se an ngay khi khoi tao
    //xu ly trap va fly cam
    public GameObject boneTrap, boneFlyCam;
    public float distanceHeightFlyCam = 7f;
    public float distanceCatchFlyCam = 3f;
    public float distanceMissFlyCam = 5f;
    //xu ly hieu ung effect stunned
    public GameObject effectStunned;
    private Rigidbody myRigid;
    //xu ly hieu ung bag
    private bool useBag = false;
    private bool takeBag = false;
    public GameObject myBagTake, myBagUse;
    public AnimationClip aniTakeBagFree, aniTakeBagHoverboard, aniTakeBagHoverbike;

    public void SetTakeBag(Material materBag)
    {
        myBagTake.GetComponent<MeshRenderer>().material = materBag;
        myBagUse.GetComponent<MeshRenderer>().material = materBag;
        myBagTake.SetActive(true);
        myBagUse.SetActive(false);
        if (Modules.useSkis)
        {
            if (skisNow.GetComponent<SkisController>().isHoverbike)
                CallAniNew(aniTakeBagHoverbike, TypeAniRun.takeBag, false, 0.5f);
            else
                CallAniNew(aniTakeBagHoverboard, TypeAniRun.takeBag, false, 0.5f);
        }
        else if(Modules.useBoat)
        {
            CallAniNew(aniTakeBagHoverbike, TypeAniRun.takeBag, false, 0.5f);
        }
        else
        {
            CallAniNew(aniTakeBagFree, TypeAniRun.takeBag, false, 0.5f);
        }
        Modules.PlayAudioClipLoop(Modules.audioDeliveryBag[Random.Range(0, Modules.audioDeliveryBag.Count)], Camera.main.transform);
        Modules.PlayAudioClipFree(audioJumpJumper);
        useBag = true;
        takeBag = true;
        //MMVibrationManager.Haptic(HapticTypes.Failure);
    }

    public void SetDoneBag()
    {
        //xu ly thuong sau khi hoan thanh delivery
        useBag = false;
        takeBag = false;
        myBagTake.SetActive(false);
        myBagUse.SetActive(false);
        Camera.main.GetComponent<PageMainGame>().bagController.GetComponent<BagController>().ResetBag();
        if (Modules.useDouble)
            Modules.PlayAudioClipLoop(Modules.audioDiamondFrenzy, Camera.main.transform);
        else Modules.PlayAudioClipLoop(Modules.audioBackgrond, Camera.main.transform);
    }

    public void SetupShowMenu(int indexValue)
    {
        onlyShowMenu = indexValue;
        if (onlyShowMenu > 0)
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(myCollider);
        }
        if (onlyShowMenu > 1)
            Destroy(GetComponent<ShadowFixed>());
    }

    void Start()
    {
        myBagTake.SetActive(false);
        myBagUse.SetActive(false);
        originScaleY = myCollider.transform.localScale.y;
        originScaleX = myCollider.transform.localScale.x;
        originPointY = myCollider.transform.localPosition.y;
        if (deactiveAfferInstan) gameObject.SetActive(false);
        myRigid = transform.GetComponent<Rigidbody>();
    }

    public void ReStart(float heightHero)
    {
        if (onlyShowMenu > 0) return;
        Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        ResetStatus();
        ResetDown(false, false);
        numberLaneNew = 0;
        numberLaneOld = 0;
        handleJumpSkisWall = 0;
        addMoreMove = 0;
        transform.position = new Vector3(numberLaneOld * moveLeftRight, transform.position.y + heightHero, 0);
        oldPointBefore = transform.position;
        overBonusRoad = false;
        checkFalling = false;
        AddForceHero();
        statusHero = StatusHero.run;
        typeAniRun = TypeAniRun.runNormal;
        CallAniNew(aniRunNormal, TypeAniRun.runNormal, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        CancelInvoke();
        Invoke("UpdateFarEnemy", Modules.timeFarEnemy);
        InvokeRepeating("CheckCeintBlock", 0.5f, 0.5f);
        usingNextGate = false;
        stumbleSlow = false;
        stumbleSide = false;
        showRemindCatch = false;
        oldSpeedRun = -1f;
        effectStunned.SetActive(false);
        TaskData.countTimeStay = 0;
        //transform.GetComponent<ShadowFixed>().SetActiveShadow(true);
        //kiem tra xem co dang dung tren bien khong, neu co thi cuoi luon boat
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f), Vector3.down, out hit))
        {
            if (hit.collider.tag == "WaterSurface")
                CallBoats();
        }
        if (useBag)
            Modules.PlayAudioClipLoop(Modules.audioDeliveryBag[Random.Range(0, Modules.audioDeliveryBag.Count)], Camera.main.transform);
        else Modules.PlayAudioClipLoop(Modules.audioBackgrond, Camera.main.transform);
    }

    void CheckCeintBlock()
    {
        if (Modules.statusGame == StatusGame.play && Modules.gameGuide != "YES" && !Modules.useBonus && !Modules.useTemple)
        {
            RaycastHit hit;
            if (Physics.Raycast(pointCheckRay.transform.position, Vector3.up, out hit))
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Default"))
                    Modules.SetAllowHoverbike(false);
            }
            else Modules.SetAllowHoverbike(true);
        }
        //check stay lane
        TaskData.countTimeRun += 0.5f;
        TaskData.countTimeStay += 0.5f;
        TaskData.HandleTaskStay(11, TaskData.countTimeStay, 6);
        TaskData.HandleTaskStay(22, TaskData.countTimeStay, 8);
        TaskData.HandleTaskStay(46, TaskData.countTimeStay, 10);
        TaskData.HandleTaskStay(79, TaskData.countTimeStay, 25);
        TaskData.HandleTaskStay(83, TaskData.countTimeStay, 25);
        TaskData.HandleTaskStay(154, TaskData.countTimeStay, 20);
        TaskData.HandleTaskStay(159, TaskData.countTimeStay, 30);
    }

    public void ResetItemUse()
    {
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Skis");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "ShoeLeft");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "ShoeRight");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Magnet");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Rocket");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Parasol");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Cable");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "JetBall");
        CancelInvoke("RemoveHoverSecretBox");
        Modules.useHoverSecretBox = 0;
        CancelInvoke("RemoveXDiamondSecretBox");
        Modules.xDiamondSecretBox = 1;
        CancelInvoke("RemoveXPointSecretBox");
        Modules.xPointSecretBox = 0;
        Modules.xPointPlayer = Modules.countScoreUse;
        Modules.UpdateXPointText();
    }

    void UpdateFarEnemy()
    {
        Modules.distanceEnemy++;
        if (Modules.distanceEnemy > 2) Modules.distanceEnemy = 2;
    }

    void Update()
    {
        if (onlyShowMenu > 0 || Modules.statusGame == StatusGame.stop) return;
        ReturnRunBasic();
        RunMoveHero();
        RunJumpHero();
        RunBackHero();
        RunFlyBalloon();
        RunFlyCam();
        if (myRigid.IsSleeping()) myRigid.WakeUp();
        if (Modules.statusGame == StatusGame.play)
        {
            //if (doneBackHero && doneMoveLeftRight)
            //    transform.position = new Vector3(Mathf.RoundToInt(moveLeftRight * numberLaneOld), transform.position.y, 0);
            if (Modules.useBonus && transform.position.y < -5f)
                SetDownBonusRoad(0);
            else if (Modules.useTemple && transform.position.y < -5f)
                SetDownTempleRun(0);
            else if (transform.position.y < -50f /*|| transform.position.x > 10 || transform.position.x < -10*/)//xu ly khi xay ra su co bay ra khoi map
            {
                Modules.statusGame = StatusGame.over;
                Modules.HandleGameOver();
            }
        }
    }

    bool CheckAniRunBasic()
    {
        //neu dang o trang thai cac loai chay co ban
        List<TypeAniRun> listBan = new List<TypeAniRun>();
        listBan.Add(TypeAniRun.runNormal);
        listBan.Add(TypeAniRun.runMagnet);
        listBan.Add(TypeAniRun.runSkis);
        listBan.Add(TypeAniRun.runSkisMagnet);
        listBan.Add(TypeAniRun.runRocket);
        listBan.Add(TypeAniRun.runRocketMagnet);
        listBan.Add(TypeAniRun.runCable);
        listBan.Add(TypeAniRun.runCableMagnet);
        listBan.Add(TypeAniRun.runJetBall);
        listBan.Add(TypeAniRun.runJetBallMagnet);
        listBan.Add(TypeAniRun.runJumper);
        return (listBan.Contains(mesAniRunNow));
    }

    bool CheckAniAllowReturnRun()
    {
        //neu dang o trang thai cac loai chay co ban
        List<TypeAniRun> listBan = new List<TypeAniRun>();
        listBan.Add(TypeAniRun.jumpNormal);
        listBan.Add(TypeAniRun.jumpPower);
        listBan.Add(TypeAniRun.jumpMagnet);
        listBan.Add(TypeAniRun.jumpMagnetPower);
        listBan.Add(TypeAniRun.jumpSkis);
        listBan.Add(TypeAniRun.jumpSkisPower);
        listBan.Add(TypeAniRun.jumpSkisMagnet);
        listBan.Add(TypeAniRun.jumpSkisMagnetPower);
        listBan.Add(TypeAniRun.fallNormal);
        listBan.Add(TypeAniRun.fallMagnet);
        listBan.Add(TypeAniRun.fallSkis);
        listBan.Add(TypeAniRun.fallSkisMagnet);
        listBan.Add(TypeAniRun.fallRocket);
        listBan.Add(TypeAniRun.fallCable);
        listBan.Add(TypeAniRun.fallJetBall);
        listBan.Add(TypeAniRun.fallJumper);
        return (!listBan.Contains(mesAniRunNow));
    }

    bool CheckAniAllowJump()
    {
        //neu khong o cac trang thai chay cho phep nhay
        List<TypeAniRun> listBan = new List<TypeAniRun>();
        listBan.Add(TypeAniRun.jumpNormal);
        listBan.Add(TypeAniRun.jumpPower);
        listBan.Add(TypeAniRun.jumpMagnet);
        listBan.Add(TypeAniRun.jumpMagnetPower);
        listBan.Add(TypeAniRun.jumpSkis);
        listBan.Add(TypeAniRun.jumpSkisPower);
        listBan.Add(TypeAniRun.jumpSkisMagnet);
        listBan.Add(TypeAniRun.jumpSkisMagnetPower);
        return !listBan.Contains(mesAniRunNow) && !Modules.useRocket && !Modules.useJumper && !Modules.useCable && !Modules.useJetBall;
    }

    bool CheckAniAllowDown()
    {
        return (!Modules.useRocket && !Modules.useJumper && !Modules.useCable && !Modules.useJetBall);
    }

    bool CheckAniAllowSkis()
    {
        return (!Modules.useSkis && !Modules.useRocket && !Modules.useJumper && !Modules.useCable && !Modules.useJetBall);
    }

    public float CallAniMenu(AnimationClip aniClip, float speedAni, bool loopAni = true)
    {
        float timeResult = 0;
        if (aniHero == null || aniClip == null) return timeResult;
        timeResult = aniHero[aniClip.name].length / speedAni;
        aniHero[aniClip.name].speed = speedAni;
        aniHero[aniClip.name].wrapMode = WrapMode.Loop;
        if (!loopAni) aniHero[aniClip.name].wrapMode = WrapMode.Once;
        aniHero.Play(aniClip.name);
        return timeResult;
    }

    void CallAniNew(AnimationClip aniClip, TypeAniRun typeAni, bool loopAni = true, float speedMore = 1, float speedAdd = 0, float maxSpeed = -1)
    {
        if (aniHero == null || aniClip == null) return;
        CheckFinishTakeBag();
        mesAniRunNow = typeAni;
        float speedAniNow = 0;
        speedAniNow = /*Modules.speedGame * */numSpeedAni * speedMore + speedAdd;
        if (maxSpeed != -1 && speedAniNow > maxSpeed) speedAniNow = maxSpeed;
        aniHero[aniClip.name].speed = speedAniNow;
        aniHero[aniClip.name].time = 0;
        aniHero[aniClip.name].wrapMode = WrapMode.Loop;
        if (!loopAni) aniHero[aniClip.name].wrapMode = WrapMode.Once;
        aniHero.Play(aniClip.name);
    }

    bool ResetDown(bool addFore, bool checkDown)
    {
        bool result = false;
        if (isDown)
        {
            handleJumpSkisWall = 0;
            RemoveSpeedSlow();
            isDown = false;
            myCollider.transform.localScale =
                new Vector3(myCollider.transform.localScale.x, originScaleY, myCollider.transform.localScale.z);
            myCollider.transform.localPosition =
                new Vector3(myCollider.transform.localPosition.x, originPointY, myCollider.transform.localPosition.z);
            result = SetFallingAfterAction(addFore, checkDown);
        }
        return result;
    }

    void SetReturnRunBasic(bool autoReturn = true)
    {
        if (ResetDown(true, true)) return;
        if (overBonusRoad) return;//neu ket thuc bonus road thi khong tu dong chuyen animation nua
        if (autoReturn)
            if (!CheckAniAllowReturnRun())
            {
                if (checkFalling)
                    SetAniFalling();
                return;//neu cac animation chay frame auto thi check them
            }
        //xu ly khi goi skis
        if (mesAniRunNow == TypeAniRun.callSkis)
        {
            if (typeAniRun == TypeAniRun.runSkis)//neu dang chay thuong
                CallAniNew(aniRunSkis, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else if (typeAniRun == TypeAniRun.runSkisMagnet)//neu dang cam nam cham
                CallAniNew(aniRunSkisMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            RemoveSpeedSlow();
            statusHero = StatusHero.run;
            return;
        }
        //khi hoan thanh cac animation trai, phai, nhay... thi tra ve animation chay co ban
        if (typeAniRun == TypeAniRun.runNormal)
        {
            if (Modules.usePower)
                CallAniNew(aniRunSneaker, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else CallAniNew(aniRunNormal, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runMagnet)
        {
            if (Modules.usePower)
                CallAniNew(aniRunSneakerMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else CallAniNew(aniRunMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runSkis)
        {
            if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                CallAniNew(aniRunCable, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else if (Modules.useBoat)
                CallAniNew(aniRunBoat, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else
                CallAniNew(aniRunSkis, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            if (skisHide != null) skisHide.SetActive(true);
        }
        else if (typeAniRun == TypeAniRun.runSkisMagnet)
        {
            if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                CallAniNew(aniRunCableMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else if (Modules.useBoat)
                CallAniNew(aniRunBoatMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else
                CallAniNew(aniRunSkisMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            if (skisHide != null) skisHide.SetActive(true);
        }
        else if (typeAniRun == TypeAniRun.runRocket)
        {
            AnimationClip aniNow = aniRunRocket;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRunBroom;
            CallAniNew(aniNow, typeAniRun, true, 0.25f, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runRocketMagnet)
        {
            AnimationClip aniNow = aniRunRocketMagnet;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRunBroomMagnet;
            CallAniNew(aniNow, typeAniRun, true, 0.25f, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runJumper)
            CallAniNew(aniRunJumper[Random.Range(0, aniRunJumper.Count)], typeAniRun, true, 1.3f, Modules.moreSpeedAni, Modules.maxSpeedAni);
        else if (typeAniRun == TypeAniRun.runCable)
            CallAniNew(aniRunCable, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        else if (typeAniRun == TypeAniRun.runCableMagnet)
            CallAniNew(aniRunCableMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        else if (typeAniRun == TypeAniRun.runJetBall)
            CallAniNew(aniRunJetBall, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        else if (typeAniRun == TypeAniRun.runJetBallMagnet)
            CallAniNew(aniRunJetBallMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        statusHero = StatusHero.run;
        if (stumbleSlow)
        {
            RemoveSpeedSlow();
            stumbleSlow = false;
        }
        AutoControlLast();
    }

    void ReturnRunBasic()
    {
        if (Modules.statusGame == StatusGame.flyScene)
        {
            if (mesAniRunNow == TypeAniRun.balloonUp || mesAniRunNow == TypeAniRun.balloonDown)
            {
                if (!aniHero.isPlaying)
                {
                    if (mesAniRunNow == TypeAniRun.balloonUp)
                    {
                        //dieu khien kinh khi cau bay len tai day
                        CallAniNew(aniDriver, TypeAniRun.balloonDriver, true, 1, 0, Modules.maxSpeedAni);
                        FlyBalloon();
                    }
                    else if (mesAniRunNow == TypeAniRun.balloonDown)
                    {
                        //thuc hien xu ly chay tiep sau khi ha khinh khi cau
                        SetReturnRunBasic();
                        Modules.statusGame = StatusGame.play;
                    }
                }
            }
            else if (mesAniRunNow == TypeAniRun.flyCamUp || mesAniRunNow == TypeAniRun.flyCamDown)
            {
                if (!aniHero.isPlaying)
                {
                    if (mesAniRunNow == TypeAniRun.flyCamUp)
                    {
                        //dieu khien fly cam bay len tai day
                        CallAniNew(aniFlyCamSway[Random.Range(0, aniFlyCamSway.Count)], TypeAniRun.flyCamSway, true, 1, 0, Modules.maxSpeedAni);
                        FlyCam();
                    }
                    else if (mesAniRunNow == TypeAniRun.flyCamDown)
                    {
                        //thuc hien xu ly chay tiep sau khi ha fly cam
                        SetReturnRunBasic();
                        Modules.statusGame = StatusGame.play;
                    }
                }
            }
        }
        if (Modules.statusGame == StatusGame.over)
        {
            if (statusHero == StatusHero.fallB && !aniHero.isPlaying)
                ShowPanelCrack();
        }
        if (Modules.statusGame != StatusGame.play) return;
        //neu khong o trang thai chay co ban va khong dang tinh trang roi thi tu quay ve trang thai chay co ban
        if (!aniHero.isPlaying)
        {
            CheckFinishTakeBag();
            if (!CheckAniRunBasic())
                SetReturnRunBasic();
            //else if (checkFalling)
            //    SetAniFalling();
        }
    }

    private void CheckFinishTakeBag()
    {
        if (takeBag)
        {
            myBagTake.SetActive(false);
            myBagUse.SetActive(true);
            Modules.lockControll = false;
            takeBag = false;
        }
    }

    //private bool CheckGround()
    //{
    //    bool result = true;
    //    if (Modules.useBonus && !mesStartJump)
    //    {
    //        if (!Physics.Raycast(pointCheckRay.transform.position, Vector3.down))
    //            result = false;
    //    }
    //    return result;
    //}
    private bool CheckCrossroads(Vector3 direction)
    {
        //xu ly crossroads
        Modules.runCrossroads = false;
        RaycastHit hit;
        if (Physics.Raycast(pointCheckRay.transform.position, direction, out hit))
        {
            Crossroads cr = hit.collider.gameObject.GetComponent<Crossroads>();
            if (cr != null)
                SetRunCrossroads(cr, direction == Vector3.left ? true : false);
        }
        return Modules.runCrossroads;
    }

    private void SetRunCrossroads(Crossroads crObject, bool leftDirect)
    {
        Modules.terrainCrossroads = crObject.terrainCrossroads;
        Modules.rotateCrossroads = Modules.terrainCrossroads.GetComponent<TerrainInformation>().objectRotate;
        Modules.runCrossroads = true;
        Modules.leftCrossroads = leftDirect;
        Modules.moveCrossroads = true;
        Modules.detalTerrain = Modules.terrainCrossroads.transform.position.z;
    }

    private Transform textGuide, arrowGuide, keyUp, keyDown, keyLeft, keyRight, keySpace;
    private int addMoreMove = 0;//0 none, 1 left, 2 right, 3 jump, 4 down;
    public void MoveLeft(bool checkMoreMove = false)
    {
        if (Modules.statusGame != StatusGame.play || Modules.runCrossroads || Modules.lockControll) return;
        //if (!CheckGround()) return;
        //if (!doneBackHero) { if (checkMoreMove) addMoreMove = 1; return; }
        if (CheckCrossroads(Vector3.left)) return;
        if (numberLaneNew < 0)
            if (Modules.useBonus || Modules.useJumper || Modules.useRocket || Modules.useCable || Modules.useJetBall) return;
        if (Modules.gameGuide == "YES" && Modules.stepGuide == 0)
        {
            Modules.stepGuide++;
            textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
            textGuide.GetComponent<Text>().text = AllLanguages.playSwipeRight[Modules.indexLanguage];
            arrowGuide = Modules.panelGameGuide.transform.Find("ArrowGuide");
            keyLeft = Modules.panelGameGuide.transform.Find("KeyLeft");
            keyRight = Modules.panelGameGuide.transform.Find("KeyRight");
            if (Application.isMobilePlatform)
                arrowGuide.transform.eulerAngles = new Vector3(0, 0, 180);
            else
            {
                keyLeft.GetComponent<Animator>().SetTrigger("TriIdle");
                keyRight.GetComponent<Animator>().SetTrigger("TriPlay");
            }
        }
        if (Modules.useBoat) Modules.PlayAudioClipFree(Modules.audioBoatSwipeMove);
        else if (Modules.useSkis)
        {
            SkisController skisCon = skisNow.GetComponent<SkisController>();
            if (skisCon.haveSwipe)
                Modules.PlayAudioClipFree(skisCon.swipeLeft);
            else Modules.PlayAudioClipFree(Modules.audioSwipeMove);
        }
        else Modules.PlayAudioClipFree(Modules.audioSwipeMove);
        //statusHero = StatusHero.left;
        MoveHero(true);
        if ((!doneJumpHero && !Modules.useJumper && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall) || checkFalling) return;
        if (typeAniRun == TypeAniRun.runNormal) { CallAniNew(aniLeftNormal, TypeAniRun.moveNormalLeft, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runMagnet) { CallAniNew(aniLeftMagnet, TypeAniRun.moveMagnetLeft, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runSkis)
        {
            if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                CallAniNew(aniLeftCable[Random.Range(0, aniLeftCable.Count)], TypeAniRun.moveSkisLeft, false, 0.9f);
            else CallAniNew(aniLeftSkis, TypeAniRun.moveSkisLeft, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runSkisMagnet)
        {
            if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                CallAniNew(aniLeftCableMagnet[Random.Range(0, aniLeftCableMagnet.Count)], TypeAniRun.moveSkisMagnetLeft, false, 0.9f);
            else CallAniNew(aniLeftSkisMagnet, TypeAniRun.moveSkisMagnetLeft, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runRocket)
        {
            AnimationClip aniNow = aniLeftRocket;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniLeftBroom;
            CallAniNew(aniNow, TypeAniRun.moveRocketLeft, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runRocketMagnet)
        {
            AnimationClip aniNow = aniLeftRocketMagnet;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniLeftBroomMagnet;
            CallAniNew(aniNow, TypeAniRun.moveRocketMagnetLeft, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runCable) { CallAniNew(aniLeftCable[Random.Range(0, aniLeftCable.Count)], TypeAniRun.moveCableLeft, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runCableMagnet) { CallAniNew(aniLeftCableMagnet[Random.Range(0, aniLeftCableMagnet.Count)], TypeAniRun.moveCableMagnetLeft, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runJetBall) { CallAniNew(aniLeftJetBall, TypeAniRun.moveJetBallLeft, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runJetBallMagnet) { CallAniNew(aniLeftJetBallMagnet, TypeAniRun.moveJetBallMagnetLeft, false, 0.6f); }
        if (Modules.flyCamCatch) Modules.flyCamCatch = false;
    }

    public void MoveRight(bool checkMoreMove = false)
    {
        if (Modules.statusGame != StatusGame.play || Modules.lockControll) return;
        //if (!CheckGround()) return;
        //if (!doneBackHero) { if (checkMoreMove) addMoreMove = 2; return; }
        if (CheckCrossroads(Vector3.right)) return;
        if (numberLaneNew > 0)
            if (Modules.useBonus || Modules.useJumper || Modules.useRocket || Modules.useCable || Modules.useJetBall) return;
        if (Modules.gameGuide == "YES" && Modules.stepGuide == 1)
        {
            Modules.stepGuide++;
            //textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
            textGuide.GetComponent<Text>().text = AllLanguages.playSwipeUp[Modules.indexLanguage];
            keyUp = Modules.panelGameGuide.transform.Find("KeyUp");
            //keyRight = Modules.panelGameGuide.transform.Find("KeyRight");
            if (Application.isMobilePlatform)
                arrowGuide.transform.eulerAngles = new Vector3(0, 0, 270);
            else
            {
                keyRight.GetComponent<Animator>().SetTrigger("TriIdle");
                keyUp.GetComponent<Animator>().SetTrigger("TriPlay");
            }
        }
        if (Modules.useBoat) Modules.PlayAudioClipFree(Modules.audioBoatSwipeMove);
        else if (Modules.useSkis)
        {
            SkisController skisCon = skisNow.GetComponent<SkisController>();
            if (skisCon.haveSwipe)
                Modules.PlayAudioClipFree(skisCon.swipeRight);
            else Modules.PlayAudioClipFree(Modules.audioSwipeMove);
        }
        else Modules.PlayAudioClipFree(Modules.audioSwipeMove);
        //statusHero = StatusHero.right;
        MoveHero(false);
        if ((!doneJumpHero && !Modules.useJumper && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall) || checkFalling) return;
        if (typeAniRun == TypeAniRun.runNormal) { CallAniNew(aniRightNormal, TypeAniRun.moveNormalRight, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runMagnet) { CallAniNew(aniRightMagnet, TypeAniRun.moveMagnetRight, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runSkis)
        {
            if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                CallAniNew(aniRightCable[Random.Range(0, aniRightCable.Count)], TypeAniRun.moveSkisRight, false, 0.9f);
            else CallAniNew(aniRightSkis, TypeAniRun.moveSkisRight, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runSkisMagnet)
        {
            if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                CallAniNew(aniRightCableMagnet[Random.Range(0, aniRightCableMagnet.Count)], TypeAniRun.moveSkisMagnetRight, false, 0.9f);
            else CallAniNew(aniRightSkisMagnet, TypeAniRun.moveSkisMagnetRight, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runRocket)
        {
            AnimationClip aniNow = aniRightRocket;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRightBroom;
            CallAniNew(aniNow, TypeAniRun.moveRocketRight, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runRocketMagnet)
        {
            AnimationClip aniNow = aniRightRocketMagnet;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRightBroomMagnet;
            CallAniNew(aniNow, TypeAniRun.moveRocketMagnetRight, false, 0.6f);
        }
        else if (typeAniRun == TypeAniRun.runCable) { CallAniNew(aniRightCable[Random.Range(0, aniRightCable.Count)], TypeAniRun.moveCableRight, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runCableMagnet) { CallAniNew(aniRightCableMagnet[Random.Range(0, aniRightCableMagnet.Count)], TypeAniRun.moveCableMagnetRight, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runJetBall) { CallAniNew(aniRightJetBall, TypeAniRun.moveJetBallRight, false, 0.6f); }
        else if (typeAniRun == TypeAniRun.runJetBallMagnet) { CallAniNew(aniRightJetBallMagnet, TypeAniRun.moveJetBallMagnetRight, false, 0.6f); }
        if (Modules.flyCamCatch) Modules.flyCamCatch = false;
    }

    private int CheckCatchFlyCam()
    {
        int checkCathFlyCam = 0;//0 normal, 1 catch fly cam, 2 miss fly cam
        if (Modules.flyCamGoOut && Modules.flyCamNow != null && Modules.flyCamNow.activeSelf)
        {
            if (Modules.flyCamNow.GetComponent<FlyCamController>().laneNow == numberLaneNew)
            {
                if (Modules.flyCamNow.transform.position.y - transform.position.y <= distanceHeightFlyCam)
                {
                    if (Modules.flyCamNow.transform.position.z > -distanceCatchFlyCam && Modules.flyCamNow.transform.position.z < distanceCatchFlyCam)
                    {
                        checkCathFlyCam = 1;
                    }
                    else if (Modules.flyCamNow.transform.position.z > -distanceMissFlyCam && Modules.flyCamNow.transform.position.z < distanceMissFlyCam)
                    {
                        checkCathFlyCam = 2;
                    }
                }
            }
        }
        return checkCathFlyCam;
    }

    public void MoveUp(bool checkMoreMove = false)
    {
        if (Modules.statusGame != StatusGame.play || Modules.lockControll) return;
        //if (!CheckGround()) return;
        if (/*!doneBackHero || */(!doneJumpHero && doneBackHero && handleJumpSkisWall == 0) || !CheckAniAllowJump()/* || (isDown && CheckOnTheAir())*/) { if (checkMoreMove) addMoreMove = 3; return; }
        if (Modules.gameGuide == "YES" && Modules.stepGuide == 2)
        {
            Modules.stepGuide++;
            //textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
            textGuide.GetComponent<Text>().text = AllLanguages.playSwipeDown[Modules.indexLanguage];
            //keyUp = Modules.panelGameGuide.transform.Find("KeyUp");
            keyDown = Modules.panelGameGuide.transform.Find("KeyDown");
            if (Application.isMobilePlatform)
                arrowGuide.transform.eulerAngles = new Vector3(0, 0, 90);
            else
            {
                keyUp.GetComponent<Animator>().SetTrigger("TriIdle");
                keyDown.GetComponent<Animator>().SetTrigger("TriPlay");
            }
        }
        if (Modules.useSkis)
        {
            SkisController skisCon = skisNow.GetComponent<SkisController>();
            if (skisCon.haveSwipe)
                Modules.PlayAudioClipFree(skisCon.swipeUp);
            else Modules.PlayAudioClipFree(Modules.audioSkisJumpStart);
        }
        else if (Modules.usePower) Modules.PlayAudioClipFree(Modules.audioSneakerJump);
        else if (Modules.useBoat) Modules.PlayAudioClipFree(Modules.audioBoatJump);
        else Modules.PlayAudioClipFree(Modules.audioSwipeUp);
        if (Modules.useBoat && boatNow != null)
        {
            boatNow.GetComponent<PlaySparksBoat>().ShowHideSparks(false);
            Modules.StopAudioClipLoop(Modules.containMainGame.transform);
        }
        JumpHero();
        //xu ly catch fly cam
        int checkCathFlyCam = CheckCatchFlyCam();
        if (checkCathFlyCam == 1)//catch fly cam
        {
            Modules.flyCamCatch = true;
            if (Modules.useSkis)
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniFlyCamCatchBoat, TypeAniRun.jumpNormal, false, 1.25f);
                else CallAniNew(aniFlyCamCatchSkis, TypeAniRun.jumpNormal, false, 1.25f);
            }
            else if (Modules.useBoat) CallAniNew(aniFlyCamCatchBoat, TypeAniRun.jumpNormal, false, 1.25f);
            else CallAniNew(aniFlyCamCatch, TypeAniRun.jumpNormal, false, 1.25f);
        }
        else if (checkCathFlyCam == 2)//miss fly cam
        {
            if (Modules.useSkis)
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniFlyCamMissBoat, TypeAniRun.jumpNormal, false, 1.25f);
                else CallAniNew(aniFlyCamMissSkis, TypeAniRun.jumpNormal, false, 1.25f);
            }
            else if (Modules.useBoat) CallAniNew(aniFlyCamMissBoat, TypeAniRun.jumpNormal, false, 1.25f);
            else CallAniNew(aniFlyCamMiss, TypeAniRun.jumpNormal, false, 1.25f);
            if (maleHero)
                Modules.PlayAudioClipFree(Modules.audioMissCatchMale[Random.Range(0, Modules.audioMissCatchMale.Count)]);
            else Modules.PlayAudioClipFree(Modules.audioMissCatchFemale[Random.Range(0, Modules.audioMissCatchFemale.Count)]);
        }
        else if (typeAniRun == TypeAniRun.runNormal)//neu dang chay thuong
        {
            if (Modules.usePower)
                CallAniNew(aniJumpPower[Random.Range(0, aniJumpPower.Count)], TypeAniRun.jumpPower, true, 1.25f);
            else
                CallAniNew(aniJumpNormal[Random.Range(0, aniJumpNormal.Count)], TypeAniRun.jumpNormal, false, 1.25f);
        }
        else if (typeAniRun == TypeAniRun.runMagnet)//neu dang cam nam cham
        {
            if (Modules.usePower)
                CallAniNew(aniJumpMagnetPower[Random.Range(0, aniJumpMagnetPower.Count)], TypeAniRun.jumpMagnetPower, true, 1.25f);
            else
                CallAniNew(aniJumpMagnet[Random.Range(0, aniJumpMagnet.Count)], TypeAniRun.jumpMagnet, false, 1.25f);
        }
        else if (typeAniRun == TypeAniRun.runSkis)//neu dang truot van [Neu chinh toc do animation thi chinh ca khi an waterRamp]
        {
            if (Modules.usePower)
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniJumpCablePower[Random.Range(0, aniJumpCablePower.Count)], TypeAniRun.jumpSkisPower, false, 1.25f);
                else if (Modules.useBoat)
                    CallAniNew(aniJumpBoatPower[Random.Range(0, aniJumpBoatPower.Count)], TypeAniRun.jumpSkisPower, false, 1.25f);
                else CallAniNew(aniJumpSkisPower[Random.Range(0, aniJumpSkisPower.Count)], TypeAniRun.jumpSkisPower, false, 1.25f);
            }
            else
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniJumpCable[Random.Range(0, aniJumpCable.Count)], TypeAniRun.jumpSkis, false, 1.5f);
                else if (Modules.useBoat)
                    CallAniNew(aniJumpBoat[Random.Range(0, aniJumpBoat.Count)], TypeAniRun.jumpSkis, false, 1.5f);
                else CallAniNew(aniJumpSkis[Random.Range(0, aniJumpSkis.Count)], TypeAniRun.jumpSkis, false, 1.5f);
            }
        }
        else if (typeAniRun == TypeAniRun.runSkisMagnet)//neu dang truot van va cam nam cham [Neu chinh toc do animation thi chinh ca khi an waterRamp]
        {
            if (Modules.usePower)
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniJumpCableMagnetPower[Random.Range(0, aniJumpCableMagnetPower.Count)], TypeAniRun.jumpSkisMagnetPower, false, 1.25f);
                else if (Modules.useBoat)
                    CallAniNew(aniJumpBoatMagnetPower[Random.Range(0, aniJumpBoatMagnetPower.Count)], TypeAniRun.jumpSkisMagnetPower, false, 1.25f);
                else CallAniNew(aniJumpSkisMagnetPower[Random.Range(0, aniJumpSkisMagnetPower.Count)], TypeAniRun.jumpSkisMagnetPower, false, 1.25f);
            }
            else
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniJumpCableMagnet[Random.Range(0, aniJumpCableMagnet.Count)], TypeAniRun.jumpSkisMagnet, false, 1.5f);
                if (Modules.useBoat)
                    CallAniNew(aniJumpBoatMagnet[Random.Range(0, aniJumpBoatMagnet.Count)], TypeAniRun.jumpSkisMagnet, false, 1.5f);
                else CallAniNew(aniJumpSkisMagnet[Random.Range(0, aniJumpSkisMagnet.Count)], TypeAniRun.jumpSkisMagnet, false, 1.5f);
            }
        }
        statusHero = StatusHero.jump;
    }

    private bool isDown = false;//danh dau trang thai dang chui
    public void MoveDown(bool checkMoreMove = false)
    {
        if (Modules.statusGame != StatusGame.play || Modules.lockControll) return;
        //if (!CheckGround()) return;
        if (/*!doneBackHero || */isDown || !CheckAniAllowDown()) { if (checkMoreMove) addMoreMove = 4; return; }
        if (Modules.gameGuide == "YES" && Modules.stepGuide == 3)
        {
            Modules.stepGuide++;
            //textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
            textGuide.GetComponent<Text>().text = AllLanguages.playCatchFlyCam[Modules.indexLanguage];
            Camera.main.GetComponent<CallFlyCam>().StartFlyCamNow();
            //keyUp = Modules.panelGameGuide.transform.Find("KeyUp");
            //keyDown = Modules.panelGameGuide.transform.Find("KeyDown");
            //keyLeft = Modules.panelGameGuide.transform.Find("KeyLeft");
            //keyRight = Modules.panelGameGuide.transform.Find("KeyRight");
            if (Application.isMobilePlatform)
                arrowGuide.gameObject.SetActive(false);
            else
            {
                keyUp.gameObject.SetActive(false);
                keyDown.gameObject.SetActive(false);
                keyLeft.gameObject.SetActive(false);
                keyRight.gameObject.SetActive(false);
            }
        }
        if ((Modules.useSkis && skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
            Modules.PlayAudioClipFree(Modules.audioBoatSpeedUp);
        else if (Modules.useSkis)
        {
            SkisController skisCon = skisNow.GetComponent<SkisController>();
            if (skisCon.haveSwipe)
                Modules.PlayAudioClipFree(skisCon.swipeDown);
            else Modules.PlayAudioClipFree(Modules.audioSwipeDown);
        }
        else Modules.PlayAudioClipFree(Modules.audioSwipeDown);
        //MMVibrationManager.Haptic(HapticTypes.LightImpact);
        SetRigibodyNormal();
        AddForceHero(25);
        TaskData.HandleTask(6, 1, 10);
        TaskData.HandleTask(9, 1, 30);
        TaskData.HandleTask(44, 1, 40);
        TaskData.HandleTask(93, 1, 3000);
        TaskData.HandleTask(107, 1, 250);
        TaskData.HandleTask(119, 1, 100);
        TaskData.HandleTask(150, 1, 1000);
        if (numberLaneOld == 0)
        {
            TaskData.HandleTask(112, 1, 500);
        }
        else if (numberLaneOld < 0)
        {
            TaskData.HandleTask(139, 1, 200);
        }
        else if (numberLaneOld > 0)
        {
            TaskData.HandleTask(147, 1, 300);
        }
        if (typeRunOn == "GroundTrain")
        {
            TaskData.HandleTask(51, 1, 30);
            TaskData.HandleTask(69, 1, 200);
        }
        else if (typeRunOn == "MonoTrain")
        {
            TaskData.HandleTask(54, 1, 30);
            TaskData.HandleTask(69, 1, 200);
        }
        if (typeAniRun == TypeAniRun.runNormal)//neu dang chay thuong
            CallAniNew(aniDownNormal[Random.Range(0, aniDownNormal.Count)], TypeAniRun.downNormal, false);
        else if (typeAniRun == TypeAniRun.runMagnet)//neu dang cam nam cham
            CallAniNew(aniDownMagnet[Random.Range(0, aniDownMagnet.Count)], TypeAniRun.downMagnet, false);
        else if (typeAniRun == TypeAniRun.runSkis)//neu dang truot van
        {
            if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                CallAniNew(aniDownCable[Random.Range(0, aniDownCable.Count)], TypeAniRun.downSkis, false);
            else CallAniNew(aniDownSkis[Random.Range(0, aniDownSkis.Count)], TypeAniRun.downSkis, false);
        }
        else if (typeAniRun == TypeAniRun.runSkisMagnet)//neu dang truot van va cam nam cham
        {
            if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                CallAniNew(aniDownCableMagnet[Random.Range(0, aniDownCableMagnet.Count)], TypeAniRun.downSkisMagnet, false);
            else CallAniNew(aniDownSkisMagnet[Random.Range(0, aniDownSkisMagnet.Count)], TypeAniRun.downSkisMagnet, false);
        }
        //statusHero = StatusHero.down;
        myCollider.transform.localScale = new Vector3(myCollider.transform.localScale.x, originScaleY / 2f, myCollider.transform.localScale.z);
        myCollider.transform.localPosition = new Vector3(myCollider.transform.localPosition.x, originPointY / 2f, myCollider.transform.localPosition.z);
        isDown = true;
        mesStartJump = false;
        doneJumpHero = true;
        addMoreMove = 0;
        if (handleJumpSkisWall != 0 || !doneBackHero)
        {
            mesStartBack = false;
            doneBackHero = true;
            mesStartMove = false;
            doneMoveLeftRight = true;
            stopMoveLeftRight = true;
            transform.position = new Vector3(numberLaneOld * moveLeftRight, transform.position.y, 0);
        }
        if (Modules.flyCamCatch) Modules.flyCamCatch = false;
        //xu ly hoverbike/ boat effect
        if (Modules.useBoat)
        {
            Modules.speedBoatUp = 0.18f;
            Modules.parSpeedFly.GetComponent<ParticleSystem>().Play();
            CancelInvoke("RemoveBoatSpeedUp");
            Invoke("RemoveBoatSpeedUp", 10f);
            if (Modules.showDownBoat == 0)
            {
                Modules.showDownBoat = 1;
                PlayerPrefs.SetInt("ShowDownBoat", Modules.showDownBoat);
                Modules.panelGameGuide.SetActive(false);
            }
        }
        else if (Modules.useSkis)
        {
            PlayFlameSkis playFlame = skisNow.GetComponent<PlayFlameSkis>();
            if (playFlame != null) playFlame.PlaySpeedFlame();
        }
        //Camera.main.GetComponent<CameraController>().ResetTimeFollow();
    }

    void RemoveBoatSpeedUp()
    {
        Modules.speedBoatUp = 0;
        SetStopEffectQuick();
    }

    void RemoveBlueArrow()
    {
        Modules.speedBuleArrow = 0;
        SetStopEffectQuick();
    }

    void SetStopEffectQuick()
    {
        if (Modules.speedBoatUp == 0 && Modules.speedBuleArrow == 0 && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall && !Modules.useJumper)
            Modules.parSpeedFly.GetComponent<ParticleSystem>().Stop();
    }

    private bool showRemindCatch = false;
    public void ShowRemindCatchFlyCam()
    {
        if (showRemindCatch) return;
        if (Modules.gameGuide == "YES" && Modules.stepGuide == 4)
        {
            if (CheckCatchFlyCam() == 1)
            {
                showRemindCatch = true;
                arrowGuide.gameObject.SetActive(showRemindCatch);
                arrowGuide.transform.eulerAngles = new Vector3(0, 0, 270);
            }
        }
    }

    public void HideRemindCatchFlyCam()
    {
        if (!showRemindCatch) return;
        if (Modules.gameGuide == "YES" && Modules.stepGuide == 4)
        {
            showRemindCatch = false;
            arrowGuide.gameObject.SetActive(showRemindCatch);
        }
    }

    void RemoveGuide()
    {
        //Modules.panelGameGuide.SetActive(false);
        Camera.main.GetComponent<PageMainGame>().ShowMissionsChallenge();
        Invoke("ShowTextBegin", 10f);
    }

    void ShowTextBegin()
    {
        foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
        GameObject effect = Instantiate(Modules.textStartMove[Modules.indexLanguage], Modules.parentTextEffect.transform);
        effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
    }

    public void UseSkis()
    {
        if (Modules.statusGame != StatusGame.play || Modules.lockControll) return;
        if (Modules.useBonus || Modules.useTemple || Modules.useBoat || !CheckAniAllowSkis() || Modules.totalSkis <= 0) return;
        if (Modules.gameGuide == "YES" && Modules.stepGuide == 5)
        {
            Modules.stepGuide++;
            keySpace = Modules.panelGameGuide.transform.Find("KeySpace");
            keySpace.gameObject.SetActive(false);
            if (Modules.totalHeadStart > 0)
            {
                Modules.SetAllowHoverbike(true);
                //textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
                textGuide.GetComponent<Text>().text = AllLanguages.playUseHoverbike[Modules.indexLanguage];
                Transform iconItemBuy = Modules.panelGameGuide.transform.Find("IconItemBuy");
                iconItemBuy.GetComponent<Image>().enabled = true;
            }
            else
            {
                //Transform textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
                //textGuide.GetComponent<Text>().text = AllLanguages.playBeginMove[Modules.indexLanguage];
                UseDoubleCoin();
                Camera.main.GetComponent<PageMainGame>().bagController.GetComponent<BagController>().SetCooldown(5, 1);
                Modules.gameGuide = "NO";
                Modules.SaveGameGuide();
                Modules.panelGameGuide.SetActive(false);
                Invoke("RemoveGuide", 1f);
            }
        }
        if (Modules.gameGuide == "YES" && Modules.stepGuide != 6) return;
        Modules.PlayAudioClipFree(Modules.audioUpSkis);
        MMVibrationManager.Haptic(HapticTypes.Failure);
        GameObject skisUse = mySkis;
        if (Modules.useHoverSecretBox == 1) skisUse = Modules.hoverSecretBox1;
        else if (Modules.useHoverSecretBox == 2) skisUse = Modules.hoverSecretBox2;
        Modules.SetPanelShowItem(TypeItems.hoverboard, Modules.ChangeIconHoverboard(skisUse.GetComponent<SkisController>().idSkis));
        Modules.useSkis = true;
        Modules.totalSkis--;
        Modules.SaveSkis();
        TaskData.HandleTask(4, 1, 1);
        TaskData.HandleTask(74, 1, 15);
        TaskData.HandleTask(127, 1, 5000);
        skisNow = Modules.SetModelUseItem(transform, codeBody, skisUse, "Skis");
        Modules.speedPercentSkis = skisNow.GetComponent<SkisController>().speedPercent;
        if (skisNow.GetComponent<SkisController>().isHoverbike)
        {
            RemoveSpeedSlow();
            if (typeAniRun == TypeAniRun.runNormal)//neu dang chay thuong
            {
                typeAniRun = TypeAniRun.runSkis;
                CallAniNew(aniRunCable, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
            else if (typeAniRun == TypeAniRun.runMagnet)//neu dang cam nam cham
            {
                typeAniRun = TypeAniRun.runSkisMagnet;
                CallAniNew(aniRunCableMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
        }
        else
        {
            if (typeAniRun == TypeAniRun.runNormal)//neu dang chay thuong
                typeAniRun = TypeAniRun.runSkis;
            else if (typeAniRun == TypeAniRun.runMagnet)//neu dang cam nam cham
                typeAniRun = TypeAniRun.runSkisMagnet;
            CallAniNew(aniCallSkis, TypeAniRun.callSkis, false);
        }
        ResetDown(false, false);
    }

    void AutoControlLast()
    {
        if (Modules.statusGame != StatusGame.play) return;
        if (addMoreMove == 1)//left more
        {
            MoveLeft(true);
        }
        else if (addMoreMove == 2)//right more
        {
            MoveRight(true);
        }
        else if (addMoreMove == 3)//jump more
        {
            MoveUp(true);
        }
        else if (addMoreMove == 4)//down more
        {
            MoveDown(true);
        }
    }

    //XU LY DI CHUYEN TRAI PHAI
    private bool mesStartMove = false;
    private float speedMove = 1f;
    private bool doneMoveLeftRight = true;
    private bool stopMoveLeftRight = false;
    private int sightCheckMove = 1;//chieu move
    private bool checkInAir = false;

    void RunMoveHero()
    {
        if (Modules.statusGame == StatusGame.flyScene || Modules.statusGame == StatusGame.bonusEffect) mesStartMove = false;
        if (stopMoveLeftRight) return;
        if (!mesStartMove) return;
        float heightNow = transform.position.y;
        if (checkFalling && checkInAir) heightNow = transform.position.y - 15f * Time.deltaTime;
        Vector3 pointFinal = new Vector3(numberLaneNew * moveLeftRight, heightNow, 0);
        transform.position = new Vector3(transform.position.x + speedMove * Time.deltaTime * sightCheckMove, pointFinal.y, pointFinal.z);
        if ((pointFinal.x - transform.position.x) * sightCheckMove <= 0)
            SetDoneMoveLeftRight();
    }

    void SetDoneMoveLeftRight()
    {
        handleJumpSkisWall = 0;
        RemoveSpeedSlow();
        mesStartMove = false;
        doneMoveLeftRight = true;
        transform.position = new Vector3(numberLaneNew * moveLeftRight, transform.position.y, 0);
        numberLaneOld = numberLaneNew;
        oldPointBefore = transform.position;
        bool aForce = true;
        if (mesSwipeJump) aForce = false;
        SetFallingAfterAction(aForce, true);
        AutoControlLast();
        if (stumbleSide)
        {
            RemoveSpeedSlow();
            stumbleSide = false;
        }
    }

    bool SetFallingAfterAction(bool addForce, bool checkDown)
    {
        bool result = false;
        if (Modules.statusGame == StatusGame.flyScene || Modules.statusGame == StatusGame.bonusEffect || Modules.useJumper || Modules.useRocket || Modules.useCable || Modules.useJetBall) return result;
        if (addForce && !mesStartJump) AddForceHero();
        if (doneJumpHero)
        {
            SetRigibodyNormal();
            if (checkDown && !CheckNearGround(5.5f) && !isDown)
            {
                checkFalling = true;
                SetAniFalling();
                result = true;
            }
        }
        return result;
    }

    void MoveHero(bool moveLeft)
    {
        int totalLane = GetTotalLaneNow();
        if (totalLane == 3)
        {
            if ((numberLaneNew > 1) || (numberLaneNew < -1)) return;
        }
        else if (totalLane == 4)
        {
            if ((numberLaneNew > 2) || (numberLaneNew < -1)) return;
        }
        else if (totalLane == 5)
        {
            if ((numberLaneNew > 2) || (numberLaneNew < -2)) return;
        }
        if (!doneMoveLeftRight)
            numberLaneOld = numberLaneNew;
        if (handleJumpSkisWall != 0)
        {
            if (moveLeft)
            {
                if (handleJumpSkisWall == 1)
                {
                    numberLaneNew = numberLaneOld;
                    return;
                }
            }
            else
            {
                if (handleJumpSkisWall == 2)
                {
                    numberLaneNew = numberLaneOld;
                    return;
                }
            }
            handleJumpSkisWall = 0;
            stopMoveLeftRight = false;
        }
        if (!doneBackHero)
        {
            mesStartBack = false;
            doneBackHero = true;
            numberLaneOld = numberLaneNew;
            listCollCheck.Clear();
        }
        ResetDown(false, false);
        speedMove = /*Modules.speedGame * */numSpeedAct * speedMoveLeftRight;
        if ((Modules.useSkis && skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
            speedMove *= 1.5f;
        int direction = 1;
        if (moveLeft) direction = -1;
        Camera.main.GetComponent<CameraController>().timeFollow = 0.1f;
        //Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        oldPointBefore = new Vector3(numberLaneOld * moveLeftRight, transform.position.y, 0);
        //checkFalling = false;
        doneMoveLeftRight = false;
        RemoveForceHero();
        //myRigid.isKinematic = false;
        //myRigid.useGravity = false;
        //myRigid.interpolation = RigidbodyInterpolation.Interpolate;
        //if (!Modules.useJumper && !Modules.useRocket && !Modules.useCable && checkFalling)
        //    AddForceHero();
        if (!Modules.useJumper && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall)
            myRigid.interpolation = RigidbodyInterpolation.Interpolate;
        numberLaneNew = numberLaneOld + direction;
        sightCheckMove = 1;
        if (numberLaneNew < numberLaneOld) sightCheckMove = -1;
        stopMoveLeftRight = false;
        mesStartMove = true;
        mesSwipeJump = false;
        addMoreMove = 0;
        //mesStartBack = false;
        //doneBackHero = true;
        TaskData.countTimeStay = 0;
        checkInAir = CheckOnTheAir();
    }

    //XU LY DIEU KHIEN CAC LOAI JUMP
    private bool mesStartJump = false;
    private float speedJump = 1f;
    private bool doneJumpHero = true;
    private bool checkFalling = false;//dieu kien de bao khi nao kiem tra tiep dat
    private float timeLerpJump = 100f;
    private float maxHeightJump = 100f;
    private float timeBeginJump = 0;//thoi gian bat dau thao tac nhay
    private bool mesSwipeJump = false;//danh dau swipe jump khi swipe thanh cong

    void RunJumpHero()
    {
        if (Modules.statusGame == StatusGame.flyScene) mesStartJump = false;
        if (!mesStartJump) return;
        timeBeginJump += 0.01f;
        if (timeBeginJump > 1.5f) timeBeginJump = 1.5f;
        Vector3 pointFinal = new Vector3(transform.position.x, maxHeightJump, 0);
        transform.position = Vector3.MoveTowards(transform.position, pointFinal, speedJump / timeBeginJump * Time.deltaTime);
        if (pointFinal.y - transform.position.y <= 0)
            SetFallJumpHero();
        else
        {
            if ((Modules.useJumper && transform.position.y < jumpJumperHeight)
                || (Modules.useRocket && transform.position.y < jumpRocketHeight)
                || (Modules.useCable && transform.position.y < jumpCableHeight)
                || (Modules.useJetBall && transform.position.y < jumpJetBallHeight))
            {
                Camera.main.GetComponent<CameraController>().timeFollow = timeLerpJump * transform.position.y;
                float angleX = Camera.main.transform.rotation.x - Time.deltaTime / 2f;
                Camera.main.transform.rotation = new Quaternion(angleX, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
            }
        }
    }

    private float timeFallJumper = 0.25f;
    private float countTimeFallJumper = 0;
    private float timeFallPower = 0.25f;
    private float countTimeFallPower = 0;
    private float timeFallNormal = 0.25f;
    private float countTimeFallNormal = 0;
    [HideInInspector]
    public bool hideMeshBonus = false;
    private bool overBonusRoad = false;

    void SetFallJumpHero()
    {
        CatchFlyCam();
        if (handleJumpSkisWall != 0)
        {
            handleJumpSkisWall = 0;
            GetCollWhenBack();
            HandleBackHero(0.3f);
            return;
        }
        RemoveSpeedSlow();
        //kiem tra xem neu la rocket hoac cable thi check thoi gian roi xuong
        foreach (Transform tran in Modules.containMesItems.transform)
        {
            if (tran.GetComponent<PanelShowUseItem>().codeItemNow == TypeItems.jetpack//neu dang bay rocket
                || tran.GetComponent<PanelShowUseItem>().codeItemNow == TypeItems.hoverbike//neu dang bay cable
                 || tran.GetComponent<PanelShowUseItem>().codeItemNow == TypeItems.jetball)//neu dang bay jetball
            {
                return;
            }
        }
        if (Modules.statusGame == StatusGame.bonusEffect && !overBonusRoad && !Modules.useTemple)
        {
            if (!Modules.startBonusRoad)
            {
                if (!hideMeshBonus && Modules.panelBGEffectBonus.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BGEffectBonusRoadShow"))
                {
                    hideMeshBonus = true;
                    //an mesh nhan vat
                    GetComponent<ShadowFixed>().SetActiveShadow(false);
                    foreach (Transform tran in transform) tran.gameObject.SetActive(false);
                    //di chuyen vao lan giua
                    numberLaneNew = 0;
                    numberLaneOld = 0;
                    transform.position = new Vector3(0, transform.position.y, 0);
                    oldPointBefore = transform.position;
                    Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    Camera.main.GetComponent<PageMainGame>().createEnemyLeft.GetComponent<EnemyController>().HideMesh();
                    //thuc hien doi map va chay animation sang dan
                    Camera.main.transform.GetComponent<TerrainController>().SetBonusScene();
                    Camera.main.transform.GetComponent<CameraController>().SetPointAngle(new Vector3(0, 19.5f, -5.5f), new Vector3(25f, 0, 0), Modules.timeShowChest, 1f);
                    Modules.PlayAudioClipLoop(Modules.audioRoadBonus, Camera.main.transform);
                    Modules.panelBGEffectBonus.GetComponent<Animator>().SetTrigger("TriClose");
                }
                transform.position = new Vector3(transform.position.x, jumpBonusHeight, 0);
                return;
            }
            else
            {
                //sau khi chay xong hieu ung troi nguoc map, hien thi mesh va bat dau chay
                Modules.statusGame = StatusGame.play;
                Modules.startBonusRoad = false;
                mesStartMove = false;
                doneMoveLeftRight = true;
                mesStartBack = false;
                doneBackHero = true;
                hideMeshBonus = false;
                GetComponent<ShadowFixed>().SetActiveShadow(true);
                foreach (Transform tran in transform) tran.gameObject.SetActive(true);
                SetAniFalling();
                Camera.main.GetComponent<CameraController>().ResetTimeFollow();
            }
        }
        else if (Modules.useJumper)
        {
            if (countTimeFallJumper < timeFallJumper)
            {
                countTimeFallJumper += Time.deltaTime;
                return;
            }
        }
        else if (Modules.usePower)
        {
            if (countTimeFallPower < timeFallPower)
            {
                countTimeFallPower += Time.deltaTime;
                return;
            }
        }
        if (countTimeFallNormal < timeFallNormal)
        {
            countTimeFallNormal += Time.deltaTime;
            return;
        }
        //thuc hien roi xuong
        mesStartJump = false;
        checkFalling = true;
        SetRigibodyNormal();
        oldPointBefore = new Vector3(numberLaneOld * moveLeftRight, transform.position.y, 0);
        //thuc hien xoa rocket, jumper ngay tai day
        if (Modules.useJumper)
        {
            AddForceHero();
            RemoveJumperItem();
            Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        }
        else if (Modules.useRocket)
        {
            AddForceHero();
            RemoveRocketItem();
            Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        }
        else if (Modules.useCable)
        {
            AddForceHero();
            RemoveCableItem();
            Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        }
        else if (Modules.useJetBall)
        {
            AddForceHero();
            RemoveJetBallItem();
            Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        }
        else
        {
            //SetAniFalling();
            AddForceHero();
        }
    }

    void RemoveSkisBeforeJump()
    {
        //xoa skis new da het thoi gian
        if (Modules.useSkis)
        {
            foreach (Transform tran in Modules.containMesItems.transform)
                if (tran.GetComponent<PanelShowUseItem>().codeItemNow == TypeItems.hoverboard && tran.GetComponent<PanelShowUseItem>().LastTime())//neu co van truot
                {
                    RemoveSkisItem(true, true);
                    tran.GetComponent<PanelShowUseItem>().SetClosePanel();
                }
        }
    }

    void JumpHero(bool useWaterRamp = false)
    {
        RemoveSkisBeforeJump();
        RemoveForceHero();
        ResetDown(false, false);
        checkFalling = false;
        if (doneMoveLeftRight && doneJumpHero && doneBackHero)
            oldPointBefore = new Vector3(numberLaneOld * moveLeftRight, transform.position.y, 0);
        //move hero to up
        myRigid.isKinematic = false;
        countTimeFallNormal = 0;
        timeLerpJump = 1f;
        maxHeightJump = transform.position.y + jumpNormalHeight;
        if (Modules.statusGame == StatusGame.bonusEffect && !overBonusRoad && !Modules.useTemple)//neu chay hieu ung bonus
        {
            speedJump = speedJumpBonus * numSpeedAct;
            myRigid.isKinematic = true;
            timeLerpJump = 0.02f;
            maxHeightJump = jumpBonusHeight;
            Modules.startBonusRoad = false;
            //thuc hien goi chay effect UI toi dan
            Modules.panelBGEffectBonus.SetActive(true);
            Modules.panelBGEffectBonus.GetComponent<Animator>().SetTrigger("TriOpen");
            Modules.underBridge = false;
        }
        else if (Modules.useJumper)//bay cung cai coc
        {
            speedJump = speedJumpJumper * numSpeedAct;
            myRigid.isKinematic = true;
            timeLerpJump = 0.015f;
            maxHeightJump = jumpJumperHeight;
            countTimeFallJumper = 0;
            Modules.PlayAudioClipFree(Modules.audioTrapoline);
            Modules.PlayAudioClipFree(audioJumpJumper);
            if (numberLaneOld > 1)
                MoveLeft(true);
            else if (numberLaneOld < -1)
                MoveRight(true);
            Modules.underBridge = false;
        }
        else if (Modules.useRocket)//bay cung ten lua
        {
            speedJump = speedJumpRocket * numSpeedAct;
            myRigid.isKinematic = true;
            timeLerpJump = 0.02f;
            maxHeightJump = jumpRocketHeight;
            if (myJetpack.transform.GetComponent<JetpackController>().isWing || myJetpack.transform.GetComponent<JetpackController>().isBroom)
                Modules.PlayAudioClipFree(Modules.audioRocket);
            else Modules.PlayAudioClipFree(Modules.audioJetpackStart);
            if (numberLaneOld > 1)
                MoveLeft(true);
            else if (numberLaneOld < -1)
                MoveRight(true);
            Modules.underBridge = false;
        }
        else if (Modules.useCable)//bay cung cap treo
        {
            speedJump = speedJumpCable * numSpeedAct;
            myRigid.isKinematic = true;
            timeLerpJump = 0.02f;
            maxHeightJump = jumpCableHeight;
            Modules.PlayAudioClipFree(Modules.audioCable);
            if (numberLaneOld > 1)
                MoveLeft(true);
            else if (numberLaneOld < -1)
                MoveRight(true);
            Modules.underBridge = false;
        }
        else if (Modules.useJetBall)//bay cung jetball
        {
            speedJump = speedJumpJetBall * numSpeedAct;
            myRigid.isKinematic = true;
            timeLerpJump = 0.02f;
            maxHeightJump = jumpJetBallHeight;
            Modules.PlayAudioClipFree(Modules.audioJetBall);
            if (numberLaneOld > 1)
                MoveLeft(true);
            else if (numberLaneOld < -1)
                MoveRight(true);
            Modules.underBridge = false;
        }
        else if (Modules.usePower || useWaterRamp)//nhay cao
        {
            TaskData.countScoreNoJump = 0;
            TaskData.HandleTask(3, 1, 20);
            TaskData.HandleTask(19, 1, 30);
            TaskData.HandleTask(91, 1, 2000);
            TaskData.HandleTask(99, 1, 300);
            TaskData.HandleTask(151, 1, 70);
            if (Modules.useBoat)
                TaskData.HandleTask(141, 1, 10);
            bool checkJump = true;
            if (useWaterRamp) checkJump = false;
            //gioi han do cao khi su dung sneaker tren cao
            if (checkJump && Modules.underBridge)
            {
                if (transform.position.y > Camera.main.GetComponent<CameraController>().GetHeightBasicNow() + 4f)
                    checkJump = false;
            }
            if (checkJump)
            {
                RaycastHit hit;
                if (Physics.Raycast(pointCheckRay.transform.position, Vector3.up, out hit))
                    if (hit.point.y <= transform.position.y + jumpPowerHeight + 3.6f)
                        checkJump = false;
            }
            if (checkJump)
            {
                speedJump = speedJumpPower * numSpeedAct;// *(Modules.speedGame > 1 ? Modules.speedGame : 1);
                timeLerpJump = 0.5f;
                maxHeightJump = transform.position.y + jumpPowerHeight;
            }
            else
            {
                speedJump = speedJumpNormal * numSpeedAct;// *(Modules.speedGame > 1 ? Modules.speedGame : 1);
            }
            Modules.speedSneakerJump = 0.35f;
            countTimeFallPower = 0;
        }
        else//nhay binh thuong
        {
            TaskData.countScoreNoJump = 0;
            TaskData.HandleTask(3, 1, 20);
            TaskData.HandleTask(19, 1, 30);
            TaskData.HandleTask(91, 1, 2000);
            TaskData.HandleTask(99, 1, 300);
            TaskData.HandleTask(151, 1, 70);
            if (Modules.useBoat)
                TaskData.HandleTask(141, 1, 10);
            speedJump = speedJumpNormal * numSpeedAct;// *(Modules.speedGame > 1 ? Modules.speedGame : 1);
        }
        doneJumpHero = false;
        mesSwipeJump = true;
        myRigid.useGravity = false;
        myRigid.interpolation = RigidbodyInterpolation.None;
        mesStartJump = true;
        addMoreMove = 0;
        timeBeginJump = 1;
        if (doneMoveLeftRight)
        {
            if (Modules.useJumper || Modules.useRocket || Modules.useCable || Modules.useJetBall)
                Camera.main.GetComponent<CameraController>().timeFollow = timeLerpJump * transform.position.y;
            else
                Camera.main.GetComponent<CameraController>().timeFollow = timeLerpJump;
        }
    }

    //XU LY DIEU KHIEN NHAN VAT BAT LAI
    private bool mesStartBack = false;
    private float speedBack = 1f;
    private bool doneBackHero = true;
    private int sightCheckBack = 1;//chieu back lai
    private int handleJumpSkisWall = 0;//0 none, 1 left, 2 right

    void RunBackHero()
    {
        if (Modules.statusGame == StatusGame.flyScene) mesStartBack = false;
        if (!mesStartBack) return;
        //xu ly chet neu back vao ben trong doi tuong va cham
        if (listCollCheck.Count > 0)
        {
            foreach (Collider col in listCollCheck)
                if (col.bounds.Contains(transform.position))
                {
                    if (Modules.useSkis)
                        RebornSkis(false);
                    else
                    {
                        ColliderWithBarrier(TypeFalling.backScene);
                        mesStartBack = false;
                    }
                    break;
                }
        }
        //xu ly chinh
        Vector3 pointFinal = new Vector3(oldPointBefore.x, transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, pointFinal, speedBack * Time.deltaTime);
        if ((pointFinal.x - transform.position.x) * sightCheckBack <= 0)
            SetDoneBackHero();
    }

    void SetDoneBackHero()
    {
        TaskData.HandleTask(27, 1, 3);
        RemoveSpeedSlow();
        mesStartBack = false;
        doneBackHero = true;
        handleJumpSkisWall = 0;
        if (Modules.statusGame == StatusGame.flyScene || Modules.statusGame == StatusGame.bonusEffect || Modules.useJumper || Modules.useRocket || Modules.useCable || Modules.useJetBall) return;
        transform.position = new Vector3(oldPointBefore.x, transform.position.y, 0);
        SetRigibodyNormal();
        //checkFalling = true;
        //xu ly chay animation side left right
        if (Modules.statusGame == StatusGame.play)
        {
            if (typeAniRun == TypeAniRun.runNormal)
            {
                int indexRan = Random.Range(0, 2);
                if (indexRan == 0) CallAniNew(aniSideLeft, TypeAniRun.seeSideLeft, false);
                else CallAniNew(aniSideRight, TypeAniRun.seeSideRight, false);
                effectStunned.SetActive(true);
                effectStunned.GetComponent<ETFXRotation>().StartEffect();
            }
        }
        RemoveForceHero(false);
        AddForceHero();
        //AutoControlLast();
    }

    void BackHero(float timeMore = 1)
    {
        TaskData.HandleTask(55, 1, 6);
        TaskData.HandleTask(125, 1, 8);
        TaskData.HandleTask(155, 1, 12);
        RemoveForceHero();
        speedBack = /*Modules.speedGame * */numSpeedAct * speedMoveBack * timeMore;
        numberLaneNew = numberLaneOld;
        sightCheckBack = 1;
        if (transform.position.x > oldPointBefore.x) sightCheckBack = -1;
        doneBackHero = false;
        //checkFalling = false;
        myRigid.isKinematic = false;
        myRigid.useGravity = false;
        myRigid.interpolation = RigidbodyInterpolation.Interpolate;
        mesStartBack = true;
        mesStartMove = false;
    }

    //XU LY VA CHAM
    private Vector3 oldPointBefore = Vector3.zero;
    private int numberLaneOld = 0, numberLaneNew = 0;//-1,0,1

    public Vector3 GetOldPoint()
    {
        return oldPointBefore;
    }

    void HandleOnTerrain()
    {
        oldPointBefore = new Vector3(numberLaneOld * moveLeftRight, transform.position.y, 0);
        mesStartJump = false;
        doneJumpHero = true;
        checkFalling = false;
        Modules.speedSneakerJump = 0;
        Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        statusHero = StatusHero.run;
    }

    void DestroyBalloon()
    {
        if (myHotAirBalloon != null) Destroy(myHotAirBalloon);
    }

    private TypeCollider typeCollider = TypeCollider.top;
    private int checkEnterExitCol = 0;
    private List<Collider> listCollCheck = new List<Collider>();
    private int oldCol = 0;
    private string typeRunOn = "Null";

    void OnCollisionEnter(Collision collision)
    {
        BarrierInformation barrier = collision.gameObject.GetComponent<BarrierInformation>();
        //xu ly chet nga xuong mat nuoc
        if (Modules.statusGame == StatusGame.over)//neu bi chet
        {
            if (statusHero == StatusHero.fallA && collision.gameObject.tag == "WaterSurface")//neu va cham voi mat nuoc
            {
                float pointParWaterDown = collision.transform.position.y + collision.transform.localScale.y / 2f + 0.1f;
                Instantiate(Modules.parWaterDown, new Vector3(transform.position.x, pointParWaterDown, transform.position.z), Quaternion.identity);
                transform.GetComponent<ShadowFixed>().SetActiveShadow(false);
                transform.gameObject.SetActive(false);
                return;
            }
        }
        //xu ly va cham tiep khi vua hoi sinh
        if (Mathf.RoundToInt(transform.position.x) == 0)
        {
            if (Time.time - Modules.timeSaveMeLatest < Modules.timeSaveMeAllow)
            {
                if (barrier != null)
                {
                    if (!barrier.isWallLeft && !barrier.isWallRight)
                        return;
                }
                else return;
            }
        }
        //xu ly binh thuong
        int tempCol = collision.gameObject.GetInstanceID();
        if (Modules.statusGame != StatusGame.play && Modules.statusGame != StatusGame.flyScene)
        {
            checkEnterExitCol = tempCol;
            return;
        }
        doneJumpHero = true;
        if (Modules.statusGame != StatusGame.flyScene && handleJumpSkisWall == 0)
            mesAniRunNow = TypeAniRun.none;
        typeCollider = TypeCollider.bottom;
        bool checkUnder = false;
        if (barrier != null && transform.position.y < barrier.parentBarrier.transform.position.y - 2f)
        {
            typeCollider = TypeCollider.front;
            checkUnder = true;
        }
        if (collision.contacts != null && collision.contacts.Length > 0)
        {
            Vector3 pointColl = Vector3.zero;
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                pointColl = new Vector3(
                      pointColl.x + collision.contacts[i].point.x,
                      pointColl.y + collision.contacts[i].point.y,
                      pointColl.z + collision.contacts[i].point.z);
                //print(collision.contacts[i].point + ";");
                //if (i == collision.contacts.Length - 1) print("=======");
            }
            pointColl /= collision.contacts.Length;
            //Vector3 pointColl = collision.contacts[collision.contacts.Length - 1].point;
            Vector3 direction = myCollider.transform.InverseTransformPoint(pointColl);//quy ve toa do tinh theo collider cua nhan vat voi tam o giua
            //voi chieu dai hien tai cua collider 1.2 va rong 0.3, cang gan gia tri 0 thi do kiem tra cang cao, be day cang lon
            if (!checkUnder)
            {
                float valueCheckBottom = -0.3f;
                if (isDown) valueCheckBottom = -0.05f;
                if (direction.y < valueCheckBottom) typeCollider = TypeCollider.bottom;//va cham phia duoi nhan vat
                else if (direction.x < -0.05f) typeCollider = TypeCollider.left;//va cham ben trai nhan vat
                else if (direction.x > 0.05f) typeCollider = TypeCollider.right;//va cham ben phai nhan vat
                //else if (direction.z < -0.05f) typeCollider = TypeCollider.bottom;//va cham phia sau nhan vat (thay the bang xet them toa do z ben duoi)
                else typeCollider = TypeCollider.front;
            }
            if (typeCollider == TypeCollider.front)//xet toa do Z de kiem tra xem co phai va cham phia sau cua nhan vat
            {
                if (!checkUnder)
                {
                    if (collision.transform.position.z < transform.position.z
                    //neu va cham voi doi tuong khong bao gio chet va lai o cung 1 lane thi thoi, khong chet duoc, giong voi hanh dong leo thang
                    || (barrier != null && barrier.typeBarrier == TypeBarrier.neverFall && Mathf.Abs(collision.transform.position.x - oldPointBefore.x) < 1.5f))
                    {
                        maxHeightJump = transform.position.y - 0.5f;
                        typeCollider = TypeCollider.bottom;
                    }
                    else
                    {
                        if (barrier != null)
                        {
                            if (!barrier.isWallLeft && !barrier.isWallRight)
                                CheckStumbleSide(pointColl.x, collision.transform.position.x);//neu khong huc dau vao gam vat can thi moi check stumble
                        }
                        else CheckStumbleSide(pointColl.x, collision.transform.position.x);//neu khong huc dau vao gam vat can thi moi check stumble
                    }
                }
            }
            else if (typeCollider == TypeCollider.bottom)
            {
                //kiem tra xem co va cham vao phan duoi tinh tu noc cua vat can - 1.5 chieu cao hay khong
                if (barrier != null && barrier.typeBarrier != TypeBarrier.neverFall)
                {
                    if (pointColl.y < collision.transform.localScale.y / 2f + collision.transform.position.y - 2.5f)
                    {
                        typeCollider = TypeCollider.front;
                    }
                }
                //kiem tra them dieu kien neu va cham bottom vao vat nghieng ma tu lane khac nhay sang
                if (Mathf.Abs(collision.gameObject.transform.localEulerAngles.x) !=0)//neu vat va cham nghieng
                {
                    if (Mathf.Abs(collision.transform.position.x - oldPointBefore.x) >= 1.5f)//neu khac lane
                    {
                        if (direction.x < -0.05f) typeCollider = TypeCollider.left;//va cham ben trai nhan vat
                        else if (direction.x > 0.05f) typeCollider = TypeCollider.right;//va cham ben phai nhan vat
                    }
                }
                //neu bi chet khong huc dau vao gam vat can thi moi check stumble
                if (typeCollider == TypeCollider.front && !checkUnder)
                {
                    if (barrier != null)
                    {
                        if (!barrier.isWallLeft && !barrier.isWallRight)
                            CheckStumbleSide(pointColl.x, collision.transform.position.x);
                    }
                    else CheckStumbleSide(pointColl.x, collision.transform.position.x);
                }
            }
            else if (typeCollider == TypeCollider.left || typeCollider == TypeCollider.right)
            {
                //neu tra ve left/right thi kiem tra xem lieu doi tuong nay co cung lane dang chay khong, neu cung thi cung chet
                if (Mathf.Abs(collision.transform.position.x - oldPointBefore.x) < 1.5f)
                {
                    typeCollider = TypeCollider.front;
                    //neu khong huc dau vao gam vat can thi moi check stumble
                    if (!checkUnder)
                    {
                        if (barrier != null)
                        {
                            if (!barrier.isWallLeft && !barrier.isWallRight)
                                CheckStumbleSide(pointColl.x, collision.transform.position.x);
                        }
                        else CheckStumbleSide(pointColl.x, collision.transform.position.x);
                    }
                }
            }
            //print(typeCollider + "---" + pointColl + "---" + direction + "\n========");
        }
        bool allowResetSkis = false;
        if (barrier != null)
        {
            if (barrier.typeBarrier == TypeBarrier.alwaysFall)
            {
                typeCollider = TypeCollider.front;
                allowResetSkis = true;
            }
            else if (barrier.typeBarrier == TypeBarrier.slowSpeed)
                typeCollider = TypeCollider.slower;
            //check dieu kien cho 2 ben tuong left/right
            if (typeCollider == TypeCollider.front || typeCollider == TypeCollider.bottom)
            {
                if (barrier.isWallLeft)
                    typeCollider = TypeCollider.left;
                else if (barrier.isWallRight)
                    typeCollider = TypeCollider.right;
            }
        }
        //print(typeCollider);
        if (typeCollider == TypeCollider.bottom) { checkEnterExitCol = tempCol; /*if (barrier != null) print("bottom");*/ }
        if (Modules.useJumper || Modules.useRocket || Modules.useCable || Modules.useJetBall) return;
        //xu ly tiep xuc mat nuoc de su dung boat
        if ((collision.gameObject.layer == LayerMask.NameToLayer("MCG-Terrain")/* || typeCollider == TypeCollider.bottom*/)
            && typeCollider != TypeCollider.left && typeCollider != TypeCollider.right
            && Modules.statusGame != StatusGame.flyScene)
        {
            if (!Modules.useBoat && collision.gameObject.tag == "WaterSurface")
                CallBoats();
            else if (Modules.useBoat && collision.gameObject.tag != "WaterSurface")
                RemoveSkisItem(true, false);
        }
        if (typeCollider == TypeCollider.bottom)//xu ly tiep dat
        {
            //neu va cham vao ramp thi thuc hien dieu chinh camera cho do jerk
            //CameraController camNow = Camera.main.GetComponent<CameraController>();
            //if (barrier != null
            //    && camNow.timeFollow == camNow.GetOriginTimeFollow()
            //    && collision.gameObject.transform.localEulerAngles.x > 1
            //    && numberLaneNew == numberLaneOld)
            //    camNow.timeFollow = 0;
            //xu ly khac
            if (checkFalling)
            {
                if (Modules.statusGame == StatusGame.flyScene)
                {
                    if (mesAniRunNow == TypeAniRun.balloonDriver)//xu ly cho khinh khi cau
                    {
                        HandleOnTerrain();
                        CallAniNew(aniMoveDown, TypeAniRun.balloonDown, false);
                        myHotAirBalloon.transform.SetParent(collision.gameObject.transform, true);
                        Invoke("DestroyBalloon", 3f);
                        Camera.main.GetComponent<ChangeHeightFog>().ResetValue();
                        Camera.main.GetComponent<ChangeHeightFog>().enabled = false;
                        Modules.panelChangeSky.SetActive(false);
                        Modules.colorBGChangeMap = new Color(Modules.colorBGChangeMap.r, Modules.colorBGChangeMap.g, Modules.colorBGChangeMap.b, 0);
                        Modules.matBGChangeMap.color = Modules.colorBGChangeMap;
                    }
                    if (mesAniRunNow == TypeAniRun.flyCamSway)//xu ly cho fly cam
                    {
                        HandleOnTerrain();
                        CallAniNew(aniFlyCamDrop, TypeAniRun.flyCamDown, false);
                        HideFlyCam();
                        Camera.main.GetComponent<ChangeHeightFog>().ResetValue(true);
                        Camera.main.GetComponent<ChangeHeightFog>().enabled = false;
                        Modules.panelChangeSky.SetActive(false);
                        Modules.colorBGChangeMap = new Color(Modules.colorBGChangeMap.r, Modules.colorBGChangeMap.g, Modules.colorBGChangeMap.b, 0);
                        Modules.matBGChangeMap.color = Modules.colorBGChangeMap;
                    }
                }
                else
                {
                    HandleOnTerrain();
                    //if (Modules.useSkis)
                    //{
                        //Modules.PlayAudioClipFree(Modules.audioSkisJumpLanding);
                        //MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    //}
                    typeRunOn = "Null";
                    if (barrier != null && oldCol != tempCol)
                    {
                        if (barrier.parentBarrier != null)
                        {
                            if (barrier.parentBarrier.tag == "Barrier")
                            {
                                TaskData.HandleTask(23, 1, 2);
                                TaskData.HandleTask(60, 1, 15);
                                TaskData.HandleTask(77, 1, 25);
                                typeRunOn = "Barrier";
                                Modules.PlayAudioClipFree(Modules.audioCollider);
                                if (!Modules.useBoat && !Modules.useSkis)
                                {
                                    CallAniNew(aniStumble[Random.Range(0, aniStumble.Count)], TypeAniRun.stumble, false);
                                    stumbleSlow = true;
                                }
                            }
                            else if (barrier.parentBarrier.tag == "MonoTrain")
                            {
                                TaskData.HandleTask(33, 1, 10);
                                TaskData.HandleTask(129, 1, 50);
                                typeRunOn = "MonoTrain";
                            }
                            else if (barrier.parentBarrier.tag == "GroundTrain")
                            {
                                TaskData.HandleTask(35, 1, 10);
                                TaskData.HandleTask(129, 1, 50);
                                typeRunOn = "GroundTrain";
                            }
                        }
                    }
                    if (!isDown && !stumbleSlow)
                        SetReturnRunBasic(false);
                    AutoControlLast();
                }
            }
            if (Modules.useBoat && boatNow != null)
            {
                boatNow.GetComponent<PlaySparksBoat>().ShowHideSparks(true);
                Modules.PlayAudioClipFree(Modules.audioBoatDown);
                Modules.PlayAudioClipLoop(Modules.audioBoatRun, Modules.containMainGame.transform, false, false);
            }
            oldCol = tempCol;
        }
        else if (typeCollider == TypeCollider.front)
        {
            //xu ly neu co van truot thi khong chet
            if (Modules.useSkis)
            {
                RebornSkis(allowResetSkis);
            }
            else if (barrier != null)
            {
                //xu ly va cham voi vat can chet
                Modules.PlayAudioClipFree(Modules.audioColliderDie);
                ColliderWithBarrier(barrier.typeFalling);
            }
            oldCol = tempCol;
        }
        else if (typeCollider == TypeCollider.right || typeCollider == TypeCollider.left)
        {
            if (!doneBackHero)
            {
                if (Modules.useSkis)
                {
                    RebornSkis(allowResetSkis);
                }
                else ColliderWithBarrier(TypeFalling.backScene);
                return;
            }
            if (handleJumpSkisWall != 0) return;
            //xu ly va cham voi vat can day lai
            if (barrier != null && barrier.supportSkis && Modules.useSkis)
            {
                JumpHero();
                if (typeCollider == TypeCollider.left)
                {
                    handleJumpSkisWall = 1;
                    if (Modules.useMagnet)
                    {
                        if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                            CallAniNew(aniLeftCableWallMagnet, TypeAniRun.wallLeftSkisMagnet, false, 1f);
                        else CallAniNew(aniLeftSkisWallMagnet, TypeAniRun.wallLeftSkisMagnet, false, 0.75f);
                    }
                    else
                    {
                        if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                            CallAniNew(aniLeftCableWall, TypeAniRun.wallLeftSkis, false, 1f);
                        else CallAniNew(aniLeftSkisWall, TypeAniRun.wallLeftSkis, false, 0.75f);
                    }
                    if (skisNow != null) skisNow.GetComponent<PlaySparksSkis>().PlayParticle(true);
                }
                else
                {
                    handleJumpSkisWall = 2;
                    if (Modules.useMagnet)
                    {
                        if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                            CallAniNew(aniRightCableWallMagnet, TypeAniRun.wallRightSkisMagnet, false, 1f);
                        else CallAniNew(aniRightSkisWallMagnet, TypeAniRun.wallRightSkisMagnet, false, 0.75f);
                    }
                    else
                    {
                        if ((skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike) || Modules.useBoat)
                            CallAniNew(aniRightCableWall, TypeAniRun.wallRightSkis, false, 1f);
                        else CallAniNew(aniRightSkisWall, TypeAniRun.wallRightSkis, false, 0.75f);
                    }
                    if (skisNow != null) skisNow.GetComponent<PlaySparksSkis>().PlayParticle(false);
                }
                stopMoveLeftRight = true;
                doneMoveLeftRight = true;
                return;
            }
            ColliderObjectSlowSpeed();
            GetCollWhenBack();
            HandleBackHero();
            oldCol = tempCol;
        }
        else if (typeCollider == TypeCollider.slower) //xu ly va cham vat can lam cham
        {
            if (!Modules.useBoat && !Modules.useSkis)
                CallAniNew(aniStumble[Random.Range(0, aniStumble.Count)], TypeAniRun.stumble, false);
            stumbleSlow = true;
            ColliderObjectSlowSpeed(0.5f);
            oldCol = tempCol;
        }
    }

    bool stumbleSlow = false;
    bool stumbleSide = false;
    void CheckStumbleSide(float pointA, float pointB)
    {
        if (Mathf.Abs(pointB - oldPointBefore.x) >= 1.5f) return;//neu khac lane thi khong xu ly
        float distanceSide = pointA - pointB;
        if (Mathf.Abs(distanceSide) > 1f)//neu va cham vao me cua 2 ben)
        {
            if (!Modules.useBoat && !Modules.useSkis)
            {
                typeCollider = TypeCollider.bottom;
                if (distanceSide < 0)//ben trai
                    CallAniNew(aniSideLeft, TypeAniRun.seeSideLeft, false);
                else CallAniNew(aniSideRight, TypeAniRun.seeSideRight, false);
                effectStunned.SetActive(true);
                effectStunned.GetComponent<ETFXRotation>().StartEffect();
                stumbleSide = true;
                ColliderObjectSlowSpeed();
            }
            else
            {
                typeCollider = TypeCollider.front;
                stumbleSide = false;
            }
        }
    }

    void CallBoats()
    {
        TaskData.HandleTask(84, 1, 1);
        TaskData.HandleTask(90, 1, 10);
        if (Modules.useSkis)
        {
            RemoveSkisItem(true, false);
            RemoveProgress(TypeItems.hoverboard, false);
        }
        boatNow = Modules.SetModelUseItem(transform, codeBody, myBoat, "Skis");
        boatNow.GetComponent<PlaySparksBoat>().ShowHideSparks(true);
        Modules.PlayAudioClipFree(Modules.audioBoatDown);
        Modules.PlayAudioClipLoop(Modules.audioBoatRun, Modules.containMainGame.transform, false, false);
        Modules.speedPercentSkis = boatNow.GetComponent<BoatController>().speedPercent;
        RemoveSpeedSlow();
        if (typeAniRun == TypeAniRun.runNormal)//neu dang chay thuong
        {
            typeAniRun = TypeAniRun.runSkis;
            CallAniNew(aniRunBoat, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runMagnet)//neu dang cam nam cham
        {
            typeAniRun = TypeAniRun.runSkisMagnet;
            CallAniNew(aniRunBoatMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        ResetDown(false, false);
        Modules.useBoat = true;
        Modules.distanceEnemy = 2;
        //them hieu ung goi thuyen
        if (Modules.showDownBoat == 0)
        {
            Modules.panelGameGuide.SetActive(true);
            Transform textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
            textGuide.GetComponent<Text>().text = AllLanguages.playDownBoat[Modules.indexLanguage];
            Transform arrowGuide = Modules.panelGameGuide.transform.Find("ArrowGuide");
            Transform keyUp = Modules.panelGameGuide.transform.Find("KeyUp");
            Transform keyDown = Modules.panelGameGuide.transform.Find("KeyDown");
            Transform keyLeft = Modules.panelGameGuide.transform.Find("KeyLeft");
            Transform keyRight = Modules.panelGameGuide.transform.Find("KeyRight");
            Transform keySpace = Modules.panelGameGuide.transform.Find("KeySpace");
            if (Application.isMobilePlatform)
            {
                arrowGuide.gameObject.SetActive(true);
                arrowGuide.transform.eulerAngles = new Vector3(0, 0, 90);
                keyUp.gameObject.SetActive(false);
                keyDown.gameObject.SetActive(false);
                keyLeft.gameObject.SetActive(false);
                keyRight.gameObject.SetActive(false);
                keySpace.gameObject.SetActive(false);
            }
            else
            {
                arrowGuide.gameObject.SetActive(false);
                keyUp.gameObject.SetActive(true);
                keyDown.gameObject.SetActive(true);
                keyLeft.gameObject.SetActive(true);
                keyRight.gameObject.SetActive(true);
                keySpace.gameObject.SetActive(false);
                keyDown.GetComponent<Animator>().SetTrigger("TriPlay");
            }
        }
    }

    void GetCollWhenBack()
    {
        listCollCheck = new List<Collider>();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 15f);
        for (var i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.layer == LayerMask.NameToLayer("MCG-Barrier"))
                listCollCheck.Add(hitColliders[i]);
        }
    }

    void RebornSkis(bool resetLane)
    {
        Modules.parSkisCollider.GetComponent<ParticleSystem>().Play();
        Modules.PlayAudioClipFree(Modules.audioParColSkis);
        //thuc hien xoa tat ca cac vat can xung quanh khu vuc nay
        Collider[] hitColliders = Physics.OverlapSphere(Modules.mainCharacter.transform.position, Modules.rangeReborn * Modules.speedGame);
        for (var i = 0; i < hitColliders.Length; i++)
        {
            BarrierInformation barrierSub = hitColliders[i].gameObject.GetComponent<BarrierInformation>();
            if (barrierSub != null && barrierSub.parentBarrier != null && !barrierSub.neverDestroy)
            {
                barrierSub.parentBarrier.GetComponent<BarrierController>().ResetBarrier();
                barrierSub.parentBarrier.SetActive(false);
            }
            ItemInformation itemSub = hitColliders[i].gameObject.GetComponent<ItemInformation>();
            if (itemSub != null && itemSub.typeItem != TypeItems.nextGate 
                && itemSub.typeItem != TypeItems.startTunner && itemSub.typeItem != TypeItems.endTunner
                && itemSub.typeItem != TypeItems.startBridge && itemSub.typeItem != TypeItems.endBridge)
            {
                itemSub.ResetItem();
                itemSub.gameObject.SetActive(false);
            }
        }
        foreach (Transform tran in Modules.containMesItems.transform)
            if (tran.GetComponent<PanelShowUseItem>().codeItemNow == TypeItems.hoverboard)//neu co van truot
                tran.GetComponent<PanelShowUseItem>().RemovePanel();
        Modules.distanceEnemy = 2;
        statusHero = StatusHero.run;
        //xu ly reset lane skis
        if (resetLane)
        {
            numberLaneNew = 0;
            numberLaneOld = 0;
            transform.position = new Vector3(0, transform.position.y, 0);
            oldPointBefore = transform.position;
        }
    }

    void HandleBackHero(float timeMore = 1)
    {
        //thuc hien reset point va xu ly chet
        if (!doneBackHero) return;
        BackHero(timeMore);
        stopMoveLeftRight = true;
        doneMoveLeftRight = true;
    }

    void ColliderObjectSlowSpeed(float moreSpeed = 0)
    {
        if (Modules.statusGame != StatusGame.play || Modules.gameGuide == "YES") return;
        //if (transform.position.y > jumpPowerHeight) return;//khi su dung jetpak, cable, luc roi xuong va dap thi check do cao
        if (!Modules.useTemple && !Modules.useBoat) Modules.distanceEnemy--;
        if (Modules.distanceEnemy == 0)//bi tom
        {
            if (Modules.useSkis)
            {
                foreach (Transform tran in Modules.containMesItems.transform)
                    if (tran.GetComponent<PanelShowUseItem>().codeItemNow == TypeItems.hoverboard)//neu co van truot
                        tran.GetComponent<PanelShowUseItem>().RemovePanel();
                Modules.distanceEnemy = 2;
                statusHero = StatusHero.run;
            }
            else ColliderWithBarrier(TypeFalling.policeCatch);
        }
        else
        {
            if (!Modules.useJumper && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall)
            {
                Modules.speedAddMoreUse = Modules.speedSlowCollider + moreSpeed;
                CancelInvoke("UpdateFarEnemy");
                Invoke("UpdateFarEnemy", Modules.timeFarEnemy);
            }
        }
        Modules.PlayAudioClipFree(Modules.audioCollider);
        MMVibrationManager.Haptic(HapticTypes.Warning);
    }

    void RemoveSpeedSlow()
    {
        if (Modules.speedAddMoreUse < 1)
            Modules.speedAddMoreUse = 1;//tra ve trai thai khong tang, khong giam
    }

    void AddForceHero(float value = 5)
    {
        RemoveForceHero(false);
        myRigid.AddForce(Vector3.down * value * (Modules.speedGame * numSpeedAct), ForceMode.VelocityChange);
        myRigid.WakeUp();
    }

    void RemoveForceHero(bool sleep = true)
    {
        myRigid.velocity = Vector3.zero;
        myRigid.angularVelocity = Vector3.zero;
        if (sleep) myRigid.Sleep();
    }

    void SetAniFalling()
    {
        if (aniFallNormal != null && typeAniRun == TypeAniRun.runNormal)
            CallAniNew(aniFallNormal, TypeAniRun.fallNormal, false);
        else if (aniFallMagnet != null && typeAniRun == TypeAniRun.runMagnet)
            CallAniNew(aniFallMagnet, TypeAniRun.fallMagnet, false);
        else if (aniFallSkis != null && typeAniRun == TypeAniRun.runSkis)
            CallAniNew(aniFallSkis, TypeAniRun.fallSkis, false);
        else if (aniFallSkisMagnet != null && typeAniRun == TypeAniRun.runSkisMagnet)
            CallAniNew(aniFallSkisMagnet, TypeAniRun.fallSkisMagnet, false);
        statusHero = StatusHero.fall;
        //if (Modules.useSkis)
        //{
        //    if (Modules.useMagnet)
        //    {
        //        if (aniFallSkisMagnet != null)
        //            CallAniNew(aniFallSkisMagnet, TypeAniRun.fallSkisMagnet);
        //    }
        //    else
        //    {
        //        if (aniFallSkis != null)
        //            CallAniNew(aniFallSkis, TypeAniRun.fallSkis);
        //    }
        //}
        //else
        //{
        //    if (Modules.useMagnet)
        //    {
        //        if (aniFallMagnet != null)
        //            CallAniNew(aniFallMagnet, TypeAniRun.fallMagnet);
        //    }
        //    else
        //    {
        //        if (aniFallNormal != null)
        //            CallAniNew(aniFallNormal, TypeAniRun.fallNormal);
        //    }
        //}
        //statusHero = StatusHero.fall;
    }

    void OnCollisionExit(Collision collision)
    {
        //neu nhay khoi ramp thi xoa che do giam sat cua camera
        //if (Camera.main.GetComponent<CameraController>().timeFollow == 0
        //    && collision.gameObject.GetComponent<BarrierController>() != null
        //    && Vector3.Distance(collision.gameObject.transform.localEulerAngles, Vector3.zero) > 1)
        //    Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        //xu ly khac
        if (Modules.statusGame != StatusGame.play) return;
        if (checkEnterExitCol != collision.gameObject.GetInstanceID()) return;
        if (mesStartJump)//xu ly bat nhiem vu nhay tren tau
        {
            BarrierInformation bi = collision.gameObject.GetComponent<BarrierInformation>();
            if (bi != null && bi.parentBarrier != null)
            {
                if (bi.parentBarrier.tag == "GroundTrain")
                {
                    TaskData.HandleTask(15, 1, 20);
                }
                else if (bi.parentBarrier.tag == "MonoTrain")
                {
                    TaskData.HandleTask(15, 1, 20);
                }
            }
        }
        if (mesStartMove || mesStartJump || mesStartBack) return;
        SetRigibodyNormal();
        AddForceHero();
        if (isDown) return;
        if (!CheckNearGround(5.5f))
        {
            checkFalling = true;
            SetAniFalling();
            Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        }
    }

    public float GetGroundNear()//lay mat dat gan nhat tinh tu do cao cua nhan vat
    {
        float result = 0;
        RaycastHit hit;
        int numCheck = 0;//so lop check ray
        bool statusCheck = true;
        Vector3 pointCheck = new Vector3(0, pointCheckRay.transform.position.y, 0);
        while (statusCheck)
        {
            if (Physics.Raycast(pointCheck, Vector3.down, out hit))
            {
                if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("MCG-Terrain")
                    && hit.collider.gameObject.GetComponent<BarrierInformation>() == null)
                    || (hit.collider.gameObject.GetComponent<BarrierInformation>() != null
                    && hit.collider.gameObject.GetComponent<BarrierInformation>().neverDestroy))
                {
                    result = hit.point.y;
                    if (hit.collider.tag == "WaterSurface")
                        result = hit.point.y + 2.5f;
                    statusCheck = false;
                }
                else
                {
                    pointCheck = new Vector3(0, hit.point.y - 0.1f, 0);
                    numCheck++;
                    if (numCheck > 5) statusCheck = false;
                }
            }
            else statusCheck = false;
        }
        return result;
    }

    bool CheckOnTheAir()
    {
        bool result = true;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.point.y + 1f > transform.position.y)
                result = false;
        }
        return result;
    }

    bool CheckNearGround(float heightCheck)//gan voi collider moi trong khoang nay
    {
        bool result = true;
        RaycastHit hit;
        if (Physics.Raycast(pointCheckRay.transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.GetComponent<BonusRoadDown>() == null)
            {
                if (Mathf.Abs(hit.point.y - pointCheckRay.transform.position.y) > heightCheck)
                    result = false;
            }
            else
            {
                if (hit.collider.gameObject.GetComponent<BonusRoadDown>().GetStatusTrap())
                    result = false;
            }
        }
        return result;
    }

    int GetTotalLaneNow()
    {
        int result = 3;
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(0, -150, 0), Vector3.up, out hit))
        {
            if (hit.collider.gameObject.transform.localScale.x > 20)
                result = 5;
            else if (hit.collider.gameObject.transform.localScale.x > 15)
                result = 4;
        }
        return result;
    }

    void ColliderWithBarrier(TypeFalling typeDie)
    {
        if (Modules.statusGame == StatusGame.stop) return;
        if (Modules.useBoat) typeDie = TypeFalling.backScene;
        if (typeDie == TypeFalling.policeCatch)
        {
            RaycastHit hit;
            if (Physics.Raycast(pointCheckRay.transform.position, Vector3.down, out hit))
            {
                if (hit.collider.gameObject.tag == "WaterSurface")
                {
                    Modules.distanceEnemy = 2;
                    typeDie = TypeFalling.backScene;
                }
            }
        }
        effectStunned.SetActive(false);
        RemoveSkisItem(false, false);
        if (Modules.useBonus)
        {
            SetDownBonusRoad(1);
            return;
        }
        else if (Modules.useTemple)
        {
            SetDownTempleRun(1);
            return;
        }
        mesStartJump = false;
        doneJumpHero = true;
        SetBackObjectFollow();
        HandleBackHero();
        RemoveBoatSpeedUp();
        RemoveBlueArrow();
        CancelInvoke();
        float timeShowBox = 1f;
        //xu ly animation die
        if (typeDie == TypeFalling.front)
        {
            statusHero = StatusHero.fallA;
            CallAniNew(aniDieFront, TypeAniRun.dieFront, false);
            timeShowBox = 1f;
        }
        else if (typeDie == TypeFalling.back)
        {
            statusHero = StatusHero.fallA;
            CallAniNew(aniDieBack, TypeAniRun.dieBack, false);
            timeShowBox = 1f;
        }
        else if (typeDie == TypeFalling.backScene)
        {
            statusHero = StatusHero.fallB;
            CallAniNew(aniDieBackScene, TypeAniRun.dieBackScene, false);
            timeShowBox = 2f;
            Camera.main.GetComponent<CameraController>().timeFollow = 0.01f;
        }
        else
        {
            TaskData.HandleTaskLess(29, TaskData.countTimeRun, 10);
            TaskData.HandleTaskLess(108, TaskData.countTimeRun, 5);
            statusHero = StatusHero.fallC;
            CallAniNew(aniDieCatch, TypeAniRun.dieCatch, false);
            Modules.distanceEnemy = 0;
            Camera.main.GetComponent<PageMainGame>().createEnemyLeft.GetComponent<EnemyController>().SetNearFarPoint(false);
            timeShowBox = 3f;
        }
        Modules.panelChallenge.SetActive(false);
        Modules.statusGame = StatusGame.over;
        //Modules.FreeMemoryNow();
        Invoke("ShowBoxSaveMe", timeShowBox);
        Camera.main.GetComponent<PageMainGame>().UpdateScoreNow();
        MMVibrationManager.Haptic(HapticTypes.Warning);
    }

    void ShowPanelCrack()
    {
        if (Modules.panelCrackGlass)
        {
            if (Modules.panelCrackGlass.gameObject.activeSelf) return;
            Modules.panelCrackGlass.gameObject.SetActive(true);
            Modules.PlayAudioClipFree(Modules.audioBrokenGlass);
            Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        }
    }

    void ShowBoxSaveMe()
    {
        if (Modules.statusGame == StatusGame.stop) return;
        if (Modules.statusGame == StatusGame.over)
        {
            bool typeBoxFull = false;
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
            if (Modules.admobAds)
            {
                if (ADSController.Instance.rewardState == AdsState.Loaded)
                    typeBoxFull = true;
            }
            else
            {
                if (Chartboost.hasRewardedVideo(CBLocation.Default))
                    typeBoxFull = true;
            }
#elif (UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0) && !UNITY_EDITOR
            if (Modules.adsInter.HaveVideoAds())
                typeBoxFull = true;
            else Modules.adsInter.RequestVideoAds();
#elif UNITY_WEBGL
            typeBoxFull = true;
#endif
            if (typeBoxFull && Modules.runTimeShowAdsSaveMe < Modules.timeShowAdsSaveMe)
            {
                Modules.mesSaveMeFullBox.SetActive(true);
                Modules.mesSaveMeFullBox.GetComponent<Animator>().SetTrigger("TriOpen");
                Modules.mesSaveMeFullBox.GetComponent<MessageSaveMe>().StartShowMessage();
                Modules.runTimeShowAdsSaveMe++;
            }
            else
            {
                Modules.mesSaveMeBox.SetActive(true);
                Modules.mesSaveMeBox.GetComponent<Animator>().SetTrigger("TriOpen");
                Modules.mesSaveMeBox.GetComponent<MessageSaveMe>().StartShowMessage();
            }
        }
    }

    public void SetStopGame()
    {
        SetRigibodyNormal();
        CallAniNew(aniIdleMenu, TypeAniRun.idleMenu, true, 1, 0, 1);
        statusHero = StatusHero.fallB;
        Modules.statusGame = StatusGame.stop;
        Modules.panelBGEffectBonus.SetActive(false);
        CancelInvoke();
    }

    //XU LY AN ITEMS
    private string valueChallenge = "";
    private int indexChallenge = -1;
    private float oldSpeedRun = -1f;

    private void CreateEffectItemFly(float speedMore)
    {
        if (speedMore < 0)
        {
            Modules.speedAddMoreUse = 1;
            oldSpeedRun = Modules.speedGame;
            Modules.speedGame = Mathf.Abs(speedMore);
        }
        else
        {
            Modules.speedAddMoreUse = Modules.speedAddUseRocket * speedMore;
            if (oldSpeedRun != -1)
            {
                Modules.speedGame = oldSpeedRun;
                oldSpeedRun = -1f;
            }
        }
        Modules.parSpeedFly.GetComponent<ParticleSystem>().Play();
        myCollider.transform.localScale = new Vector3(originScaleX * 2, myCollider.transform.localScale.y, myCollider.transform.localScale.z);
    }

    private void RemoveEffectItemFly()
    {
        Modules.speedAddMoreUse = 1;
        if (oldSpeedRun != -1)
        {
            Modules.speedGame = oldSpeedRun;
            Modules.UpdateSpeedScoreBooster();
        }
        SetStopEffectQuick();
        myCollider.transform.localScale = new Vector3(originScaleX, myCollider.transform.localScale.y, myCollider.transform.localScale.z);
        if (useBag)
            myBagUse.SetActive(true);
    }

    //private GameObject itemCamera;//item dieu chinh toa do, goc camera
    private bool usingNextGate = false;
    void OnTriggerEnter(Collider collider)
    {
        //xu ly khi roi xuong nuoc o temple run
        if (collider.gameObject.tag == "WaterTemple")
            Instantiate(Modules.parWaterDown, new Vector3(transform.position.x, -2.8f, transform.position.z), Quaternion.identity);
        if (Modules.statusGame != StatusGame.play) return;
        ItemInformation item = collider.gameObject.GetComponent<ItemInformation>();
        if (item != null)
        {
            if (item.typeItem == TypeItems.balloon)//khinh khi cau
            {
                if (Modules.statusGame == StatusGame.flyScene) return;
                transform.position = collider.transform.position;
                if (myHotAirBalloon != null) Destroy(myHotAirBalloon);
                myHotAirBalloon = Instantiate(collider.gameObject, transform, true) as GameObject;
                if (myHotAirBalloon.GetComponent<Collider>() != null)
                    myHotAirBalloon.GetComponent<Collider>().enabled = false;
                item.ResetItem();
                collider.gameObject.SetActive(false);
            }
            else if (item.typeItem == TypeItems.nextGate)//neu la next gate
            {
                if (item.pointFllow != null && !usingNextGate)
                {
                    //itemCamera = collider.gameObject;
                    //itemCamera.transform.parent = null;
                    //Camera.main.GetComponent<CameraController>().SetObjectFollow(item.pointFllow);
                    //Camera.main.GetComponent<CameraController>().timeFollow = 0.5f;
                    usingNextGate = true;
                    Camera.main.GetComponent<CameraController>().UpdateDeltaPoint(new Vector3(0, -5f, -3f), new Vector3(-30, 0, 0));
                    Invoke("SetBackObjectFollow", 0.75f);
                    return;
                }
            }
            else if (item.typeItem == TypeItems.endBag)//end bag
            {
                print("thuc hien thuong sau khi giao hang thanh cong");
                SetDoneBag();
                int valueBonus = Random.Range(200, 500);
                Modules.BonusMissionsChallenge(0, AllLanguages.playDeliveryComplete[Modules.indexLanguage], valueBonus, Vector3.zero);
                Destroy(collider.gameObject);
                //MMVibrationManager.Haptic(HapticTypes.Failure);
                return;
            }
            else if (item.typeItem == TypeItems.startTunner)//start tunner
            {
                Modules.SetAllowHoverbike(false);
                return;
            }
            else if (item.typeItem == TypeItems.endTunner)//end tunner
            {
                Modules.SetAllowHoverbike(true);
                return;
            }
            else if (item.typeItem == TypeItems.startBridge)//start bridge
            {
                Modules.underBridge = true;
                return;
            }
            else if (item.typeItem == TypeItems.endBridge)//end bridge
            {
                Modules.underBridge = false;
                return;
            }
            else if (item.typeItem == TypeItems.trap)//xu ly khi dam vao trap
            {
                if (boneTrap != null)
                    collider.gameObject.GetComponent<TrapController>().SetTrapPlay(boneTrap);
                return;
            }
            else if (item.typeItem == TypeItems.chestTemple)//xu ly khi chay toi chest temple run
            {
                TaskData.HandleTask(89, 1, 5);
                TaskData.HandleTask(96, 1, 15);
                transform.position = new Vector3(collider.transform.position.x, transform.position.y, transform.position.z);
                collider.gameObject.GetComponent<OpenChestTemple>().StartOpen();
                SetDownTempleRun(2, 4, false);
                return;
            }
            else
            {
                if (item.typeItem == TypeItems.challenge)//neu la challenge
                {
                    valueChallenge = item.valueText;
                    indexChallenge = item.indexText;
                }
                else if (item.typeItem == TypeItems.trampoline || item.typeItem == TypeItems.roadBonus)//neu la jumper hoac road bonus
                {
                    transform.position = collider.transform.position;
                }
                if (item.typeItem == TypeItems.coin)
                {
                    if (item.GetComponent<MoveToMagnet>() != null || !item.transform.GetChild(0).gameObject.activeSelf) return;
                    Modules.poolOthers.GetComponent<HighItemsController>().PlayEffectEatCoins(collider.transform.position);
                }
                else if (item.typeItem == TypeItems.boomTNT)
                    Modules.poolOthers.GetComponent<HighItemsController>().PlayEffectBoom(collider.transform.position);
                else if (item.typeItem == TypeItems.spinWheel)
                {
                    Modules.poolOthers.GetComponent<HighItemsController>().PlayEffectEatItems(collider.transform.position, false);
                    Modules.PlayAudioClipFree(Modules.audioPickSpinWheel);
                }
                else
                    Modules.poolOthers.GetComponent<HighItemsController>().PlayEffectEatItems(collider.transform.position);
                item.ResetItem();
                if (item.typeItem != TypeItems.trampoline && item.typeItem != TypeItems.roadBonus && item.typeItem != TypeItems.waterRamp)
                    collider.gameObject.SetActive(false);
            }
            RunFunctionItem(item.typeItem, collider.transform.position.x);
        }
        else
        {
            FlyCamController fly = collider.gameObject.GetComponent<FlyCamController>();
            if (fly != null) CatchFlyCam();
        }
    }

    void CatchFlyCam()
    {
        if (Modules.flyCamCatch)
        {
            TaskData.HandleTask(88, 1, 10);
            //xu ly khi bat duoc flycam o day
            Modules.flyCamNow.SetActive(false);
            Modules.flyCamCatch = false;
            Modules.coinPlayer += 200;
            Modules.textCoinPlay.text = Modules.coinPlayer.ToString();
            GameObject mesEffect = Instantiate(Modules.mesDiamondIncrease, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            mesEffect.GetComponent<SetValueDD>().SetValue(200, false);
            Instantiate(Modules.effectCatchFlyCam, Modules.flyCamNow.transform.position, Quaternion.identity);
            MMVibrationManager.Haptic(HapticTypes.Success);

            //xu ly qua huong dan
            if (Modules.gameGuide == "YES" && Modules.stepGuide == 4)
            {
                Modules.stepGuide++;
                Transform textGuide = Modules.panelGameGuide.transform.Find("TextGuide");
                textGuide.GetComponent<Text>().text = AllLanguages.playUseHoverboard[Modules.indexLanguage];
                showRemindCatch = false;
                arrowGuide.gameObject.SetActive(showRemindCatch);
                Transform keySpace = Modules.panelGameGuide.transform.Find("KeySpace");
                if (!Application.isMobilePlatform)
                {
                    keySpace.gameObject.SetActive(true);
                    keySpace.GetComponent<Animator>().SetTrigger("TriPlay");
                }
            }
        }
    }

    void SetBackObjectFollow()
    {
        //Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        //Camera.main.GetComponent<CameraController>().SetObjectFollow(Modules.mainCharacter);
        //if (itemCamera != null) Destroy(itemCamera);
        Camera.main.GetComponent<CameraController>().ResetDeltaPoint();
        usingNextGate = false;
    }

    public void RunFunctionItem(TypeItems codeItem, float pointXItems, bool useBuy = false)
    {
        if (Modules.statusGame == StatusGame.flyScene) return;
        //xu ly neu va cham items
        if (codeItem == TypeItems.coin)//neu la dong xu
        {
            int xNum = 1;
            if (Modules.useDouble) xNum = 2;
            xNum *= Modules.buyDoubleCoins * Modules.xDiamondSecretBox;
            Modules.coinPlayer += xNum;
            Modules.textCoinPlay.text = Modules.coinPlayer.ToString();
            TaskData.HandleTask(0, xNum, 100);
            TaskData.HandleTask(12, xNum, 200);
            TaskData.HandleTask(18, xNum, 1000);
            TaskData.HandleTask(45, xNum, 400);
            TaskData.HandleTask(70, xNum, 15000);
            if (Modules.useRocket)
                TaskData.HandleTask(10, xNum, 100);
            if (Modules.useBoat)
            {
                TaskData.HandleTask(104, xNum, 20000);
                TaskData.HandleTask(113, xNum, 500);
                TaskData.HandleTask(120, xNum, 1000);
            }
            TaskData.countScoreNoDiamond = 0;
        }
        else if (codeItem == TypeItems.key)//neu la key
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(57, 1, 2);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            Modules.totalKey++;
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.sneaker)//neu la power (giay)
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(5, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(38, 1, 5);
            TaskData.HandleTask(50, 1, 3);
            TaskData.HandleTask(65, 1, 4);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(92, 1, 100);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(116, 1, 500);
            TaskData.HandleTask(122, 1, 30);
            TaskData.HandleTask(128, 1, 25);
            TaskData.HandleTask(136, 1, 30);
            TaskData.HandleTask(152, 1, 15);
            if (!Modules.usePower)
            {
                Modules.SetModelUseItem(transform, codeBody, Modules.itemShoeLeft, "ShoeLeft");
                Modules.SetModelUseItem(transform, codeBody, Modules.itemShoeRight, "ShoeRight");
                if (typeAniRun == TypeAniRun.runNormal)
                    CallAniNew(aniRunSneaker, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else if (typeAniRun == TypeAniRun.runMagnet)
                    CallAniNew(aniRunSneakerMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
            Modules.usePower = true;
            Modules.SetPanelShowItem(codeItem, Modules.listIconItem[1]);
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.magnet)//neu la magnet (nam cham)
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(21, 1, 3);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(42, 1, 5);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            TaskData.HandleTask(130, 1, 20);
            if (!Modules.useMagnet) Modules.SetModelUseItem(transform, codeBody, Modules.itemMagnet, "Magnet");
            Modules.useMagnet = true;
            Modules.SetPanelShowItem(codeItem, Modules.listIconItem[2]);
            SetAniAddMagnet();
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.jetpack)//neu la rocket
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(25, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(48, 1, 5);
            TaskData.HandleTask(67, 1, 15);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            TaskData.HandleTask(137, 1, 300);
            if (!Modules.useRocket) Modules.SetModelUseItem(transform, codeBody, myJetpack, "Rocket");
            Modules.speedPercentJetpack = myJetpack.GetComponent<JetpackController>().speedPercent;
            SetLaneFollowItem(pointXItems);
            Modules.distanceEnemy = 2;
            Modules.useRocket = true;
            Modules.SetPanelShowItem(codeItem, Modules.listIconItem[3]);
            CreateEffectItemFly(1);
            JumpHero();
            SetAniAddRocket();
            HideFlyCam();
            myBagUse.SetActive(false);
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.trampoline)//neu la jumper
        {
            SetLaneFollowItem(pointXItems);
            Modules.distanceEnemy = 2;
            Modules.useJumper = true;
            CreateEffectItemFly(-1.2f);
            JumpHero();
            SetAniAddJumper();
            HideFlyCam();
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.xpoint)//neu la X2 score
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            int numberXpoint = Modules.GetXScoreNow();
            Modules.xPointPlayer += numberXpoint;
            Modules.ShowPanelEffectAddPoint(numberXpoint, Vector3.zero, Modules.containEffectAddPoint, 0.3f);
            Invoke("UpdateXPoint", 0.3f);
            Modules.useXPoint = true;
            Modules.SetPanelShowItem(codeItem, Modules.listIconItem[4]);
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.hoverboard)//neu la skis
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            Modules.totalSkis++;
            if (Modules.totalSkis > Modules.maxHoverboard)
                Modules.totalSkis = Modules.maxHoverboard;
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.scoreBooster)//neu la scoreBooster
        {
            if (useBuy)
            {
                Modules.xPointPlayer++;
                Modules.countScoreUse++;
                Modules.ShowPanelEffectAddPoint(1, Vector3.zero, Modules.containEffectAddPoint, 0.3f);
                Invoke("UpdateXPoint", 0.3f);
            }
            else
            {
                Modules.totalScoreBooster++;
                if (Modules.totalScoreBooster > Modules.maxScorebooster)
                    Modules.totalScoreBooster = Modules.maxScorebooster;
            }
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.headStart)//neu la headStart
        {
            Modules.totalHeadStart++;
            if (Modules.totalHeadStart > Modules.maxHeadstart)
                Modules.totalHeadStart = Modules.maxHeadstart;
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.mysteryBox)//neu la mysteryBox
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(31, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(43, 1, 5);
            TaskData.HandleTask(68, 1, 8);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(118, 1, 4);
            TaskData.HandleTask(128, 1, 25);
            TaskData.HandleTask(138, 1, 80);
            Modules.totalMysteryBox++;
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.hoverbike)//neu la cable
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            if (!Modules.useCable) Modules.SetModelUseItem(transform, codeBody, Modules.itemCable, "Cable");
            SetLaneFollowItem(pointXItems);
            Modules.distanceEnemy = 2;
            Modules.useCable = true;
            Modules.SetPanelShowItem(codeItem, Modules.listIconItem[5]);
            CreateEffectItemFly(1);
            JumpHero();
            SetAniAddCable();
            HideFlyCam();
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.jetball)//neu la jetball
        {
            if (!Modules.useJetBall) Modules.SetModelUseItem(transform, codeBody, Modules.itemJetBall, "JetBall");
            SetLaneFollowItem(pointXItems);
            Modules.distanceEnemy = 2;
            Modules.useJetBall = true;
            Modules.SetPanelShowItem(codeItem, Modules.listIconItem[6]);
            CreateEffectItemFly(1);
            JumpHero();
            SetAniAddJetBall();
            HideFlyCam();
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.balloon)//neu la balloon (khinh khi cau)
        {
            SetLaneFollowItem(pointXItems);
            RemoveEffectItemFly();
            ResetStatus();
            Modules.distanceEnemy = 2;
            Modules.statusGame = StatusGame.flyScene;
            SetAniAddBalloon();
            Camera.main.GetComponent<CameraController>().UpdateDeltaPoint(new Vector3(0, 3f, 0), Vector3.zero);
            Modules.poolOthers.GetComponent<HighItemsController>().ResetAllItems();
            HideFlyCam();
            Modules.colorBGChangeMap = new Color(Modules.colorBGChangeMap.r, Modules.colorBGChangeMap.g, Modules.colorBGChangeMap.b, 0);
            Modules.matBGChangeMap.color = Modules.colorBGChangeMap;
            Modules.panelChangeSky.SetActive(true);
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.missions)//neu la missions
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            Modules.runItemMissions++;
            if (Modules.runItemMissions == Modules.totalItemMissions)
            {
                //neu hoan thanh nhiem vu
                Modules.newMissions = false;
                Modules.dataMissionsOld = Modules.dataMissionsUse;
                Modules.SaveDataMissionsOld();
                Modules.dataMissionsUse = "";
                Modules.SaveDataMissions();
                Modules.panelMissions.SetActive(false);
                Modules.BonusMissionsChallenge(Modules.indexBonusMissions, AllLanguages.playMissionComplete[Modules.indexLanguage], Modules.totalBonusMissions, Vector3.zero);
                Modules.PlayAudioClipFree(Modules.audioChallMissDone);
            }
            else
            {
                if (Modules.dataMissionsUse != "")
                {
                    Modules.UpdateValueMissions();
                    Modules.panelMissions.SetActive(true);
                }
            }
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.challenge)//neu la challenge
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            if (indexChallenge == Modules.listTextColect.Count)
            {
                Modules.listTextColect.Add(valueChallenge);
                if (Modules.listTextColect.Count == Modules.listTextRequire.Count)
                {
                    //neu hoanh thanh thu thach
                    TaskData.HandleTask(17, 1, 1);
                    TaskData.HandleTaskSave(95, 1, 5);
                    TaskData.HandleTaskSave(114, 1, 20);
                    Modules.newChallenge = false;
                    Modules.dataChallengeOld = Modules.dataChallengeUse;
                    Modules.SaveDataChallengeOld();
                    Modules.dataChallengeUse = "";
                    Modules.SaveDataChallenge();
                    Modules.panelChallenge.SetActive(false);
                    Modules.BonusMissionsChallenge(Modules.indexBonusChallenge, AllLanguages.playChallengeComplete[Modules.indexLanguage], Modules.totalBonusChallenge, Vector3.zero);
                    Modules.PlayAudioClipFree(Modules.audioChallMissDone);
                }
                else
                {
                    if (Modules.dataChallengeUse != "")
                    {
                        Modules.UpdateValueChallenge();
                        Modules.panelChallenge.SetActive(true);
                        Invoke("AudoHideChallenge", 2f);
                    }
                }
            }
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.roadBonus)//neu la road bonus
        {
            //SetLaneFollowItem(pointXItems);
            Modules.distanceEnemy = 2;
            Modules.useBonus = true;
            Modules.SetAllowHoverbike(false);
            Modules.statusGame = StatusGame.bonusEffect;
            Modules.runAffterDownBonus = false;
            JumpHero();
            SetAniAddBonus();
            HideFlyCam();
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.boxBonus)//neu la box bonus
        {
            if (Modules.useBonus)
            {
                Modules.PlayAudioClipFree(Modules.audioEatBonusBox);
                //thuc hien thuong bonus box
                int indexBonus = 0;//coins
                int numberBonus = 5000;
                int maxRan = 4;
                if (Modules.allowHoverbike) maxRan = 5;
                int iRan = Random.Range(1, maxRan);
                if (iRan == 1)
                {
                    indexBonus = 1;//keys
                    numberBonus = 15;
                }
                else if (iRan == 2)
                {
                    indexBonus = 2;//hoverboards
                    numberBonus = 15;
                }
                else if (iRan == 3)
                {
                    if (Modules.allowHoverbike)
                    {
                        indexBonus = 3;//hoverbike
                        numberBonus = 10;
                    }
                    else
                    {
                        indexBonus = 4;//scoreBooster
                        numberBonus = 7;
                    }
                }
                else if (iRan == 4)
                {
                    indexBonus = 4;//scoreBooster
                    numberBonus = 7;
                }
                Modules.BonusMissionsChallenge(indexBonus, "", numberBonus, Vector3.zero);
                SetDownBonusRoad(2, 2, false);
                //MMVibrationManager.Haptic(HapticTypes.Failure);
            }
        }
        else if (codeItem == TypeItems.doubleCoin)//neu la double coin
        {
            TaskData.countScoreNoItem = 0;
            TaskData.HandleTask(2, 1, 2);
            TaskData.HandleTask(34, 1, 12);
            TaskData.HandleTask(86, 1, 50);
            TaskData.HandleTask(110, 1, 120);
            TaskData.HandleTask(128, 1, 25);
            UseDoubleCoin();
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.boomTNT)//neu la boom
        {
            TaskData.HandleTask(7, 1, 5);
            TaskData.HandleTask(49, 1, 10);
            TaskData.HandleTask(76, 1, 15);
            TaskData.HandleTask(87, 1, 200);
            TaskData.HandleTask(101, 1, 500);
            int numDeduction = Random.Range(15, 38);
            Modules.coinPlayer -= numDeduction;
            TaskData.HandleTask(0, -numDeduction, 100);
            TaskData.HandleTask(12, -numDeduction, 200);
            TaskData.HandleTask(18, -numDeduction, 1000);
            TaskData.HandleTask(28, -numDeduction, 50);
            TaskData.HandleTask(41, -numDeduction, 200);
            TaskData.HandleTask(45, -numDeduction, 400);
            TaskData.HandleTask(62, -numDeduction, 250);
            TaskData.HandleTask(70, -numDeduction, 15000);
            TaskData.HandleTask(106, -numDeduction, 4000);
            if (Modules.useRocket)
                TaskData.HandleTask(10, -numDeduction, 100);
            if (Modules.coinPlayer < 0) Modules.coinPlayer = 0;
            Modules.textCoinPlay.text = Modules.coinPlayer.ToString();
            GameObject mesEffect = Instantiate(Modules.mesDiamondDeduction, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            mesEffect.GetComponent<SetValueDD>().SetValue(numDeduction);
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.spinWheel)
        {
            Modules.totalWheelSpin++;
            Modules.SaveSpinWheel();
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.waterRamp)//neu la water ramp
        {
            if (Modules.useBoat && boatNow != null)
            {
                boatNow.GetComponent<PlaySparksBoat>().ShowHideSparks(false);
                Modules.StopAudioClipLoop(Modules.containMainGame.transform);
            }
            JumpHero(true);
            if (Modules.useSkis && skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
            {
                if (Modules.useMagnet)//neu dang su dung magnet
                    CallAniNew(aniJumpCableMagnetPower[Random.Range(0, aniJumpCableMagnetPower.Count)], typeAniRun, false, 1.25f);
                else
                    CallAniNew(aniJumpCablePower[Random.Range(0, aniJumpCablePower.Count)], typeAniRun, false, 1.25f);
            }
            else if (Modules.useBoat)
            {
                if (Modules.useMagnet)//neu dang su dung magnet
                    CallAniNew(aniJumpBoatMagnetPower[Random.Range(0, aniJumpBoatMagnetPower.Count)], typeAniRun, false, 1.25f);
                else
                    CallAniNew(aniJumpBoatPower[Random.Range(0, aniJumpBoatPower.Count)], typeAniRun, false, 1.25f);
            }
            else
            {
                if (Modules.useSkis)
                {
                    if (Modules.useMagnet)//neu dang su dung magnet
                        CallAniNew(aniJumpSkisMagnetPower[Random.Range(0, aniJumpSkisMagnetPower.Count)], typeAniRun, false, 1.25f);
                    else
                        CallAniNew(aniJumpSkisPower[Random.Range(0, aniJumpSkisPower.Count)], typeAniRun, false, 1.25f);
                }
                else
                {
                    if (Modules.useMagnet)//neu dang su dung magnet
                        CallAniNew(aniJumpMagnetPower[Random.Range(0, aniJumpMagnetPower.Count)], typeAniRun, false, 1.25f);
                    else
                        CallAniNew(aniJumpPower[Random.Range(0, aniJumpPower.Count)], typeAniRun, false, 1.25f);
                }
            }
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.blueArrow)//neu la mui ten xanh
        {
            Modules.speedBuleArrow = 0.35f;
            Modules.parSpeedFly.GetComponent<ParticleSystem>().Play();
            CancelInvoke("RemoveBlueArrow");
            Invoke("RemoveBlueArrow", 15f);
            //MMVibrationManager.Haptic(HapticTypes.Failure);
        }
        else if (codeItem == TypeItems.secretBox)//neu la hop bi mat
        {
            int ranIndex = Random.Range(0, 5);
            GameObject effectMes = Modules.mesMultiplyX30;
            int numXRan = 30;
            if (ranIndex == 0)
            {
                numXRan = 30;
                effectMes = Modules.mesMultiplyX30;
            }
            else if (ranIndex == 1)
            {
                numXRan = 50;
                effectMes = Modules.mesMultiplyX50;
            }
            else if (ranIndex == 2)
            {
                numXRan = 80;
                effectMes = Modules.mesMultiplyX80;
            }
            else if (ranIndex == 3)
            {
                numXRan = 100;
                effectMes = Modules.mesMultiplyX100;
            }
            else if (ranIndex == 4)
            {
                numXRan = 150;
                effectMes = Modules.mesMultiplyX150;
            }
            GameObject mesEffect = Instantiate(effectMes, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            if (Modules.GetXScoreNow() == 1) numXRan--;
            Modules.xPointSecretBox += numXRan;
            Modules.xPointPlayer += numXRan;
            Modules.UpdateXPointText();
            CancelInvoke("RemoveXPointSecretBox");
            Invoke("RemoveXPointSecretBox", 60);
            //MMVibrationManager.Haptic(HapticTypes.Failure);

            //if (ranIndex == 0)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesX2Diamonds, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    Modules.xDiamondSecretBox = 2;
            //    CancelInvoke("RemoveXDiamondSecretBox");
            //    Invoke("RemoveXDiamondSecretBox", 60);
            //}
            //else if (ranIndex == 1)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesX4Diamonds, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    Modules.xDiamondSecretBox = 4;
            //    CancelInvoke("RemoveXDiamondSecretBox");
            //    Invoke("RemoveXDiamondSecretBox", 60);
            //}
            //else if (ranIndex == 2)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesMultiplyX12, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    int numX = 12;
            //    if (Modules.GetXScoreNow() == 1) numX = 11;
            //    Modules.xPointSecretBox += numX;
            //    Modules.xPointPlayer += numX;
            //    Modules.UpdateXPointText();
            //    CancelInvoke("RemoveXPointSecretBox");
            //    Invoke("RemoveXPointSecretBox", 60);
            //}
            //else if (ranIndex == 3)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesMultiplyX18, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    int numX = 18;
            //    if (Modules.GetXScoreNow() == 1) numX = 17;
            //    Modules.xPointSecretBox += numX;
            //    Modules.xPointPlayer += numX;
            //    Modules.UpdateXPointText();
            //    CancelInvoke("RemoveXPointSecretBox");
            //    Invoke("RemoveXPointSecretBox", 60);
            //}
            //else if (ranIndex == 4)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesMultiplyX30, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    int numX = 30;
            //    if (Modules.GetXScoreNow() == 1) numX = 29;
            //    Modules.xPointSecretBox += numX;
            //    Modules.xPointPlayer += numX;
            //    Modules.UpdateXPointText();
            //    CancelInvoke("RemoveXPointSecretBox");
            //    Invoke("RemoveXPointSecretBox", 60);
            //}
            //else if (ranIndex == 5)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesMultiplyX50, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    int numX = 50;
            //    if (Modules.GetXScoreNow() == 1) numX = 49;
            //    Modules.xPointSecretBox += numX;
            //    Modules.xPointPlayer += numX;
            //    Modules.UpdateXPointText();
            //    CancelInvoke("RemoveXPointSecretBox");
            //    Invoke("RemoveXPointSecretBox", 60);
            //}
            //else if (ranIndex == 6)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesBikerPride, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    Modules.useHoverSecretBox = 2;
            //    CancelInvoke("RemoveHoverSecretBox");
            //    Invoke("RemoveHoverSecretBox", 60);
            //    //xu ly khi dang su dung skis
            //    if (Modules.useSkis) SetSkisSecretBox(Modules.hoverSecretBox2);
            //    else
            //    {
            //        Modules.totalSkis += 1;
            //        Camera.main.GetComponent<PageMainGame>().UseHoverboard();
            //    }
            //}
            //else if (ranIndex == 7)
            //{
            //    GameObject mesEffect = Instantiate(Modules.mesYouRock, Vector3.zero, Quaternion.identity, Modules.containMesBoom.transform) as GameObject;
            //    mesEffect.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            //    Modules.useHoverSecretBox = 1;
            //    CancelInvoke("RemoveHoverSecretBox");
            //    Invoke("RemoveHoverSecretBox", 60);
            //    //xu ly khi dang su dung skis
            //    if (Modules.useSkis) SetSkisSecretBox(Modules.hoverSecretBox1);
            //    else
            //    {
            //        Modules.totalSkis += 1;
            //        Camera.main.GetComponent<PageMainGame>().UseHoverboard();
            //    }
            //}
        }
    }

    void SetSkisSecretBox(GameObject skisUse)
    {
        Modules.SetPanelShowItem(TypeItems.hoverboard, Modules.ChangeIconHoverboard(skisUse.GetComponent<SkisController>().idSkis));
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Skis");
        skisNow = Modules.SetModelUseItem(transform, codeBody, skisUse, "Skis");
        Modules.speedPercentSkis = skisNow.GetComponent<SkisController>().speedPercent;
        if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
        {
            if (typeAniRun == TypeAniRun.runSkis)//neu dang chay thuong
                CallAniNew(aniRunCable, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else if (typeAniRun == TypeAniRun.runSkisMagnet)//neu dang cam nam cham
                CallAniNew(aniRunCableMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else
        {
            if (typeAniRun == TypeAniRun.runSkis)//neu dang chay thuong
                CallAniNew(aniRunSkis, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else if (typeAniRun == TypeAniRun.runSkisMagnet)//neu dang cam nam cham
                CallAniNew(aniRunSkisMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
    }

    void RemoveXPointSecretBox()
    {
        int result = Modules.xPointPlayer - Modules.xPointSecretBox;
        if (result <= 0) return;
        Modules.xPointPlayer = result;
        Modules.xPointSecretBox = 0;
        Modules.UpdateXPointText();
    }

    void RemoveXDiamondSecretBox()
    {
        Modules.xDiamondSecretBox = 1;
    }

    void RemoveHoverSecretBox()
    {
        Modules.useHoverSecretBox = 0;
    }

    public void UseFlyCam(GameObject flyCamNow)
    {
        if (Modules.statusGame == StatusGame.flyScene) return;
        Modules.flyCamNow = flyCamNow;
        Modules.flyCamNow.transform.parent = transform;
        Modules.flyCamNow.transform.localPosition = new Vector3(0.035f, 0.47f, 0.1f);
        Modules.flyCamNow.GetComponent<FlyCamController>().myAnimator.SetTrigger("TriPickUp");

        RemoveEffectItemFly();
        ResetStatus();
        Modules.distanceEnemy = 2;
        Modules.useTemple = true;
        Modules.statusGame = StatusGame.flyScene;
        Modules.colorBGChangeMap = new Color(Modules.colorBGChangeMap.r, Modules.colorBGChangeMap.g, Modules.colorBGChangeMap.b, 0);
        Modules.matBGChangeMap.color = Modules.colorBGChangeMap;
        Modules.panelChangeSky.SetActive(true);
        Modules.runAffterDownBonus = false;
        SetAniAddFlyCam();
        Camera.main.GetComponent<CameraController>().UpdateDeltaPoint(new Vector3(0, 3f, 0), Vector3.zero);
        Modules.poolOthers.GetComponent<HighItemsController>().ResetAllItems();
    }

    private void HideFlyCam()
    {
        if (Modules.flyCamNow != null && Modules.flyCamNow.activeSelf)
        {
            Modules.flyCamNow.transform.SetParent(Modules.containFlyCam.transform, true);
            Modules.flyCamNow.GetComponent<FlyCamController>().FlyAway();
        }
    }

    public void UseDoubleCoin()
    {
        Modules.useDouble = true;
        foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
        GameObject effect = Instantiate(Modules.textDiamond[Modules.indexLanguage], Modules.parentTextEffect.transform);
        effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
        Modules.SetPanelShowItem(TypeItems.doubleCoin, Modules.listIconItem[7]);
        Modules.PlayAudioClipLoop(Modules.audioDiamondFrenzy, Camera.main.transform);
    }

    void AudoHideChallenge()
    {
        Modules.panelChallenge.SetActive(false);
    }

    void UpdateXPoint()
    {
        Modules.UpdateXPointText();
    }

    //XU LY LOAI BO ITEMS
    public void RemoveSkisItem(bool setAni, bool finish)
    {
        if (finish)
        {
            TaskData.HandleTask(30, 1, 1);
            TaskData.HandleTask(32, 1, 3);
            TaskData.HandleTask(56, 1, 3);
            TaskData.HandleTask(75, 1, 5);
            TaskData.HandleTask(126, 1, 10);
            TaskData.HandleTask(146, 1, 24);
        }
        Modules.useSkis = false;
        if (Modules.useBoat)
        {
            Modules.useBoat = false;
            Modules.StopAudioClipLoop(Modules.containMainGame.transform);
            //them hieu ung khi xoa bo thuyen
            if (Modules.showDownBoat == 0)
                Modules.panelGameGuide.SetActive(false);
        }
        Modules.speedPercentSkis = 0;
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Skis");
        if (setAni) SetAniRemoveSkis();
    }

    public void RemovePowerItem()
    {
        Modules.usePower = false;
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "ShoeLeft");
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "ShoeRight");
        if (!Modules.useBonus && !Modules.useTemple && doneJumpHero)
        {
            if (typeAniRun == TypeAniRun.runSkis)
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniRunCable, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else if (Modules.useBoat)
                    CallAniNew(aniRunBoat, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else
                    CallAniNew(aniRunSkis, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
            else if (typeAniRun == TypeAniRun.runSkisMagnet)
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniRunCableMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else if (Modules.useBoat)
                    CallAniNew(aniRunBoatMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else
                    CallAniNew(aniRunSkisMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
            else if (typeAniRun == TypeAniRun.runNormal)
                CallAniNew(aniRunNormal, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else if (typeAniRun == TypeAniRun.runMagnet)
                CallAniNew(aniRunMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
    }

    public void RemoveMagnetItem(bool setAni = true)
    {
        Modules.useMagnet = false;
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Magnet");
        if (setAni) SetAniRemoveMagnet();
    }

    public void RemoveRocketItem(bool setAni = true)
    {
        Modules.useRocket = false;
        Modules.speedPercentJetpack = 0;
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Rocket");
        if (setAni) SetAniRemoveJumperRocketCable();
        RemoveEffectItemFly();
    }

    public void RemoveJetBallItem(bool setAni = true)
    {
        Modules.useJetBall = false;
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "JetBall");
        if (setAni) SetAniRemoveJumperRocketCable();
        RemoveEffectItemFly();
    }

    public void RemoveJumperItem(bool setAni = true)
    {
        Modules.useJumper = false;
        if (setAni) SetAniRemoveJumperRocketCable();
        RemoveEffectItemFly();
    }

    public void RemoveCableItem(bool setAni = true)
    {
        Modules.useCable = false;
        Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Cable");
        if (setAni) SetAniRemoveJumperRocketCable();
        RemoveEffectItemFly();
    }

    public void RemoveXPointItem()
    {
        if (Modules.useXPoint)
        {
            Modules.xPointPlayer = Modules.countScoreUse;
            Modules.xPointPlayer += Modules.xPointSecretBox;
            Modules.UpdateXPointText();
        }
        Modules.useXPoint = false;
    }

    public void RemoveDoubleCoinItem(bool setAudio = true)
    {
        Modules.useDouble = false;
        if (setAudio)
        {
            if (useBag)
                Modules.PlayAudioClipLoop(Modules.audioDeliveryBag[Random.Range(0, Modules.audioDeliveryBag.Count)], Camera.main.transform);
            else Modules.PlayAudioClipLoop(Modules.audioBackgrond, Camera.main.transform);
        }
    }

    //CAN BAT CHAT CAC DIEU KIEN THEM HUY ANIMATION
    void SetAniRemoveSkis()
    {
        if (typeAniRun == TypeAniRun.runSkis)//neu dang luot van
        {
            typeAniRun = TypeAniRun.runNormal;
            if (doneJumpHero)
            {
                if (Modules.usePower)
                    CallAniNew(aniRunSneaker, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else CallAniNew(aniRunNormal, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
        }
        else if (typeAniRun == TypeAniRun.runSkisMagnet)//neu dang truot van cam nam cham
        {
            typeAniRun = TypeAniRun.runMagnet;
            if (doneJumpHero)
            {
                if (Modules.usePower)
                    CallAniNew(aniRunSneakerMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else CallAniNew(aniRunMagnet, typeAniRun, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
        }
        ResetDown(false, false);
    }

    void SetAniAddMagnet()
    {
        if (typeAniRun == TypeAniRun.runNormal)//neu dang chay thuong
        {
            typeAniRun = TypeAniRun.runMagnet;
            if (Modules.usePower)
                CallAniNew(aniRunSneakerMagnet, TypeAniRun.runMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else CallAniNew(aniRunMagnet, TypeAniRun.runMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runSkis)//neu dang truot van
        {
            typeAniRun = TypeAniRun.runSkisMagnet;
            if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                CallAniNew(aniRunCableMagnet, TypeAniRun.runSkisMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else if (Modules.useBoat)
                CallAniNew(aniRunBoatMagnet, TypeAniRun.runSkisMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            else CallAniNew(aniRunSkisMagnet, TypeAniRun.runSkisMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runRocket)//neu dang bay ten lua
        {
            typeAniRun = TypeAniRun.runRocketMagnet;
            AnimationClip aniNow = aniRunRocketMagnet;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRunBroomMagnet;
            CallAniNew(aniNow, typeAniRun, true, 0.25f, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runCable)//neu dang bay cable
        {
            typeAniRun = TypeAniRun.runCableMagnet;
            CallAniNew(aniRunCableMagnet, TypeAniRun.runCableMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runJetBall)//neu dang bay jetball
        {
            typeAniRun = TypeAniRun.runJetBallMagnet;
            CallAniNew(aniRunJetBallMagnet, TypeAniRun.runJetBallMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        ResetDown(false, false);
    }

    void SetAniRemoveMagnet()
    {
        if (typeAniRun == TypeAniRun.runMagnet)//neu dang chay cam nam cham
        {
            typeAniRun = TypeAniRun.runNormal;
            if (doneJumpHero)
            {
                if (Modules.usePower)
                    CallAniNew(aniRunSneaker, TypeAniRun.runNormal, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else CallAniNew(aniRunNormal, TypeAniRun.runNormal, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
        }
        else if (typeAniRun == TypeAniRun.runSkisMagnet)//neu dang truot van cam nam cham
        {
            typeAniRun = TypeAniRun.runSkis;
            if (doneJumpHero)
            {
                if (skisNow != null && skisNow.GetComponent<SkisController>().isHoverbike)
                    CallAniNew(aniRunCable, TypeAniRun.runSkis, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else if (Modules.useBoat)
                    CallAniNew(aniRunBoat, TypeAniRun.runSkis, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
                else CallAniNew(aniRunSkis, TypeAniRun.runSkis, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
            }
        }
        else if (typeAniRun == TypeAniRun.runRocketMagnet)//neu dang bay jetpack cam nam cham
        {
            typeAniRun = TypeAniRun.runRocket;
            AnimationClip aniNow = aniRunRocket;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRunBroom;
            CallAniNew(aniNow, typeAniRun, true, 0.25f, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runCableMagnet)//neu dang bay hoverbike cam nam cham
        {
            typeAniRun = TypeAniRun.runCable;
            CallAniNew(aniRunCable, TypeAniRun.runCable, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else if (typeAniRun == TypeAniRun.runJetBallMagnet)//neu dang bay jetball cam nam cham
        {
            typeAniRun = TypeAniRun.runJetBall;
            CallAniNew(aniRunJetBall, TypeAniRun.runJetBall, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        ResetDown(false, false);
    }

    private GameObject skisHide, skisNow, boatNow;//doi tuong bi an khi su dung item jumper, rocket, cable
    void SetAniAddJumper()
    {
        RemoveProgress(TypeItems.jetpack);
        RemoveProgress(TypeItems.hoverbike);
        RemoveProgress(TypeItems.jetball);
        if (Modules.useSkis) skisHide = Modules.HideModelUseItem(Modules.mainCharacter.transform, "Skis");
        else if (Modules.useBoat) RemoveSkisItem(false, false);
        if (Modules.useCable)
            RemoveCableItem(false);
        if (Modules.useRocket)
            RemoveRocketItem(false);
        if (Modules.useJetBall)
            RemoveJetBallItem(false);
        typeAniRun = TypeAniRun.runJumper;
        CallAniNew(aniRunJumper[Random.Range(0, aniRunJumper.Count)], TypeAniRun.runJumper, false, 1.3f);
        ResetDown(false, false);
    }

    void SetAniAddBonus()
    {
        RemoveProgress(TypeItems.hoverboard);//skis
        RemoveProgress(TypeItems.sneaker);//giay
        RemoveProgress(TypeItems.magnet);//nam cham
        RemoveProgress(TypeItems.xpoint);//x point
        RemoveProgress(TypeItems.jetpack);//jetpack
        RemoveProgress(TypeItems.hoverbike);//cable
        RemoveProgress(TypeItems.jetball);//jetball
        RemoveProgress(TypeItems.doubleCoin);//double coin
        if (Modules.useSkis || Modules.useBoat)
            RemoveSkisItem(false, false);
        if (Modules.usePower)
            RemovePowerItem();
        if (Modules.useMagnet)
            RemoveMagnetItem(false);
        if (Modules.useXPoint)
            RemoveXPointItem();
        if (Modules.useCable)
            RemoveCableItem(false);
        if (Modules.useRocket)
            RemoveRocketItem(false);
        if (Modules.useJumper)
            RemoveJumperItem(false);
        if (Modules.useJetBall)
            RemoveJetBallItem(false);
        if (Modules.useDouble)
            RemoveDoubleCoinItem(false);
        typeAniRun = TypeAniRun.runNormal;
        CallAniNew(aniRunBonus, TypeAniRun.runBonus, false);
    }

    void SetAniAddRocket()
    {
        RemoveProgress(TypeItems.hoverbike);
        RemoveProgress(TypeItems.jetball);
        if (Modules.useSkis) skisHide = Modules.HideModelUseItem(Modules.mainCharacter.transform, "Skis");
        else if (Modules.useBoat) RemoveSkisItem(false, false);
        if (Modules.useCable)//neu dang cable
        {
            Modules.useCable = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Cable");
        }
        if (Modules.useJetBall)//neu dang jetball
        {
            Modules.useJetBall = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "JetBall");
        }
        if (Modules.useJumper)//neu dang jumper
        {
            Modules.useJumper = false;
        }
        if (Modules.useMagnet)
        {
            typeAniRun = TypeAniRun.runRocketMagnet;
            AnimationClip aniNow = aniRunRocketMagnet;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRunBroomMagnet;
            CallAniNew(aniNow, typeAniRun, true, 0.25f, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else
        {
            typeAniRun = TypeAniRun.runRocket;
            AnimationClip aniNow = aniRunRocket;
            if (myJetpack.GetComponent<JetpackController>().isBroom) aniNow = aniRunBroom;
            CallAniNew(aniNow, typeAniRun, true, 0.25f, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
    }

    void SetAniAddCable()
    {
        RemoveProgress(TypeItems.jetpack);
        RemoveProgress(TypeItems.jetball);
        if (Modules.useSkis) skisHide = Modules.HideModelUseItem(Modules.mainCharacter.transform, "Skis");
        else if (Modules.useBoat) RemoveSkisItem(false, false);
        if (Modules.useRocket)//neu dang rocket
        {
            Modules.speedPercentJetpack = 0;
            Modules.useRocket = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Rocket");
        }
        if (Modules.useJetBall)//neu dang cable
        {
            Modules.useJetBall = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "JetBall");
        }
        if (Modules.useJumper)//neu dang jumper
        {
            Modules.useJumper = false;
        }
        if (Modules.useMagnet)
        {
            typeAniRun = TypeAniRun.runCableMagnet;
            CallAniNew(aniRunCableMagnet, TypeAniRun.runCableMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else
        {
            typeAniRun = TypeAniRun.runCable;
            CallAniNew(aniRunCable, TypeAniRun.runCable, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
    }

    void SetAniAddJetBall()
    {
        RemoveProgress(TypeItems.jetpack);
        RemoveProgress(TypeItems.hoverbike);
        if (Modules.useSkis) skisHide = Modules.HideModelUseItem(Modules.mainCharacter.transform, "Skis");
        else if (Modules.useBoat) RemoveSkisItem(false, false);
        if (Modules.useRocket)//neu dang rocket
        {
            Modules.speedPercentJetpack = 0;
            Modules.useRocket = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Rocket");
        }
        if (Modules.useCable)//neu dang cable
        {
            Modules.useCable = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Cable");
        }
        if (Modules.useJumper)//neu dang jumper
        {
            Modules.useJumper = false;
        }
        if (Modules.useMagnet)
        {
            typeAniRun = TypeAniRun.runJetBallMagnet;
            CallAniNew(aniRunJetBallMagnet, TypeAniRun.runJetBallMagnet, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
        else
        {
            typeAniRun = TypeAniRun.runJetBall;
            CallAniNew(aniRunJetBall, TypeAniRun.runJetBall, true, 1, Modules.moreSpeedAni, Modules.maxSpeedAni);
        }
    }

    void SetAniAddBalloon()
    {
        RemoveProgress(TypeItems.jetpack);
        RemoveProgress(TypeItems.jetball);
        RemoveProgress(TypeItems.hoverbike);
        if (Modules.useSkis) skisHide = Modules.HideModelUseItem(Modules.mainCharacter.transform, "Skis");
        else if (Modules.useBoat) RemoveSkisItem(false, false);
        if (Modules.useCable)//neu dang cable
        {
            Modules.useCable = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Cable");
        }
        if (Modules.useRocket)//neu dang rocket
        {
            Modules.speedPercentJetpack = 0;
            Modules.useRocket = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "Rocket");
        }
        if (Modules.useJetBall)//neu dang jetball
        {
            Modules.useJetBall = false;
            Modules.RemoveModelUseItem(Modules.mainCharacter.transform, "JetBall");
        }
        if (Modules.useJumper)//neu dang jumper
        {
            Modules.useJumper = false;
        }
        SetAniAfterFall();
        CallAniNew(aniMoveUp, TypeAniRun.balloonUp, false);
    }

    void SetAniAddFlyCam()
    {
        RemoveProgress(TypeItems.hoverboard);//skis
        RemoveProgress(TypeItems.sneaker);//giay
        RemoveProgress(TypeItems.magnet);//nam cham
        RemoveProgress(TypeItems.xpoint);//x point
        RemoveProgress(TypeItems.jetpack);//jetpack
        RemoveProgress(TypeItems.hoverbike);//cable
        RemoveProgress(TypeItems.jetball);//jetball
        RemoveProgress(TypeItems.doubleCoin);//double coin
        if (Modules.useSkis || Modules.useBoat)
            RemoveSkisItem(false, false);
        if (Modules.usePower)
            RemovePowerItem();
        if (Modules.useMagnet)
            RemoveMagnetItem(false);
        if (Modules.useXPoint)
            RemoveXPointItem();
        if (Modules.useCable)
            RemoveCableItem(false);
        if (Modules.useRocket)
            RemoveRocketItem(false);
        if (Modules.useJumper)
            RemoveJumperItem(false);
        if (Modules.useJetBall)
            RemoveJetBallItem(false);
        if (Modules.useDouble)
            RemoveDoubleCoinItem(false);
        typeAniRun = TypeAniRun.runNormal;
        CallAniNew(aniFlyCamPickUp, TypeAniRun.flyCamUp, false);
    }

    void RemoveProgress(TypeItems codeItem, bool handleContent = true)
    {
        foreach (Transform tran in Modules.containMesItems.transform)
        {
            if (tran.GetComponent<PanelShowUseItem>().codeItemNow == codeItem)
                tran.GetComponent<PanelShowUseItem>().RemovePanel(handleContent);
        }
    }

    void SetAniRemoveJumperRocketCable()
    {
        if (aniFallRocket != null && (typeAniRun == TypeAniRun.runRocket || typeAniRun == TypeAniRun.runRocketMagnet))
            CallAniNew(aniFallRocket, TypeAniRun.fallRocket, false);
        else if (aniFallJumper != null && typeAniRun == TypeAniRun.runJumper)
            CallAniNew(aniFallJumper, TypeAniRun.fallJumper, false);
        else if (aniFallCable != null && (typeAniRun == TypeAniRun.runCable || typeAniRun == TypeAniRun.runCableMagnet))
            CallAniNew(aniFallCable, TypeAniRun.fallCable, false);
        else if (aniFallJetBall != null && (typeAniRun == TypeAniRun.runJetBall || typeAniRun == TypeAniRun.runJetBallMagnet))
            CallAniNew(aniFallJetBall, TypeAniRun.fallJetBall, false);
        SetAniAfterFall();
    }

    void SetAniAfterFall()
    {
        if (Modules.useSkis)
        {
            if (Modules.useMagnet)
                typeAniRun = TypeAniRun.runSkisMagnet;
            else
                typeAniRun = TypeAniRun.runSkis;
        }
        else
        {
            if (Modules.useMagnet)
                typeAniRun = TypeAniRun.runMagnet;
            else
                typeAniRun = TypeAniRun.runNormal;
        }
    }

    void SetDownBonusRoad(int typeAni, float timeDelay = 0, bool stopCam = true)
    {
        if (Modules.statusGame == StatusGame.bonusEffect) return;
        Modules.statusGame = StatusGame.bonusEffect;
        if (stopCam) Camera.main.GetComponent<CameraController>().StopAllowFollow();
        overBonusRoad = true;
        if (typeAni == 0) SetAniFalling();
        else if (typeAni == 1) CallAniNew(aniDieBack, TypeAniRun.dieBack, false);
        else CallAniNew(aniIdleMenu, TypeAniRun.idleMenu, true, 1, 0, 1);
        //thuc hien goi chay effect UI toi dan
        Modules.panelBGEffectBonus.SetActive(true);
        if (timeDelay == 0)
            OverBonusRoad();
        else
            Invoke("OverBonusRoad", timeDelay);
    }

    void OverBonusRoad()
    {
        Modules.panelBGEffectBonus.GetComponent<Animator>().SetTrigger("TriOpen");
        Invoke("CheckEffectBonusDone", 0.1f);
    }

    void CheckEffectBonusDone()
    {
        if (Modules.panelBGEffectBonus.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BGEffectBonusRoadShow"))
        {
            RemoveSpeedSlow();
            Modules.useBonus = false;
            Modules.SetAllowHoverbike(true);
            //di chuyen vao lan giua
            numberLaneNew = 0;
            numberLaneOld = 0;
            transform.position = new Vector3(0, jumpCableHeight, 0);
            ResetStatus();
            doneJumpHero = false;
            checkFalling = true;
            SetAniFalling();
            SetRigibodyNormal();
            AddForceHero();
            if (Modules.distanceEnemy < 2)
            {
                Camera.main.GetComponent<PageMainGame>().createEnemyLeft.GetComponent<EnemyController>().ShowMesh();
                CancelInvoke("UpdateFarEnemy");
                Invoke("UpdateFarEnemy", Modules.timeFarEnemy);
            }
            //thuc hien doi map va chay animation sang dan
            Camera.main.GetComponent<CameraController>().StartAllowFollow();
            Camera.main.GetComponent<TerrainController>().SetNewScene(-1);
            Modules.runAffterDownBonus = true;
            Modules.PlayAudioClipLoop(Modules.audioBackgrond, Camera.main.transform);
            Modules.panelBGEffectBonus.GetComponent<Animator>().SetTrigger("TriClose");
            Modules.statusGame = StatusGame.play;
            overBonusRoad = false;
        }
        else Invoke("CheckEffectBonusDone", 0.1f);
    }

    void SetDownTempleRun(int typeAni, float timeDelay = 0, bool stopCam = true)
    {
        if (Modules.statusGame == StatusGame.bonusEffect) return;
        Modules.statusGame = StatusGame.bonusEffect;
        if (stopCam) Camera.main.GetComponent<CameraController>().StopAllowFollow();
        HideFlyCam();
        if (typeAni == 0) SetAniFalling();
        else if (typeAni == 1) CallAniNew(aniDieBack, TypeAniRun.dieBack, false);
        else CallAniNew(aniIdleMenu, TypeAniRun.idleMenu, true, 1, 0, 1);
        //thuc hien goi chay effect UI toi dan
        Modules.panelBGEffectBonus.SetActive(true);
        if (timeDelay == 0)
            OverTempleRun();
        else
            Invoke("OverTempleRun", timeDelay);
    }

    void OverTempleRun()
    {
        Modules.panelBGEffectBonus.GetComponent<Animator>().SetTrigger("TriOpen");
        Invoke("CheckEffectTempleDone", 0.1f);
    }

    void CheckEffectTempleDone()
    {
        if (Modules.panelBGEffectBonus.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BGEffectBonusRoadShow"))
        {
            RemoveSpeedSlow();
            Modules.useTemple = false;
            Modules.SetAllowHoverbike(true);
            //di chuyen vao lan giua
            numberLaneNew = 0;
            numberLaneOld = 0;
            transform.position = new Vector3(0, jumpCableHeight, 0);
            Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, Camera.main.transform.position.z);
            ResetStatus();
            doneJumpHero = false;
            checkFalling = true;
            SetAniFalling();
            SetRigibodyNormal();
            AddForceHero();
            if (Modules.distanceEnemy < 2)
            {
                Camera.main.GetComponent<PageMainGame>().createEnemyLeft.GetComponent<EnemyController>().ShowMesh();
                CancelInvoke("UpdateFarEnemy");
                Invoke("UpdateFarEnemy", Modules.timeFarEnemy);
            }
            //thuc hien doi map va chay animation sang dan
            Camera.main.GetComponent<CameraController>().StartAllowFollow();
            Camera.main.GetComponent<TerrainController>().SetNewScene(-1);
            Modules.runAffterDownBonus = true;
            Modules.PlayAudioClipLoop(Modules.audioBackgrond, Camera.main.transform);
            Modules.panelBGEffectBonus.GetComponent<Animator>().SetTrigger("TriClose");
            Modules.statusGame = StatusGame.play;
            Modules.speedGame = Modules.speedTempleRunBefore;
        }
        else Invoke("CheckEffectTempleDone", 0.1f);
    }

    //XU LY DIEU KHIEN KHINH KHI CAU
    private GameObject myHotAirBalloon;//doi tuong khinh khi cau
    private float speedFlying = 1f;
    private float timeFlying = 0f;//thoi gian lo lung tren khinh khi cau
    private float runTimeFlying = 0f;
    private bool isFlying = false;
    private bool mesFlyBalloon = false;

    void RunFlyBalloon()
    {
        if (!mesFlyBalloon) return;
        Vector3 pointFinal = new Vector3(transform.position.x, balloonHeight, 0);
        transform.position = Vector3.MoveTowards(transform.position, pointFinal, speedFlying * Time.deltaTime);
        if (pointFinal.y - transform.position.y <= 0)
        {
            if (!isFlying)
            {
                Camera.main.GetComponent<PlaneController>().RemoveAllPlane();
                Camera.main.GetComponent<TerrainController>().SetNewScene(-1);
                //Camera.main.GetComponent<CameraController>().ResetDeltaPoint();
                //Camera.main.GetComponent<CameraController>().timeFollow = 0.05f;
                isFlying = true;
            }
            runTimeFlying += Time.deltaTime;
            if (runTimeFlying >= timeFlying)
                SetFallBalloon();
        }
        else
        {
            if (transform.position.y < balloonHeight)
            {
                float angleX = Camera.main.transform.rotation.x - Time.deltaTime / 2f;
                Camera.main.transform.rotation = new Quaternion(angleX, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
            }
        }
    }

    void SetFallBalloon()
    {
        //thuc hien roi xuong
        RemoveSpeedSlow();
        checkFalling = true;
        isFlying = false;
        mesFlyBalloon = false;
        SetRigibodyNormal();
        //AddForceHero();
        Camera.main.GetComponent<CameraController>().ResetDeltaPoint();
    }

    void FlyBalloon()
    {
        checkFalling = false;
        Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        speedFlying =  /*Modules.speedGame * */numSpeedAct * speedBalloonFly;
        myRigid.isKinematic = true;
        myRigid.useGravity = false;
        myRigid.interpolation = RigidbodyInterpolation.None;
        mesFlyBalloon = true;
        Camera.main.GetComponent<ChangeHeightFog>().enabled = true;
        runTimeFlying = 0;
        Modules.underBridge = false;
    }

    //XU LY DIEU KHIEN FLY CAM
    private float speedFlyCam = 1f;
    private float timeFlyCam = 0f;//thoi gian lo lung tren fly cam
    private float runTimeFlyCam = 0f;
    private bool isFlyCam = false;
    private bool mesFlyCam = false;

    void RunFlyCam()
    {
        if (!mesFlyCam) return;
        Vector3 pointFinal = new Vector3(transform.position.x, flyHeight, 0);
        transform.position = Vector3.MoveTowards(transform.position, pointFinal, speedFlyCam * Time.deltaTime);
        if (pointFinal.y - transform.position.y <= 0)
        {
            if (!isFlyCam)
            {
                Camera.main.GetComponent<PlaneController>().RemoveAllPlane();
                Camera.main.GetComponent<TerrainController>().SetTempleScene();
                Modules.PlayAudioClipLoop(Modules.audioTempleRun, Camera.main.transform);
                numberLaneNew = 0;
                numberLaneOld = 0;
                transform.position = new Vector3(0, transform.position.y, 0);
                oldPointBefore = transform.position;
                Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, Camera.main.transform.position.z);
                Camera.main.GetComponent<CameraController>().ResetDeltaPoint();
                Camera.main.GetComponent<CameraController>().timeFollow = 0.1f;
                isFlyCam = true;
            }
            runTimeFlyCam += Time.deltaTime;
            if (runTimeFlyCam >= timeFlyCam)
                SetFallFly();
        }
        else
        {
            if (transform.position.y < flyHeight)
            {
                float angleX = Camera.main.transform.rotation.x - Time.deltaTime / 2f;
                Camera.main.transform.rotation = new Quaternion(angleX, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
            }
        }
    }

    void SetFallFly()
    {
        //thuc hien roi xuong
        RemoveSpeedSlow();
        checkFalling = true;
        isFlyCam = false;
        mesFlyCam = false;
        SetRigibodyNormal();
        //AddForceHero();
    }

    void FlyCam()
    {
        checkFalling = false;
        Camera.main.GetComponent<CameraController>().ResetTimeFollow();
        speedFlyCam =  /*Modules.speedGame * */numSpeedAct * speedFly;
        myRigid.isKinematic = true;
        myRigid.useGravity = false;
        myRigid.interpolation = RigidbodyInterpolation.None;
        mesFlyCam = true;
        Camera.main.GetComponent<ChangeHeightFog>().enabled = true;
        runTimeFlyCam = 0;
        Modules.underBridge = false;
    }

    void ResetStatus()
    {
        mesStartMove = false;
        doneMoveLeftRight = true;
        mesStartJump = false;
        doneJumpHero = true;
        mesStartBack = false;
        doneBackHero = true;
    }

    void SetLaneFollowItem(float pointItems)
    {
        int laneItem = 0;
        if (Mathf.RoundToInt(pointItems) < -1) laneItem = -1;
        else if (Mathf.RoundToInt(pointItems) > 1) laneItem = 1;
        numberLaneNew = laneItem;
        numberLaneOld = numberLaneNew;
        transform.position = new Vector3(numberLaneNew * moveLeftRight, transform.position.y, 0);
        oldPointBefore = transform.position;
    }

    void SetRigibodyNormal()
    {
        myRigid.isKinematic = false;
        myRigid.useGravity = true;
        myRigid.interpolation = RigidbodyInterpolation.Interpolate;
    }

    public void PlaySneakerLeft()
    {
        Modules.PlayAudioClipFree(Modules.audioSneakerLeft);
    }

    public void PlaySneakerRight()
    {
        Modules.PlayAudioClipFree(Modules.audioSneakerRight);
    }

    public bool IsFinishJump()
    {
        if (doneJumpHero && !checkFalling)
            return true;
        else return false;
    }
}

public enum StatusHero
{
    idle,
    run,
    jump,
    down,
    left,
    right,
    fall,
    fallA,
    fallB,
    fallC
}

public enum TypeCollider
{
    top,
    bottom,
    right,
    left,
    front,
    slower
}

public enum TypeAniRun
{
    none,
    idleMenu,
    runNormal,
    runMagnet,
    runSkis,
    runSkisMagnet,
    runRocket,
    runRocketMagnet,
    runCable,
    runCableMagnet,
    runJetBall,
    runJetBallMagnet,
    runJumper,
    runBonus,
    jumpNormal,
    jumpPower,
    jumpMagnet,
    jumpMagnetPower,
    jumpSkis,
    jumpSkisPower,
    jumpSkisMagnet,
    jumpSkisMagnetPower,
    fallNormal,
    fallMagnet,
    fallSkis,
    fallSkisMagnet,
    fallRocket,
    fallCable,
    fallJetBall,
    fallJumper,
    moveNormalLeft,
    moveMagnetLeft,
    moveSkisLeft,
    moveSkisMagnetLeft,
    moveRocketLeft,
    moveRocketMagnetLeft,
    moveCableLeft,
    moveCableMagnetLeft,
    moveJetBallLeft,
    moveJetBallMagnetLeft,
    moveNormalRight,
    moveMagnetRight,
    moveSkisRight,
    moveSkisMagnetRight,
    moveRocketRight,
    moveRocketMagnetRight,
    moveCableRight,
    moveCableMagnetRight,
    moveJetBallRight,
    moveJetBallMagnetRight,
    downNormal,
    downMagnet,
    downSkis,
    downSkisMagnet,
    callSkis,
    balloonUp,
    balloonDown,
    balloonDriver,
    seeSideLeft,
    seeSideRight,
    wallLeftSkis,
    wallRightSkis,
    wallLeftSkisMagnet,
    wallRightSkisMagnet,
    dieFront,
    dieBack,
    dieBackScene,
    dieCatch,
    flyCamUp,
    flyCamDown,
    flyCamSway,
    stumble,
    takeBag
}