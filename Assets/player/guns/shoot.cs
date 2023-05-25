using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float attack_speed = 2f;
    public GameObject projectile;

    private int swap;
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
        Transform barl = transform.GetChild(1);
        time += Time.deltaTime * attack_speed;

        if (time >= 1)
        {

            Instantiate(projectile, new Vector3(
                barl.transform.position.x,
                barl.transform.position.y,
                barl.transform.position.z - .35f), new Quaternion(0, 0, 0, 0));
            time = 0;
        }
    }
}
