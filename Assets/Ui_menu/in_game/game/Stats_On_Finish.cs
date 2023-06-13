using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Stats_On_Finish : MonoBehaviour
{
    public TextMeshProUGUI Current_Level;
    public TextMeshProUGUI Time_Spent;
    public TextMeshProUGUI Points_Earn;
    public TextMeshProUGUI Enemy_Kill;

    private float Points;
    private float EnemyKill;
    private float In_game_Time;
    private float Current_Points;
    private float Current_EnemyKill;
    private Data_In_Game Data;
    void Start()
    {
        int Level = Save_sys.instance.Level;
        Current_Level.text = "Level: " + Level.ToString() + " -> " + (Level+1).ToString();
    }

    private void Update()
    {
        if (Data)
        {


            float Status_P = Mathf.Lerp(Current_Points, Points, 5 * Time.deltaTime );
            float Status_E = Mathf.Lerp(Current_EnemyKill, EnemyKill, 5 * Time.deltaTime);

            Current_Points = Status_P;
            Current_EnemyKill = Status_E;

            Points_Earn.text = Math.Round(Current_Points).ToString();
            Enemy_Kill.text = Math.Round(Current_EnemyKill).ToString();
        }
    }

    public void Update_Stats()
    {
        Data = GameObject.Find("EventSystem").GetComponent<Data_In_Game>();

        Points = Data.Points;
        EnemyKill = Data.Enemy_Killed;
        Current_Points = 0;
        Current_EnemyKill = 0;
    }

    public void Back_To_Shop()
    {
        Data = GameObject.Find("EventSystem").GetComponent<Data_In_Game>();
        Save_sys.instance.Level += 1;
        Save_sys.instance.Points += Data.Points;
        Save_sys.instance.Shop_Start = true;
        Save_sys.instance.Save();

        SceneManager.LoadScene("Menu");
    }


}
