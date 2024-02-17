using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mission1 : MonoBehaviour
{
    [SerializeField]
    private MissionTracker _missionTracker;
    [SerializeField]
    private float _timeToStartGame = 7f;

    private void Start()
    {
        GameEvents.Instance.EnterCutScene();
        DOVirtual.Float(0, 1, _timeToStartGame, (v) => { }).OnComplete(() =>
        {
            GameEvents.Instance.LeaveCutScene();
            SoundsManager.Instance.PlayDoorBell();
            _missionTracker.SetNewObjective("Vá até a porta de entrada");
            GameSettings.Instance.ChangeGameState(GameStates.Playing);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DOVirtual.Float(0, 1, .2f, (v) => { }).OnComplete(() =>
        {
            GameSettings.Instance.ChangeGameState(GameStates.CutScene);
            GameEvents.Instance.EnterCutScene();
            GameEvents.Instance.ShowTextPanel("Ué, parece que não tem ninguém aqui.. será que estou ouvindo coisas?");
            DOVirtual.Float(0, 1, 3f, (v) => { }).OnComplete(() =>
            {
                GameEvents.Instance.LeaveCutScene();
                GameSettings.Instance.ChangeGameState(GameStates.Playing);
            });
        });
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.Instance.CloseTextPanel();
        _missionTracker.ClearObjective();
        _missionTracker.StartMission2();
        gameObject.SetActive(false);
    }
}
