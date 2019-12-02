using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{

    [SerializeField] int playerLives = 6;
    [SerializeField] int isActive;
    [SerializeField] TextMeshProUGUI livesText;

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
        livesText.text = playerLives.ToString();
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
        SceneManager.LoadScene(6);
        Destroy(gameObject);
    }
}
