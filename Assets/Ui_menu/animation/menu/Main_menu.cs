using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public Animator Camera_animation;
    public Animator Ui_MainMenu;
    public Animator Ui_Shop;
    public void Start_game()
    {
        Ui_Shop.SetBool("Ui_Shop", true);
        Ui_MainMenu.SetBool("Ui_menu", false);
        Camera_animation.SetBool("shop", true);
        Camera_animation.SetBool("menu", false);
    }

    public void Settings()
    {

    }
    public void Empty()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
