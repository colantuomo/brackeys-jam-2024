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
    private GameObject _powerLightRoom, _finalDoorNoise;
    [SerializeField]
    private PlayerInteractions _playerInteractions;

    private void Start()
    {
        GameEvents.Instance.OnPlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        EngameManager.Instance.LoadEndgame();
    }

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
            _finalDoorNoise.SetActive(true);
            _missionTracker.CloseLastRoomDoor();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactableText.HideText();
        //gameObject.SetActive(false);
    }
}
