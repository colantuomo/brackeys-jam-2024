using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class InteractableBehaviour : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _interactTXT;

    private void Start()
    {
        _interactTXT.DOFade(0, 0);
    }

    public void ShowText(string text = "Press F to interact")
    {
        _interactTXT.text = text;
        _interactTXT.DOFade(1, .1f);
    }

    public void HideText()
    {
        _interactTXT.DOFade(0, .1f);
    }
}
