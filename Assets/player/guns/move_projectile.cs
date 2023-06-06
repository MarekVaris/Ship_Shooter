using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move_projectile : MonoBehaviour
{
    public float Speed = 15f;
    public int Projectile_Dmg;
    // Start is called before the first frame update
    void Start()
    {
        Projectile_Dmg += 2;
        transform.rotation *= Quaternion.Euler(90, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - Speed * Time.deltaTime);

        if (transform.position.z < -80)
        {
            Destroy(gameObject);
        }
    }
    
}
