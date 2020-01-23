using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject levelInformationUI;
    public GameObject pauseButton;

    public void pause()
    {
        pauseButton.SetActive(false);
        levelInformationUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.song.Pause();
        gameIsPaused = true;
    }

    public void resume()
    {
        pauseButton.SetActive(true);
        levelInformationUI.SetActive(GameManager.instance.hasStarted == false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.song.UnPause();
        gameIsPaused = false;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
