using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorMove : MonoBehaviour
{
    public GameObject rightHeavyDoor;
    public float moveDistance = 10f;

    public void MoveRDoor()
    {
        if (rightHeavyDoor != null)
        {
            Vector3 newPosition = rightHeavyDoor.transform.position + new Vector3(moveDistance, 0, 0);
            rightHeavyDoor.transform.position = newPosition;
        }
    }
}
