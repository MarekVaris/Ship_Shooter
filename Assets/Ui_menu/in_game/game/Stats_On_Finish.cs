using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats_On_Finish : MonoBehaviour
{
    public TextMeshProUGUI Current_Level;
    public TextMeshProUGUI Time_Spent;
    public TextMeshProUGUI Points_Earn;
    public TextMeshProUGUI Enemy_Kill;

    private Data_In_Game Data;
    void Start()
    {
        int Level = Save_sys.instance.Level;
        Current_Level.text = "Level: " + Level.ToString() + " -> " + (Level+1).ToString();

        Save_sys.instance.Level += 1;
    }

    public void Update_Stats()
    {
        Data = GameObject.Find("EventSystem").GetComponent<Data_In_Game>();

        Points_Earn.text = Data.Points.ToString();
        Enemy_Kill.text = Data.Enemy_Killed.ToString();
    }

    public void Back_To_Shop()
    {
        Data = GameObject.Find("EventSystem").GetComponent<Data_In_Game>();

        Save_sys.instance.Points += Data.Points;
        Save_sys.instance.Shop_Start = true;
        Save_sys.instance.Save();

        SceneManager.LoadScene("Menu");
    }


}
