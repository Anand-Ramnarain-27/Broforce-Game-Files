using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    public float climbSpeed = 2f;

    private bool isClimbing = false;

    private void Update()
    {
        // Check if the player is touching the ladder (use a layer mask or check collision with the ladder tag)
        if (isTouchingLadder())
        {
            float verticalInput = Input.GetAxis("Vertical");
            if (verticalInput != 0f)
            {
                // Player is climbing
                isClimbing = true;
                // Disable gravity to prevent the player from falling down
                GetComponent<Rigidbody2D>().gravityScale = 0f;
                // Move the player up or down the ladder
                transform.Translate(Vector2.up * verticalInput * climbSpeed * Time.deltaTime);
            }
            else
            {
                isClimbing = false;
                // Enable gravity again when not climbing
                GetComponent<Rigidbody2D>().gravityScale = 5f;
            }
        }
        else
        {
            isClimbing = false;
            // Enable gravity again when not touching the ladder
            GetComponent<Rigidbody2D>().gravityScale = 5f;
        }
    }

    private bool isTouchingLadder()
    {
        // Check if the player's collider is touching the ladder
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<CapsuleCollider2D>().size, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Ladder"))
            {
                return true;
            }
        }
        return false;
    }
}
