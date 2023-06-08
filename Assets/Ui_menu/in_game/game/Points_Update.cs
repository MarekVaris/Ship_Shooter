using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points_Update : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = GameObject.Find("EventSystem").GetComponent<Data_In_Game>().Points.ToString(); ;
    }
}
