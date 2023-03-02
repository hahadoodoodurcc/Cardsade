using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Accessing Other Scripts
    [SerializeField] internal PlayerController PlayerControllerScript;

    // Accessing Other Components
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private Transform GroundCheck;
    private Rigidbody2D PlayerRb2D;

    // Movement Variables ==========================================
    public float jumpDuration;
    public float moveSpeed;
    public float jumpPower;
    [HideInInspector] public bool isJumping;
    [HideInInspector] public float jumpTimer;

    private float _horizontal;
    private bool _isFacingRight;
    // ============================================================

    private void Awake()
    {
        PlayerControllerScript = gameObject.GetComponent<PlayerController>();
        PlayerRb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()  // Make sure player can't jump forever
    {
        if (isJumping)
        {
            jumpTimer += 1 * Time.deltaTime;
        }
    }

    void Update()
    {
        if (_isFacingRight && _horizontal > 0f)
        {
            Flip();
        }
        else if (!_isFacingRight && _horizontal < 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public bool isRunning;
    public void MoveInputDetector(InputAction.CallbackContext context) // REMEMBER TO UPDATE THIS IN UNITY INPUT EVENT
    {
        _horizontal = context.ReadValue<Vector2>().x;

        if (context.performed)
        {
            isRunning = true;
        }

        if (context.canceled)
        {
            isRunning = false;
        }
    }

    public void JumpInputDetector(InputAction.CallbackContext context) // REMEMBER TO UPDATE THIS IN UNITY INPUT EVENT
    {
        if (context.performed && IsGrounded())  // Reset jump, also tells PlayerAnimationScript to play Jump Anim
        {
            isJumping = true;
            jumpTimer = 0;
            PlayerControllerScript.PlayerRb2D.velocity = new Vector2(PlayerControllerScript.PlayerRb2D.velocity.x, jumpPower); // Small hop when player jump
        }

        if (context.canceled)
        {
            isJumping = false;
        }
    }

    public void HorizontalMovement() // Put this & VerticleMovement in FixedUpdate() of PlayerControllerScript
    {
        PlayerRb2D.velocity = new Vector2(_horizontal * moveSpeed, PlayerRb2D.velocity.y);
    }

    public void VerticleMovement() 
    {
        if (isJumping && jumpDuration > jumpTimer)
        {
            PlayerRb2D.velocity = new Vector2(PlayerRb2D.velocity.x, jumpPower * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }
}
