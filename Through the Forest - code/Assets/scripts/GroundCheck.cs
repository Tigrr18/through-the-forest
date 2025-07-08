using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Reference to the PlayerController script
    private PlayerController playerController;
    public Animator anim;
    
    void Start()
    {
        // Get the PlayerController script attached to the player GameObject
        playerController = GetComponentInParent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            // Set the isGrounded variable in the PlayerController script to true
            if (playerController != null)
            {
                playerController.isGrounded = true;
                anim.SetBool("isJumping", !playerController.isGrounded);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            // Set the isGrounded variable in the PlayerController script to false
            if (playerController != null)
            {
                playerController.isGrounded = false;
                anim.SetBool("isJumping", !playerController.isGrounded);
            }
        }
    }
}
