using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatUnlock : MonoBehaviour {

    public string codeValue = "000";
    public TypeShop typeShop = TypeShop.hero;
    public List<GameObject> listMatGay = new List<GameObject>();
    public List<Material> listMatColor = new List<Material>();

    void Start()
    {
        CheckNow();
    }

	public void CheckNow () {
        bool checkChange = false;
        if (typeShop == TypeShop.hero)
        {
            if (Modules.listHeroUnlock.Contains(codeValue))
                checkChange = true;
        }
        else
        {
            if (Modules.listSkisUnlock.Contains(codeValue))
                checkChange = true;
        }
        if (checkChange)
        {
            if (listMatGay[0].GetComponent<Renderer>().material != listMatColor[0])
                for (int i = 0; i < listMatGay.Count; i++)
                    listMatGay[i].GetComponent<Renderer>().material = listMatColor[i];
        }
	}
}
public enum TypeShop
{
    hero,
    skis
}