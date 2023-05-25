using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float attack_speed = 2f;
    public GameObject projectile;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        time += Time.deltaTime * attack_speed;

        if (time >= 1)
        {
            Instantiate(projectile, transform.position, new Quaternion(0, 0, 0, 0));
            time = 0;
        }
    }
}
