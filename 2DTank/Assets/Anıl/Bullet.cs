using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<TankHealthSystem>().damagePlayer(damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);

    }
  
}
