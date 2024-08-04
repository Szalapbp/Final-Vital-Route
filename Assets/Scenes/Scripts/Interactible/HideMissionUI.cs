using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMissionUI : MonoBehaviour
{
    public GameObject missionUI;
    public GameObject CamHolder;
    public GameObject player;

    private PlayerCam cameraMovement;
    private PMovement playerMovement;

    void Start()
    {
        cameraMovement = CamHolder.GetComponent<PlayerCam>();
        playerMovement = player.GetComponent<PMovement>();
    }


    public void HidePanel()
    {
        missionUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraMovement.enabled = true;
        playerMovement.enabled = true;
        
    }

}
