using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Enemy : MonoBehaviour
{
    public float HP = 20;
    public float Speed = 5;
    public ParticleSystem Expolsion;

    private GameObject Player_Ship;
    private health Health_Bar;
    private float Max_Hp = 50;
    private float Distance = 1;
    private float Random_Speed;

    void Start()
    {
        HP += Save_sys.instance.Level * .5f;

        if (Max_Hp < HP) HP = Max_Hp;

        Health_Bar = GetComponentInChildren<health>();
        Health_Bar.Hp_Update(HP);

        Random_Speed = Random.Range(.4f, .2f);
    }

    void Update()
    {
        Player_Ship = GameObject.Find("player_ship");
        if (Player_Ship != null)
        {
            Move_Big_Enemy();
            Destroy_On();
        }
        else transform.rotation = new Quaternion(0, 0, 0, 20);

    }

    private void Destroy_On()
    {
        if (HP <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Big_Dead");
            gameObject.transform.Find("Health").gameObject.SetActive(false);
        }
    }

    public void Destroy_Enemy()
    {
        gameObject.GetComponent<Update_Game>().Update_Game_Components_on_dead();
        Instantiate(Expolsion, transform.Find("Body").position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Move_Big_Enemy()
    {

        transform.rotation = new Quaternion(Speed * .2f, 0, gameObject.transform.position.x - Player_Ship.transform.position.x, 40);
        if (Distance < 0) Distance *= -1;

        gameObject.transform.position = Vector3.Lerp(
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),
            new Vector3(Player_Ship.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),
            Time.deltaTime * Random_Speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if (other.gameObject.name == "BumGun_bullet")
            {
                HP -= other.transform.parent.GetComponent<move_projectile>().Standard_Dmg;
                Health_Bar.Health_bar(HP);
            }
            else
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
}
