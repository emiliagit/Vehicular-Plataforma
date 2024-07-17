using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        Debug.Log("salida");
        Application.Quit();
    }
}
