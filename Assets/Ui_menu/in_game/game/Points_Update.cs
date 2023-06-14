using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points_Update : MonoBehaviour
{   
    private float Status = 0;

    void Update()
    {

        float Points = GameObject.Find("EventSystem").GetComponent<Data_In_Game>().Points;
        float Current = Mathf.Lerp(Status, Points, 5 * Time.deltaTime);
        Status = Current;
        gameObject.GetComponent<TextMeshProUGUI>().text = Math.Round(Current).ToString();
    }
}

