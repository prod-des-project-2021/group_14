using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    int intToSave;
    float floatToSave;
    string stringToSave = "";


    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 125, 50), "Raise integer"))
            intToSave++;

        if (GUI.Button(new Rect(0, 100, 125, 50), "Raise FLoat"))
            floatToSave += 0.1f;

        stringToSave = GUI.TextField(new Rect(0, 200, 125, 25), stringToSave, 15);

        GUI.Label(new Rect(375, 0, 125, 50), "Integer value is " + intToSave);

        GUI.Label(new Rect(375, 100, 125, 50), "Float value is " + floatToSave.ToString("F1"));

        GUI.Label(new Rect(375, 200, 125, 50), "String value is " + stringToSave);

        if (GUI.Button(new Rect(750, 0, 125, 50), "Save your game"))
            saveGame();

        if (GUI.Button(new Rect(750, 100, 125, 50), "Load your game"))
            loadGame();

        if (GUI.Button(new Rect(750, 200, 125, 50), "Reset your game data"))
            resetData();
    }

    void saveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", intToSave);

        PlayerPrefs.SetFloat("SavedFloat", floatToSave);

        PlayerPrefs.SetString("SavedString", stringToSave);

        PlayerPrefs.Save();

        Debug.Log("Game data saved!");
    }

    void loadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            intToSave = PlayerPrefs.GetInt("SavedInteger");
            floatToSave = PlayerPrefs.GetFloat("SavedFloat");
            stringToSave = PlayerPrefs.GetString("SavedString");
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    void resetData()
    {
        PlayerPrefs.DeleteAll();
        intToSave = 0;
        floatToSave = 0.0f;
        stringToSave = "";
        Debug.Log("Data reset complete");
    }

}

