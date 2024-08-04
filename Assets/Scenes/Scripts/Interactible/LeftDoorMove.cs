using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorMove : MonoBehaviour
{
    public GameObject leftHeavyDoor;
    public float moveDistance = -10f;

    public void MoveLDoor()
    {
        if(leftHeavyDoor != null)
        {
            Vector3 newPosition = leftHeavyDoor.transform.position + new Vector3(moveDistance, 0, 0);
            leftHeavyDoor.transform.position = newPosition;
        }
    }
}
