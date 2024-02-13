using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : Singleton<GameEvents>
{
    public event Action OnPlayerCollectedBattery;
    public void PlayerCollectedBattery()
    {
        OnPlayerCollectedBattery?.Invoke();
    }
}
