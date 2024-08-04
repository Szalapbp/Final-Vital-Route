using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public string ContinueToHub;

    public void LoadScene()
    {
        SceneManager.LoadScene(ContinueToHub);
    }


}
