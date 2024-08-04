using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseDistance;
    public NavMeshAgent navMeshAgent;
    public int maxHealth = 100;
    private int currentHealth;
    private AudioSource audioSource;

    private StateMachine currentState;

    public float damageAmount = 10f;
    public float damageInterval = 2f;
    private Coroutine damageCoroutine;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ChangeState(new IdleState(this));
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if(player == null)
            {
                Debug.LogError("Player could not be found");
            }
        }

        EnemyManager.Instance.RegisterEnemy(this);
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(StateMachine newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        EnemyManager.Instance.UnregisterEnemy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyTrigger"))
        {
            if(damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DamageOverTime(other.GetComponentInParent<PlayerHealth>()));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyTrigger"))
        {
            if(damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
      
    }

    private IEnumerator DamageOverTime(PlayerHealth playerHealth)
    {
        while (true)
        {
            playerHealth.TakeDamage(damageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
