using UnityEngine;
using System.Collections;

public class MoveToMagnet : MonoBehaviour {

    public GameObject myMagnet;
    public float speedMove = 10f;
    public float radiusEnd = 0.1f;
    private Transform oldParent;

    void Start()
    {
        oldParent = transform.parent;
        transform.parent = null;
        if (transform.GetComponent<Collider>() != null)
            transform.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        if (myMagnet == null || Modules.statusGame == StatusGame.over) DestroyMe();
        else if (Vector3.Distance(transform.position, myMagnet.transform.position) > radiusEnd)
        {
            transform.LookAt(myMagnet.transform);
            transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
        }
        else
        {
            //neu bay toi noi
            Modules.poolOthers.GetComponent<HighItemsController>().PlayEffectEatCoins(transform.position);
            int xNum = 1;
            if (Modules.useDouble) xNum = 2;
            xNum *= Modules.buyDoubleCoins * Modules.xDiamondSecretBox;
            Modules.coinPlayer += xNum;
            Modules.textCoinPlay.text = Modules.coinPlayer.ToString();
            TaskData.HandleTask(0, xNum, 100);
            TaskData.HandleTask(12, xNum, 200);
            TaskData.HandleTask(18, xNum, 1000);
            TaskData.HandleTask(28, xNum, 50);
            TaskData.HandleTask(41, xNum, 200);
            TaskData.HandleTask(45, xNum, 400);
            TaskData.HandleTask(62, xNum, 250);
            TaskData.HandleTask(70, xNum, 15000);
            TaskData.HandleTask(106, xNum, 4000);
            TaskData.HandleTask(117, xNum, 6000);
            TaskData.HandleTask(132, xNum, 240);
            if (Modules.useRocket)
                TaskData.HandleTask(10, xNum, 100);
            if (Modules.useBoat)
            {
                TaskData.HandleTask(104, xNum, 20000);
                TaskData.HandleTask(113, xNum, 500);
                TaskData.HandleTask(120, xNum, 1000);
            }
            TaskData.countScoreNoDiamond = 0;
            DestroyMe();
        }
    }

    void DestroyMe()
    {
        transform.parent = oldParent;
        if (transform.GetComponent<MoveToMagnet>() != null)
            Destroy(transform.GetComponent<MoveToMagnet>());
        if (transform.GetComponent<Collider>() != null)
            transform.GetComponent<Collider>().enabled = true;
        ItemInformation item = transform.GetComponent<ItemInformation>();
        item.ResetItem();
        item.gameObject.SetActive(false);
    }
}
