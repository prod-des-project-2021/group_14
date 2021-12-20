using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public static string timePlayingStr;
    public Text timeCounter;

    public TimeSpan timePlaying;
    public bool timerGoing;

    public float elapsedTime;

    public void Awake()
    {
        instance = this;

        Debug.Log("TimerController");
    }

    public void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = true;
        

        

        Debug.Log("Start");
        
    }

    public void BeginTimer()
    {
        Debug.Log("BeginTimer");

        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    public IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
    }
}
