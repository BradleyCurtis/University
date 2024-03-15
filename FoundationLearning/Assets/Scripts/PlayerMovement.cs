using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float inputX;
    public float inputZ;

    public float jumpSpeed;
    public float rotateSpeed;

    public int maxJumps = 2;
    public int currentJumpCount;

    private Rigidbody myRigidbody;
    private GroundCheck groundCheck;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        
    }

    void Update()
    {
        //call our move, jump and rotate functions every frame
        Move();
        Jump();
        RotatePlayer();
    }

    void Move()
    {
        //get values for the X and Z inputs
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        //set the player velocity
        myRigidbody.velocity = new Vector3(inputX * speed, myRigidbody.velocity.y, inputZ * speed);
    }

    void Jump()
    {
        //if spacebar pressed and jump is available perform the jump
        if (Input.GetButtonDown("Jump") && currentJumpCount < maxJumps)
        {
            currentJumpCount++;
            myRigidbody.velocity = new Vector3(0, jumpSpeed, 0);
        }
    }

    void RotatePlayer() 
    {
        //set a ray from the mouse position
        Ray raycastFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        //declare a point for the ray to hit
        RaycastHit hitPoint;

        if (Physics.Raycast(raycastFromMouse, out hitPoint))
        {
            //get distance between player and hitpoint
            Vector3 playerToPoint = hitPoint.point - myRigidbody.position;

            //calculate angle
            float angle = Mathf.Atan2(playerToPoint.z, playerToPoint.x) * Mathf.Rad2Deg;

            //rotate player
            gameObject.transform.eulerAngles = new Vector3(0, -angle + 90, 0);
        }
    }
}

