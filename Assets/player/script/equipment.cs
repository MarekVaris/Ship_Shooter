using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour
{
    public GameObject parent_obj;
    public GameObject gun1_obj;
    public GameObject gun2_obj;
    // Start is called before the first frame update
    void Start()
    {
        if (gun1_obj != null)
        {
            Transform location1 = parent_obj.transform.GetChild(0);
            GameObject gun1 = Instantiate(gun1_obj, new Vector3(
                location1.transform.position.x + .02f,
                location1.transform.position.y + .05f,
                location1.transform.position.z),
                location1.transform.rotation);

            gun1.transform.SetParent(location1.transform);
        }
        if (gun2_obj != null)
        {
            Transform location2 = parent_obj.transform.GetChild(1);
            GameObject gun1 = Instantiate(gun2_obj, new Vector3(
                location2.transform.position.x + .02f,
                location2.transform.position.y + .05f,
                location2.transform.position.z),
                location2.transform.rotation);

            gun1.transform.SetParent(location2.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
