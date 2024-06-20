using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalkStrafe : MonoBehaviour
{
    public float speed = 4f;

    private Animator animator;
    private CharacterController charCont;

    void Start()
    {
        animator = GetComponent<Animator>();
        charCont = GetComponent<CharacterController>();
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");

        Vector3 moveDirection = transform.forward * move + transform.right * strafe;

        //Normalize the movement direction and scale by speed
        moveDirection = moveDirection.normalized * speed * Time.deltaTime;

        charCont.Move(moveDirection);


        if (move != 0 || strafe != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // You can also use this more concise notation:
        //bool isWalking = move != 0 || strafe != 0;
        //animator.SetBool("isWalking", isWalking);

    }
}
