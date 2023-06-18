using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class spawning : MonoBehaviour
{

    public GameObject Enemy_Guy;
    public GameObject Enemy_Guy_Medium;
    public float spawning_intens = 5f;
    public GameObject Follow;

    private GameObject Spawned;
    private BoxCollider boxCollider;
    private float random_x;
    private float random_z;
    private float Small_Enemy_Timer = 10;
    private float Medium_Enemy_Timer = 10;
    private float Max_Intens = 15;
    void Start()
    {
        spawning_intens += Save_sys.instance.Level;

        if (Max_Intens < spawning_intens) spawning_intens = Max_Intens;
    }

    void Update()
    {
        if (Follow) gameObject.transform.position = new Vector3(Follow.transform.position.x, transform.position.y, transform.position.z);

        Spawn_Small_Enemy();
        if (Save_sys.instance.Level >= 2) Spawn_Medium_Enemy();
    }

    private void Spawn_Small_Enemy()
    {
        Small_Enemy_Timer += Time.deltaTime * spawning_intens;
        if (Small_Enemy_Timer > 10)
        {
            boxCollider = GetComponent<BoxCollider>();
            random_x = Random.Range(-boxCollider.size.x, boxCollider.size.x) * .5f;
            random_z = Random.Range(-boxCollider.size.z, boxCollider.size.z) * .5f;
            Small_Enemy_Timer = 0;

            Spawned = Instantiate(Enemy_Guy, new Vector3(
                transform.position.x + random_x,
                transform.position.y,
                transform.position.z + random_z), Quaternion.identity);

            Spawned.transform.SetParent(GameObject.Find("Enemies").transform);
        }
    }

    private void Spawn_Medium_Enemy()
    {
        Medium_Enemy_Timer += Time.deltaTime * spawning_intens *.2f;
        if (Medium_Enemy_Timer > 10)
        {
            boxCollider = GetComponent<BoxCollider>();
            random_x = Random.Range(-boxCollider.size.x, boxCollider.size.x) * .5f;
            random_z = Random.Range(-boxCollider.size.z, boxCollider.size.z) * .5f;
            Medium_Enemy_Timer = 0;

            Spawned = Instantiate(Enemy_Guy_Medium, new Vector3(
                transform.position.x + random_x,
                transform.position.y,
                transform.position.z + random_z), Quaternion.identity);

            Spawned.transform.SetParent(GameObject.Find("Enemies").transform);
        }
    }
}
