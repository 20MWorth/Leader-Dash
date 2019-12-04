using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] int collectibleItems = 4;
    [SerializeField] bool allowExit;
    GameSession gamesession;

    private void Start()
    {
        allowExit = false;
        gamesession = FindObjectOfType<GameSession>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(allowExit)
        {
            var currentSceneindex = SceneManager.GetActiveScene().buildIndex;
                if (currentSceneindex == 4)
                {
                    Destroy(GameObject.FindWithTag("Lives"));
                }
            gamesession.CaptureTimer();
            SceneManager.LoadScene(currentSceneindex + 1);
        }
    }
    public void AllowExit()
    {
        allowExit = true;
    }
}
