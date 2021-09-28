using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, pauseButton;

    private bool paused;

    public void PauseGame()
    {
        paused = true;

        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        paused = false;

        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GoToScene(string sceneName)
    {
        ResumeGame();

        SceneManager.LoadScene(sceneName);
    }
}
