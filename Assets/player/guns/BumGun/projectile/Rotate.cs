using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float Hori = 0;
    private float Speed;
    private int Stop;
    private int Left;
    private void Start()
    {
        Left = Random.Range(0, 2);
        Stop = Random.Range(10,15);
        Speed = transform.GetComponentInParent<move_projectile>().Speed * 4;

    }

    void Update()
    {
        transform.Rotate(new  Vector3(0f, 0f, 400f) * Time.deltaTime);
        Move();

    }

    private void Move()
    {
        if (Left == 0)
        {
            Hori += Time.deltaTime * 1.2f * Speed;
            if (Hori > Stop)
            {
                Left = 1;
            }
        }
        else if (Left == 1)
        {
            Hori -= Time.deltaTime * 1.2f * Speed;
            if (Hori < -Stop)
            {
                Left = 0;
            }
        }
        transform.position = new Vector3(transform.position.x + Hori * Time.deltaTime, 0, transform.position.z);

    }
}
