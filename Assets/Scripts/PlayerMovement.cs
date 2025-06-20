using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    [Header("Player Movement")]
    [SerializeField]
    private float moveSpeed = 2f;
    private float horizontalInput;
    private float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    [SerializeField]
    private Transform orientation;

    // Is Grounded
    [Header("Grounded")]
    [SerializeField]
    private float playerHeight;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool grounded;
    [SerializeField]
    private float groundDrag;



    private void Start ()
    {
        // Set the player to the rb and to stop the player from falling
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Get the player input
        PlayerInput();

        // Check if the player is on the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        // Handle the ground drag on the player
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Get Movement Input
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Move the Player
    private void MovePlayer()
    {
        // To move in the direction that the player is looking in
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}