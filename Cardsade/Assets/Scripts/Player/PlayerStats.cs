using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string name;
    public int maxLevel;
    public int level;
    public int currentEXP;
    public int requiredEXP = 5; //config this 
    public int maxHealth;
    public int baseHealth = 50; //config this 
    public static int currentHealth;
    public int maxPoint;
    public int currentPoint;
    public int maxShield;
    public int currentShield;

    public HealthBar healthBar;

    void Start()
    {
        PlayerStat("GOOFYAHH");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("the health of player is " + currentHealth + " and your name is " + name);
    }

    private void PlayerStat(string _name)
    {
        name = _name;
        maxLevel = 10;
        level = 0;
        maxPoint = 8;
        currentEXP = 0;
        maxHealth = baseHealth + level * 5;
        maxShield = 0;
    }
}
