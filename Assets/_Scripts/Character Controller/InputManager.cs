using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace YassinDhahbi
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private InputAction movementInput;

        [SerializeField]
        private InputAction jumpInput;

        private SimpleCharacterController2D characterController;

        private void OnEnable()
        {
            movementInput.Enable();
            jumpInput.Enable();
            characterController = GetComponent<SimpleCharacterController2D>();
            movementInput.performed += ctx => characterController.Move(ctx.ReadValue<Vector2>());
            movementInput.canceled += ctx => characterController.Move(Vector2.zero);
            jumpInput.started += ctx => characterController.isJumping = true;
            jumpInput.started += ctx => characterController.Jump();
        }

        private void OnDisable()
        {
            movementInput.Disable();
            jumpInput.Disable();
            movementInput.performed -= ctx => characterController.Move(ctx.ReadValue<Vector2>());
            movementInput.canceled -= ctx => characterController.Move(Vector2.zero);
            jumpInput.started -= ctx => characterController.isJumping = true;

            jumpInput.started -= ctx => characterController.Jump();
        }
    }
}