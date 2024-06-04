using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDispenser : MonoBehaviour
{
    float catFood = 1f;

    void FeedPet()
    {
        FindObjectOfType<Pet>().Eat(catFood);
    }
    
}
