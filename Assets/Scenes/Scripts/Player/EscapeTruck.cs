using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeTruck : MonoBehaviour
{
    public string LevelSelect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Truck"))
        {
            if (EnemyManager.Instance.EnemiesEliminated())
            {
                SceneManager.LoadScene(LevelSelect);
            }
            else
            {
                Debug.Log("Can't leave yet, there are more enemies to eliminate");
            }
        }
    }
}
