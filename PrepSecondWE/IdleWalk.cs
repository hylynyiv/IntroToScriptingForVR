using UnityEngine;

public class IdleWalk : MonoBehaviour
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
        Debug.Log("Move: "+ move);


        Vector3 moveDirection = transform.forward * move * speed * Time.deltaTime;
        charCont.Move(moveDirection);

        if(move != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
