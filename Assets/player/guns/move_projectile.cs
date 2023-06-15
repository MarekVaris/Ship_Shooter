using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move_projectile : MonoBehaviour
{
    public float Speed = 15f;
    public float Standard_Dmg = 5f;
    public int Projectile_Dmg;

    void Start()
    {
        if (gameObject.name == "Sniper(Clone)") Standard_Dmg += 1.5f * Projectile_Dmg;
        else Standard_Dmg += .5f * Projectile_Dmg;
        transform.rotation *= Quaternion.Euler(90, 180, 0);
    }

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
