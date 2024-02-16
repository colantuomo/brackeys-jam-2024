using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission3 : MonoBehaviour
{
    [SerializeField]
    private PlayerInteractions _playerInteractions;
    private AudioSource _audioSource;
    [SerializeField]
    private MissionTracker _missionTracker;
    private bool _pickedPhone;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameSettings.Instance.ChangeGameState(GameStates.CutScene);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && !_pickedPhone)
        {
            _pickedPhone = true;
            _missionTracker.ClearObjective();
            _audioSource.enabled = false;
            GameEvents.Instance.ShowTextPanel("Achei!\nDroga! ta na hora de eu tomar meu remédio.. sei que está aqui no quarto em algum lugar..");
            _playerInteractions.TurnOnFlashlight();
            GameSettings.Instance.ChangeGameState(GameStates.Playing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_pickedPhone) return;
        _missionTracker.StartMission4();
        GameEvents.Instance.CloseTextPanel();
        gameObject.SetActive(false);
    }
}
