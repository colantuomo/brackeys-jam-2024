using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mission3 : MonoBehaviour
{
    [SerializeField]
    private PlayerInteractions _playerInteractions;
    private AudioSource _audioSource;
    [SerializeField]
    private MissionTracker _missionTracker;
    private bool _pickedPhone;
    [SerializeField]
    private InteractableBehaviour _interactableText;
    [SerializeField]
    private GameObject _phone;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameSettings.Instance.ChangeGameState(GameStates.CutScene);
        _interactableText.ShowText("Press F to grab your phone");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && !_pickedPhone)
        {
            _phone.SetActive(false);
            _missionTracker.TurnOffLightningLight();
            _interactableText.HideText();
            _pickedPhone = true;
            _missionTracker.ClearObjective();
            _audioSource.enabled = false;
            GameEvents.Instance.ShowTextPanel("Ah, here it is! \nIt's time for me to take my medication, I know it's somewhere in this room...");
            _playerInteractions.TurnOnFlashlight();
            GameEvents.Instance.ContinueSanityDecreasing();
            GameSettings.Instance.ChangeGameState(GameStates.CutScene);
            DOVirtual.Float(0, 1, 2f, (v) => { }).OnComplete(() =>
            {
                GameSettings.Instance.ChangeGameState(GameStates.Playing);
            });
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactableText.HideText();
        if (!_pickedPhone) return;
        _missionTracker.StartMission4();
        GameEvents.Instance.CloseTextPanel();
        gameObject.SetActive(false);
    }
}
