using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    public Slider slider;
    private move_enemy enemy_helth;
    // Start is called before the first frame update
    void Start()
    {
        enemy_helth = GetComponentInParent<move_enemy>();
        slider.maxValue = enemy_helth.HP;
        slider.value = enemy_helth.HP;
        gameObject.active = false;
    }

    void Update()
    {

    }

    public void Health_bar(float hp)
    {
        gameObject.active = true;
        slider.value = hp;
    }
}
