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
    private float _openDistance = 200f, _timeToOpen = 1f;
    bool _isOpen;

    private void Start()
    {
        GameEvents.Instance.OnShowTextPanel += Open;
        GameEvents.Instance.OnCloseTextPanel += Close;
    }

    public void Open(string text)
    {
        if (_isOpen)
        {
            return;
        }
        transform.DOKill();
        _textBox.text = text;
        transform.DOMoveY(transform.position.y + _openDistance, _timeToOpen).SetEase(Ease.OutBack);
        _isOpen = true;
    }

    public void Close()
    {
        _isOpen = false;
        transform.DOKill();
        transform.DOMoveY(transform.position.y + -_openDistance, _timeToOpen - 0.5f);
    }
}
