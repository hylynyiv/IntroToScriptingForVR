using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Color bumperColor = new Color(1, 0, 0);
    public bool change = false;

    void Update()
    {
        if(change == true)
        {
            Bump();
        }       
    }

    void Bump()
    { 
        FindObjectOfType<ColorChanger>().ColorChange(bumperColor);
    }
}


