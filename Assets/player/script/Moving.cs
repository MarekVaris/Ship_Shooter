using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Moving : MonoBehaviour
{
    public float HP = 10;
    public float Speed = 2f;
    public float move_rotate = 2f;
    public game_over_scene GameOver;
    public Hp_Player Ui_Hp_Player;
    public ParticleSystem Dead_explosion;


    private GameObject hitted_by;
    private float move_x;
    private float move_z;
    private float move_hori = 0.1f;
    private float move_ver = 0.1f;

    void Start()
    {
        HP += 10 * Save_sys.instance.Hp;
        Speed += Save_sys.instance.Speed;

    }

    void Update()
    {
        if (HP <= 0)
        {
            Game_over();
        }
        else
        {
            move_x = Input.GetAxis("Horizontal");
            move_z = Input.GetAxis("Vertical");
            Move();
        }
        
    }

    private void Move()
    {

        if (move_x != 0 || move_z != 0)
        {

            if (transform.position.z > 4) move_z += 1f;
            else if (transform.position.z < -10) move_z -= 1f;

            transform.position = new Vector3(
                transform.position.x - move_x * Speed * Time.deltaTime,
                transform.position.y,
                transform.position.z - move_z * Speed * Time.deltaTime);

        }

        move_hori -= Time.deltaTime * move_x * move_rotate * Speed;
        move_ver -= Time.deltaTime * move_z * move_rotate * Speed;

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
        GameOver.Setup();
        Instantiate(Dead_explosion, transform.position, Dead_explosion.transform.rotation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "enemy_bullet" && hitted_by != other.gameObject)
        {
            hitted_by = other.gameObject;
            HP -= 1;
            Ui_Hp_Player.Update_Hp(HP);
            Destroy(other.gameObject);
        }
    }
}
