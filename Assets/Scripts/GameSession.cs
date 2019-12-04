using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] float timeAmountInSec = 20f;
    [SerializeField] TextMeshProUGUI timer;
    float countdown;
    bool startTimer = false;
    Lives lives;

    private void Start()
    {
        countdown = timeAmountInSec;
    }
    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            countdown -= Time.deltaTime;
            timer.text = countdown.ToString("F1");
            if (countdown < 0)
            {
                lives.CalculateLifeLoss();
            }
        }
        else { return; }

    }
    public void TriggerTimer()
    {
        startTimer = true;
    }
    public void CaptureTimer()
    {
        lives = FindObjectOfType<Lives>();
        lives.calculatedScore += countdown;
        lives.DisplayScore();
    }

}
