using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    [SerializeField] GameObject door;

    bool isOpened = false;
    
    
    [SerializeField] float pressablePlatform = 0.1f;
    [SerializeField] float movingWall = 6.0f;
    

    
    void OnTriggerEnter(Collider collider)
    {
        if(!isOpened)
        {
            isOpened = true;
            door.transform.position += new Vector3(0, movingWall, 0);
            transform.position -= new Vector3(0, pressablePlatform, 0);
        }

    }

    void OnTriggerExit(Collider collider)
    {
        if(isOpened)
        {
            isOpened = false;
            door.transform.position -= new Vector3(0, movingWall, 0);
            transform.position += new Vector3(0, pressablePlatform, 0);
        }
    }
    
    

}
