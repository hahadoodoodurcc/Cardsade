using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    // Accessing Other Scripts
    [SerializeField] internal PlayerAnimations PlayerAnimationsScript;
    [SerializeField] internal EnterBattle EnterBattleScript;
    [SerializeField] internal PlayerMovement PlayerMovementScript;

    // Accessing Player Component
    [HideInInspector] public Rigidbody2D PlayerRb2D;

    private void Awake()
    {
        PlayerRb2D = gameObject.GetComponent<Rigidbody2D>();
        PlayerMovementScript = gameObject.GetComponent<PlayerMovement>();
        PlayerAnimationsScript = gameObject.GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        PlayerAnimationsScript.UpdatePlayerAnimation();
    }

    private void FixedUpdate()
    {
        PlayerMovementScript.HorizontalMovement();
        PlayerMovementScript.VerticleMovement();
    }
}
