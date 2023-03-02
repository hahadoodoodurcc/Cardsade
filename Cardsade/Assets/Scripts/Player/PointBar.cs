using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPoint(int _point)
    {
        slider.maxValue = _point;
        slider.value = 0;
    }

    public void SetPoint(int _point)
    {
        slider.value = _point;
    }
}
