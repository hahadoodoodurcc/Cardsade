using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsFollowPlayer : MonoBehaviour
{
    public Transform PlayerPosition;
    private Transform StatsXPos;
    [SerializeField] private float abovePlayer;

    private void Start()
    {
        StatsXPos = gameObject.transform;
    }

    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(PlayerPosition.position.x, PlayerPosition.position.y + abovePlayer, PlayerPosition.position.z);
        StatsXPos.position = newPosition;
    }
}
