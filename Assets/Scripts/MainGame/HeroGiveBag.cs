using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGiveBag : MonoBehaviour {

    public string idHero = "001";//ma nhan biet loai nhan vat
    public GameObject bagObject;
    public float speedRunStart = 7, speedRunEnd = 10;
    public float distanceMax = 1.5f;
    public float farToDeactive = -7;
    private float speedNow;
    private bool startGive = false;
    private bool runForward = true;
    private BagController bagController;

    public void CallStart(GameObject bagControll)
    {
        if (bagController == null) bagController = bagControll.GetComponent<BagController>();
        bagObject.SetActive(true);
        bagObject.GetComponent<BagAddHero>().RandomMaterial();
        speedNow = speedRunStart;
        runForward = true;
        startGive = true;
    }

    void Update()
    {
        if (!startGive) return;
        Vector3 pointFollow = Modules.mainCharacter.transform.position;
        if (runForward)//dang chay tien len
        {
            if (bagController.CheckUseSpecialItem())
            {
                speedNow = speedRunEnd;
                runForward = false;
                bagController.SetBackCooldown();
                return;
            }
            if (Vector3.Distance(transform.position, Modules.mainCharacter.transform.position) <= distanceMax)//chay toi nhan vat chinh
            {
                bagObject.SetActive(false);
                Modules.mainCharacter.GetComponent<HeroController>().SetTakeBag(bagObject.GetComponent<MeshRenderer>().material);
                speedNow = speedRunEnd;
                runForward = false;
            }
        }
        else
        {
            pointFollow = new Vector3(0, 0, farToDeactive);
            if (transform.position.z <= farToDeactive + 1)
            {
                //startGive = false;
                //transform.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, pointFollow, speedNow * Time.deltaTime);
    }
}
