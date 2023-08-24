using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isGrounded;
    
    [SerializeField] private float _playerSpeed = 10;
    [SerializeField] private float _playerJumpForce = 5;
    [SerializeField] private float _maxJumpTime = 0.5f;

    private Rigidbody2D _rb;

    private bool _isJumping;
    private float jumpStartTime;

    private float jumpTimeRatio;

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
        if (isGrounded)
        {
            jumpStartTime = Time.time;
            jumpTimeRatio = 0f;
            _rb.AddForce(Vector2.up * _playerJumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            _isJumping = true;
        }
    }

    public void StopJump()
    {
        _isJumping = false;
    }

    private void FixedUpdate()
    {
        if (_isJumping && jumpTimeRatio < 1)
        {
            jumpTimeRatio = Mathf.Clamp01((Time.time - jumpStartTime) / _maxJumpTime);
            float modifiedJumpForce = _playerJumpForce * (1f - jumpTimeRatio);

            //_rb.AddForce(Vector2.up * modifiedJumpForce); // check this alternative
            _rb.velocity = new Vector2(_rb.velocity.x, modifiedJumpForce);
        }
    }

    public float GetPlayerSpeed()
    {
        return _playerSpeed;
    }
}
