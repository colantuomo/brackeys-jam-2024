using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class EngameManager : Singleton<EngameManager>
{

    [SerializeField]
    private Image _blackScreen;

    private void Start()
    {
        GameEvents.Instance.OnPlayerDied += LoadGameOver;
    }

    public void LoadEndgame()
    {
        _blackScreen.DOFade(1, 2f).OnComplete(() =>
        {
            SoundsManager.Instance.ReduceRainToZero().OnComplete(() =>
            {
                SceneManager.LoadScene("Endgame");
            });
        });
    }

    public void LoadGameOver()
    {
        _blackScreen.DOFade(1, 2f).OnComplete(() =>
        {
            SoundsManager.Instance.ReduceRainToZero().OnComplete(() =>
            {
                SceneManager.LoadScene("GameOver");
            });
        });
    }
}
