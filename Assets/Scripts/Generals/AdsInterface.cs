using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AdsInterface {

    bool HaveDisplayAds();
    bool ErrorDisplayAds();
    bool WatchDisplayAds();
    bool CloseDisplayAds();
    bool HaveVideoAds();
    bool ErrorVideoAds();
    bool WatchVideoAds();
    bool CloseVideoAds();
    void ShowDisplayAds(string nameCallback);
    void ShowVideoAds(string nameCallback);
    void RequestDisplayAds();
    void RequestVideoAds();
    void ResetCallbackVideo();
    string GetCallbackVideo();
}
