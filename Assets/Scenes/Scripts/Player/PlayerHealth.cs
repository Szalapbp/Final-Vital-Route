using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    public delegate void OnHealthChanged(float currentHealth);
    public event OnHealthChanged HealthChanged;

    public AudioSource damage;
   
   

    private void Start()
    {
        currentHealth = maxHealth;
        HealthChanged?.Invoke(currentHealth);
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        
        if(damage != null)
        {
            damage.Play();
        }
       
        


        
        if(currentHealth <= 0f)
        {
            Die();
        }
        HealthChanged?.Invoke(currentHealth);

        
    }
    void Die()
    {
        Debug.Log("Died");

        Destroy(gameObject);
        SceneManager.LoadScene("Failed Mission Screen");
    }
}
