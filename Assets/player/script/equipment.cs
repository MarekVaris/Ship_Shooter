using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class equipment : MonoBehaviour
{
    public GameObject parent_obj;
    public GameObject[] Gun_obj = new GameObject[4] { null, null, null, null };

    private shoot Current_gun;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < Gun_obj.Length; i++)
        {   
            if (Save_sys.instance.Gun_Saved[i] != null)
            {
                Transform location = parent_obj.transform.GetChild(i);
                Gun_obj[i] = Instantiate(Save_sys.instance.Gun_Saved[i], new Vector3(
                    location.transform.position.x,
                    location.transform.position.y,
                    location.transform.position.z),
                    location.transform.rotation);
                Current_gun = Gun_obj[i].GetComponent<shoot>();
                Current_gun.Gun_number = i;
                Gun_obj[i].transform.SetParent(location.transform);

            }
        }

    }

    public void Update_Guns(int Gun_Number)
    {
        if (Gun_obj[Gun_Number] != null)
        {
            Destroy(Gun_obj[Gun_Number]);
        }
        if (Save_sys.instance.Gun_Saved[Gun_Number] != null)
        {

            Transform location = parent_obj.transform.GetChild(Gun_Number);
            Gun_obj[Gun_Number] = Instantiate(Save_sys.instance.Gun_Saved[Gun_Number], new Vector3(
                location.transform.position.x,
                location.transform.position.y,
                location.transform.position.z),
                location.transform.rotation);
            Current_gun = Gun_obj[Gun_Number].GetComponent<shoot>();
            Current_gun.Gun_number = Gun_Number;
            Gun_obj[Gun_Number].transform.SetParent(location.transform);
        }
    }
}
