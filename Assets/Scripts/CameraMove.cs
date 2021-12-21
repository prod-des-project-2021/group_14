using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraMove : MonoBehaviour
{

    private const float cameraSpeed = 3.0f;
    public Quaternion TargetRotation { private set; get; }
    public Transform player;
    public Transform pivot;
    public Vector3 cameraOffset;
    private new Rigidbody rigidbody;
    bool CursorLockedVar;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);
        CursorLockedVar = (true);
        TargetRotation = transform.rotation;
    }

    private void Update()
    {

        // Rotate the camera.
        var rotation = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        var targetEuler = TargetRotation.eulerAngles + (Vector3)rotation * cameraSpeed;
        if(targetEuler.x > 180.0f)
        {
            targetEuler.x -= 360.0f;
        }
        targetEuler.x = Mathf.Clamp(targetEuler.x, -75.0f, 75.0f);
        TargetRotation = Quaternion.Euler(targetEuler);

        transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, 
            Time.deltaTime * 15.0f);

        if (Input.GetKeyDown("escape") && !CursorLockedVar) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
            CursorLockedVar = (true);
        }
        else if(Input.GetKeyDown("escape") && CursorLockedVar){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);
            CursorLockedVar = (false);
        }
    }


    void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        transform.position = newPosition;
    }





    public void ResetTargetRotation()
    {
        TargetRotation = Quaternion.LookRotation(transform.forward, Vector3.up);
    }
}