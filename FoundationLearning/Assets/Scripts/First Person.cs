using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float playerSpeed;
    public float rotateSpeed;
    private Rigidbody myRigidbody;

    float xRotation = 0;
    float yRotation = 0;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        //lock the cursor to the centre of the screen and hide it in first person
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //call our move and rotate functions every frame
        Move();
        Rotate();
    }

    private void Move()
    {
        //get values for the X and Z inputs
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;
        float inputZ = Input.GetAxis("Vertical") * playerSpeed;

        //create a vector to move the player in the direction of
        Vector3 move = transform.right * inputX + transform.forward * inputZ;

        //set the players speed in the direction of our vector
        myRigidbody.velocity = new Vector3(move.x, myRigidbody.velocity.y, move.z);
    }

    void Rotate()
    {
        //get values for the X and Y mouse movements
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        //apply these values to our rotation values
        xRotation -= mouseY;
        yRotation += mouseX;

        //lock the player's view up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate the player and camera
        transform.eulerAngles = new Vector3(0, yRotation, 0);
        Camera.main.transform.localEulerAngles = new Vector3(xRotation, 0, 0);
    }
}

