using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject LevelSelectPanel;


    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
    }

    public void ShowLevelPanel()
    {
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
        
    }


    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }

    public void CloseLevelPanel()
    {
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
    if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPanel.SetActive(!MenuPanel.gameObject.activeSelf);
            LevelSelectPanel.SetActive(false);    
        }
    }
}
