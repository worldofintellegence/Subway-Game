using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonDownItem : MonoBehaviour {

    public GameObject listItems;
    public float minHeightItem = 80f;
    public float maxHeightItem = 160f;
    [HideInInspector]
    public bool statusOpen = false;
    public GameObject objParent;
    public ScrollRect myScrollrect;
    public float pointWorld = -1;//vi tri nho hon se cho phep day scroll len
    private float originElas, originDeceler;
    private LayoutElement layoutEdit;
    private float speedRun = 250f;
    private bool mesRun = false;
    private int typeRun = 1;

    void Start()
    {
        if (myScrollrect != null)
        {
            originElas = myScrollrect.elasticity;
            originDeceler = myScrollrect.decelerationRate;
        }
        layoutEdit = transform.parent.parent.gameObject.GetComponent<LayoutElement>();
    }

    public void ButtonClick()
    {
        if (statusOpen) ButtonUp();
        else ButtonDown();
    }

    private bool pullUp = false;
    public void ButtonDown()
    {
        if (mesRun) return;
        typeRun = 1;
        mesRun = true;
        TurnOffEffectScroll();
        float pointClick = Input.mousePosition.y * Modules.KTCScenes.y / (float)Screen.height;
        if (pointClick < pointWorld) pullUp = true;
        else pullUp = false;
        //print(pointClick);
        CloseItemOther();
    }
	
    public void ButtonUp()
    {
        if (mesRun) return;
        typeRun = -1;
        mesRun = true;
    }

    private void CloseItemOther()
    {
        foreach (Transform tran in listItems.transform)
        {
            Transform parentDown = tran.transform.Find("AllElements");
            if (parentDown)
            {
                Transform buttonDown = parentDown.Find("ButDown");
                if (buttonDown)
                {
                    ButtonDownItem butComponent = buttonDown.GetComponent<ButtonDownItem>();
                    if (butComponent.statusOpen) butComponent.ButtonUp();
                }
            }
        }
    }

    void Update()
    {
        if (mesRun)
        {
            float value = typeRun * speedRun * Time.deltaTime;
            layoutEdit.preferredHeight += value;
            if (objParent != null && !statusOpen && pullUp)
            {
                RectTransform rect = objParent.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(0, rect.anchoredPosition.y + value);
            }
            if (layoutEdit.preferredHeight >= maxHeightItem || layoutEdit.preferredHeight <= minHeightItem)
            {
                if (typeRun == 1)
                {
                    layoutEdit.preferredHeight = maxHeightItem;
                    statusOpen = true;
                    TurnOnEffectScroll();
                }
                else
                {
                    layoutEdit.preferredHeight = minHeightItem;
                    statusOpen = false;
                }
                mesRun = false;
                pullUp = false;
            }
        }
    }

    private void TurnOffEffectScroll()
    {
        if (myScrollrect != null)
        {
            myScrollrect.elasticity = 0;
            myScrollrect.decelerationRate = 0;
        }
    }

    private void TurnOnEffectScroll()
    {
        if (myScrollrect != null)
        {
            myScrollrect.elasticity = originElas;
            myScrollrect.decelerationRate = originDeceler;
        }
    }
}
