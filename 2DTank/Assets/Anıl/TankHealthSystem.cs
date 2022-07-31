using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject deathExplosion;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(deathExplosion, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }
    public void damagePlayer(int damageTaken)
    {
        currentHealth -= damageTaken;
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
