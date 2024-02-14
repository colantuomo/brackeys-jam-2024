using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _lights;
    [SerializeField]
    private bool _lightState = false;

    private void Start()
    {
        ModifyLights(_lightState);
    }

    public void TurnOn()
    {
        _lightState = true;
        ModifyLights(_lightState);
    }

    public void TurnOff()
    {
        _lightState = false;
        ModifyLights(_lightState);
    }

    private void ModifyLights(bool lightState)
    {
        _lights.ForEach((light) =>
        {
            light.gameObject.SetActive(lightState);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInteractions playerInteractions))
        {
            playerInteractions.CanInteract(true);
            playerInteractions.OnPlayerInteract += OnPlayerInteract;
        }
    }

    private void OnPlayerInteract()
    {
        OnUseLight();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInteractions playerInteractions))
        {
            //OnUseLight();
            playerInteractions.CanInteract(false);
            playerInteractions.OnPlayerInteract -= OnPlayerInteract;
        }
    }

    private void OnUseLight()
    {
        if (IsLightEnable())
        {
            TurnOff();
            return;
        }
        TurnOn();
    }

    private bool IsLightEnable()
    {
        return _lightState;
    }
}
