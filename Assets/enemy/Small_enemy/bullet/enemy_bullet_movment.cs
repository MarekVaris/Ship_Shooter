using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_movment : MonoBehaviour
{
    public float speed= 5;
    public float Dmg = 1;
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
            transform.position.z + Time.deltaTime * speed);

        if (transform.position.z > 7)
        {
            Destroy(gameObject);
        }
    }
}
