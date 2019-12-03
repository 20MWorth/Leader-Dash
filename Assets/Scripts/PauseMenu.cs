using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject instructions;

    Lives lives;

    private void Start()
    {
        lives = FindObjectOfType<Lives>();
    }
    private void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        instructions.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        instructions.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void RestartLevel()
    {
        var currentSceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneindex);
        Time.timeScale = 1f;
        GameIsPaused = false;
        lives.CalculateLifeLoss();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
