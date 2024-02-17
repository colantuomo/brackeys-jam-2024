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

    public event Action<float> OnUpdateSanityLevel;
    public void UpdateSanityLevel(float sanityAmount = 20)
    {
        OnUpdateSanityLevel?.Invoke(sanityAmount);
    }

    public event Action<float> OnUpdateSanityDecreaseRate;
    public void UpdateSanityDecreaseRate(float sanityRateDecreaseAmount = 5)
    {
        OnUpdateSanityDecreaseRate?.Invoke(sanityRateDecreaseAmount);
    }

    public event Action OnPauseSanityDecreasing;
    public void PauseSanityDecreasing()
    {
        OnPauseSanityDecreasing?.Invoke();
    }

    public event Action OnContinueSanityDecreasing;
    public void ContinueSanityDecreasing()
    {
        OnContinueSanityDecreasing?.Invoke();
    }

    public event Action OnPlayerDied;
    public void PlayerDied()
    {
        OnPlayerDied?.Invoke();
    }
}
