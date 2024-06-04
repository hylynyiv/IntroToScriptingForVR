using UnityEngine;
// with offset

using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // Reference to the target object's transform
    public float verticalOffset = 2.0f; // Vertical offset

    void Update()
    {
        // Check if the target is set
        if (target != null)
        {
            // Get the position of the target and apply it to the object this script is attached to
            Vector3 newPosition = target.position;
            newPosition.y += verticalOffset; // Apply the vertical offset
            transform.position = newPosition;
        }
    }
}



// without offset
//public class FollowObject : MonoBehaviour
//{
//    public Transform target; 

//    void Update()
//    {
//        if (target != null)
//        {
//            transform.position = target.position;
//        }
//    }
//}
