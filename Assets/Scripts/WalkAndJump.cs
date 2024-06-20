using UnityEngine;

public class WalkAndJump : MonoBehaviour
{
    public float speed = 4f;
    public float jumpSpeed = 8f;
    public float gravity = 9f;

    private Animator animator;
    private CharacterController charCont;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
        charCont = GetComponent<CharacterController>();
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");

        //Reset the y component to 0 to avoid accumulation of gravity over time
        Vector3 inputDirection = transform.forward * move + transform.right * strafe;
        inputDirection = inputDirection.normalized * speed;

        if (charCont.isGrounded)
        {
            moveDirection = inputDirection;

            //Check for jump
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection.x = inputDirection.x;
            moveDirection.z = inputDirection.z;
        }

        //Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //Move the character controller
        charCont.Move(moveDirection * Time.deltaTime);

        //Check if there is any movement (forward/backward or strafing)
        bool isWalking = move != 0 || strafe != 0;
        animator.SetBool("isWalking", isWalking);
    }
}
