using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mission4 : MonoBehaviour
{
    [SerializeField]
    private MissionTracker _missionTracker;
    private bool _tookMedicine;
    [SerializeField]
    private InteractableBehaviour _interactableText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameSettings.Instance.ChangeGameState(GameStates.CutScene);
        _interactableText.ShowText("Press F to use your medicine");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && !_tookMedicine)
        {
            GameSettings.Instance.ChangeGameState(GameStates.CutScene);
            _tookMedicine = true;
            _interactableText.HideText();
            _missionTracker.ClearObjective();
            SoundsManager.Instance.PlayTakingPill();
            GameEvents.Instance.UpdateSanityLevel();
            DOVirtual.Float(0, 1, 3f, (v) => { }).OnComplete(() =>
            {
                GameEvents.Instance.ShowTextPanel("Ah.. estou melhor, agora preciso ver o disjuntor");
                GameSettings.Instance.ChangeGameState(GameStates.Playing);
            });
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactableText.HideText();
        if (!_tookMedicine) return;
        _missionTracker.TurnOffLightningLight();
        _missionTracker.SetNewObjective("Encontre o Disjuntor");
        GameEvents.Instance.CloseTextPanel();
        _missionTracker.StartFinalMission();
        _missionTracker.EnableDoorsToBarricade();
        _missionTracker.EnablePillsToFind();
        _missionTracker.OpenLastRoomDoor();
        gameObject.SetActive(false);
    }
}
