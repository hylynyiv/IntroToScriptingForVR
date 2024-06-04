using UnityEngine;

public class MoveZRandomSpeed : MonoBehaviour
{
    public float speed;
    public float minSpeed = -0.1f;
    public float maxSpeed = 0.1f;
    public float changeInterval = 2.0f;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0;
            speed = Random.Range(minSpeed, maxSpeed);
        }
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}





