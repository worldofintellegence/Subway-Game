using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    public float speedDrop = 5f;
    public float speedGrow = 1f;
    public Animator myAni, aniFloat;
    public bool exploNow = false;
    public GameObject effectDestroy;
    public GameObject effectFloat;
    private bool mesDrop = false;

    public void SetTrapDrop(Vector3 pointStart, GameObject containTrap)
    {
        transform.parent = containTrap.transform;
        if (aniFloat != null)
            aniFloat.SetTrigger("TriIdle");
        if (effectFloat != null)
            effectFloat.SetActive(false);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        transform.position = pointStart;
        transform.eulerAngles = Vector3.zero;
        mesDrop = true;
    }

    public void SetTrapPlay(GameObject boneTrap)
    {
        if (exploNow)
        {
            int numDeduction = Random.Range(10, 30);
            Modules.ExploTrapBoom(numDeduction);
            Instantiate(effectDestroy, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        else
        {
            transform.SetParent(boneTrap.transform, true);
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            transform.localPosition = Vector3.zero;
            Modules.PlayAudioClipFree(Modules.audioTrapClose);
            if (myAni != null) myAni.SetTrigger("TriPlay");
        }
    }

    void Update()
    {
        if (mesDrop)
        {
            RaycastHit hit;
            float speed = speedDrop * Time.deltaTime;
            float grow = speedGrow * Time.deltaTime;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, speed))
            {
                if (hit.collider.gameObject.GetComponent<BoxCollider>().isTrigger != true)
                {
                    if (hit.collider.tag == "WaterSurface")
                    {
                        if (aniFloat != null)
                            aniFloat.SetTrigger("TriPlay");
                        if (effectFloat != null)
                        {
                            effectFloat.SetActive(true);
                            effectFloat.GetComponent<ParticleSystem>().Stop();
                            effectFloat.GetComponent<ParticleSystem>().Play();
                        }
                    }
                    transform.SetParent(hit.collider.transform.parent, true);
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    transform.position = new Vector3(hit.point.x, hit.point.y - 0.3f, hit.point.z);
                    transform.GetComponent<ItemInformation>().CallStart();
                    mesDrop = false;
                }
                else
                {
                    HandleDrop(speed, grow);
                }
            }
            else
            {
                HandleDrop(speed, grow);
            }
        }
    }

    void HandleDrop(float speedNew, float growNew)
    {
        float scale = transform.localScale.x + growNew;
        if (scale > 1) scale = 1;
        transform.localScale = new Vector3(scale, scale, scale);
        transform.localPosition = new Vector3(transform.position.x, transform.position.y - speedNew, transform.position.z);
        if (transform.localPosition.y < -50f) transform.gameObject.SetActive(false);
    }
}
