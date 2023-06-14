using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move_enemy : MonoBehaviour
{
    public float Ver_Speed = 3f;
    public float Speed = 2f;
    public float HP = 3f;
    public ParticleSystem explosion;

    private health Health_Bar;
    private float move_hori = 1f;
    private bool left = false;
    private int stop = 0;

    void Start()
    {
        Health_Bar = GetComponentInChildren<health>();
        Health_Bar.Hp_Update(HP);
        stop = Random.Range(2, 6);
    }

    void Update()
    {
        destroy_when();
        Move();
    }
    private void Move()
    {

        if (left == false)
        {
            move_hori += Time.deltaTime * 1.2f * Ver_Speed;
            if (move_hori > stop)
            {
                left = true;
            }
        }
        else if (left == true)
        {
            move_hori -= Time.deltaTime * 1.2f * Ver_Speed;
            if (move_hori < -stop)
            {
                left = false;
            }
        }

        transform.position = new Vector3(
            transform.position.x + move_hori * Time.deltaTime,
            0,
            transform.position.z + Speed * Time.deltaTime);

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
            
            gameObject.GetComponent<Animator>().SetTrigger("Start_Destroy_Animation");
            gameObject.transform.Find("Health").gameObject.SetActive(false);
        }
    }

    public void Destroy_Enemy()
    {
        gameObject.GetComponent<Update_Game>().Update_Game_Components_on_dead();
        Instantiate(explosion, transform.Find("Cube").position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            HP -= other.GetComponent<move_projectile>().Standard_Dmg;
            Health_Bar.Health_bar(HP);
            if (other.gameObject.name != "Sniper_bullet(Clone)")
            {
                Destroy(other.gameObject);
            }

        }
    }
}
