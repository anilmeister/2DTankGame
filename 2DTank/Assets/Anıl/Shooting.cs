using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public Transform machineGun;


    [Header("Cannon Attributions")]
    [SerializeField]
    private GameObject bulletPrefab, mgBulletPrefab, muzzleFlash, machineGunMuzzleFlash;

    public float bulletForce = 20f;

    public int objectPoolSize = 20;

    private ObjectPool cannonObjectPool,mgObjectPool;

    private void Awake()
    {
        mgObjectPool = GetComponent<ObjectPool>();
        cannonObjectPool = GetComponent<ObjectPool>();

    }

    private void Start()
    {
        mgObjectPool.Initialize(mgBulletPrefab, objectPoolSize);
        cannonObjectPool.Initialize(bulletPrefab, objectPoolSize);

    }


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if(Input.GetKey("space"))
        {
            //MachineGun();
        }
    }


    void Shoot()
    {
       GameObject effect = Instantiate(muzzleFlash, transform.position, Quaternion.identity);
       Destroy(effect, 0.2f);
       var bullet = cannonObjectPool.CreateObject();
       bullet.transform.position = firePoint.position;
       bullet.transform.rotation = firePoint.rotation; 
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
    void MachineGun()
    {
        GameObject effect = Instantiate(machineGunMuzzleFlash, machineGun.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        //GameObject bullet = Instantiate(mgBulletPrefab, machineGun.position, machineGun.rotation);
        var bullet = mgObjectPool.CreateObject();
        bullet.transform.position = machineGun.position;
        bullet.transform.rotation = machineGun.rotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(machineGun.up * bulletForce, ForceMode2D.Impulse);
    }


}
