using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Util;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float remaining;

    void LateUpdate()
    {

        if (isGameOver())
        {
            timer.text = "Game Over";
        }
        else
        {
            timer.text = "Time Left: " + TimeSpan.FromSeconds(remaining).ToString(@"mm\:ss\:fff");
        }
    }

    void Update()
    {
        remaining = 2 * 60 - Time.timeSinceLevelLoad;
        if (remaining < 0)
        {
            setGameOver(true);
        }
        if (Input.GetAxis("Quit") != 0)
        {
            Application.Quit();
        }
    }
}
