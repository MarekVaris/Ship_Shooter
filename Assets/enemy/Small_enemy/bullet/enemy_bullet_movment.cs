using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_movment : MonoBehaviour
{
    public float Speed= 5;
    public float Dmg = 1;

    void Start()
    {
        Speed += Save_sys.instance.Level * .2f;
        Dmg += Save_sys.instance.Level * .5f;

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
