using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Value_Update : MonoBehaviour
{
    public Slider Slider;
    void Start()
    {
        if (gameObject.name == "Hp") Slider.value = Save_sys.instance.Hp;
        if (gameObject.name == "Speed") Slider.value = Save_sys.instance.Speed;
    }
}
