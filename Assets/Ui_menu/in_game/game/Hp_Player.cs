using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hp_Player : MonoBehaviour
{
    
    public Slider slider;
    public GameObject player;

    private Moving player_info;
    void Start()
    {
        player_info = player.GetComponent<Moving>();
        slider.maxValue = player_info.HP;
        slider.value = player_info.HP;
    }

    public void Update_Hp(float HP)
    {
        slider.value = HP;
    }
}
