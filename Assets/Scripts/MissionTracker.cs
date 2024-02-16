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
    private Image _introPanel;
    [SerializeField]
    private TMP_Text _objectiveTXT;
    [SerializeField]
    private List<Light2D> _sceneLights = new();
    [SerializeField]
    private Light2D _lightningLight;
    [Header("Missions")]
    [SerializeField]
    private Mission2 _mission2;
    [SerializeField]
    private Mission3 _mission3;
    [SerializeField]
    private Mission4 _mission4;

    private void Start()
    {
        GameEvents.Instance.OnTurnOffAllTheLights += OnTurnOffAllTheLights;
        _introPanel.DOFade(1, 0f);
        _introPanel.DOFade(0, 5f);
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
        return _objectiveTXT.DOFade(0, .5f).OnComplete(() =>
        {
            _objectiveTXT.text = "";
        });
    }

    public void SetNewObjective(string text)
    {
        ClearObjective().OnComplete(() =>
        {
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
        DOVirtual.Float(0, 1, GameSettings.Instance.TimeToStartSecondMission, (v) => { }).OnComplete(() =>
        {
            _mission3.gameObject.SetActive(true);
        });
    }

    public void StartMission4()
    {
        SetNewObjective("Pegue seu remédio");
        DOVirtual.Float(0, 1, GameSettings.Instance.TimeToStartSecondMission, (v) => { }).OnComplete(() =>
        {
            _mission4.gameObject.SetActive(true);
        });
    }
}
