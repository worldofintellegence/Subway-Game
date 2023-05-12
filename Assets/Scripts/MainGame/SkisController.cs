using UnityEngine;
using System.Collections;

public class SkisController : MonoBehaviour {

    public string idSkis = "001";//ma nhan biet loai skis
    public float costSkis = 10000f;//gia tien mua skis nay
    public int noteSkis = 0;//index information
    public Sprite iconSale;//cac icon sale
    public float speedPercent = 0;//phan tram tang toc do
    public bool isHoverbike = false;
    public GameObject effectUnlock;
    public bool haveSwipe = false;
    public AudioClip swipeLeft, swipeRight, swipeUp, swipeDown;
}
