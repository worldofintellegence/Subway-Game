using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour {

	public string nameSceneLoad = "MainGame";
    public GameObject poolTerrains;
    public GameObject poolOthers;
    public Image imgProgress;
    public Color colorStart, colorEnd;
    public GameObject effectPanel;
    public Text typeStateLoad;

    public void CallStart()
    {
        Modules.poolTerrains = poolTerrains;
        Modules.poolOthers = poolOthers;
        Invoke("CallRun", 1);
    }

    void CallRun()
    {
        Modules.poolTerrains.GetComponent<CreatePoolTerrains>().StartLoading();
        Invoke("CheckProgress", 0.02f);
    }

    void CheckProgress()
    {
        imgProgress.fillAmount = Modules.poolTerrains.GetComponent<CreatePoolTerrains>().GetPercent();
        imgProgress.color = Color.Lerp(colorStart, colorEnd, imgProgress.fillAmount);
        int indexLoad = Modules.poolTerrains.GetComponent<CreatePoolTerrains>().GetIndexLoad();
        if (indexLoad == 0)
            typeStateLoad.text = "Downloading (" + Mathf.RoundToInt(imgProgress.fillAmount * 100) + "%)";
        else
            typeStateLoad.text = "Installing (" + Mathf.RoundToInt(imgProgress.fillAmount * 100) + "%)";
        if (imgProgress.fillAmount >= 1)
        {
            if (indexLoad <= 0)
            {
                imgProgress.fillAmount = 0;
                Modules.poolTerrains.GetComponent<CreatePoolTerrains>().CallStart();
                Invoke("CheckProgress", 0.02f);
            }
            else
            {
                imgProgress.color = new Color(0, 0, 0, 0);
                effectPanel.SetActive(true);
                effectPanel.GetComponent<RunEffectPanel>().CallClose();
                Invoke("NextScene", 1.2f);
            }
        }
        else Invoke("CheckProgress", 0.02f);
    }

    void NextScene()
    {
        CancelInvoke();
        SceneManager.LoadSceneAsync(nameSceneLoad, LoadSceneMode.Single);
    }
}