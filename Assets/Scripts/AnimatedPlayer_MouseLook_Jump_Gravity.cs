using UnityEngine;
using System.Collections;
using System.Linq; // Needed for the Any() method

public class AnimatedPlayer_MouseLook_Jump_Gravity : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 200f;
    public Transform cameraTransform;

    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpHeight = 2f;

    [Header("Gravity Settings")]
    public float gravity = -9.81f;

    private CharacterController controller;
    private Animator animator;
    private float xRotation;
    private float yRotation;
    private Vector3 velocity;
    private bool hasIsMovingParameter;
    private bool hasIsJumpingParameter;

    void Start()
    {
        // Ensure that the CharacterController and Animator components are assigned
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (controller == null)
        {
            Debug.LogError("CharacterController component missing from the player.");
        }

        if (animator == null)
        {
            Debug.LogError("Animator component missing from the player.");
        }
        else
        {
            // Check if the 'isMoving' parameter exists
            hasIsMovingParameter = animator.parameters.Any(param => param.name == "isMoving" && param.type == AnimatorControllerParameterType.Bool);
            if (!hasIsMovingParameter)
            {
                Debug.LogWarning("Animator parameter 'isMoving' is missing.");
            }

            // Check if the 'isJumping' parameter exists
            hasIsJumpingParameter = animator.parameters.Any(param => param.name == "isJumping" && param.type == AnimatorControllerParameterType.Bool);
            if (!hasIsJumpingParameter)
            {
                Debug.LogWarning("Animator parameter 'isJumping' is missing.");
            }
        }

        Cursor.lockState = CursorLockMode.Locked;

        // Initialize rotation with the current camera rotation
        xRotation = cameraTransform.localEulerAngles.x;
        yRotation = transform.localEulerAngles.y;

        // Ensure the camera is a child of the player object
        if (cameraTransform.parent != transform)
        {
            cameraTransform.SetParent(transform);
        }
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        // Debugging: Check if method is called
        Debug.Log("HandleMovement called");

        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Apply movement
        if (controller != null)
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        // Update animator parameters
        if (animator != null)
        {
            if (hasIsMovingParameter)
            {
                animator.SetBool("isMoving", move != Vector3.zero);
            }
        }

        // Debugging: Check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump button pressed");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            if (animator != null && hasIsJumpingParameter)
            {
                animator.SetBool("isJumping", true);
            }
        }

        // Apply gravity continuously
        velocity.y += gravity * Time.deltaTime;

        // Apply the velocity to the CharacterController
        if (controller != null)
        {
            controller.Move(velocity * Time.deltaTime);
        }

        // Reset jumping animation when grounded
        if (controller.isGrounded)
        {
            velocity.y = -2f; // Ensure the player stays grounded
            if (animator != null && hasIsJumpingParameter)
            {
                animator.SetBool("isJumping", false);
            }
        }
    }
}
