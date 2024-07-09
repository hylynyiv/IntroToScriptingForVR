// Attach this script to a player object. the camera should be a child of it.
// In the Inspector of the Player object, drag the camera into the "Player
// Camera" field of the script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithMouseLook : MonoBehaviour

{
    public float speed = 7.0f;
    public float mouseSensitivity = 300.0f;
    public Transform playerCamera;

    private float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // WASD movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
