using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PIll : MonoBehaviour
{
    [SerializeField]
    private InteractableBehaviour _interactableTXT;
    private bool _tookMedicine = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _interactableTXT.ShowText("Press F to use your medicine");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && !_tookMedicine)
        {
            GameSettings.Instance.ChangeGameState(GameStates.CutScene);
            _interactableTXT.HideText();
            _tookMedicine = true;
            SoundsManager.Instance.PlayTakingPill();
            GameEvents.Instance.UpdateSanityLevel();
            DOVirtual.Float(0, 1, 2f, (v) => { }).OnComplete(() =>
            {
                GameSettings.Instance.ChangeGameState(GameStates.Playing);
            });
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactableTXT.HideText();
        gameObject.SetActive(false);
    }
}
