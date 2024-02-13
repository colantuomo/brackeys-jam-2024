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

    void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        Vector2 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - _rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        _flashLight.rotation = rotation;
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = _movement.normalized * GameSettings.Singleton.PlayerSpeed;
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, targetVelocity, ref _currentVelocity, _accelerationTime);
    }
}
