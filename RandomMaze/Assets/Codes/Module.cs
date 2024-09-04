using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public Door[] doors;
    public Door nDoor, eDoor, sDoor, wDoor;

    private void Awake()
    {
        doors = GetComponentsInChildren<Door>();
        for (int i = 0; i < doors.Length; i++)
        {
            CheckCompass(doors[i]);
        }
    }

    public void CheckCompass(Door door)
    {
        Vector2 myPos = transform.position;
        Vector2 doorPos = door.transform.position;

        if (doorPos.y > myPos.y + 0.3f)
        {
            nDoor = door;
        }
        else if (doorPos.y < myPos.y - 0.3f)
        {
            sDoor = door;
        }
        if (doorPos.x > myPos.x + 0.3f)
        {
            eDoor = door;
        }
        else if (doorPos.x < myPos.x - 0.3f)
        {
            wDoor = door;
        }
    }
}
