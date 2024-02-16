using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.Universal;


public class PlayerInteractions : MonoBehaviour
{
    private bool _canInteract = false;
    public event Action OnPlayerInteract;
    [SerializeField]
    private Light2D _flashlight;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canInteract)
        {
            OnPlayerInteract?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //GameEvents.Instance.ShowTextPanel("Será que essa merda funciona?");
            GameEvents.Instance.EnterCutScene();
        }
    }

    public void CanInteract(bool canInteract)
    {
        _canInteract = canInteract;
    }

    public void TurnOnFlashlight()
    {
        _flashlight.gameObject.SetActive(true);
    }
}
