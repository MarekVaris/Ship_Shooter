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
            GameObject gun1 = Instantiate(gun1_obj, location1.localPosition * .5f, location1.localRotation);
            gun1.transform.SetParent(parent_obj.transform);
        }
        if (gun2_obj != null)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
