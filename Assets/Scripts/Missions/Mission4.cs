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
    [SerializeField]
    private GameObject _medicine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameSettings.Instance.ChangeGameState(GameStates.CutScene);
        _interactableText.ShowText("Press F to use your medicine");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && !_tookMedicine)
        {
            _medicine.SetActive(false);
            GameSettings.Instance.ChangeGameState(GameStates.CutScene);
            _tookMedicine = true;
            _interactableText.HideText();
            _missionTracker.ClearObjective();
            SoundsManager.Instance.PlayTakingPill();
            GameEvents.Instance.UpdateSanityLevel();
            DOVirtual.Float(0, 1, 3f, (v) => { }).OnComplete(() =>
            {
                GameEvents.Instance.ShowTextPanel("Ah... I feel better... only this way the noises won't drive me insane! Now I need to turn the light back on.");
                GameSettings.Instance.ChangeGameState(GameStates.Playing);
            });
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactableText.HideText();
        if (!_tookMedicine) return;
        _missionTracker.TurnOffLightningLight();
        _missionTracker.SetNewObjective("Find the room to turn the light back on.");
        GameEvents.Instance.CloseTextPanel();
        _missionTracker.StartFinalMission();
        _missionTracker.EnableDoorsToBarricade();
        _missionTracker.EnablePillsToFind();
        _missionTracker.OpenLastRoomDoor();
        gameObject.SetActive(false);
    }
}
