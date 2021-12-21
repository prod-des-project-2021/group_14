using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using THP_Text;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] Material[] characterPrefabs;
    [SerializeField] GameObject player;
    //[SerializeField] THP_Text label;

    void Start()
    {
        
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        Material prefab = characterPrefabs[selectedCharacter];
        player.GetComponent<MeshRenderer>().material = prefab;
    }
}
