using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrierController : MonoBehaviour {

    public float lengthBarrier = 0;//chieu dai cua vat can
    [Range(0, 100)]
    public int percentShow = 100;//phan tram ty le xuat hien
    public float speedMove = 0;
    public List<GameObject> objectOther;//doi tuong thay the neu doi tuong goc khong xuat hien
    public List<GameObject> objectMore;//doi tuong duoc goi them neu doi tuong goc xuat hien
    public float farMoreHide = 0;//danh cho doi tuong nao noi them phia sau dai ra (vi du noi them duoi coins)
    //xu ly hieu ung den va coi car and train
    public GameObject listLights;
    public AudioClip audioHorn;
    [Range(0, 100)]
    public int percentPlay = 100;
    private float distancePlay = 40;
    private bool statusPlay = false;
    //private float numEdit = 1.5f;
    private bool startNow = false;
    //xu ly random materials
    public List<GameObject> listMaterials = new List<GameObject>();

    public void ResetBarrier()
    {
        startNow = false;
    }

    public void CallStart()
    {
        if (Modules.useTakeBag) { gameObject.SetActive(false); return; }
        if (Modules.gameGuide == "YES") { gameObject.SetActive(false); return; }
        if (Modules.statusGame != StatusGame.play)
        {
            if (Modules.statusGame == StatusGame.flyScene || Modules.statusGame == StatusGame.menu || Modules.statusGame == StatusGame.start)
            {
                if (transform.position.z - lengthBarrier / 2f <= Modules.rangeTakeOff + Mathf.Abs(speedMove) * 100)
                { gameObject.SetActive(false); return; }
            }
            else if (Modules.statusGame == StatusGame.bonusEffect)
            {
                if (!Modules.useBonus)
                {
                    if (transform.position.z - lengthBarrier / 2f <= Modules.rangeTakeOff + Mathf.Abs(speedMove) * 100)
                    { gameObject.SetActive(false); return; }
                }
            }
            else { gameObject.SetActive(false); return; }
        }
        if ((Modules.useRocket || Modules.useCable || Modules.useJetBall) && lengthBarrier <= 3) { gameObject.SetActive(false); return; }
        //int percentNew = Mathf.RoundToInt((Modules.speedGame / Modules.maxSpeedMove * numEdit) * percentShow);
        int ran = Random.Range(0, 100);
        if (ran >= percentShow /*percentNew*/)
        {
            CallStartObject(objectOther);
            gameObject.SetActive(false); return;
        }
        else
        {
            CallStartObject(objectMore);
        }
        if (listLights != null) listLights.SetActive(false);
        statusPlay = false;
        startNow = true;
        //xu ly doi materials
        if (listMaterials != null && listMaterials.Count > 0)
        {
            int indexMat = Random.Range(0, Modules.listMaterTrain.Count);
            for (int i = 0; i < listMaterials.Count; i++)
            {
                listMaterials[i].GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(Modules.listMaterTrain[indexMat]);
            }
        }
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
        if (!startNow || Modules.statusGame != StatusGame.play)
        {
            if (Modules.statusGame == StatusGame.over)//xu ly xoa vat can chan truoc nhan vat khi chet
            {
                if (Modules.mainCharacter != null)
                {
                    if ((transform.position.z + lengthBarrier / 2f + farMoreHide) < 0)//neu o dang sau
                    {
                        if (Mathf.Abs(Modules.mainCharacter.transform.position.x - transform.position.x) < 1.5f)//neu cung lane
                        {
                            gameObject.SetActive(false);
                            return;
                        }
                    }
                }
            }
            return;
        }
        float point = transform.position.z - lengthBarrier / 2f;
        if (point <= Modules.rangeRunObj)//move object
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speedMove * Modules.speedGameNow * 50 * Time.deltaTime);
        if (point <= -lengthBarrier - Modules.rangeHireBack - farMoreHide)
        {
            if (gameObject.tag == "Barrier")
            {
                TaskData.HandleTask(14, 1, 20);
                TaskData.HandleTask(63, 1, 80);
                TaskData.HandleTask(133, 1, 80);
                TaskData.HandleTask(149, 1, 100);
            }
            else if (gameObject.tag == "MonoTrain" || gameObject.tag == "GroundTrain")
            {
                TaskData.HandleTask(115, 1, 4000);
            }
            gameObject.SetActive(false);
            return;
        }
        //xu ly light horn
        if (!statusPlay && transform.position.z - lengthBarrier / 2f <= distancePlay)
        {
            statusPlay = true;
            if (Mathf.Abs(Modules.mainCharacter.transform.position.y - transform.position.y) < 7 &&//neu khong bay qua cao hoac qua thap
                Mathf.Abs(Modules.mainCharacter.transform.position.x - transform.position.x) < 5)//neu khong cach trai/phai qua xa
            {
                int ran = Random.Range(0, 100);
                if (ran < percentPlay)
                {
                    if (audioHorn != null) Modules.PlayAudioClipFree(audioHorn);
                    if (listLights != null) listLights.SetActive(true);
                }
            }
        }
    }
}
