using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera _cam;
    private Vector2 _movement;
    private Rigidbody2D _rb;
    [SerializeField]
    private Transform _flashLight;
    private Vector2 _currentVelocity = Vector2.zero;
    [SerializeField]
    private float _accelerationTime = 0.1f;
    private Animator _anim;
    [SerializeField]
    private AnimationClip _idleUp, _idleDown, _idleLeft, _idleRight;

    void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        GameSettings.Instance.OnChangeGameState += OnChangeGameState;
    }

    private void OnChangeGameState(GameStates state)
    {
        _movement = Vector2.zero;
        _rb.velocity = Vector2.zero;
    }

    void Update()
    {
        if (GameSettings.Instance.GameState != GameStates.Playing) return;

        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        Vector2 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - _rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        _flashLight.rotation = rotation;
        //var pos = transform.position - Input.mousePosition;
        //var posX = Mathf.Abs(pos.x / Screen.width);
        //var posY = Mathf.Abs(pos.y / Screen.height);
        _anim.SetBool("isWalking", _movement != Vector2.zero);
    }

    void FixedUpdate()
    {
        if (GameSettings.Instance.GameState != GameStates.Playing) return;

        Vector2 targetVelocity = _movement.normalized * GameSettings.Instance.PlayerSpeed;
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, targetVelocity, ref _currentVelocity, _accelerationTime);
    }
}
