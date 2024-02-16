using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class FlickLightBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _canTurnOff;
    private Light2D _light;

    float timer;
    float interval = 1;

    void Start()
    {
        _light = GetComponent<Light2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            if (_canTurnOff)
            {
                _light.enabled = !_light.enabled;
            }
            else
            {
                var alpha = Random.Range(0.4f, 1f);
                _light.color = new Color(_light.color.r, _light.color.g, _light.color.b, alpha);
            }
            interval = Random.Range(0f, 1f);
            timer = 0;
        }
    }
}
