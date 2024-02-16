using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mission2 : MonoBehaviour
{
    [SerializeField]
    private MissionTracker _missionTracker;
    [SerializeField]
    private float _cutSceneTime = 5f;

    private void OnEnable()
    {
        print("Mission 2 started");
        _missionTracker.ClearObjective();
        CamerasManager.Instance.EnableMissionCam(transform);
        GameSettings.Instance.ChangeGameState(GameStates.CutScene);
        SoundsManager.Instance.PitchDownRain(3f);
        DOVirtual.Float(0, 1, 3f, (v) => { }).OnComplete(() =>
        {
            SoundsManager.Instance.PlayDoorBell();
        });
        DOVirtual.Float(0, 1, _cutSceneTime, (v) => { }).OnComplete(() =>
        {
            SoundsManager.Instance.PitchNormalRain();
            CamerasManager.Instance.BackToNormal();
            GameSettings.Instance.ChangeGameState(GameStates.Playing);
            _missionTracker.SetNewObjective("Volte at� a porta");
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSettings.Instance.ChangeGameState(GameStates.CutScene);
        GameEvents.Instance.EnterCutScene();
        DOVirtual.Float(0, 1, 2f, (v) => { }).OnComplete(() =>
        {
            _missionTracker.ClearObjective();
            SoundsManager.Instance.PlayLightningStrike();
            DOVirtual.Float(0, 1, 1.5f, (v) => { }).OnComplete(() =>
            {
                GameEvents.Instance.TurnOffAllTheLights();

            });
            DOVirtual.Float(0, 1, 4f, (v) => { }).OnComplete(() =>
            {
                GameEvents.Instance.ShowTextPanel("Preciso ir at� o disjuntor no por�o, acho que ele desarmou.. mas preciso pegar o meu celular antes");
                DOVirtual.Float(0, 1, 2f, (v) => { }).OnComplete(() =>
                {
                    GameSettings.Instance.ChangeGameState(GameStates.Playing);
                });

            });
        });

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.Instance.LeaveCutScene();
        GameEvents.Instance.CloseTextPanel();
        _missionTracker.ClearObjective();
        _missionTracker.StartMission3();
        gameObject.SetActive(false);
    }
}