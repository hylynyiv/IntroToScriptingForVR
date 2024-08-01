using UnityEngine;

public class AnimatedPlayerMovementWMouseLook : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 200f;
    public Transform cameraTransform;

    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpHeight = 2f;

    [Header("Ground Check Settings")]
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Animator animator;
    private float xRotation;
    private float yRotation;
    private Vector3 velocity;
    private bool isGrounded;

    private float gravity = -9.81f;

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
        // Ground check using Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to ensure the player stays grounded
        }

        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (controller != null)
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (animator != null)
        {
            if (move != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

/*
Step-by-Step Guide to Create and Assign a Ground Layer:

1. Create a New Layer:
   - Go to the top menu and select `Edit` > `Project Settings`.
   - In the Project Settings window, go to the `Tags and Layers` section.
   - In the `Layers` list, click on an empty `User Layer` slot (e.g., `User Layer 8`).
   - Enter the name "Ground" (or another name of your choice) for this layer.

2. Assign the Ground Layer to Ground Objects:
   - Select the objects in your scene that should be considered ground (e.g., terrain, platforms).
   - In the Inspector, find the `Layer` dropdown at the top of the Inspector window.
   - Click the dropdown and select the newly created "Ground" layer.

3. Set the `groundMask` in the Script:
   - Select your player object in the hierarchy.
   - In the Inspector, find the `AnimatedPlayerMovementWMouseLook` component.
   - Set the `Ground Mask` field by selecting the "Ground" layer.

4. Additional Notes:
   - `groundDistance`: Set this to the maximum distance you want the ray to check for the ground (e.g., slightly more than the player's height).
   - `groundMask`: This layer mask tells the script which objects should be considered ground.

This setup will ensure that your player character correctly identifies ground objects and behaves as expected when moving, jumping, and applying gravity.
*/
