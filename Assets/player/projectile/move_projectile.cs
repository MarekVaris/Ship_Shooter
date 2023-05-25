using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move_projectile : MonoBehaviour
{
    public float speed_proj = 15f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation *= Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - speed_proj * Time.deltaTime);

        if (transform.position.z < -80)
        {
            Destroy(gameObject);
        }
    }
    
}
