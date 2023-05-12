using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour {

    public string idJetpack = "001";//ma nhan biet loai jetpack
    public float costJetpack = 10000f;//gia tien mua jetpack nay
    public int noteJetpack = 0;//index information
    public Sprite iconSale;//cac icon sale
    public float speedPercent = 0;//phan tram tang toc do
    public bool isWing = false;//phan biet may moc hay canh
    public bool isBroom = false;//phan biet la choi bay
    public GameObject effectUnlock;
}
