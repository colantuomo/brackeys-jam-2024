using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : Singleton<GameEvents>
{
    // public static GameEvents Singleton { get; private set; }

    // private void Awake()
    // {
    //     if (Singleton != null && Singleton != this)
    //     {
    //         Destroy(this);
    //     }
    //     else
    //     {
    //         Singleton = this;
    //     }
    // }

    public event Action OnPlayerCollectedBattery;
    public void PlayerCollectedBattery()
    {
        OnPlayerCollectedBattery?.Invoke();
    }

    public event Action<float> OnUpdateSanityLevel;
    public void UpdateSanityLevel(float sanityDecreaseAmount)
    {
        OnUpdateSanityLevel?.Invoke(sanityDecreaseAmount);
    }

    public event Action<float> OnUpdateSanityDecreaseRate;
    public void UpdateSanityDecreaseRate(float sanityRateDecreaseAmount)
    {
        OnUpdateSanityDecreaseRate?.Invoke(sanityRateDecreaseAmount);
    }
}
