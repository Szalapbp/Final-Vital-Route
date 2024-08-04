using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MFSBackToTitle : MonoBehaviour
{
    public string LoadTitle;

    public void LoadScene()
    {
        SceneManager.LoadScene(LoadTitle);
    }
}
