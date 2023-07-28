using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundDistance = 0.2f;

    private bool isGrounded;
    private CharacterController characterController;
    private Vector3 moveDirection;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // Get input for movement and rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Calculate move direction relative to the camera
        moveDirection = Camera.main.transform.forward * inputDirection.z + Camera.main.transform.right * inputDirection.x;
        moveDirection.y = 0f; // Ensure the player stays on the ground

        // Move the player
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Rotate the player in the direction of movement
        if (inputDirection != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float rotation = Mathf.LerpAngle(transform.eulerAngles.y, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        // Apply gravity
        if (!isGrounded)
        {
            moveDirection.y -= 9.81f * Time.deltaTime;
        }
    }
}

