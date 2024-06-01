using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise4 : MonoBehaviour
{
    public GameObject[] myMonsters;
    public bool alive = true;

    void Update()
    {
        if(alive != true)
        {
            DestroyAll();
        }
    }

    void DestroyAll()
    {
        foreach (GameObject monster in myMonsters)
        {
            Destroy(monster);
        }
    }
}
