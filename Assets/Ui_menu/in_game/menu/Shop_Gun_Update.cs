using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Gun_Update : MonoBehaviour
{
    public GameObject Text_Price;

    private int Price;
    private int Current_Place;
    private GameObject Gun;
    private TextMeshProUGUI Text;
    private Button Button;

    private void Update()
    {
        Current_Place = gameObject.transform.parent.parent.Find("Dmg").GetComponent<Value_Update>().Current_Gun;
        Gun = Save_sys.instance.Gun_Saved[Current_Place];
        Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Button = gameObject.GetComponent<Button>();

        if (Gun != null)
        {
            if (gameObject.name == "Pistol")
            {
                if (Gun.name == "Pistol")
                {
                    Button.interactable = true;
                    Text_Price.SetActive(false);
                    Text.text = "Sell";
                }
                else
                {
                    Text_Price.SetActive(true);
                    Button.interactable = false;
                    Text.text = gameObject.name;
                }
            }
            else if (gameObject.name == "Rifle")
            {
                if (Gun.name == "Rifle")
                {
                    Button.interactable = true;
                    Text_Price.SetActive(false);
                    Text.text = "Sell";
                }
                else
                {
                    Text_Price.SetActive(true);
                    Button.interactable = false;
                    Text.text = gameObject.name;
                }
            }
            else if (gameObject.name == "Sniper")
            {
                if(Gun.name == gameObject.name)
                {
                    Text_Price.SetActive(false);
                    Button.interactable = true;
                    Text.text = "Sell";
                }
                else
                {
                    Text_Price.SetActive(true);
                    Button.interactable = false;
                    Text.text = gameObject.name;
                }
            }
            else if (gameObject.name == "BumGun")
            {
                if (Gun.name == gameObject.name)
                {
                    Text_Price.SetActive(false);
                    Button.interactable = true;
                    Text.text = "Sell";
                }
                else
                {
                    Text_Price.SetActive(true);
                    Button.interactable = false;
                    Text.text = gameObject.name;
                }
            }
            else Button.interactable = false;
        }
        else
        {
            if (gameObject.name == "Pistol") Price = 200;
            else if (gameObject.name == "Rifle") Price = 300;
            else if (gameObject.name == "Sniper") Price = 400;
            else if (gameObject.name == "BumGun") Price = 500;

            if (Save_sys.instance.Points < Price) Button.interactable = false;
            else Button.interactable = true;
            Text_Price.SetActive(true);
            Text.text = gameObject.name;
        }
    }
}
