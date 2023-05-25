using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move_enemy : MonoBehaviour
{
    public float ver_speed = 3f;
    public float speed = 2f;
    public float HP = 3f;
    public GameObject enemy_bullet;
    public float shooting_speed = 3f;

    private GameObject hitted_by;
    private float time;
    private float move_hori = 1f;
    private int swap;
    private int left = 0;
    private int stop = 0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stop = Random.Range(2, 6);

        

    }

    // Update is called once per frame
    void Update()
    {
        destroy_when();
        Move();
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
                Instantiate(enemy_bullet, new Vector3(
                    gun1.transform.position.x,
                    gun1.transform.position.y,
                    gun1.transform.position.z + .2f), Quaternion.identity);
                swap = 0;
            }
            else
            {
                Instantiate(enemy_bullet, new Vector3(
                    gun2.transform.position.x,
                    gun2.transform.position.y,
                    gun2.transform.position.z + .2f), Quaternion.identity);
                swap = 1;
            }
            time = 0;
        }
    }
    private void Move()
    {

        if (left == 0)
        {
            move_hori += Time.deltaTime * 1.2f * ver_speed;
            if (move_hori > stop)
            {
                left = 1;
            }
        }
        else if (left == 1)
        {
            move_hori -= Time.deltaTime * 1.2f * ver_speed;
            if (move_hori < -stop)
            {
                left = 0;
            }
        }

        transform.position = new Vector3(
            transform.position.x + move_hori * Time.deltaTime,
            0,
            transform.position.z + speed * Time.deltaTime);

        transform.rotation = new Quaternion(0 , 0, move_hori, -20);

    }
    private void destroy_when()
    {
        if (transform.position.z > 10f)
        {
            Destroy(gameObject);
        }

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "bullet" && hitted_by != other.gameObject)
        {
            hitted_by = other.gameObject;
            HP -= 1;
            Destroy(other.gameObject);
        }
    }
}
