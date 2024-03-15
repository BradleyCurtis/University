using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool onGround;
    private PlayerMovement playerMovement;

    private void Start()
    {
        //get reference to our player movement script
        playerMovement = GetComponentInParent<PlayerMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //when the trigger overlaps with the ground set jump count to 0
        if (other.CompareTag("Ground"))
        {
            playerMovement.currentJumpCount = 0;
        }
    }
}

