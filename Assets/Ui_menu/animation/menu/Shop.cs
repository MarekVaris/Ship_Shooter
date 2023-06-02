using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Animator Camera_animation;
    public Animator Ui_MainMenu;
    public Animator Ui_Shop;
    
    public void Body_Upgrade()
    {
        transform.Find("List").gameObject.SetActive(false);
        transform.Find("Menu_back").gameObject.SetActive(false);
        transform.Find("Body_Upgrade").gameObject.SetActive(true);

    }
    
    public void Back(Button button)
    {
        button.transform.parent.gameObject.SetActive(false);
        transform.Find("List").gameObject.SetActive(true);
        transform.Find("Menu_back").gameObject.SetActive(true);
    }

    public void Start_game()
    {
        SceneManager.LoadScene("Game");
    }
    public void Back_MainMenu()
    {
        Ui_Shop.SetBool("Ui_Shop", false);
        Ui_MainMenu.SetBool("Ui_menu", true);
        Camera_animation.SetBool("shop", false);
        Camera_animation.SetBool("menu", true);
    }
}
