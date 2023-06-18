using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_movment : MonoBehaviour
{
    public float Speed= 5;
    public float Dmg = 1;
    public float Max_Dmg = 20;

    private float Max_Speed = 5;

    void Start()
    {
        Speed += Save_sys.instance.Level * .2f;
        Dmg += Save_sys.instance.Level * .3f;

        if (Dmg > Max_Dmg) Dmg = Max_Dmg;
        if (Speed > Max_Speed) Speed = Max_Speed;

        transform.rotation *= Quaternion.Euler(90, 0, 0);
    }


    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z + Time.deltaTime * Speed);

        if (transform.position.z > 12)
        {
            Destroy(gameObject);
        }
    }
}
