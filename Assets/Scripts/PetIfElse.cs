using UnityEngine;

public class PetIfElse : MonoBehaviour
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

        if (weight <= 8) { 
            speed = 0;
            Debug.Log("Garfield: I need to stop, I'm out of energy.");
        }

        else if (weight <= 9){
            Debug.Log("Garfield: I'm hungry!");
        }

        else { 
            Debug.Log("Garfield: I just love running after these butterflies!");
        }

    }
}

