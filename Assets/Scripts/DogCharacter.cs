using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DogCharacter : MonoBehaviour
{

    /// <summary>
    /// 
    /// most the movement portion of this script came from CHATGPT
    /// 
    /// the rest is me
    /// 
    /// </summary>
    // Movement Vairables
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    private CharacterController characterController;
    private Vector3 moveDirection;

    //  Variable used in points system
    public static int bonePoints;
    private int buryPoints;
    [SerializeField] private TMP_Text scoreText;


    // UI Variables
    [SerializeField] private Image boneImage;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        bonePoints = 0;
        boneImage.enabled = false;

    }

    private void Update()
    {

        // movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        moveDirection = Camera.main.transform.forward * inputDirection.z + Camera.main.transform.right * inputDirection.x;
        moveDirection.y = 0f; 
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (inputDirection != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float rotation = Mathf.LerpAngle(transform.eulerAngles.y, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        // collecting bones for points
        // this also ensures that the player can never have more or less than the required amount of points
        
        if(bonePoints > 1.1)
        {
            bonePoints = 1;
        }
        if(bonePoints < 0)
        {
            bonePoints = 0;
        }

        if (bonePoints == 1)
        {
            boneImage.enabled = true;
        }
        if(bonePoints == 0)
        {
            boneImage.enabled = false;
        }
    }

    public void AddBuryPoint()
    {
        if (bonePoints > 0)
        {
            bonePoints--; // Subtract one bonePoint
            buryPoints++; // Add one buryPoint
            UpdateScoreText();
            Debug.Log("Bury point added. Total bury points: " + buryPoints);
        }
    }


        // Call this method whenever you want to increase the scor

        private void UpdateScoreText()
        {
            scoreText.text = buryPoints.ToString();
        }
    
}

