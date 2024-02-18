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
    private GameObject _powerLightRoom, _finalDoorNoise, _exitGameButton, _circuitUP, circuitDOWN;
    [SerializeField]
    private PlayerInteractions _playerInteractions;
    [SerializeField]
    private Image _blankPanel, _blackPanel, _catImage;
    [SerializeField]
    private TMP_Text _finalText;
    private bool _isGameFinished;

    private void Start()
    {
        GameEvents.Instance.OnPlayerDied += OnPlayerDied;
    }

    private void OnEnable()
    {
        _catImage.gameObject.SetActive(true);
        _catImage.DOFade(0, 0);
    }

    private void OnPlayerDied()
    {
        if (!_isGameFinished) return;
        //EngameManager.Instance.LoadEndgame();
        _finalDoorNoise.SetActive(false);
        GameSettings.Instance.ChangeGameState(GameStates.CutScene);
        SoundsManager.Instance.ReduceRainToZero(3f);
        _blackPanel.DOFade(1, 5f).OnComplete(() =>
        {
            GameEvents.Instance.UpdateSanityLevel(100);
            SoundsManager.Instance.PlayCatMeow();
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
                            _catImage.DOFade(1, 1f).OnComplete(() =>
                            {
                                _exitGameButton.SetActive(true);
                            });
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
            _circuitUP.SetActive(false);
            _isGameFinished = true;
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
