using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shoot : MonoBehaviour
{
    public float attack_speed = 2f;
    public GameObject projectile;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Menu")
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();

    }
    private void Shoot()
    {
        Transform barl = transform.GetChild(1);
        time += Time.deltaTime * attack_speed;

        if (time >= 1)
        {

            Instantiate(projectile, new Vector3(
                barl.transform.position.x,
                barl.transform.position.y,
                barl.transform.position.z - .35f), new Quaternion(0, 0, 0, 0));
            time = 0;
        }
    }
}
