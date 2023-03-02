using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxShield(int _shield)
    {
        slider.maxValue = _shield;
        slider.value = 0;
    }

    public void SetShield(int _shield)
    {
        slider.value = _shield;
    }
}
