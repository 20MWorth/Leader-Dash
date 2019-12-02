using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCount : MonoBehaviour
{
    LevelExit levelExit;
    void Start()
    {
        levelExit = FindObjectOfType<LevelExit>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.hierarchyCount == 1)
        {
            levelExit.AllowExit();
        }
    }
}
