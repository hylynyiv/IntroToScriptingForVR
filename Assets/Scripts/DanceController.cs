using UnityEngine;

public class DanceController : MonoBehaviour
{
    private Animator animator;
    private bool isDancing = false;
    private bool hasIsDancingParameter;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on GameObject.");
            return;
        }

        hasIsDancingParameter = animator.parameters.Any(p => p.name == "isDancing" && p.type == AnimatorControllerParameterType.Bool);
        if (!hasIsDancingParameter)
        {
            Debug.LogWarning("Animator parameter 'isDancing' not found.");
        }
    }

    void Update()
    {
        if (hasIsDancingParameter && Input.GetKeyDown(KeyCode.G))
        {
            isDancing = !isDancing;
            animator.SetBool("isDancing", isDancing);
        }
    }
}
