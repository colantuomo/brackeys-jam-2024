using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField]
    private Transform _topFX, bottomFX;
    private bool _isInCutScene;
    [SerializeField]
    private float _distanceFX = 50f;

    private void Start()
    {
        GameEvents.Instance.OnEnterCutScene += OnEnterCutScene;
        GameEvents.Instance.OnLeaveCutScene += OnLeaveCutScene;
        var midScreenSize = Camera.main.orthographicSize * Screen.width / Screen.height;
        var topPosition = midScreenSize * 2.2f;
        var bottomPosition = midScreenSize - (midScreenSize + 50f);
        //_topFX.position = new Vector2(_topFX.position.x, topPosition);
        //bottomFX.position = new Vector2(_topFX.position.x, bottomPosition);
    }

    private void Update()
    {
        
    }

    private void OnEnterCutScene()
    {
        if (_isInCutScene) return;
        _topFX.DOMoveY(_topFX.position.y - _distanceFX, 0.5f);
        bottomFX.DOMoveY(bottomFX.position.y + _distanceFX, 0.5f);
        _isInCutScene = true;
    }

    private void OnLeaveCutScene()
    {
        if (!_isInCutScene) return;
        _topFX.DOMoveY(_topFX.position.y + _distanceFX, 0.5f);
        bottomFX.DOMoveY(bottomFX.position.y - _distanceFX, 0.5f);
        _isInCutScene = false;
    }
}
