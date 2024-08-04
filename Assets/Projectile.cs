using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 100f;
    public float lifeTime = 2f;
    public int damage = 50;
    public GameObject enemyDamage;
   
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);

            if(enemyDamage!= null)
            {
                Instantiate(enemyDamage, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);

        
    }


}
