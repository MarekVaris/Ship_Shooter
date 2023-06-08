using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Status_Bar : MonoBehaviour
{
    public PlayableDirector Timeline;
    public GameObject Ui_Finish;

    private Slider Slider;
    void Start()
    {

        Slider = GetComponent<Slider>();
        Slider.maxValue = 30 + (10 * Save_sys.instance.Level);
        Slider.value = Slider.maxValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Timeline.Play();
            Ui_Finish.gameObject.GetComponent<Stats_On_Finish>().Update_Stats();
            Ui_Finish.SetActive(true);
        }
    }
}
