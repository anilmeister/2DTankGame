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
    [SerializeField] BoxCollider2D playerCollider;
    [SerializeField] private Transform playerTank;
    [SerializeField] Transform tankForward;
    //public NavMeshAgent agent;

    [Header("Range")]
    public float playerInSightRange = 20f;
    public float playerInAttackRange = 10f;
    public bool readyToAttack;
    public bool MoveTowards = false;



    public ParticleSystem smoke;


    // Update is called once per frame


    private void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;
    }


    public bool isPlayerInSightRange()
    {
        if (playerTank == null)
            return false;
        //Can be done like this too Vector3.Distance(transform.position, playerTank.position);
        if (Mathf.Abs((transform.position - playerTank.position).magnitude) < playerInSightRange)
            return true;
        return false;
    }
    public bool isPlayerInAttackRange()
    {
        if (playerTank == null)
            return false;
        //Can be done like this too Vector3.Distance(transform.position, playerTank.position);
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
        if (playerTank != null)
        {
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
                    MoveTowards = true;
                }
            }
        }
    }


    public void ChasePlayer()
    {
        //Debug.Log("Chasing player");
        rotateTowards();


        //if navmesh can be done 
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
        /*
         * This doesnt work if 
        if (desiredAngle == 0)
        {
            Debug.Log("Finished");
            MoveTowards = true;

        }
        */
    }

    private void FixedUpdate()
    {

        if (playerTank != null)
        {
            Vector3 moveSpeed = transform.position - playerTank.position;

            if (MoveTowards)
                enemyTank.MovePosition(transform.position + (-moveSpeed / 8) * Time.deltaTime);
        }
        /*
        Raycast doesnt work idk why
        Need to improve and make the enemy tank move only when facing towards the player

        RaycastHit2D hit = Physics2D.Raycast(transform.position, tankForward.position);
        //RaycastHit2D hit1 = Physics2D.Linecast(transform.position, tankForward.position);
        //playerTank.
        // If it hits something...
        if (hit.collider == playerCollider)
        {
            MoveTowards = true;
            Debug.Log("Raycast hit player = " + hit.collider.name);
        }
        else
        {
            //MoveTowards = false;
            //Debug.Log(hit.collider.name);
            //Debug.Log("Start pos = " +enemyTank.transform.position + "Direction" + "empty" + " Collision name = " + hit.collider.name);
            //hit.
            //Debug.DrawRay(hit.origin, hit.direction, Color.red, 10.0f);
        }

        */
    }
}
