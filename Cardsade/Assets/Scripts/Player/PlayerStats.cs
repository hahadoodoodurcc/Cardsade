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
    public int currentHealth;
    public int maxPoint = 8; //config this
    public int currentPoint;
    public int maxShield;
    public int currentShield;

    public HealthBar HealthBar;
    public PointBar PointBar;
    public ShieldBar ShieldBar;
    public HealthCounter HealthCounter;

    void Start()
    {
        PlayerStat("GOOFYAHH");
        PlayerBattleStat(1);
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        HealthCounter.SetHealthCounter(currentHealth);
        PointBar.SetMaxPoint(maxPoint);
        ShieldBar.SetMaxShield(maxShield);
    }


    void Update()
    {

    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        HealthBar.SetHealth(currentHealth);
        HealthCounter.SetHealthCounter(currentHealth);
    }

    private void PlayerStat(string _name)
    {
        name = _name;
        maxLevel = 10;
        level = 0;
        maxPoint = 8;
        currentEXP = 0;
        maxHealth = baseHealth + level * 5;
        maxShield = maxHealth;
    }

    private void PlayerBattleStat(int _startPoint)
    {
        currentPoint = _startPoint;
        currentShield = 0;
    }
}
