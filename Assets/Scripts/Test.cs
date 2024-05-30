using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int count;
    string petName = "Garfield";
    float weight = 13.5f;
    float weightGain = 0.5f;
    float age = 8f;
    float agingRate = 1f/30/60;
    // We want Garfield to age 1 year every 30 seconds. 
    // With a frame rate of 60 Hz, which is 60 frames per second, we can
    // calculate the percentage of aging per frame by dividing 1/30/60 or 
    // 1/(30*60).


    void Start()
    {
        float newWeight = weight + weightGain;
        Debug.Log($"{petName}'s new weight is {newWeight}.\n");
    }

    void Update()
    {
        count += 1;
        Debug.Log($"{count}");
        age += agingRate;
        Debug.Log($"{petName}'s age is now {age}.\n");
    }
}

