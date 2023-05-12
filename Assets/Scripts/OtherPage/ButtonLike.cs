using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLike : MonoBehaviour {

    public string idLike = "";
    public Text textLike;
    private string status = "add";

    public void SetValue(string newValue)
    {
        textLike.text = newValue;
    }

    public void ClickLike()
    {
        if (idLike == "") return;
        if (Modules.listIDLike.Contains(idLike))//neu da like roi
        {
            int numLike = Modules.IntParseFast(textLike.text.ToString());
            if (numLike <= 0) return;
            Modules.listIDLike.Remove(idLike);
            Modules.SaveListIDLike();
            textLike.text = (numLike - 1).ToString();
            status = "rem";
        }
        else
        {
            Modules.listIDLike.Add(idLike);
            if (Modules.listIDLike.Count > 100)
                Modules.listIDLike.RemoveAt(0);
            Modules.SaveListIDLike();
            textLike.text = (Modules.IntParseFast(textLike.text.ToString()) + 1).ToString();
            status = "add";
        }
        StartCoroutine(PostLike());
    }

    IEnumerator PostLike()
    {
        WWWForm form = new WWWForm();
        form.AddField("table", "useBusSubway");
        form.AddField("id", idLike);
        form.AddField("like", status);
        WWW _resuilt = new WWW(Modules.linkLike, form);
        float runTime = 0f;
        while (!_resuilt.isDone && runTime < Modules.maxTime)
        {
            runTime += Modules.requestTime;
            yield return new WaitForSeconds(Modules.requestTime);
        }
        yield return _resuilt;
        if (_resuilt.text == "Done")
        { //hoan thanh
        }
        else
        { //qua lau, khong mang, cau lenh loi
        }
        yield break;
    }
}
