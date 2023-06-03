using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class Save_sys : MonoBehaviour
{
    public static Save_sys instance { get; private set; }

    //Body Upgrade
    public int Hp;
    public int Speed;


    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Save_system/player_data.dat");
        Player_Data data = new Player_Data();

        data.Hp = Hp;
        data.Speed = Speed;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/Save_system/player_data.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/Save_system/player_data.dat", FileMode.Open);
            Player_Data data = (Player_Data)bf.Deserialize(file);

            Hp = data.Hp;
            Speed = data.Speed;
        }
    }
}

[Serializable]
class Player_Data
{
    public int Hp;
    public int Speed;
}
