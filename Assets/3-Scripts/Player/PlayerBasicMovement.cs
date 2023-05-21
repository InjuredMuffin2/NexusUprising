using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    public GameObject playerGO;
    public Rigidbody2D playerRB;

    public PhysicsMaterial2D whileInMotion;
    public PhysicsMaterial2D whileIsStatic;

    public LayerMask surface;
    public LayerMask enemy;
    public GameObject groundCheckGO;
    public float groundCheckDistance = 0.2f;
    public bool isGrounded;
    public int collisionType;

    public float movementSpeed;
    public float movementSpeedMultiplier = 1f;

    public float jumpStrength;
    public float jumpStrengthMultiplier = 1f;

    private void Awake()
    {
        ResolveUnassignedOnAwake();
    }

    void Update()
    {
        if(DialogueManager.dialogueInProgress == false)
        {
            HorizontalMovement();
            (isGrounded, collisionType) = CheckForCollision();
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            else if (collisionType == 2)
            {
                Jump();
            }
            
            Crouch();
        }
        else
        {
            playerRB.sharedMaterial = whileIsStatic;
        }
    }

    // Assign default values to variables if they are not set in the editor
    public void ResolveUnassignedOnAwake()
    {
        if (movementSpeed == 0)
        {
            movementSpeed = 7;
        }
        if (jumpStrength == 0)
        {
            jumpStrength = 22;
        }
        if (playerGO == null)
        {
            playerGO = gameObject;
        }
        if (playerRB == null)
        {
            playerRB = gameObject.GetComponent<Rigidbody2D>();
        }
        if (groundCheckGO == null)
        {
            Transform childTransform = playerGO.transform.GetChild(0);
            groundCheckGO = childTransform.gameObject;
        }
    }

    // Handle player's horizontal movement
    private void HorizontalMovement()
    {
        //reset player mesh when inputs are made, root motion is enabled because without it the mesh slids around
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
        {
            playerGO.transform.GetChild(2).localEulerAngles = new Vector3(0, 90, 0);
            playerGO.transform.GetChild(2).transform.localPosition = new Vector3(0, -1, 0);
        }

        //Set the character's facing direction
        if (Input.GetKey(KeyCode.D))
        {
            playerGO.transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerGO.transform.eulerAngles = new Vector3(0, 180, 0);
            
        }

        //movement
        if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(-1 * movementSpeed * movementSpeedMultiplier, playerRB.velocity.y);
            playerRB.sharedMaterial = whileInMotion;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(1 * movementSpeed * movementSpeedMultiplier, playerRB.velocity.y);
            playerRB.sharedMaterial = whileInMotion;
        }
        else
        {
            playerRB.sharedMaterial = whileIsStatic;
        }
    }

    // Check if the player is grounded, or if they are on top of an enemy
    private (bool, int) CheckForCollision()
    {
        RaycastHit2D hitSurface = Physics2D.Raycast(groundCheckGO.transform.position, Vector2.down, groundCheckDistance, surface);
        RaycastHit2D hitEnemy = Physics2D.Raycast(groundCheckGO.transform.position, Vector2.down, groundCheckDistance, surface);

        if (hitSurface)
        {
            return (true, 1);
        }
        else if (hitEnemy)
        {
            return (true, 2);
        }
        else
        {
            return (false, 0);
        }
    }

    // Handle player's jumping
    private void Jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpStrength * jumpStrengthMultiplier);
    }

    // Handle player's crouching
    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerGO.transform.localScale = new Vector3(1, 0.5f, 1);
            jumpStrengthMultiplier = 0.5f;
            movementSpeedMultiplier = 0.5f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerGO.transform.localScale = Vector3.one;
            jumpStrengthMultiplier = 1;
            movementSpeedMultiplier = 1;
        }
    }

    public void SetMovementSpeedMultiplier(float multiplier)
    {
        movementSpeedMultiplier = multiplier;
    }

    public void ResetMovementSpeedMultiplier()
    {
        movementSpeedMultiplier = 1f;
    }

    public void SetJumpStrengthMultiplier(float multiplier)
    {
        jumpStrengthMultiplier = multiplier;
    }

    public void ResetJumpStrengthMultiplier()
    {
        jumpStrengthMultiplier = 1f;
    }
}
