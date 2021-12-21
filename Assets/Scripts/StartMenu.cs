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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log(TimerController.TotalTime);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log(TimerController.TotalTime);
    }

    public void Level2()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log(TimerController.TotalTime);
    }

    public void Level3()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log(TimerController.TotalTime);
    }



    public void GetTime()
    {
        string time = TimerController.TotalTime;
        timerText.text = time;
    }
    
    public void Awake()
    {
        GetTime();
    }

    
}
