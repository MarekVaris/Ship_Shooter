using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class spawning : MonoBehaviour
{

    public GameObject Enemy_Guy;
    public GameObject Enemy_Guy_Medium;
    public GameObject Enemy_Guy_Big;
    public float spawning_intens = 5f;
    public GameObject Follow;

    private GameObject Spawned;
    private BoxCollider boxCollider;
    private float random_x;
    private float random_z;
    private float Small_Enemy_Timer = 10;
    private float Medium_Enemy_Timer = 10;
    private float Big_Enemy_Timer = 5;
    private float Max_Intens = 15;
    void Start()
    {
        spawning_intens += Save_sys.instance.Level * 1.5f;

        if (Max_Intens < spawning_intens) spawning_intens = Max_Intens;
    }

    void Update()
    {
        if (Follow) gameObject.transform.position = new Vector3(Follow.transform.position.x, transform.position.y, transform.position.z);
        
        Small_Enemy_Timer += Time.deltaTime * spawning_intens;
        if (Small_Enemy_Timer > 10) {
            Spawn_Enemy(Enemy_Guy);
            Small_Enemy_Timer = 0;
        } 


        Medium_Enemy_Timer += Time.deltaTime * spawning_intens * .2f;
        if (Save_sys.instance.Level >= 2 && Medium_Enemy_Timer > 10)
        {
            Spawn_Enemy(Enemy_Guy_Medium);
            Medium_Enemy_Timer = 0;
        }

        Big_Enemy_Timer += Time.deltaTime * spawning_intens * .05f;
        if (Save_sys.instance.Level >= 4 && Big_Enemy_Timer > 10)
        {
            Spawn_Enemy(Enemy_Guy_Big);
            Big_Enemy_Timer = 0;
        }
    }

    private void Spawn_Enemy(GameObject Enemy_obj)
    {
        
        boxCollider = GetComponent<BoxCollider>();
        random_x = Random.Range(-boxCollider.size.x, boxCollider.size.x) * .5f;
        random_z = Random.Range(-boxCollider.size.z, boxCollider.size.z) * .5f;
        Small_Enemy_Timer = 0;
        
        Spawned = Instantiate(Enemy_obj, new Vector3(
                transform.position.x + random_x,
                transform.position.y,
                transform.position.z + random_z), Quaternion.identity);

        Spawned.transform.SetParent(GameObject.Find("Enemies").transform);
    }

}
