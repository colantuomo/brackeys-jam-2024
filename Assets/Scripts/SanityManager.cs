using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Unity.Mathematics;

public class SanityManager : MonoBehaviour
{
    public float sanityLevel;
    public float sanityDecreaseRateSeconds;
    private float _totalIntervalSecondsElapsed;
    public GameObject sanityBar;
    public Volume volume;

    void Start()
    {
        SubscribeEvents();

        sanityLevel = 100f;
        sanityDecreaseRateSeconds = 1;
    }

    void Update()
    {
        _totalIntervalSecondsElapsed += Time.deltaTime;
        if(_totalIntervalSecondsElapsed >= 1)
        {
            _totalIntervalSecondsElapsed -= 1;
            sanityLevel -= sanityDecreaseRateSeconds;
            sanityLevel = Mathf.Max(sanityLevel, 0);
            if(volume.profile.TryGet(out Vignette vignette)){
                vignette.intensity.value = math.remap(100f, 0, 0.3f, 0.8f, sanityLevel);
            }

            sanityBar.GetComponent<Slider>().value = (int)sanityLevel;
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
    }

    void OnUpdateSanityDecreaseRate(float sanityRateDecreaseAmount)
    {
        sanityDecreaseRateSeconds += sanityRateDecreaseAmount;
    }

}
