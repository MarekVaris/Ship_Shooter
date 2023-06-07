using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_Bar : MonoBehaviour
{
    private Slider Slider;

    void Start()
    {
        Slider = GetComponent<Slider>();
        Slider.maxValue = 30 + (10 * Save_sys.instance.Level);
        Slider.value = Slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
