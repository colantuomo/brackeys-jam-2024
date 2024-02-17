using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseDamageArea : MonoBehaviour
{
    [SerializeField]
    private DoorNoise _doorNoise;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _doorNoise.TakeNoiseDamage();
        _doorNoise.PlayKnockNoise();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _doorNoise.BackNoiseDamangeToNormal();
    }
}
