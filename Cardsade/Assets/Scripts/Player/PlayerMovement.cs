using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;

    public LayerMask GroundLayer;
    public Transform GroundCheck;

    private Animator Animator;

    private Rigidbody2D PlayerRb2D;

    private float _jumpTimer;
    [SerializeField] private float jumpDuration;
    private float _horizontal;

    private bool _isFacingRight;
    private bool _isJumping;

    void Start()
    {
        PlayerRb2D = gameObject.GetComponent<Rigidbody2D>();
        Animator = gameObject.GetComponent<Animator>();
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

        if (!_isJumping)
        {
            Animator.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        PlayerRb2D.velocity = new Vector2(_horizontal * moveSpeed, PlayerRb2D.velocity.y);

        if (_isJumping && jumpDuration > _jumpTimer)
        {
            Animator.SetBool("isJumping", true);
            _jumpTimer += 1 * Time.deltaTime;
            PlayerRb2D.velocity = new Vector2(PlayerRb2D.velocity.x, jumpPower * 0.5f);
        }

        if (jumpDuration <= _jumpTimer)
        {
            Animator.SetBool("isJumping", false);
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void move(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;

        if (context.performed && IsGrounded())
        {
            Animator.SetBool("isRunning", true);
        }

        if (context.canceled)
        {
            Animator.SetBool("isRunning", false);
        }
    }

    public void jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _isJumping = true;
            _jumpTimer = 0;
            PlayerRb2D.velocity = new Vector2(PlayerRb2D.velocity.x, jumpPower);
        }

        if (context.canceled)
        {
            _isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }
}
