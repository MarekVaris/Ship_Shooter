using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class equipment : MonoBehaviour
{
    public GameObject parent_obj;
    public GameObject[] gun_obj;
    // Start is called before the first frame update
    void Start()
    {
        if (gun_obj[0] != null)
        {
            Transform location = parent_obj.transform.GetChild(0);
            GameObject gun = Instantiate(gun_obj[0], new Vector3(
                location.transform.position.x + .03f,
                location.transform.position.y,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }

        if (gun_obj[1] != null)
        {
            Transform location = parent_obj.transform.GetChild(1);
            GameObject gun = Instantiate(gun_obj[1], new Vector3(
                location.transform.position.x - .03f,
                location.transform.position.y,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }

        if (gun_obj[2] != null)
        {
            Transform location = parent_obj.transform.GetChild(2);
            GameObject gun = Instantiate(gun_obj[2], new Vector3(
                location.transform.position.x + .02f,
                location.transform.position.y + .05f,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }

        if (gun_obj[3] != null)
        {
            Transform location = parent_obj.transform.GetChild(3);
            GameObject gun = Instantiate(gun_obj[3], new Vector3(
                location.transform.position.x - .02f,
                location.transform.position.y + .05f,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }
    }

    
}
