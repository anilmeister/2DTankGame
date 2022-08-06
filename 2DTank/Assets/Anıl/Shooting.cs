using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public Transform machineGun;


    [Header("Cannon Attributions")]
    [SerializeField]
    private GameObject mgBulletPrefab, muzzleFlash, machineGunMuzzleFlash;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public int objectPoolSize = 20;
    public bool canShoot = true;
    private float currentDelay = 0f;
    private float reloadDelay = 1f;

    private ObjectPool cannonObjectPool,mgObjectPool;

    public UnityEvent<float> OnReloading;

    private void Awake()
    {
        //mgObjectPool = GetComponent<ObjectPool>();
        cannonObjectPool = GetComponent<ObjectPool>();

    }

    private void Start()
    {
        //mgObjectPool.Initialize(mgBulletPrefab, objectPoolSize);
        cannonObjectPool.Initialize(bulletPrefab, objectPoolSize);
        OnReloading?.Invoke(currentDelay);
    }


    void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            OnReloading.Invoke(currentDelay / reloadDelay);
            if (currentDelay <= 0f)
            {
                canShoot = true;
            }
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            //FindObjectOfType<AudioManager>().Play("CannonSound");
            FindObjectOfType<AudioManager>().PlaySound(1);
            Shoot();

        }

    }


    void Shoot()
    {

        canShoot = false;
       currentDelay = reloadDelay;
       GameObject effect = Instantiate(muzzleFlash, transform.position, Quaternion.identity);
       Destroy(effect, 0.2f);
       var bullet = cannonObjectPool.CreateObject();
       bullet.transform.position = firePoint.position;
       bullet.transform.rotation = firePoint.rotation; 
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }



}
