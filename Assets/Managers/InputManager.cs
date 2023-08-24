using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInputs _playerInputs;

    [SerializeField]
    private MovementController _movementController;

    [SerializeField]
    private ArmMovement _armController;

    private Vector2 _movementInput;
    //private bool _interact;
    private bool _aiming;

    private void OnEnable()
    {
        if (_playerInputs == null)
        {
            _playerInputs = new PlayerInputs();

            _playerInputs.Player.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerInputs.Player.Jump.performed += i => _movementController.Jump();
            _playerInputs.Player.Jump.canceled += i => _movementController.StopJump();
            _playerInputs.Player.Aim.started += i => _armController._isAiming = true;
            _playerInputs.Player.Aim.canceled += i => _armController._isAiming = false;
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

    public void HandleMovementInput()
    {
        _movementController.HandleMovement(_movementInput.x);
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