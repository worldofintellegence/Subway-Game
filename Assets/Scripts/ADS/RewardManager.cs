using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RewardManager : MonoBehaviour
{
    public static Action<int> onReward; 
    void Start()
    {
        onReward += OnReward;
    }

    private void OnReward(int reward)
    {
       // Do something with reward
    }
    private void OnDestroy()
    {
        onReward -= OnReward;
    }
}
