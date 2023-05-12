using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckUseSkis : MonoBehaviour {

    public GameObject boneControllSkis;
    public GameObject meshShowSkis;
    void FixedUpdate()
    {
        //if (Modules.statusGame != StatusGame.play) return;
        string codeNow = Modules.codeSkisUse;
        if (Modules.codeSkisTrying != "") codeNow = Modules.codeSkisTrying;
        if ((boneControllSkis != null && boneControllSkis.transform.childCount > 0) || Modules.totalSkis <= 0 || Modules.useRocket || Modules.listIDSkisHover.Contains(codeNow))
        {
            if (meshShowSkis.activeSelf)
                meshShowSkis.SetActive(false);
        }
        else
        {
            if (!meshShowSkis.activeSelf)
                meshShowSkis.SetActive(true);
        }
    }
}
