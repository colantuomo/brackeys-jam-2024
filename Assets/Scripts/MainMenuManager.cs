using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private Image _panel;
    [SerializeField]
    private AudioClip _enterGameFX;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _panel.DOFade(1, 0);
        _audioSource.volume = 0f;
        DOVirtual.Float(0, 0.3f, 5f, (v) =>
        {
            _audioSource.volume = v;
        });
        _panel.DOFade(0, 5f);
    }
    public void StartGame()
    {
        DOTween.KillAll();
        _panel.DOKill();
        _audioSource.PlayOneShot(_enterGameFX);
        DOVirtual.Float(0.3f, 0, 2f, (v) =>
        {
            _audioSource.volume = v;
        });
        _panel.DOFade(1, 3f).OnComplete(() =>
        {
            SceneManager.LoadScene("SampleScene");
        });
    }
}
