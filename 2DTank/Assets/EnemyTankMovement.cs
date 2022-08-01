using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    public float maxSpeed = 450f;
    public float currentSpeed = 0f;
    public float acceleration = 70f;
    public float deacceleration = 50f;
    public float forwardDirection = 1;
    Vector2 movement;
    public float rotation;
    public float rotationSpeed = 60f;
    //public float move;
    public ParticleSystem tankTrail;
    public Rigidbody2D enemyTank;

    public Transform playerTank;

    [Header("Range")]
    public float playerInSightRange = 20f;
    public float playerInAttackRange = 10f;
    public bool readyToAttack;

    public ParticleSystem smoke;


    // Update is called once per frame

    public bool isPlayerInSightRange()
    {
        //iki türlü yapýlabilir Vector3.Distance(transform.position, playerTank.position);
        if (Mathf.Abs((transform.position - playerTank.position).magnitude) < playerInSightRange)
            return true;
        return false;
    }
    public bool isPlayerInAttackRange()
    {
        //iki türlü yapýlabilir Vector3.Distance(transform.position, playerTank.position);
        if (Mathf.Abs((transform.position - playerTank.position).magnitude) < playerInAttackRange)
            return true;
        return false;
    }


    private void Update()
    {
        if (currentSpeed == 0 && currentSpeed == 0)
        {
            smoke.Stop();

        }
        else
        {
            smoke.Play();
        }
        //MoveCalc();
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
        enemyTank.velocity = (Vector2)transform.up * currentSpeed * forwardDirection * Time.fixedDeltaTime;
        enemyTank.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movement.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
