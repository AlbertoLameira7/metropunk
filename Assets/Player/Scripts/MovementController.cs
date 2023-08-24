using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isGrounded;
    
    [SerializeField] private float _playerSpeed = 10;
    [SerializeField] private float _playerJumpForce = 5;
    [SerializeField] private float _maxJumpTime = 0.5f;
    [SerializeField] private float _coyoteTime = 0.1f;

    private Rigidbody2D _rb;
    private bool _isJumping, _hasJumped, _canJump, _fallTimerStarted = false;
    private float _jumpTime, _fallTime, _previousUpdateVelocity;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void HandleMovement(float horizontal)
    {
        _rb.velocity = new Vector2(horizontal * _playerSpeed, _rb.velocity.y);
    }

    public void Jump()
    {   
        if (isGrounded || _canJump)
        {
            _jumpTime = Time.time + _maxJumpTime;
            _rb.AddForce(Vector2.up * _playerJumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            _isJumping = true;
            _hasJumped = true;
        }
    }

    public void StopJump()
    {
        _isJumping = false;
    }

    private void Update()
    {
        _canJump = (!_hasJumped && Time.time < _fallTime) ? true : false;
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.y < 0 && !_fallTimerStarted && !_hasJumped)
        {
            // is falling
            isGrounded = false;
            _fallTime = Time.time + _coyoteTime;
            _fallTimerStarted = true;
        } else if (_rb.velocity.y == 0 && _previousUpdateVelocity < 0)
        {
            isGrounded = true;
            _fallTimerStarted = false;
            _hasJumped = false;
        }

        if (_isJumping && Time.time < _jumpTime)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _playerJumpForce);
        }

        _previousUpdateVelocity = _rb.velocity.y;
    }

    public float GetPlayerSpeed()
    {
        return _playerSpeed;
    }
}
