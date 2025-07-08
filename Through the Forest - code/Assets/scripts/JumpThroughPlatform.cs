using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThroughPlatform : MonoBehaviour
{
    // Reference to the PlayerController script
    private PlayerController playerController;

    public int platformLayer = 6; // Set this in the Inspector to the desired platform layer

    void Start()
    {
        // Get the PlayerController script attached to the player GameObject
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            // Attempt to jump through the platform
            JumpThrough();
        }
    }

    void JumpThrough()
    {
        // Check if the player is grounded and touching the platform layer
        if (playerController != null && playerController.isGrounded && IsTouchingPlatformLayer())
        {
            // Disable the player's collider temporarily
            playerController.col.enabled = false;

            // Enable the collider after a short delay (adjust the delay as needed)
            Invoke("EnablePlayerCollider", 0.5f);
        }
    }

    bool IsTouchingPlatformLayer()
    {
        // Check if the player is touching the platform layer using Physics2D
        Collider2D collider = Physics2D.OverlapCircle(playerController.col.bounds.center, playerController.col.bounds.extents.x, platformLayer);

        return collider != null;
    }

    void EnablePlayerCollider()
    {
        // Enable the player's collider
        playerController.col.enabled = true;
    }
}
