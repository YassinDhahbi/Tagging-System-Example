using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace YassinDhahbi
{
    public class SimpleCharacterController2D : MonoBehaviour
    {
        private Rigidbody2D playerRb;

        [SerializeField]
        private float jumpForce;

        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float maxSpeed;

        [SerializeField]
        private Vector2 moveDirection;

        [SerializeField]
        public bool isJumping;

        [SerializeField]
        private int numberOfJumpsLeft;

        private SpriteRenderer spriteRenderer;
        private AnimationHandler animationHandler;

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animationHandler = GetComponent<AnimationHandler>();
            numberOfJumpsLeft = 0;
        }

        public void Jump()
        {
            if (isJumping == true && numberOfJumpsLeft > 0)
            {
                numberOfJumpsLeft = 0;
                playerRb.velocity += Vector2.up * jumpForce;
                animationHandler.PlayAnimation(PlayerAnimationTag.Jump);
            }
        }

        public void LandingBehaviour()
        {
            if (moveDirection.sqrMagnitude > 0)
            {
                animationHandler.PlayAnimation(PlayerAnimationTag.Walk);
            }
            else
            {
                animationHandler.PlayAnimation(PlayerAnimationTag.Idle);
            }
        }

        private void FixedUpdate()
        {
            HandleRigidBody(playerRb);
        }

        private void HandleRigidBody(Rigidbody2D rb)
        {
            rb.velocity += Vector2.right * moveDirection.x * Time.fixedDeltaTime * moveSpeed;
            rb.velocity += Vector2.up * Physics.gravity * Time.fixedDeltaTime;
            rb.velocity.Normalize();
            rb.velocity = Vector2.ClampMagnitude(playerRb.velocity, maxSpeed);
        }

        public void Move(Vector2 direction)
        {
            moveDirection = direction;
            animationHandler.MoveAnimationHandler(isJumping, direction, spriteRenderer);
        }

        public void SetJumpingState(bool state)
        {
            isJumping = state;
        }

        public void SetNumberOfJumps(int x)
        {
            numberOfJumpsLeft += x;
        }
    }
}