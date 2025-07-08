using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        // Check for the Pause button input (you can customize this based on your needs)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // Toggle the pause state
        if (Time.timeScale == 0f)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        // Pause the game
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);

        // You can add additional pause functionality here, like freezing player movement, hiding the cursor, etc.
    }

    public void ResumeGame()
    {
        // Resume the game
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

        // You can add additional resume functionality here, like unfreezing player movement, showing the cursor, etc.
    }
}
