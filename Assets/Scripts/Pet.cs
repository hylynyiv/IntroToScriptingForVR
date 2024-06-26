using UnityEngine;

public class Pet : MonoBehaviour
{
    public string petName = "Garfield";
    public float weight = 13.5f;
    public float speed = 0.1f;
    public float hunger = 0;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        hunger += 0.1f * Time.deltaTime;
        hunger += speed * Time.deltaTime * 0.1f;
        weight -= speed * Time.deltaTime * 0.1f;
    }

    public void Eat(float food)
    {
        hunger -= food;
        weight += food;
    }

}

