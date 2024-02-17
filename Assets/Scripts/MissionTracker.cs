using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class MissionTracker : MonoBehaviour
{
    [SerializeField]
    private Image _introPanel, _objectivePlaceholder;
    [SerializeField]
    private TMP_Text _objectiveTXT, _moveTipTXT;
    [SerializeField]
    private List<Light2D> _sceneLights = new();
    [SerializeField]
    private Light2D _lightningLight;
    [SerializeField]
    private GameObject _powerRoomDoor;
    [SerializeField]
    private GameObject _doorsToBarricade, _pills;
    [Header("Missions")]
    [SerializeField]
    private Mission2 _mission2;
    [SerializeField]
    private Mission3 _mission3;
    [SerializeField]
    private Mission4 _mission4;
    [SerializeField]
    private FinalMission _finalMission;

    private void Start()
    {
        GameEvents.Instance.OnTurnOffAllTheLights += OnTurnOffAllTheLights;
        GameEvents.Instance.OnPlayerDied += OnPlayerDied;
        _introPanel.DOFade(1, 0f);
        _introPanel.DOFade(0, 5f);
        _moveTipTXT.DOFade(0, 0f);
        DOVirtual.Float(0, 1, 11f, (v) => { }).OnComplete(() =>
        {
            _moveTipTXT.DOFade(1, 3f).OnComplete(() =>
            {
                _moveTipTXT.DOFade(0, 3f);
            });
        });
        _objectivePlaceholder.DOFade(0, 0f);
    }

    private void OnPlayerDied()
    {
        // Load Game Over scene
    }

    private void OnTurnOffAllTheLights()
    {
        _sceneLights.ForEach((light) =>
        {
            light.gameObject.SetActive(false);
        });
        _lightningLight.gameObject.SetActive(true);
    }

    public Tween ClearObjective()
    {
        _objectivePlaceholder.DOFade(0, .5f);
        return _objectiveTXT.DOFade(0, .5f).OnComplete(() =>
        {
            _objectiveTXT.text = "";
        });
    }

    public void SetNewObjective(string text)
    {
        ClearObjective().OnComplete(() =>
        {
            _objectivePlaceholder.DOFade(1, .5f);
            _objectiveTXT.DOFade(1, .5f).OnComplete(() =>
            {
                //_objectiveTXT.transform.DOShakeScale(.2f);
                _objectiveTXT.text = text;
            });
        });
    }

    public void StartMission2()
    {
        DOVirtual.Float(0, 1, GameSettings.Instance.TimeToStartSecondMission, (v) => { }).OnComplete(() =>
          {
              _mission2.gameObject.SetActive(true);
          });
    }

    public void StartMission3()
    {
        SetNewObjective("Encontre seu smartphone");
        _mission3.gameObject.SetActive(true);
    }

    public void StartMission4()
    {
        SetNewObjective("Pegue seu remédio");
        _mission4.gameObject.SetActive(true);
    }

    public void StartFinalMission()
    {
        _finalMission.gameObject.SetActive(true);
    }

    public void TurnOffLightningLight()
    {
        _lightningLight.gameObject.SetActive(false);
    }

    public void OpenLastRoomDoor()
    {
        _powerRoomDoor.SetActive(false);
    }

    public void CloseLastRoomDoor()
    {
        _powerRoomDoor.SetActive(true);
    }

    public void EnableDoorsToBarricade()
    {
        _doorsToBarricade.SetActive(true);
    }

    public void EnablePillsToFind()
    {
        _pills.SetActive(true);
    }
}
