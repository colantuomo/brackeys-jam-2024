using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundsManager : Singleton<SoundsManager>
{
    [SerializeField]
    private AudioClip _doorbell, _lightningStrike;
    private AudioSource _audioSource;
    [SerializeField]
    [Range(0, 1)]
    private float _maxVolume = 1;
    [SerializeField]
    private float _timeToReachMaxVolume = 5f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DOVirtual.Float(0, _maxVolume, _timeToReachMaxVolume, (v) => {
            _audioSource.volume = v;
        });
    }

    public void PlayDoorBell()
    {
        _audioSource.PlayOneShot(_doorbell);
    }

    public void PlayLightningStrike()
    {
        _audioSource.PlayOneShot(_lightningStrike);
    }

    public void PitchDownRain(float duration = 1f)
    {
        _audioSource.DOPitch(0.5f, duration);
    }

    public void PitchNormalRain()
    {
        _audioSource.DOPitch(1f, 0.1f);
    }
}
