using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMission : MonoBehaviour
{
    [SerializeField]
    private InteractableBehaviour _interactableText;
    [SerializeField]
    private MissionTracker _missionTracker;
    [SerializeField]
    private GameObject _powerLightRoom;
    [SerializeField]
    private PlayerInteractions _playerInteractions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _interactableText.ShowText("Press F to turn on the power");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _interactableText.HideText();
            _missionTracker.ClearObjective();
            _powerLightRoom.SetActive(true);
            _playerInteractions.TurnOffFlashlight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactableText.HideText();
    }
}
