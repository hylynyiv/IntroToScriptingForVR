using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour {

    public GameObject[] myMonsters;

    void Start(){
        foreach (GameObject monster in myMonsters)
        {
            Destroy(monster);
        }
        //for (int i = 0; i <= myMonsters.Length; i++) {
        //    Destroy(myMonsters[i]);
        //}
    }
}



