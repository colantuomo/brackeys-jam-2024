using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorNoise : MonoBehaviour
{
    [SerializeField]
    private InteractableBehaviour _interactableText;
    [SerializeField]
    private List<AudioClip> _knockFXs = new();
    private AudioSource _audioSource;
    [SerializeField]
    private float _noiseDamage = 5f;
    [SerializeField]
    private SpriteRenderer _barricadedDoor, _soundNoiseLeft, _soundNoiseRight;
    [SerializeField]
    private NoiseDamageArea _noiseDamageArea;

    float timer;
    float interval = 1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            PlayKnockNoise();
            interval = Random.Range(0f, 5f);
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _interactableText.ShowText("Press F to barricade");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _interactableText.HideText();
            Barricate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactableText.HideText();
    }

    private AudioClip GetRandomKnockSound()
    {
        var random = Random.Range(0, _knockFXs.Count);
        return _knockFXs[random];
    }

    private void Barricate()
    {
        _barricadedDoor.gameObject.SetActive(true);
        _audioSource.enabled = false;
        SoundsManager.Instance.PlayDoorBaricated();
        _noiseDamageArea.gameObject.SetActive(false);
        _interactableText.gameObject.SetActive(false);
    }

    public void TakeNoiseDamage()
    {
        ShowVisualNoiseFX();
        GameEvents.Instance.UpdateSanityDecreaseRate(_noiseDamage);
    }

    public void BackNoiseDamangeToNormal()
    {
        GameEvents.Instance.UpdateSanityDecreaseRate(-_noiseDamage);
    }

    public void PlayKnockNoise()
    {
        //_audioSource.Stop();
        _audioSource.PlayOneShot(GetRandomKnockSound());
    }

    private void ShowVisualNoiseFX()
    {
        //_soundNoiseLeft.transform.DOShakeScale(.2f, 0.1f, 1).SetLoops(-1).SetDelay(1f);
        //_soundNoiseRight.transform.DOShakeScale(.2f, 0.1f, 1).SetLoops(-1).SetDelay(1f);
    }
}
