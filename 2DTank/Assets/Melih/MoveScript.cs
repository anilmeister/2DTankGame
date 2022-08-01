using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    public float movementSpeed;
    public float maxSpeed = 450f;
    public float currentSpeed = 0f;
    public float acceleration = 70f;
    public float deacceleration = 50f;
    public float forwardDirection = 1;
    Vector2 movement;
    public float rotation;
    public float rotationSpeed;
    //public float move;
    public ParticleSystem tankTrail;
    public Rigidbody2D rb;


    private float stopSmokeTime = 1f * Time.deltaTime;
    public ParticleSystem smoke;
   

    // Update is called once per frame

    private void Start()
    {
        movementSpeed = 450f;
        rotationSpeed = 60f;
    }


    private void Update()
    {
        //Y w-s
        //X a-d
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.y == 0 && movement.x == 0)
        {

            if (smoke.IsAlive())
            {
                Invoke("SmokeStop", 3f);
                
            }

        }
        else
        {
            smoke.Play();
        }
        MoveCalc();
    }

    private void SmokeStop()
    {
        smoke.Stop();
    }


    public void MoveCalc()
    {
        CalculateSpeed();
        if (movement.y > 0)
        {
            if (forwardDirection == -1)
                currentSpeed = 0;
            forwardDirection = 1;
        }
        else if (movement.y < 0)
        {
            if (forwardDirection == 1)
                currentSpeed = 0;
            forwardDirection = -1;
        }
        
    }

    private void CalculateSpeed()
    {
        //throw new NotImplementedException();
        if (Mathf.Abs(movement.y) > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

    }


    //Fixed for movement (physics)
    void FixedUpdate()       
    {   
        //Adds speed and rotation to rigidbody
        rb.velocity = (Vector2)transform.up * currentSpeed * forwardDirection * Time.fixedDeltaTime;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movement.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
