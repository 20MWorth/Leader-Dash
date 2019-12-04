using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI finalScore;

    //cached
    [SerializeField] Score GameScore;
    private void Start()
    {
        finalScore.text += GameScore.score;
    }
}
