using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAController : MonoBehaviour {

	void Awake () {
        GameAnalytics.Initialize();
    }
}
