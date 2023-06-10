using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Power_Player : MonoBehaviour
{
    
    public Slider slider;
    public GameObject player;

    private Moving player_info;
    void Start()
    {
        player_info = player.GetComponent<Moving>();
        slider.maxValue = player_info.POWER;
        slider.value = player_info.POWER;
    }

    public void Update_Power(float POWER)
    {
        slider.value = POWER;
    }
}
