using UnityEngine;

public class Exercise7 : MonoBehaviour
{
    private float speedX;
    private float speedZ;
    public float minSpeed = -4f;
    public float maxSpeed = 4f;
    public float changeInterval = 2.0f;
    public float timer;
    public int boundary = 30;
    private Rigidbody rb;
    private Renderer objRenderer;
    private bool isFading = false;
    private Color origColor;
    private Color targColor = Color.red;
    private float cooldownTime = 3f;
    private float elapsedTime;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objRenderer = GetComponent<Renderer>();
        origColor = objRenderer.material.color;
        SetRandomDirAndSpeed(4f);
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= changeInterval)
        {
            timer = 0;
            SetRandomDirAndSpeed(4f);
        }

        // Apply movement by setting velocity
        rb.velocity = new Vector3(speedX, rb.velocity.y, speedZ);

        // Boundary Check
        if (Mathf.Abs(rb.position.x) > boundary)
        {
            speedX = -speedX;
            rb.position = new Vector3(Mathf.Sign(rb.position.x) * (boundary - 0.5f), rb.position.y, rb.position.z);
            // We include a little offset to prevent the object to be stuck in the corners
        }
        if (Mathf.Abs(rb.position.z) > boundary)
        {
            speedZ = -speedZ;
            rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Sign(rb.position.z) * (boundary - 0.5f));
        }
    }

    void Update()
    {
        if (isFading == true)
        {
            FadingColor();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cats"))
        {
            GetComponent<Renderer>().material.color = targColor; // getting somewhat upset
            isFading = true; // cooling down
            elapsedTime = 0;
            SetRandomDirAndSpeed(4f); // politely changing direction
        }
    }

    public void SetRandomDirAndSpeed(float maxInterval)
    {
        speedX = Random.Range(minSpeed, maxSpeed);
        speedZ = Random.Range(minSpeed, maxSpeed);
        changeInterval = Random.Range(1f, maxInterval);
    }

    public void FadingColor()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / cooldownTime;

        if(elapsedTime <= cooldownTime){
            objRenderer.material.color = Color.Lerp(targColor, origColor, t);
        }
        else
        {
            isFading = false;   
            elapsedTime = 0;
        }
    }
}
