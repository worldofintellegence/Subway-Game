using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour {

    public float timeCool = 60;
    private float timeCoolNow = 60;
    public float timeTake = 15;
    public Vector2 timePlay = new Vector2(100, 200);
    private float timePlayNow = 30;
    public float timeEnd = 10;
    public Image coolImg;
    public GameObject endBag;
    public List<GameObject> listHeroGiveBag = new List<GameObject>();
    public Text textLeftKm;
    private StateBag stateBag;
    private float runCool = 0, runTake = 0, runPlay = 0, runEnd = 0, runBag = 0, runKm = 0;
    //xu ly lock khi khong the chay cooldown
    public GameObject iconBag, iconLock;
    private bool lockCool = false;

    private void OnEnable()
    {
        ResetBag();
    }

    public void ResetBag()
    {
        timeCoolNow = timeCool;
        timePlayNow = Random.Range(timePlay.x, timePlay.y);
        runCool = 0;
        runBag = 0;
        stateBag = StateBag.cooldown;
        textLeftKm.transform.parent.gameObject.SetActive(false);
        Modules.useTakeBag = false;
        lockCool = false;
        iconBag.SetActive(true);
        iconLock.SetActive(false);
    }

    public void SetCooldown(float timeCoolNew, float timePlayNew)
    {
        ResetBag();
        timeCoolNow = timeCoolNew;
        timePlayNow = timePlayNew;
    }

    public bool CheckUseSpecialItem()
    {
        return (Modules.useJumper || Modules.useRocket || Modules.useCable || Modules.useJetBall || Modules.useBoat || Modules.statusGame == StatusGame.over);
    }

    public void SetBackCooldown()
    {
        runCool -= 7;
        runBag -= 7;
        stateBag = StateBag.cooldown;
        Modules.useTakeBag = false;
    }

    void Update()
    {
        if (Modules.gameGuide == "YES" || Modules.statusGame != StatusGame.play)
        {
            if (!lockCool)
            {
                lockCool = true;
                iconBag.SetActive(false);
                iconLock.SetActive(true);
            }
            return;
        }
        if (stateBag == StateBag.cooldown)
        {
            float timeStep = Time.deltaTime;
            //kiem tra xem co o bien hay khong
            if (CheckUseSpecialItem()) timeStep = 0;
            runCool += timeStep;
            float timeNow = timeCoolNow / Modules.speedGameNow;
            if (runCool >= timeNow && timeStep > 0)
            {
                runCool = timeNow;
                runTake = 0;
                stateBag = StateBag.takeBag;
                //Modules.useTakeBag = true;
                print("finish cooldown");
            }
        }
        else if (stateBag == StateBag.takeBag)
        {
            runTake += Time.deltaTime;
            float timeNow = timeTake / Modules.speedGameNow;
            if (runTake >= timeNow)
            {
                //kiem tra neu dang su dung cac item dac biet thi quay ve trang thai cooldown
                if (CheckUseSpecialItem())
                {
                    SetBackCooldown();
                    return;
                }
                runTake = timeNow;
                runPlay = 0;
                runKm = 0;
                stateBag = StateBag.runPlay;
                Modules.useTakeBag = false;
                textLeftKm.transform.parent.gameObject.SetActive(true);
                coolImg.fillAmount = 1;
                //xu ly nhan vat giao va nhan bag tu luc nay
                print("effect give bag");
                int indexHeroGive = 0;
                bool check = true;
                while (check)
                {
                    indexHeroGive = Random.Range(0, listHeroGiveBag.Count);
                    if (listHeroGiveBag[indexHeroGive].GetComponent<HeroGiveBag>().idHero != Modules.codeHeroUse)
                        check = false;
                }
                GameObject heroGiveBag = Instantiate(listHeroGiveBag[indexHeroGive], Modules.containMainGame.transform);
                heroGiveBag.transform.position = new Vector3(Modules.mainCharacter.transform.position.x, Modules.mainCharacter.transform.position.y, Modules.mainCharacter.transform.position.z - 10f);
                heroGiveBag.GetComponent<HeroGiveBag>().CallStart(gameObject);
                //Modules.lockControll = true;
                Modules.distanceEnemy = 2;
                //xu ly hieu ung
                foreach (Transform tran in Modules.parentTextEffect.transform) Destroy(tran.gameObject);
                GameObject effect = Instantiate(Modules.textDelivery[Modules.indexLanguage], Modules.parentTextEffect.transform);
                effect.GetComponent<DestroyParticle>().hideObjects = Modules.parentShowHide;
            }
        }
        else if (stateBag == StateBag.runPlay)
        {
            runPlay += Time.deltaTime;
            float timeNow = timePlayNow / Modules.speedGameNow;
            if (runPlay >= timeNow)
            {
                runPlay = timeNow;
                runEnd = 0;
                stateBag = StateBag.endBag;
                Modules.useTakeBag = true;
                print("finish delivery");
            }
        }
        else if (stateBag == StateBag.endBag)
        {
            runEnd += Time.deltaTime;
            float timeNow = timeEnd / Modules.speedGameNow;
            if (runEnd >= timeNow)
            {
                runEnd = timeNow;
                runCool = 0;
                runBag = 0;
                stateBag = StateBag.nothing;
                Modules.useTakeBag = false;
                textLeftKm.transform.parent.gameObject.SetActive(false);
                //xu ly dat dich cuoi cua bag
                RaycastHit hit;
                float pointEnd = 100;
                if (Physics.Raycast(new Vector3(0, -100, pointEnd), Vector3.up, out hit))
                {
                    GameObject endTarget = Instantiate(endBag, Vector3.zero, Quaternion.identity);
                    endTarget.transform.position = new Vector3(0, 0, pointEnd);
                    endTarget.transform.SetParent(hit.transform.parent.transform);
                    endTarget.GetComponent<ItemInformation>().CallStart();
                    print("effect end bag");
                }
            }
        }
        if (stateBag == StateBag.cooldown || stateBag == StateBag.takeBag)
        {
            float timeStep = Time.deltaTime;
            //kiem tra xem co o bien hay khong
            if (CheckUseSpecialItem())
            {
                timeStep = 0;
                if (!lockCool)
                {
                    lockCool = true;
                    iconBag.SetActive(false);
                    iconLock.SetActive(true);
                }
            }
            else
            {
                if (lockCool)
                {
                    lockCool = false;
                    iconBag.SetActive(true);
                    iconLock.SetActive(false);
                }
            }
            runBag += timeStep;
            float timeBag = (timeCoolNow + timeTake) / Modules.speedGameNow;
            coolImg.fillAmount = runBag / timeBag;
        }
        if (stateBag == StateBag.runPlay || stateBag == StateBag.endBag)
        {
            if (lockCool)
            {
                lockCool = false;
                iconBag.SetActive(true);
                iconLock.SetActive(false);
            }
            //xu ly km con lai
            runKm += Time.deltaTime;
            float timeKm = (timePlayNow + timeEnd) / Modules.speedGameNow;
            float kmLeft = (timeKm - runKm) / 10;
            textLeftKm.text = kmLeft.ToString("F1") + " Km";
        }
    }
}
public enum StateBag
{
    nothing,
    cooldown,
    takeBag,
    runPlay,
    endBag
}
