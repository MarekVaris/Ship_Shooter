using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Slider : MonoBehaviour
{
    public float Status_Value;
    
    private Slider Slider;

    private void Start()
    {
        GameObject Satus_bar = GameObject.Find("Status_Bar_value");
        Slider = Satus_bar.GetComponent<Slider>();
    }
    public void Update_slider()
    {
        Slider.value -= Status_Value;
    }
}
