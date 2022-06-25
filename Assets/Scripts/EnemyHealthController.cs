using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public Slider slider;
    // public Color low;
    // public Color high;
    //
    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position);
    }

    public void setHealth(float hitpoints, float maxHitpoints)
    {
        slider.maxValue = maxHitpoints;
        slider.value = hitpoints;
        // slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.value)2;
    }
}
