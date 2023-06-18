using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save_sys : MonoBehaviour
{
    public static Save_sys instance { get; private set; }

    //Game
    public int Level;
    public int Points;
    public float Valume_settings;

    // Body Upgrade
    public int Hp;
    public int Speed;

    // Guns Upgrade
    public GameObject[] Gun_Saved = new GameObject[4];
    public int[] Dmg = new int[4];
    public int[] Attack_Speed = new int[4];

    public bool Shop_Start = false;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
        AudioListener.volume = Save_sys.instance.Valume_settings;
    }

    public void Save(int current_gun = 0)
    {
        string filePath = Application.dataPath + "/Save_system/player_data.json";
        Player_Data data = new Player_Data();

        data.Valume_settings = Valume_settings;
        data.Level = Level;
        data.Points = Points;   
        data.Hp = Hp;
        data.Speed = Speed;
        data.Dmg = Dmg;
        data.Gun_Saved = Gun_Saved;
        data.Attack_Speed = Attack_Speed;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, jsonData);
    }

    public void Load()
    {
        string filePath = Application.dataPath + "/Save_system/player_data.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            Player_Data data = JsonUtility.FromJson<Player_Data>(jsonData);

            Valume_settings = data.Valume_settings;
            Level = data.Level;
            Points = data.Points;
            Hp = data.Hp;
            Speed = data.Speed;
            Dmg = data.Dmg;
            Gun_Saved = data.Gun_Saved;
            Attack_Speed = data.Attack_Speed;
        }
    }
}

[Serializable]
class Player_Data
{
    public float Valume_settings;
    public int Level;
    public int Points;
    public int Hp;
    public int Speed;
    public GameObject[] Gun_Saved;
    public int[] Dmg;
    public int[] Attack_Speed;
}
