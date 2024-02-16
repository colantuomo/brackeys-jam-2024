using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio3DBehaviour : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _maxVolume = 0.2f, _distanceToLowVolume = 400f;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector2.Distance(transform.position, _player.position);
        if(distance > _distanceToLowVolume)
        {
            _audioSource.volume -= Time.deltaTime * _maxVolume;
        } else if (_audioSource.volume < _maxVolume)
        {
            _audioSource.volume += Time.deltaTime * _maxVolume;
        }
    }
}
