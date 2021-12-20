using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using THP_Text;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefabs;
    [SerializeField] Transform spawnPoint;
    //[SerializeField] THP_Text label;

    void Start()
    {
        
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        //label.text = prefab.name;
    }
}
