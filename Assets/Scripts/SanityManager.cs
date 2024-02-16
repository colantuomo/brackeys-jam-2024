using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{
    public float sanityLevel;
    public float sanityDecreaseRateSeconds;
    private float _totalIntervalSecondsElapsed;
    public GameObject sanityBar;

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
        }
        sanityBar.GetComponent<Slider>().value = (int)sanityLevel;

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
