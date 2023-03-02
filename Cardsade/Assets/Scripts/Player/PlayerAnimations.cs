using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //Accessing Other Scripts
    [SerializeField] internal PlayerController PlayerControllerScript;
    [SerializeField] internal PlayerMovement PlayerMovementScript;

    //Access Player Component
    public Animator Animator;

    private void Awake()
    {
        Animator = PlayerControllerScript.gameObject.GetComponent<Animator>();
        PlayerControllerScript = gameObject.GetComponent<PlayerController>();
        PlayerMovementScript = gameObject.GetComponent<PlayerMovement>();
    }

    public void UpdatePlayerAnimation()
    {
        if (!PlayerMovementScript.isJumping)
        {
            Animator.SetBool("isJumping", false);
        }

        if (PlayerMovementScript.isJumping && PlayerMovementScript.jumpDuration > PlayerMovementScript.jumpTimer)
        {
            Animator.SetBool("isJumping", true);
        }

        if (PlayerMovementScript.jumpDuration <= PlayerMovementScript.jumpTimer)
        {
            Animator.SetBool("isJumping", false);
        }

        if (PlayerMovementScript.isRunning)
        {
            Animator.SetBool("isRunning", true);
        }

        if (!PlayerMovementScript.isRunning)
        {
            Animator.SetBool("isRunning", false);
        }
    }
}
