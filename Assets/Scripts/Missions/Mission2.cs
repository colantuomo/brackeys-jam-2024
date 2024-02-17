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
            //SoundsManager.Instance.PlayDoorBell();
            SoundsManager.Instance.PlayDoorKnocking();
        });
        DOVirtual.Float(0, 1, _cutSceneTime, (v) => { }).OnComplete(() =>
        {
            SoundsManager.Instance.PitchNormalRain();
            CamerasManager.Instance.BackToNormal();
            GameSettings.Instance.ChangeGameState(GameStates.Playing);
            _missionTracker.SetNewObjective("Go back to the front door");
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DOVirtual.Float(0, 1, .2f, (v) => { }).OnComplete(() =>
        {
            GameSettings.Instance.ChangeGameState(GameStates.CutScene);
            GameEvents.Instance.EnterCutScene();
            DOVirtual.Float(0, 1, 2f, (v) => { }).OnComplete(() =>
            {
                _missionTracker.ClearObjective();
                SoundsManager.Instance.PlayLightningStrike();
                DOVirtual.Float(0, 1, 0.5f, (v) => { }).OnComplete(() =>
                {
                    GameEvents.Instance.TurnOffAllTheLights();
                });
                DOVirtual.Float(0, 1, 4f, (v) => { }).OnComplete(() =>
                {
                    GameEvents.Instance.ShowTextPanel("Damn, the light went out! I need to turn it back on... but where's my phone?");
                    DOVirtual.Float(0, 1, 2f, (v) => { }).OnComplete(() =>
                    {
                        GameEvents.Instance.LeaveCutScene();
                        GameSettings.Instance.ChangeGameState(GameStates.Playing);
                    });

                });
            });
        });

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.Instance.CloseTextPanel();
        _missionTracker.ClearObjective();
        _missionTracker.StartMission3();
        gameObject.SetActive(false);
    }
}
