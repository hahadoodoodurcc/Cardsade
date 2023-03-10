using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBattle : MonoBehaviour
{
    //Get player scripts
    [SerializeField] internal PlayerController PlayerControllerScript;

    [HideInInspector] public bool isInBattle;

    [SerializeField] GameObject BattleField;

    private void Awake()
    {
        PlayerControllerScript = gameObject.GetComponent<PlayerController>();
    }

    public void StartBattle()
    {
        isInBattle = true;
        Instantiate(BattleField, new Vector3(0f, gameObject.transform.position.y - 0.25f), Quaternion.identity);
        Debug.Log("start battle");
    }
}

//Note UPDATE CMPONENTSSSSSSS