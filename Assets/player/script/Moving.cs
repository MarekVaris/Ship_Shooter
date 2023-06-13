using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Moving : MonoBehaviour
{

    public ImgsFillDynamic ImgsFD_HP;
    public ImgsFillDynamic ImgsFD_POWER;


    private float UI_HP = 1f;
    public float HP = 10;
    private float MAX_HP;
    public float Speed = 2f;
    public float move_rotate = 2f;
    public game_over_scene GameOver;
    public Hp_Player Ui_Hp_Player;
    public Power_Player Ui_Power_Player;
    public ParticleSystem Dead_explosion;
    

    public float maxPower = 100;
    public float minPower = 0; 

    private float _power = 100;
    private float UI_POWER_1 = 1f;

    public float maxUI_POWER = 1f;
    public float minUI_POWER = 0f; 
    
    public float POWER
    {
        get { return _power; }
        set { _power = Mathf.Clamp(value, minPower, maxPower); }
    }

    public float UI_POWER
    {
        get { return UI_POWER_1; }
        set { UI_POWER_1 = Mathf.Clamp(value, minUI_POWER, maxUI_POWER); }
    }


    private GameObject hitted_by;
    private float move_x;
    private float move_z;
    private float move_hori = 0.1f;
    private float move_ver = 0.1f;

    void Start()
    {
        this.ImgsFD_HP.SetValue(1f, false, 2f);
        this.ImgsFD_POWER.SetValue(1f, false, 2f);
        MAX_HP = HP;
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
            Bonus_Power();

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
            HP -= other.GetComponent<enemy_bullet_movment>().Dmg;
            UI_HP = UI_HP - (other.GetComponent<enemy_bullet_movment>().Dmg / MAX_HP);
            this.ImgsFD_HP.SetValue(UI_HP, false, 2f);
            Ui_Hp_Player.Update_Hp(HP);
            Destroy(other.gameObject);
        }
    }
    private void Bonus_Power()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            POWER -= Time.deltaTime * 10;
            UI_POWER = UI_POWER - ((Time.deltaTime * 10) / 100);
        }
        else 
        {
            if (POWER <100)
            {
                POWER += Time.deltaTime * 2;
                UI_POWER = UI_POWER + ((Time.deltaTime * 2) / 100);
            }
        }

        if (POWER > 0)
        {
            Ui_Power_Player.Update_Power(POWER);
            this.ImgsFD_POWER.SetValue(UI_POWER, false, 2f);
        }

    }

}
