using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Unity.Mathematics;
using DG.Tweening;

public class SanityManager : MonoBehaviour
{
    //[SerializeField]
    private float sanityLevel = 100f, sanityDecreaseRateSeconds = 1;
    private float _totalIntervalSecondsElapsed;
    public GameObject sanityBar;
    public Volume volume;
    private Slider _slider;
    private bool _isPaused = true;
    [SerializeField]
    private Image _pillsPanel;

    void Start()
    {
        SubscribeEvents();
        _slider = sanityBar.GetComponent<Slider>();
        GameEvents.Instance.OnPauseSanityDecreasing += Pause;
        GameEvents.Instance.OnContinueSanityDecreasing += Continue;
        HideSanityBar();
    }

    void Update()
    {
        if (_isPaused) return;

        _totalIntervalSecondsElapsed += Time.deltaTime;
        if (_totalIntervalSecondsElapsed >= 1)
        {
            _totalIntervalSecondsElapsed -= 1;
            sanityLevel -= sanityDecreaseRateSeconds;
            sanityLevel = Mathf.Max(sanityLevel, 0);
            sanityBar.transform.DOShakeScale(.1f, .1f, 2);
            if (volume.profile.TryGet(out Vignette vignette))
            {
                vignette.intensity.value = math.remap(120f, 0, 0.2f, 0.8f, sanityLevel);
                print(vignette.intensity.value);
            }
            _slider.value = (int)sanityLevel;
            if (sanityLevel < 52)
            {
                print("You died");
            }
        }

        // Update stuff based on sanity
        // UpdateMusicPitch();
        // UpdateScreenDarkness();
    }

    private void SubscribeEvents()
    {
        GameEvents.Instance.OnUpdateSanityLevel += OnUpdateSanityLevel;
        GameEvents.Instance.OnUpdateSanityDecreaseRate += OnUpdateSanityDecreaseRate;
    }

    void OnUpdateSanityLevel(float sanityAmount)
    {
        sanityLevel += sanityAmount;
        sanityLevel = Mathf.Max(sanityLevel, 0);
        sanityBar.transform.DOShakeScale(.1f, .5f, 2);
        _pillsPanel.DOFade(1, 0.1f).OnComplete(() =>
        {
            _pillsPanel.DOFade(0, 1f);
        });
    }

    void OnUpdateSanityDecreaseRate(float sanityRateDecreaseAmount)
    {
        sanityDecreaseRateSeconds += sanityRateDecreaseAmount;
    }

    public void Pause()
    {
        HideSanityBar();
        _isPaused = true;
    }

    public void Continue()
    {
        ShowSanityBar();
        _isPaused = false;
    }

    public void ShowSanityBar()
    {
        sanityBar.transform.DOScale(Vector3.one, .5f);
    }

    public void HideSanityBar()
    {
        sanityBar.transform.DOScale(Vector3.zero, 0);
    }

}
