using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Points_Shop_Update : MonoBehaviour
{
    private float Status;
    private float CurrentVelo;
    void Update()
    {
        float Value = Save_sys.instance.Points;
        float Current = Mathf.SmoothDamp(Status, Value, ref CurrentVelo, 1000 * Time.deltaTime);
        Status = Current;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Points: " + Math.Round(Current).ToString();
    }
}
