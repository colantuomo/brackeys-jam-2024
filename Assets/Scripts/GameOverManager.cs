using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private Image _panel;
    [SerializeField]
    private float _timeToShow = 20f;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _panel.DOFade(1, 0);
        _audioSource.volume = 0f;
        DOVirtual.Float(0, 0.3f, _timeToShow, (v) =>
        {
            _audioSource.volume = v;
        });
        _panel.DOFade(0, _timeToShow);
    }

    public void LoadMenu()
    {
        DOVirtual.Float(0.3f, 0, 3f, (v) =>
        {
            _audioSource.volume = v;
        });
        _panel.DOFade(1, 3f).OnComplete(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }
}
