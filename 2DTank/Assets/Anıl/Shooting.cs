using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public Transform machineGun;
    public GameObject bulletPrefab;
    public GameObject mgBulletPrefab;
    public GameObject muzzleFlash;
    public GameObject machineGunMuzzleFlash;


    public float bulletForce = 20f;


    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {

            Shoot();
        }

        if(Input.GetButtonDown("Jump"))
        {
            MachineGun();
        }
    }


    void Shoot()
    {
       GameObject effect = Instantiate(muzzleFlash, transform.position, Quaternion.identity);
       Destroy(effect, 0.2f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
    void MachineGun()
    {
        GameObject effect = Instantiate(machineGunMuzzleFlash, machineGun.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        GameObject bullet = Instantiate(mgBulletPrefab, machineGun.position, machineGun.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(machineGun.up * bulletForce, ForceMode2D.Impulse);
    }


}
