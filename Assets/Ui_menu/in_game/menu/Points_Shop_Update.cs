using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Points_Shop_Update : MonoBehaviour
{
    void Update()
    {
        int Points = Save_sys.instance.Points;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Points: " + Points.ToString();
    }
}
