using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public Animator Camera_animation;
    public Animator Ui_MainMenu;
    public Animator Ui_Shop;
    public GameObject Options_UI;

    public void Start()
    {
        if (Save_sys.instance.Shop_Start == true)
        {
            Camera_animation.SetBool("shop_start", Save_sys.instance.Shop_Start);
            Ui_Shop.SetBool("Ui_Shop", true);
            Ui_MainMenu.SetBool("Ui_menu", false);
            Camera_animation.SetBool("shop", true);
            Camera_animation.SetBool("menu", false);
            Save_sys.instance.Shop_Start = false;
        }

    }

    public void Start_game()
    {
        Ui_Shop.SetBool("Ui_Shop", true);
        Ui_MainMenu.SetBool("Ui_menu", false);
        Camera_animation.SetBool("shop", true);
        Camera_animation.SetBool("menu", false);
    }

    public void Settings()
    {
        gameObject.SetActive(false);
        Options_UI.SetActive(true);
    }

    public void Exit_settings()
    {
        Options_UI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Empty()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

}
