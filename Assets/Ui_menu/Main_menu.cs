using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void Start_game()
    {
        SceneManager.LoadScene("Game");
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
