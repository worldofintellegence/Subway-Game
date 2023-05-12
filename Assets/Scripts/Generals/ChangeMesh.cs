using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour {

    public List<GameObject> listMesh = new List<GameObject>();
    public Vector2 timeChange = new Vector2(1, 3);
    private int indexNow = 0;

    void Start()
    {
        Invoke("ChangeMeshNow", Random.Range(timeChange.x, timeChange.y));
    }

    void ChangeMeshNow()
    {
        for (int i = 0; i < listMesh.Count; i++) listMesh[i].gameObject.SetActive(false);
        indexNow++;
        if (indexNow >= listMesh.Count) indexNow = 0;
        listMesh[indexNow].SetActive(true);
        Invoke("ChangeMeshNow", Random.Range(timeChange.x, timeChange.y));
    }
}
