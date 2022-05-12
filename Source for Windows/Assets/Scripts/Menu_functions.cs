using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_functions : MonoBehaviour
{
    public void Chips_game_start()
    {
        SceneManager.LoadScene("Chips_game");
    }

    public void Connection_game_start()
    {
        SceneManager.LoadScene("Connected_game");
    }

    public void Exit_game()
    {
        Application.Quit();
    }

    public void Open_github()
    {
        Application.OpenURL("https://github.com/Dx-by-Dy");
    }

}
