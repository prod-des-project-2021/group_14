using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotateSpeed;
    public Transform player;
    public Vector3 offset;
    public bool useOffsetValues;
    public Transform pivot;
    
    // Camera Zoom
    [SerializeField] private float maxCameraZoom; // Camera rotation max limit
    [SerializeField] private float minCameraZoom; // Camera zoom min limit
    [SerializeField] private float camZoom; // Mousewheel input
    [SerializeField] private float camZoomSpeed; // Speed multiplier
    [SerializeField] private float camDistance; // Distance between camera and target

    void Start() 
    {
    if (!useOffsetValues)
        {
            offset = player.position - transform.position;
        }
        pivot.position = transform.position = new Vector3 (player.position.x, player.position.y +4f, player.position.z);
        Cursor.lockState = CursorLockMode.Locked;
    }

   

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizontal,0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(vertical, 0, 0);



        if(pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 315f)
        {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);
        }
        

        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = player.position - (rotation * offset);

        if(transform.position.y < player.position.y)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        

        transform.LookAt(pivot);

        // Zooming in/out
        if (Input.GetAxis("Mouse ScrollWheel") != 0.0f) {
            camZoom = 0;
            camZoom += Input.GetAxis("Mouse ScrollWheel") * camZoomSpeed;

            camDistance += camZoom;

            // Limits distance from the target
            camDistance = Mathf.Clamp(camDistance, minCameraZoom, maxCameraZoom);
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, camDistance);

    }
}
