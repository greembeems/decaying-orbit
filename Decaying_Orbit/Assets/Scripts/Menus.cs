using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void StartClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitClicked()
    {
        Application.Quit();
    }

    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
