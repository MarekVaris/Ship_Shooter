using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Button_Update : MonoBehaviour
{
    private int Gun_Pos;
    private int Base_Price;
    private int Upgrade_Price;
    private int Upgrade_Status;
    private TextMeshProUGUI Text;
    void Update()
    {
        Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Gun_Pos = gameObject.GetComponentInParent<Value_Update>().Current_Gun;
        if (Save_sys.instance.Gun_Saved[Gun_Pos] != null)
        {
            if (gameObject.name == "Buy_HP")
            {
                Upgrade_Status = Save_sys.instance.Hp;
                Update_Body_Price();
            }
            else if (gameObject.name == "Buy_Speed")
            {
                Upgrade_Status = Save_sys.instance.Speed;
                Update_Body_Price();
            }
            else if (gameObject.name == "Buy_Dmg")
            {
                Upgrade_Status = Save_sys.instance.Dmg[Gun_Pos];
                Update_Gun_Price();
            }
            else if (gameObject.name == "Buy_Aa_Speed")
            {
                Upgrade_Status = Save_sys.instance.Attack_Speed[Gun_Pos];
                Update_Gun_Price();
            }
        }
        else
        {
            Text.text = "--";
            gameObject.GetComponent<Button>().interactable = false;
        }
        
    }

    public void Update_Gun_Price()
    {
        if (Upgrade_Status < 5)
        {
            if (Save_sys.instance.Gun_Saved[Gun_Pos].name == "Pistol")
            {
                Base_Price = 100;
                Upgrade_Price = 100 * Upgrade_Status;
            }
            else if (Save_sys.instance.Gun_Saved[Gun_Pos].name == "Sniper")
            {
                Base_Price = 200;
                Upgrade_Price = 200 * Upgrade_Status;

            }
            Text.text = (Base_Price + Upgrade_Price).ToString();
            Points_Status();
        }
        else
        {
            Text.text = "Max";
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void Update_Body_Price()
    {
        if (Upgrade_Status < 5)
        {
            Base_Price = 100;
            Upgrade_Price = 200 * Upgrade_Status;
            Text.text = (Base_Price + Upgrade_Price).ToString();
            Points_Status();
        }
        else
        {
            Text.text = "Max";
        }
    }

    public void Points_Status()
    {
        if (Save_sys.instance.Points < (Base_Price + Upgrade_Price)) gameObject.GetComponent<Button>().interactable = false;
        else gameObject.GetComponent<Button>().interactable = true;
    }

    public void Points_Update_On_Click()
    {
        Save_sys.instance.Points -= (Base_Price + Upgrade_Price);
    }
}
