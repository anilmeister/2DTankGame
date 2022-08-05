using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    public float healthValue;
    private void Awake()
    {
        healthValue = 20f;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Health Picked Up");

            if (collision.GetComponent<TankHealthSystem>().currentHealth > 80)
                collision.GetComponent<TankHealthSystem>().setMaxHealth();
            else
                collision.GetComponent<TankHealthSystem>().addHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
