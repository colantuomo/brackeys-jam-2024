using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextPanelManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textBox;
    [SerializeField]
    private float _timeToOpen = 1f;
    [SerializeField]
    private Transform _pointToSlide;
    private Vector2 _defaultPosition;
    bool _isOpen;

    private void Start()
    {
        GameEvents.Instance.OnShowTextPanel += Open;
        GameEvents.Instance.OnCloseTextPanel += Close;
        _defaultPosition = transform.position;
    }

    public void Open(string text)
    {
        if (_isOpen)
        {
            return;
        }
        transform.DOKill();
        _textBox.text = text;
        transform.DOMove(_pointToSlide.position, _timeToOpen).SetEase(Ease.OutBack);
        _isOpen = true;
    }

    public void Close()
    {
        _isOpen = false;
        transform.DOKill();
        transform.DOMove(_defaultPosition + new Vector2(0, -50f), _timeToOpen - 0.5f);
    }
}
