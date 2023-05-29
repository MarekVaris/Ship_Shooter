using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class equipment : MonoBehaviour
{
    public GameObject parent_obj;
    public GameObject gun1_obj;
    public GameObject gun2_obj;
    public GameObject gun3_obj;
    public GameObject gun4_obj;
    // Start is called before the first frame update
    void Start()
    {
        if (gun1_obj != null)
        {
            Transform location = parent_obj.transform.GetChild(0);
            GameObject gun = Instantiate(gun1_obj, new Vector3(
                location.transform.position.x + .03f,
                location.transform.position.y,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }

        if (gun2_obj != null)
        {
            Transform location = parent_obj.transform.GetChild(1);
            GameObject gun = Instantiate(gun2_obj, new Vector3(
                location.transform.position.x - .03f,
                location.transform.position.y,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }

        if (gun3_obj != null)
        {
            Transform location = parent_obj.transform.GetChild(2);
            GameObject gun = Instantiate(gun1_obj, new Vector3(
                location.transform.position.x + .02f,
                location.transform.position.y + .05f,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }

        if (gun4_obj != null)
        {
            Transform location = parent_obj.transform.GetChild(3);
            GameObject gun = Instantiate(gun2_obj, new Vector3(
                location.transform.position.x - .02f,
                location.transform.position.y + .05f,
                location.transform.position.z),
                location.transform.rotation);

            gun.transform.SetParent(location.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
