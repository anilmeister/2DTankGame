using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            gameObject.SetActive(false);


        if (collision != null)
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
                collision.gameObject.GetComponent<TankHealthSystem>().damagePlayer(damage);

    }
  
}
