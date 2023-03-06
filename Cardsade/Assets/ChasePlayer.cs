using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    // Get Components
    [SerializeField] Transform RayCastPosition;
    private Rigidbody2D rb2D;
    private Transform TargetTransform;
    private Transform objectTransform; // transform of the enemy

    // Ray properties
    [SerializeField] private float _baseCastDistance;

    // movement properties
    private Vector3 baseScale;
    const string RIGHT = "right";
    const string LEFT = "left";
    private string _facingDirection;
    public float moveSpeed = 2f;
    public float aggresiveRange = 5f;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        TargetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // get player position
    }

    private void FixedUpdate()
    {
        ChaseTarget();
        _playerDetected();
    }

    private void Flip()
    {
        if (_facingDirection == RIGHT)
        {

        }
    }

    private bool _playerDetected()
    {
        bool _value = false;
        float distanceToPlayer = Vector2.Distance(transform.position, TargetTransform.position);
        print("distance: " + distanceToPlayer);

        return _value;
    }

    private void ChaseTarget()
    {
        objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector2.MoveTowards(objectTransform.position, TargetTransform.position, moveSpeed * Time.fixedDeltaTime);
    }
}
