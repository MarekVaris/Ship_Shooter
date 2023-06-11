using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_enemy : MonoBehaviour
{
    public GameObject enemy_bullet;
    public float shooting_speed = 5f;

    private GameObject Shooted;
    private float time;
    private int swap;
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
        Transform gun1 = transform.GetChild(1);
        Transform gun2 = transform.GetChild(2);

        time += Time.deltaTime * shooting_speed;

        
        if (time > 30)
        {
            if (swap == 1)
            {
                Shooted = Instantiate(enemy_bullet, new Vector3(
                   gun1.transform.position.x,
                   gun1.transform.position.y,
                   gun1.transform.position.z + .2f), Quaternion.identity);
                   swap = 0;
            }
            else
            {
                Shooted = Instantiate(enemy_bullet, new Vector3(
                   gun2.transform.position.x,
                   gun2.transform.position.y,
                   gun2.transform.position.z + .2f), Quaternion.identity);
                   swap = 1;
            }

                Shooted.transform.SetParent(GameObject.Find("Projectiles").transform);
                time = 0;
        }
    }
}
