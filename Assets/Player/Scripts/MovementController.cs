using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 10;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        Vector3 _mov = (transform.forward * vertical) + (transform.right * horizontal);
        _rb.velocity = _mov * _playerSpeed * Time.deltaTime;
    }

    public float GetPlayerSpeed()
    {
        return _playerSpeed;
    }
}
