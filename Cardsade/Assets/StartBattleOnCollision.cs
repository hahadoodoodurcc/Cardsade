using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleOnCollision : MonoBehaviour
{
    //Access player scripts
    internal PlayerMovement PlayerMovementScript;
    internal EnterBattle EnterBattleScript;

    //Access player components
    Rigidbody2D rb2D;
    Rigidbody2D playerRb2D;

    //Access player child
    Transform PlayerTransform;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Scripts
        PlayerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        EnterBattleScript = GameObject.FindGameObjectWithTag("Player").GetComponent<EnterBattle>();
        //Components
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerRb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //Childs

        if (collision.tag == "Player" && !EnterBattleScript.isInBattle)
        {
            playerRb2D.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
            EnterBattleScript.StartBattle();
        }
    }
}
