using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject Enemy_guy;
    public float spawning_intens = 5f;

    private BoxCollider boxCollider;
    private float random_x;
    private float random_z;
    private float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * spawning_intens;

        if(timer > 10)
        {
            boxCollider = GetComponent<BoxCollider>(); 
            random_x = Random.Range(-boxCollider.size.x, boxCollider.size.x) * .5f;
            random_z = Random.Range(-boxCollider.size.z, boxCollider.size.z) * .5f;
            timer = 0;

            Instantiate(Enemy_guy, new Vector3(
                transform.position.x + random_x,
                transform.position.y,
                transform.position.z + random_z), Quaternion.identity);

        }

    }
}