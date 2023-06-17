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


    public AudioSource audioSource;
    public AudioClip clip;
    public Moving PO;

    private int Dmg;
    private int Speed;
    private float time;
    private GameObject Shooted;

    void Start()
    {
        if (transform.parent.name == "gun_holder1") time = 0;
        if (transform.parent.name == "gun_holder2") time = 3;
        if (transform.parent.name == "gun_holder3") time = 6;
        if (transform.parent.name == "gun_holder4") time = 9;

        Dmg = Save_sys.instance.Dmg[Gun_number];
        Speed = Save_sys.instance.Attack_Speed[Gun_number];

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "Game")
        {
            this.enabled = false;
        }

        PO = FindObjectOfType<Moving>();
    }


    void Update()
    {
        if (transform.parent.parent.parent.GetComponent<Moving>().Active_Guns)
        {
            Shoot();
        }

    }
    private void Shoot()
    {

        float Power = PO.POWER;

        if (Input.GetKey(KeyCode.Space))
        {
            if (Power > 0)
            {
                time += Time.deltaTime * ( Attack_speed * 3 + Speed ); 
            }
            else
            {
                time += Time.deltaTime * ( Attack_speed + Speed );
            }
        }
        else
        {
            time += Time.deltaTime * ( Attack_speed + Speed );
        }

        Transform barl = transform.GetChild(0);

        if (time >= 10)
        {

            Shooted = Instantiate(Projectile, new Vector3(
                barl.transform.position.x,
                barl.transform.position.y,
                barl.transform.position.z - .35f), new Quaternion(0, 0, 0, 0));

            ParticleSystem Particle_System = GetComponentInChildren<ParticleSystem>();
            Particle_System.Play();
            Shooted.GetComponent<move_projectile>().Projectile_Dmg = Dmg;
            Shooted.transform.SetParent(GameObject.Find("Projectiles").transform);    
            time = 0;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

        }
    }
}
