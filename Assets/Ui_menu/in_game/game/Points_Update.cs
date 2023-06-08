using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points_Update : MonoBehaviour
{   
    private float Status = 0;
    private float CurrentVelo;
    void Update()
    {

        float Points = GameObject.Find("EventSystem").GetComponent<Data_In_Game>().Points;
        float Current = Mathf.SmoothDamp(Status, Points, ref CurrentVelo, 100 * Time.deltaTime);
        Status = Current;
        gameObject.GetComponent<TextMeshProUGUI>().text =  ((int)Current).ToString();
    }
}

