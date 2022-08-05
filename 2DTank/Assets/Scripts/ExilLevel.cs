using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExilLevel : MonoBehaviour
{
    
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("bumbastic");
            gameManager.SaveData();
            gameManager.LoadNextLevel();
        }
    }

}
