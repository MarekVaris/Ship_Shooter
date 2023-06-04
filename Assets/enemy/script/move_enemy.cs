using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move_enemy : MonoBehaviour
{
    public float ver_speed = 3f;
    public float speed = 2f;
    public float HP = 3f;
    public ParticleSystem explosion;


    private GameObject hitted_by;
    private float move_hori = 1f;
    private int left = 0;
    private int stop = 0;
    private health health_bar;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stop = Random.Range(2, 6);
        health_bar = GetComponentInChildren<health>();
    }

    void Update()
    {
        destroy_when();
        Move();
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
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "bullet" && hitted_by != other.gameObject)
        {
            hitted_by = other.gameObject;
            HP -= hitted_by.GetComponent<move_projectile>().Projectile_Dmg;
            health_bar.Health_bar(HP);
            Destroy(other.gameObject);
        }
    }
}
