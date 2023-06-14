using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Status_Bar : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Ui_Finish;
    public GameObject Text;
    public GameObject Player;

    private bool Active = true;
    private Slider Slider;
    void Start()
    {

        Slider = GetComponent<Slider>();
        Slider.maxValue = 30 + (10 * Save_sys.instance.Level);
        Slider.value = Slider.maxValue;
    }

    private void Update()
    {
        if (Slider.value <= 0)
        {
            Text.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && Player && Active)
            {
                Active = false;
                Timeline.Play();
                Player.GetComponent<Moving>().enabled = false;
                Ui_Finish.gameObject.GetComponent<Stats_On_Finish>().Update_Stats();
                Ui_Finish.SetActive(true);
                
            }
        }
    }
}
