using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    public Slider slider;

    public void Hp_Update(float HP)
    {
        slider.maxValue = HP;
        slider.value = HP;
        gameObject.SetActive(false);
    }

    public void Health_bar(float HP)
    {
        gameObject.SetActive (true);
        slider.value = HP;
    }
}
