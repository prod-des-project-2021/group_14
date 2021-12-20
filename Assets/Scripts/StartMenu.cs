using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{   

    public Text timerText;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log(TimerController.TotalTime);
    }

    public void Awake()
    {
        GetTime();
    }

    public void GetTime()
    {
        string time = TimerController.TotalTime;
        timerText.text = time;
    }
}
