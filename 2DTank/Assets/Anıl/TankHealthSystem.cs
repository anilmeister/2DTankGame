using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class TankHealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth = 0f;
    public GameObject deathExplosion;
    public GameObject whichTank;
    public UnityEvent<float> HealthFill;
    //public UnityEvent<float> OnHealthChange;
    public float delay = 2f;
    void Start()
    {
        if (currentHealth == 0f)
            currentHealth = maxHealth;
        HealthFill?.Invoke(1);
        Debug.Log("this tank" + whichTank.tag);
    }

    void Update()
    {
        HealthFill.Invoke(currentHealth / maxHealth);
        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
            GameObject effect = Instantiate(deathExplosion, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
            if (whichTank.tag == "Player") {

                //StartCoroutine(PlayerDeathFunc(delay));
                //Invoke("RestartScene", 0f);
                Scene thisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(thisScene.name);
            }

            //Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator PlayerDeathFunc(float delay)
    {
        //Print the time of when the function is first called.
        Debug.Log("Death Timestamp = " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(delay);
        

    }
    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
    public void damagePlayer(float damageTaken)
    {
        //HealthFill.Invoke(currentHealth / maxHealth);
        currentHealth -= damageTaken;
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
