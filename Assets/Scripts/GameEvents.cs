using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Singleton { get; private set; }

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }
    }

    public event Action OnPlayerCollectedBattery;
    public void PlayerCollectedBattery()
    {
        OnPlayerCollectedBattery?.Invoke();
    }
}
