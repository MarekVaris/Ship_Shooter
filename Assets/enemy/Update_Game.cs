using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Update_Game : MonoBehaviour
{
    public float Status_Value;
    public int Add_Points;

    private Slider Slider;
    private Data_In_Game Data;

    private void Start()
    {
        Slider = GameObject.Find("Status_Bar_value").GetComponent<Slider>();
        
    }
    public void Update_Game_Components_on_dead()
    {
        Data = GameObject.Find("EventSystem").GetComponent<Data_In_Game>();

        Slider.value -= Status_Value;
        Data.Points += Add_Points;
        Data.Enemy_Killed += 1;
    }
}
