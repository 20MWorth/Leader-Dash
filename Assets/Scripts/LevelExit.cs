using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] int collectibleItems = 4;
    [SerializeField] bool allowExit;

    private void Start()
    {
        allowExit = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(allowExit)
        {
        var currentSceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneindex + 1);
        }
    }
    public void AllowExit()
    {
        allowExit = true;
    }
}
