using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

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
    [SerializeField]
    private Image _blankPanel, _blackPanel;
    [SerializeField]
    private TMP_Text _finalText;

    private void Start()
    {
        GameEvents.Instance.OnPlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        //EngameManager.Instance.LoadEndgame();
        _finalDoorNoise.SetActive(false);
        GameSettings.Instance.ChangeGameState(GameStates.CutScene);
        SoundsManager.Instance.ReduceRainToZero(3f);
        _blackPanel.DOFade(1, 5f).OnComplete(() =>
        {
            _playerInteractions.ShowCat();
            _blackPanel.DOFade(0, 2f).OnComplete(() =>
            {
                GameEvents.Instance.ShowTextPanel("Whew! It was just you!");
                DOVirtual.Float(0, 1, 5f, (v) => { }).OnComplete(() =>
                {
                    _blankPanel.DOFade(1, 1f).OnComplete(() =>
                    {
                        DOVirtual.Float(0, 1, 3f, (v) => { }).OnComplete(() =>
                        {
                            _finalText.gameObject.SetActive(true);
                            _finalText.DOFade(1, 1f);
                        });
                    });
                });
            });
        });
        //_blankPanel.DOFade(1, 5f);
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
