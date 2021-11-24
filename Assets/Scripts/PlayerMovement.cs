using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Transform cameraTarget;
    public Transform MainCamera;
    Vector2 input;
    float heading;
    float rotation;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        rotation += Input.GetAxis("Mouse Y")*Time.deltaTime*180;
        heading += Input.GetAxis("Mouse X")*Time.deltaTime*180;
        cameraTarget.rotation = Quaternion.Euler(0, heading, 0);
        cameraTarget.rotation = Quaternion.Euler(-rotation, heading, 0);

        //rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        
        Vector3 camF = MainCamera.forward;
        Vector3 camR = MainCamera.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF*input.y + camR*input.x)*Time.deltaTime*movementSpeed;
        //transform.position += new Vector3(input.x,0,input.y)*deltaTime*5;
        


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
        }
        
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .4f, ground);
    }

}
