using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundsManager : Singleton<SoundsManager>
{
    [SerializeField]
    private AudioClip _doorbell, _lightningStrike, _doorKnocking, _takingPill, _barricadeFX;
    [SerializeField]
    private AudioSource _audioSourceLoop, _audioSourceFXs, _audioSourceIntroMusic;
    [SerializeField]
    [Range(0, 1)]
    private float _maxVolume = 1;
    [SerializeField]
    private float _timeToReachMaxVolume = 5f;

    private void Start()
    {
        DOVirtual.Float(0, _maxVolume, _timeToReachMaxVolume, (v) =>
        {
            _audioSourceLoop.volume = v;
        });
        DOVirtual.Float(0, 1, 30f, (v) => { }).OnComplete(() =>
        {
            DOVirtual.Float(0.7f, 0, 1f, (v) =>
            {
                _audioSourceIntroMusic.volume = v;
            });
        });
    }

    public void PlayDoorBell()
    {
        _audioSourceFXs.PlayOneShot(_doorbell);
    }

    public void PlayLightningStrike()
    {
        _audioSourceFXs.PlayOneShot(_lightningStrike);
    }

    public void PitchDownRain(float duration = 1f)
    {
        _audioSourceLoop.DOPitch(0.5f, duration);
    }

    public void PitchNormalRain()
    {
        _audioSourceLoop.DOPitch(1f, 0.1f);
    }

    public void PlayDoorKnocking()
    {
        _audioSourceFXs.PlayOneShot(_doorKnocking);
    }

    public void PlayTakingPill()
    {
        DOVirtual.Float(0.4f, 0.1f, 1f, (v) =>
        {
            _audioSourceLoop.volume = v;
        }).OnComplete(() =>
        {
            _audioSourceFXs.PlayOneShot(_takingPill);
            DOVirtual.Float(0, 1, 1f, (v) => { }).OnComplete(() =>
            {
                DOVirtual.Float(0.1f, 0.4f, 1f, (v) =>
                {
                    _audioSourceLoop.volume = v;
                });
            });

        });
    }

    public void PlayDoorBaricated()
    {
        _audioSourceFXs.PlayOneShot(_barricadeFX);
    }

    public void PlayAudioClip(AudioClip clip)
    {
        _audioSourceFXs.PlayOneShot(clip);
    }

    public Tween ReduceRainToZero(float seconds = 5f)
    {
        return _audioSourceLoop.DOFade(0, seconds);
    }
}
