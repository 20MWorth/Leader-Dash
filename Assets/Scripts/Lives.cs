using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{

    [SerializeField] int playerLives = 6;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public float calculatedScore;


    FinalScore finalscore;
    [SerializeField] Score GameScore;

    private void Awake()
    {
        int numLives = FindObjectsOfType<Lives>().Length;
        if (numLives > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Destroy(gameObject);
        }
        livesText.text = playerLives.ToString();
        scoreText.text = calculatedScore.ToString("F0");
    }

    public void CalculateLifeLoss()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetLivesSystem();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    private void ResetLivesSystem()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(6);
    }
    
    public void DisplayScore()
    {
        GameScore.score = calculatedScore.ToString("F0");
        scoreText.text = calculatedScore.ToString("F0");
    }
}
