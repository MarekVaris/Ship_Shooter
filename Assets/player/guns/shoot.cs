using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shoot : MonoBehaviour
{
    public float Attack_speed = 5;
    public int Gun_number;
    public GameObject Projectile;

    private int Dmg;
    private int Speed;
    private float time;
    private GameObject Shooted;

    void Start()
    {
        Dmg = Save_sys.instance.Dmg[Gun_number];
        Speed = Save_sys.instance.Attack_Speed[Gun_number];

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "Game")
        {
            this.enabled = false;
        }
    }


    void Update()
    {

        Shoot();

    }
    private void Shoot()
    {
        Transform barl = transform.GetChild(1);
        time += Time.deltaTime * ( Attack_speed + Speed );

        if (time >= 10)
        {

            Shooted = Instantiate(Projectile, new Vector3(
                barl.transform.position.x,
                barl.transform.position.y,
                barl.transform.position.z - .35f), new Quaternion(0, 0, 0, 0));

            Shooted.GetComponent<move_projectile>().Projectile_Dmg = Dmg;
            Shooted.transform.SetParent(GameObject.Find("Projectiles").transform);    
            time = 0;
        }
    }
}
