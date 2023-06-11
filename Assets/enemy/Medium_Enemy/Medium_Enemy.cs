using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Medium_Enemy : MonoBehaviour
{
    public float HP = 3;
    public float Speed = 5;

    private GameObject Player_Ship;
    private health Health_Bar;
    private float Distance = 1;
    private float Random_Dis;
    private float Random_Speed;
    private float CurrentVelo;

    void Start()
    {
        Health_Bar = GetComponentInChildren<health>();
        Health_Bar.Hp_Update(HP);

        Random_Dis = Random.Range(20.0f, 25.0f);
        Random_Speed = Random.Range(.4f, 1.2f);
    }

    void Update()
    {
        Player_Ship = GameObject.Find("player_ship");
        if (Player_Ship != null )
        {
            Move_Medium_Enemy();
            Destroy_On();
        }
        else transform.rotation = new Quaternion(0,0,0, 20);



    }

    private void Destroy_On()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move_Medium_Enemy()
    {

        if (Player_Ship.transform.position.z - Random_Dis < gameObject.transform.position.z )
        {
            float Current = Mathf.SmoothDamp(Speed, 0, ref CurrentVelo, 200 * Time.deltaTime);
            Speed = Current;
            if (gameObject.transform.position.z > Player_Ship.transform.position.z - 10) Speed = .1f;
        }
        
        transform.rotation = new Quaternion(Speed * .2f, 0, gameObject.transform.position.x - Player_Ship.transform.position.x, 20);
        if (Distance < 0) Distance *= -1;

        gameObject.transform.position = Vector3.Lerp(
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),
            new Vector3(Player_Ship.transform.position.x, gameObject.transform.position.y , gameObject.transform.position.z + Speed),
            Time.deltaTime * Random_Speed);

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
