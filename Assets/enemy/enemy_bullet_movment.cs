using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_movment : MonoBehaviour
{
    public float Base_Speed;
    public float Dmg;
    public float Max_Dmg;
    public float Max_Speed = 5;


    void Start()
    {
        Base_Speed += Save_sys.instance.Level * .2f;
        Dmg += Save_sys.instance.Level * .3f;

        if (Dmg > Max_Dmg) Dmg = Max_Dmg;
        if (Base_Speed > Max_Speed) Base_Speed = Max_Speed;

        transform.rotation *= Quaternion.Euler(90, 0, 0);
    }


    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z + Time.deltaTime * Base_Speed);

        if (transform.position.z > 12)
        {
            Destroy(gameObject);
        }
    }
}
