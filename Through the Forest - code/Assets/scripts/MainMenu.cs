using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("intro");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
