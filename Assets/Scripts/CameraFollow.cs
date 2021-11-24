using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject sphere;
    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - sphere.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = distance + sphere.transform.position;
    }
}
