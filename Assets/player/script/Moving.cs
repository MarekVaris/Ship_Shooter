using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Moving : MonoBehaviour
{
    public int HP = 10;
    public float speed = 3f;
    public float rotatnion_speed = 3f;

    private GameObject hitted_by;
    private float move_x;
    private float move_z;
    private float move_hori = 0.1f;
    private float move_ver = 0.1f;

    public float move_rotate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            move_x = Input.GetAxis("Horizontal");
            move_z = Input.GetAxis("Vertical");
            Move();
            Game_over();

    }

    private void Move()
    {

        if (move_x != 0 || move_z != 0)
        {

            if (transform.position.x < -13) move_x -= 1f;
            else if (transform.position.x > 13) move_x += 1f;
            if (transform.position.z > 4) move_z += 1f;
            else if (transform.position.z < -10) move_z -= 1f;

            transform.position = new Vector3(
                transform.position.x - move_x * speed * Time.deltaTime,
                transform.position.y,
                transform.position.z - move_z * speed * Time.deltaTime);

        }

        move_hori -= Time.deltaTime * move_x * move_rotate * rotatnion_speed;
        move_ver -= Time.deltaTime * move_z * move_rotate * rotatnion_speed;

        if (move_hori > 0) move_hori -= Time.deltaTime * move_rotate;
        else if (move_hori < 0) move_hori += Time.deltaTime * move_rotate;

        if (move_hori > 5) move_hori = 5;
        else if (move_hori < -5) move_hori = -5;

        if (move_ver > 5) move_ver = 5;
        else if (move_ver < -5) move_ver = -5;

        if (move_ver > 0) move_ver -= Time.deltaTime * move_rotate;
        else if (move_ver < 0) move_ver += Time.deltaTime * move_rotate;

        if ((-0.5 < move_x && move_x < .5) && (-0.5 < move_z && move_z < .5)) move_rotate = 10f;
        else move_rotate = 2f;
        

        if (move_hori >= .1 || move_hori <= -.1 || move_ver >= .1 || move_ver <= -.1)
        {
            transform.rotation = new Quaternion(-move_ver, move_hori * .5f, move_hori, -50);
        }
        else
        {
            move_rotate = 2f; 
        }

    }

    private void Game_over()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "enemy_bullet" && hitted_by != other.gameObject)
        {
            hitted_by = other.gameObject;
            HP -= 1;
            Destroy(other.gameObject);
        }
    }
}
