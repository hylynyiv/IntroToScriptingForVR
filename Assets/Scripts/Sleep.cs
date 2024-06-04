using UnityEngine;

public class Sleep : MonoBehaviour
{
    public GameObject[] myMonsters;

    void Start(){
        foreach(GameObject monster in myMonsters)
        {
            Destroy(monster);
        }
    }
}



