using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_In_Game : MonoBehaviour
{
    public int Points;
    public int Enemy_Killed;
    public float Timer;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        Timer = Time.time - startTime;
    }
}
