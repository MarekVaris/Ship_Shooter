using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_over_scene : MonoBehaviour
{
    
    public void Setup()
    {
        gameObject.SetActive(true);   
    }

    public void Reser_button()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu_button()
    {
        SceneManager.LoadScene("Menu");
    }
}
