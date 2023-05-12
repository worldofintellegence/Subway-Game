using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInformation : MonoBehaviour {

    public TypeItems typeItem = TypeItems.coin;
    [Range(0, 100)]
    public int percentShow = 100;//phan tram ty le xuat hien
    public float speedMove = 0;
    public List<GameObject> objectOther;//doi tuong thay the neu doi tuong goc khong xuat hien
    public List<GameObject> objectMore;//doi tuong duoc goi them neu doi tuong goc xuat hien
    //public GameObject effectDestroy;
    public GameObject pointFllow;//chi danh cho next gate
    public GameObject meshShow;
    public float speedRotate = 50f;
    public bool heightItem = false;//neu la true thi se check hien thi khi su dung jumper, rocket, cable
    public AudioClip audioPlay;
    private bool playedAudio = false;
    //danh cho challenge
    [HideInInspector]
    public string valueText = "";
    [HideInInspector]
    public int indexText = -1;
    private bool checkShowItems = false;
    private bool startNow = false;

    public void ResetItem()
    {
        playedAudio = false;
        startNow = false;
        transform.eulerAngles = Vector3.zero;
        if (meshShow) meshShow.transform.eulerAngles = Vector3.zero;
    }

    public void CallStart()
    {
        if (Modules.useTakeBag && typeItem != TypeItems.endBag) { gameObject.SetActive(false); return; }
        if (Modules.gameGuide == "YES" && typeItem != TypeItems.trap && typeItem != TypeItems.playAudio) { gameObject.SetActive(false); return; }
        if (Modules.statusGame != StatusGame.play && typeItem != TypeItems.playAudio)
        {
            if (Modules.statusGame == StatusGame.flyScene || Modules.statusGame == StatusGame.menu || Modules.statusGame == StatusGame.start)
            {
                if (transform.position.z <= Modules.rangeTakeOff + Mathf.Abs(speedMove) * 100)
                { gameObject.SetActive(false); return; }
            }
            else if (Modules.statusGame == StatusGame.bonusEffect)
            {
                if (!Modules.useBonus)
                {
                    if (transform.position.z <= Modules.rangeTakeOff + Mathf.Abs(speedMove) * 100)
                    { gameObject.SetActive(false); return; }
                }
            }
            else { gameObject.SetActive(false); return; }
        }
        if ((Modules.useRocket || Modules.useCable || Modules.useJetBall) && !heightItem && typeItem != TypeItems.trap && typeItem != TypeItems.endBag) { gameObject.SetActive(false); return; }
        if (typeItem == TypeItems.missions && Modules.dataMissionsUse == "") { gameObject.SetActive(false); return; }
        else if (typeItem == TypeItems.challenge && Modules.dataChallengeUse == "") { gameObject.SetActive(false); return; }
        int ran = Random.Range(0, 100);
        if (ran >= percentShow)
        {
            CallStartObject(objectOther);
            gameObject.SetActive(false); return;
        }
        else
        {
            CallStartObject(objectMore);
        }
        if (typeItem == TypeItems.coin || heightItem)//neu la coin hoac item tren cao
        {
            foreach (Transform tran in transform) tran.gameObject.SetActive(false);
            //GetComponent<BoxCollider>().enabled = false;
            checkShowItems = true;
        }
        //xu ly missions va challenge
        if (typeItem == TypeItems.missions)//neu la missions
        {
            if (meshShow) Destroy(meshShow);
            meshShow = Instantiate(Modules.listMissions[Modules.indexItemMissions].model, transform) as GameObject;
            meshShow.transform.localPosition = Vector3.zero;
        }
        else if (typeItem == TypeItems.challenge)//neu la challenge
        {
            valueText = Modules.listTextRequire[Modules.listTextColect.Count];
            indexText = Modules.listTextColect.Count;
            GameObject textModel = null;
            for (int i = 0; i < Modules.listChallenge.Count; i++)
            {
                if (Modules.listChallenge[i].value == valueText)
                {
                    textModel = Modules.listChallenge[i].model;
                    break;
                }
            }
            if (textModel != null)
            {
                if (meshShow) Destroy(meshShow);
                meshShow = Instantiate(textModel, transform) as GameObject;
                meshShow.transform.localPosition = Vector3.zero;
            }
            else gameObject.SetActive(false);
        }
        else if (typeItem == TypeItems.chestTemple)//neu la chest temple run
        {
            transform.GetComponent<OpenChestTemple>().ResetChest();
        }
        startNow = true;
        playedAudio = false;
    }

    void CallStartObject(List<GameObject> listObject)
    {
        if (listObject == null) return;
        if (listObject.Count < 1) return;
        foreach (GameObject go in listObject)
        {
            if (go != null)
            {
                go.SetActive(true);
                if (go.GetComponent<BarrierController>()) go.GetComponent<BarrierController>().CallStart();
                else if (go.GetComponent<ItemInformation>()) go.GetComponent<ItemInformation>().CallStart();
                else//neu khong thi la list coin
                {
                    foreach (Transform tran in go.transform)
                    {
                        tran.gameObject.SetActive(true);
                        tran.GetComponent<ItemInformation>().CallStart();
                    }
                }
            }
        }
    }

    void Update()
    {
        if (!startNow) return;
        if (meshShow != null && meshShow.activeSelf && typeItem != TypeItems.challenge)
            meshShow.transform.Rotate(0, speedRotate * Time.deltaTime, 0);
        if (Modules.statusGame == StatusGame.play)
        {
            if (speedMove != 0)
            {
                float point = transform.position.z;
                if (point <= Modules.rangeRunObj)//move object
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speedMove * Modules.speedGame * 50 * Time.deltaTime);
            }
            if (transform.position.z <= Modules.rangeShowCoin && transform.position.x < 50 && transform.position.x > -50)
            {
                if (!playedAudio)
                {
                    playedAudio = true;
                    Modules.PlayAudioClipFree(audioPlay);
                }
            }
            if (transform.position.z <= -Modules.rangeHireBack)
            {
                if (typeItem == TypeItems.boomTNT)
                {
                    TaskData.HandleTask(37, 1, 10);
                    TaskData.HandleTask(40, 1, 30);
                    TaskData.HandleTask(97, 1, 200);
                }
                gameObject.SetActive(false);
                return;
            }
        }
        if (typeItem == TypeItems.coin || heightItem) UpdateShowItems();
    }

    void UpdateShowItems()
    {
        if (!startNow || !checkShowItems) return;
        if (heightItem)
        {
            if (!Modules.useJumper && !Modules.useRocket && !Modules.useCable && !Modules.useJetBall)
                return;
        }
        else
        {
            if (Modules.useRocket || Modules.useCable || Modules.useJetBall)
                return;
        }
        if (transform.position.z > Modules.rangeShowCoin || Mathf.Abs(transform.position.x) > Modules.rangeShowCoin
            || transform.position.z <= Modules.mainCharacter.transform.position.z) return;
        if (Modules.reducedEffect < 2 && Modules.statusGame == StatusGame.play)
            Modules.poolOthers.GetComponent<HighItemsController>().PlayEffectCoin(transform.gameObject);
        foreach (Transform tran in transform) tran.gameObject.SetActive(true);
        //GetComponent<BoxCollider>().enabled = true;
        checkShowItems = false;
    }
}
public enum TypeItems
{
    coin,
    key,
    sneaker,
    magnet,
    jetpack,
    trampoline,
    xpoint,
    hoverboard,
    scoreBooster,
    headStart,
    mysteryBox,
    hoverbike,
    balloon,
    missions,
    challenge,
    nextGate,
    roadBonus,
    boxBonus,
    startTunner,
    endTunner,
    jetball,
    doubleCoin,
    boomTNT,
    trap,
    spinWheel,
    chestTemple,
    waterRamp,
    playAudio,
    blueArrow,
    secretBox,
    startBridge,
    endBridge,
    endBag
}