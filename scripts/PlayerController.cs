using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Movement floats and Definitions
    public float moveSp = 6.0f;
    public float jumpSp = 8.0f;
    public float gravSp = 20.0f;
    private Vector3 moveDir = Vector3.zero;

    //Camera floats and definitions
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axis = RotationAxes.MouseXandY;
    public float sensX = 15f;
    public float sensY = 15f;
    public float minX = -360f;
    public float maxX = 360f;
    public float minY = -60f;
    public float maxY = 60f;
    float rotationY = 0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(rb)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {

        //// Movement Script
        CharacterController controller = GetComponent<CharacterController>();

        //if controller is grounded
        if(controller.isGrounded)
        {
            //Feed moveDir with input
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);

            //Multiply by speed
            moveDir *= moveSp;

            //if jumping
            if(Input.GetButton("Jump"))
            {
                moveDir.y = jumpSp;
            }
        }

        //Applying grav to controller
        moveDir.y -= gravSp * Time.deltaTime;

        //making char move
        controller.Move(moveDir * Time.deltaTime);

        //// Camera Script
        if(axis == RotationAxes.MouseXandY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensX;

            rotationY += Input.GetAxis("Mouse Y") * sensY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0); 
        }
        else if(axis == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}
