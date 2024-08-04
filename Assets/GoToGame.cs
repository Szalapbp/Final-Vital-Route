using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    public string LevelSelect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Helipad"))
        {
            SceneManager.LoadScene(LevelSelect);
        }
    }
}
