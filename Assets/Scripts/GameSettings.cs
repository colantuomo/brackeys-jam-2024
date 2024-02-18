using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameStates
{
    Playing,
    CutScene,
    Reading,
}

public class GameSettings : Singleton<GameSettings>
{
    public GameStates GameState;
    public float PlayerSpeed = 100f;
    public float TimeToStartSecondMission = 8f;

    private void Start()
    {
        GameState = GameStates.CutScene;
    }

    public event Action<GameStates> OnChangeGameState;
    public void ChangeGameState(GameStates state)
    {
        GameState = state;
        OnChangeGameState?.Invoke(state);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
