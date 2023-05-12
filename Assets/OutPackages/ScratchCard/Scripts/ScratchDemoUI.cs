using UnityEngine;
using UnityEngine.UI;

public class ScratchDemoUI : MonoBehaviour
{
	public ScratchCardManager CardManager;
	public Texture[] Brushes;
	//public Toggle[] BrushToggles;
	//public Toggle ProgressToggle;
	public Text ProgressText;
	public EraseProgress EraseProgress;

	void Start()
	{
        //ProgressToggle.isOn = PlayerPrefs.GetInt("Toggle", 0) == 0;
		EraseProgress.OnProgress += OnEraseProgress;

        //for (var i = 0; i < BrushToggles.Length; i++)
        //{
        //    BrushToggles[i].onValueChanged.AddListener(OnChange);
        //}
        //BrushToggles[PlayerPrefs.GetInt("Brush")].isOn = true;
	}

    //public void OnChange(bool val)
    //{
    //    for (var i = 0; i < BrushToggles.Length; i++)
    //    {
    //        if (BrushToggles[i].isOn)
    //        {
    //            CardManager.SetEraseTexture(Brushes[i]);
    //            PlayerPrefs.SetInt("Brush", i);
    //            break;
    //        }
    //    }
    //}

    //public void OnCheck(bool check)
    //{
    //    EraseProgress.gameObject.SetActive(ProgressToggle.isOn);
    //    PlayerPrefs.SetInt("Toggle", ProgressToggle.isOn ? 0 : 1);
    //}

	public void Restart()
	{
        EraseProgress.ResetScratch();
	}

    public void OnEraseProgress(float progress)
    {
        float pro = Mathf.Round(progress * 100f);
        //ProgressText.text = AllLanguages.otherProgressCard[Modules.indexLanguage] + ": " + pro.ToString() + "%";
        if (pro > 80) transform.GetComponent<PageScratchCard>().HandleBonus();
    }
}