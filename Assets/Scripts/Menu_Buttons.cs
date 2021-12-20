using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
    if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPanel.SetActive(!MenuPanel.gameObject.activeSelf);
            LevelSelectPanel.SetActive(false);    
        }
    }
}
