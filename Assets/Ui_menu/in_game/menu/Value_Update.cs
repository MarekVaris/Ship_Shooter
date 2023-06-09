using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Value_Update : MonoBehaviour
{
    public Slider Slider;
    public int Current_Gun;

    void Start()
    {
        if (gameObject.name == "Hp") Slider.value = Save_sys.instance.Hp;
        if (gameObject.name == "Speed") Slider.value = Save_sys.instance.Speed;
    }

    public void Update_Gun(int Gun_number)
    {
        Current_Gun = Gun_number;
        if (gameObject.name == "Dmg") Slider.value = Save_sys.instance.Dmg[Gun_number];
        if (gameObject.name == "Attack_Speed") Slider.value = Save_sys.instance.Attack_Speed[Gun_number];
    }
}
