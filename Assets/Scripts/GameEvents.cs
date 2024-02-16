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

    public event Action<string> OnShowTextPanel;
    public void ShowTextPanel(string text)
    {
        OnShowTextPanel?.Invoke(text);
    }

    public event Action OnCloseTextPanel;
    public void CloseTextPanel()
    {
        OnCloseTextPanel?.Invoke();
    }

    public event Action OnEnterCutScene;
    public void EnterCutScene()
    {
        OnEnterCutScene?.Invoke();
    }

    public event Action OnLeaveCutScene;
    public void LeaveCutScene()
    {
        OnLeaveCutScene?.Invoke();
    }

    public event Action OnTurnOffAllTheLights;
    public void TurnOffAllTheLights()
    {
        OnTurnOffAllTheLights?.Invoke();
    }
}
