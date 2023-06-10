using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Medium_Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float HP = 3f;

    private health Health_Bar;
    void Start()
    {
        Health_Bar = GetComponentInChildren<health>();
        Health_Bar.Hp_Update(HP);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            HP -= other.GetComponent<move_projectile>().Standard_Dmg;
            Health_Bar.Health_bar(HP);
            if (other.gameObject.name != "Sniper_bullet(Clone)")
            {
                Destroy(other.gameObject);
            }

        }
    }
}
