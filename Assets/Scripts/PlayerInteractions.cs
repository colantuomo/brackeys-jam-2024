using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteractions : MonoBehaviour
{
    private bool _canInteract = false;
    public event Action OnPlayerInteract;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canInteract)
        {
            OnPlayerInteract?.Invoke();
        }
    }

    public void CanInteract(bool canInteract)
    {
        _canInteract = canInteract;
    }
}
