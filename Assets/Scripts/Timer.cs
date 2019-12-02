using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    GameSession gamesession;

    private void Start()
    {
        gamesession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gamesession.TriggerTimer();
    }
}
