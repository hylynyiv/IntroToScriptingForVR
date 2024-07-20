using UnityEngine;

public class AnimatedPlayerMovementWMouseLook : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 200f;
    public Transform cameraTransform;

    [Header("Movement Settings")]
    public float speed = 5f;

    private CharacterController controller;
    private Animator animator;
    private float xRotation;
    private float yRotation;

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
    }
}
