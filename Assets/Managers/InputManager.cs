using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInputs _playerInputs;

    [SerializeField]
    private MovementController _movementController;

    private Vector2 _movementInput;
    //private bool _interact;
    private (float x, float y) _moveSpeed;

    private void OnEnable()
    {
        if (_playerInputs == null)
        {
            _playerInputs = new PlayerInputs();

            _playerInputs.Player.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            //_playerInputs.PlayerInteraction.Interact.started += i => _interact = true;
        }

        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    public void HandleInput()
    {
        // handle all inputs
        HandleInteractInput();
    }

    public (float, float) HandleMovementInput()
    {
        _movementController.HandleMovement(_movementInput.x, _movementInput.y);

        _moveSpeed.x = _movementInput.x;
        _moveSpeed.y = _movementInput.y;
        return _moveSpeed;
    }

    private void HandleInteractInput()
    {
        /*if (_interact)
        {
            _playerInteractController.HandleInteract();
            _interact = false;
        }*/
    }
}