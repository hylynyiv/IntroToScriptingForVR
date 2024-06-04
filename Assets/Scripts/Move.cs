using UnityEngine;

public class Move : MonoBehaviour
{
    public float speedX;
    public float speedZ;
    public float minSpeed = -4f;
    public float maxSpeed = 4f;
    public float changeInterval = 2.0f;
    public float timer;
    public int boundary = 30;

    void Start()
    {
        SetRandomDirAndSpeed(4f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0;
            SetRandomDirAndSpeed(4f);
        }

        // Apply movement
        transform.position += new Vector3(speedX, 0, speedZ) * Time.deltaTime;

        // Boundary Check
        if (Mathf.Abs(transform.position.x) >= boundary)
        {
            speedX = -speedX; 
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * boundary, 0, transform.position.z);
        }
        if (Mathf.Abs(transform.position.z) >= boundary)
        {
            speedZ = -speedZ;
            transform.position = new Vector3(transform.position.x, 0, Mathf.Sign(transform.position.z) * boundary);
            // Use the following to see a little "quantum" glitch that looks like the object is at two positions at the same time when reaching the boundary
            //transform.position = new Vector3(transform.position.x, 0, Mathf.Sign(speedZ) * boundary);
        }
    }

    public void SetRandomDirAndSpeed(float maxInterval)
    {
        speedX = Random.Range(minSpeed, maxSpeed);
        speedZ = Random.Range(minSpeed, maxSpeed);
        changeInterval = Random.Range(1f, maxInterval);
    }
}
