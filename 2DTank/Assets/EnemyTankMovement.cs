using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    public float maxSpeed = 450f;
    public float currentSpeed = 30f;
    public float acceleration = 70f;
    public float deacceleration = 50f;
    public float forwardDirection = 1;
    Vector2 movement;
    public float rotation;
    public float rotationSpeed = 60f;
    //public float move;
    public ParticleSystem tankTrail;


    [Header("Physics")]
    public Rigidbody2D enemyTank;
    [SerializeField] private Transform playerTank;
    public NavMeshAgent agent;

    [Header("Range")]
    public float playerInSightRange = 20f;
    public float playerInAttackRange = 10f;
    public bool readyToAttack;
    public bool MoveTowards = false;



    public ParticleSystem smoke;


    // Update is called once per frame


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


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
        //agent.SetDestination(playerTank.position);
        if (currentSpeed == 0 && currentSpeed == 0)
        {
            smoke.Stop();

        }
        else
        {
            smoke.Play();
        }
        //MoveCalc();


        if (!isPlayerInSightRange())
        {
            MoveTowards = false;
            //idle()
        }
        else
        {
            if (isPlayerInAttackRange())
            {
                MoveTowards = false;
                //attack()
            }
            else
            {
                ChasePlayer();
                //MoveTowards = true;
            }
        }

    }


    public void ChasePlayer()
    {
        //Debug.Log("Chasing player");

        rotateTowards();

        //Debug.Log("Finished");
        //agent.SetDestination(playerTank.position);

    }
    private void rotateTowards()
    {
        Vector2 playerPosition = playerTank.position;
        var turretDirection = (Vector3)playerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        //Debug.Log(turretDirection);
        //Multiplying with deltatime
        var rotationStep = rotationSpeed * Time.deltaTime;
        //Rotating the turret with rotation speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle - 90), rotationStep);
        if (transform.rotation.z == desiredAngle - 90)
        {
            Debug.Log("Finished");
            MoveTowards = true;

        }
        
    }

    private void FixedUpdate()
    {
        Vector3 moveSpeed = transform.position - playerTank.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, enemyTank.transform.forward);
        //playerTank.
        // If it hits something...
        if (hit.collider == playerTank)
        {
            MoveTowards = true;
            
        }
        else
        {
            MoveTowards = false;
            //Debug.Log(hit.collider.name);
            Debug.Log("Start pos = " +enemyTank.transform.position + "Direction" + "empty" + " Collision name = " + hit.collider.name);
            //hit.
            //Debug.DrawRay(hit.origin, hit.direction, Color.red, 10.0f);
        }

        if (MoveTowards)
        enemyTank.MovePosition(transform.position + (-moveSpeed / 10) * Time.deltaTime);
        //enemyTank.AddForce(transform.up * currentSpeed, ForceMode2D.Force);
        //enemyTank.velocity = (Vector2)transform.up * currentSpeed * forwardDirection * Time.fixedDeltaTime;
    }
}
