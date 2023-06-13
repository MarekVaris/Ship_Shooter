using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Points_Shop_Update : MonoBehaviour
{
    private float Status;
    void Update()
    {
        float Value = Save_sys.instance.Points;
        float Current = Mathf.Lerp(Status, Value, 5 * Time.deltaTime);
        Status = Current;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Points: " + Math.Round(Current).ToString();
    }
}
