using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public Text CurrentHealth;

    public void SetHealthCounter(int _health)
    {
        CurrentHealth.text = _health.ToString();
    }
}
