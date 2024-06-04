using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public bool changeMovement = false;
    float timer = 5f;

    private void Update()
    {
        timer += Time.deltaTime;

        if(changeMovement == true && timer >= 5f)
        {
            ChangeMovement();
            changeMovement = false;
            timer = 0f;
        }
    }

    void ChangeMovement()
    {
        FindObjectOfType<Move>().SetRandomDirAndSpeed(1f);
    }
}

