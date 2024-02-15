using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public float sanityLevel;
    public float sanityDecreaseRateSeconds;
    private float _totalIntervalSecondsElapsed;

    void Start()
    {
        SubscribeEvents();

        sanityLevel = 100f;
        sanityDecreaseRateSeconds = 1;
    }

    void Update()
    {
        _totalIntervalSecondsElapsed += Time.deltaTime; 
        if(_totalIntervalSecondsElapsed >= sanityDecreaseRateSeconds)
        {
            _totalIntervalSecondsElapsed -= sanityDecreaseRateSeconds;
            sanityLevel--;
        }

        // Update stuff based on sanity
        // UpdateMusicPitch();
        // UpdateScreenDarkness();
    }

    private void SubscribeEvents()
    {
        GameEvents.Singleton.OnUpdateSanityLevel += OnUpdateSanityLevel;
        GameEvents.Singleton.OnUpdateSanityDecreaseRate += OnUpdateSanityDecreaseRate;
    }

    void OnUpdateSanityLevel(float sanityDecreaseAmount)
    {
        sanityLevel -= sanityDecreaseAmount;
    }

    void OnUpdateSanityDecreaseRate(float sanityRateDecreaseAmount)
    {
        sanityDecreaseRateSeconds -= sanityRateDecreaseAmount;
    }

}
