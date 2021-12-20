using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject LevelSelectPanel;

    public void GoBack()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LevelSelectPanel.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LevelSelectPanel.SetActive(false);
        }
    }
}
