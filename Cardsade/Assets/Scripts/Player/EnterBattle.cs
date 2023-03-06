using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleInput : MonoBehaviour
{
    //Get player scripts
    [SerializeField] internal PlayerController PlayerControllerScript;

    private void Awake()
    {
        PlayerControllerScript = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }
}

//Note UPDATE CMPONENTSSSSSSS