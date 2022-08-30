using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{

    public Transform firePoint;
    public bool canShoot = true;
    private float currentDelay = 0f;
    private float reloadDelay = 4f;


    private Vector2 randomDirection = Vector2.zero;



    [Header("Cannon Attributions")]
    [SerializeField]
    private GameObject muzzleFlash;
    public GameObject bulletPrefab;
    public float bulletForce = 0.5f;
    public int objectPoolSize = 10;
    public Transform tank;
    public Transform player;
    public float offset = 90f;
    public float rotationSpeed;
    // Start is called before the first frame update

    [SerializeField] GameObject getSight;
    //EnemyTankMovement sight;


    private ObjectPool cannonObjectPool;

    private void Awake()
    {
        //mgObjectPool = GetComponent<ObjectPool>();
        cannonObjectPool = GetComponent<ObjectPool>();
        randomDirection = Random.insideUnitCircle;
    }

    private void Start()
    {
        cannonObjectPool.Initialize(bulletPrefab, objectPoolSize);
    }


    void Update()
    {
        if (getSight.GetComponent<EnemyTankMovement>().isPlayerInSightRange())
        {
            Vector2 playerPosition = player.position;


            var turretDirection = (Vector3)playerPosition - transform.position;
            //Getting the direction needed to turn   (Mouse position - turret position)
            //var turretDirection = (Vector3)mouseWorldPosition - transform.position;
            var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

            //Multiplying with deltatime
            var rotationStep = rotationSpeed * Time.deltaTime;

            //Rotating the turret with rotation speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle - offset), rotationStep);
            //Quaternion.
            if (canShoot == false)
            {
                currentDelay -= Time.deltaTime;
                if (currentDelay <= 0f)
                {
                    canShoot = true;
                }
            }
            if (getSight.GetComponent<EnemyTankMovement>().isPlayerInAttackRange())
            {
                if(canShoot)
                    Shoot();

            }
        }
        else
        {
            randomDirection = Random.insideUnitCircle;
            var turretDirection = (Vector3)randomDirection - transform.position;
            //Getting the direction needed to turn   (Mouse position - turret position)
            //var turretDirection = (Vector3)mouseWorldPosition - transform.position;
            var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

            //Multiplying with deltatime
            var rotationStep = rotationSpeed * Time.deltaTime;

            //Rotating the turret with rotation speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle - offset), rotationStep);
        }
    }
    void Shoot()
    {
        canShoot = false;
        currentDelay = reloadDelay;
        GameObject effect = Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        Destroy(effect, 0.2f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        /*var bullet = cannonObjectPool.CreateObject();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        */
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        Destroy(bullet, 5f);
        //Invoke("Destory", 10f);
    }

    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - offset);
        transform.position = tank.position;
    }
}
