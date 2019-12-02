using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject howToPlayButton;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject controls;
    [SerializeField] GameObject backButton;
    Lives lives;
    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {

        playButton.SetActive(true);
        quitButton.SetActive(true);
        howToPlayButton.SetActive(true);
        instructions.SetActive(false);
        controls.SetActive(false);
        backButton.SetActive(false);
    }
    public void HowToPlay()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        howToPlayButton.SetActive(false);
        instructions.SetActive(true);
        controls.SetActive(true);
        backButton.SetActive(true);
}
}
