using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagAddHero : MonoBehaviour {

    public List<Material> listMater = new List<Material>();
    public void RandomMaterial()
    {
        transform.GetComponent<MeshRenderer>().material = listMater[Random.Range(0, listMater.Count)];
    }
}
