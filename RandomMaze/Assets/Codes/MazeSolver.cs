using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeSolver : MonoBehaviour
{
    public int x, y;
    public GameObject nModule, sModule, eModule, wModule, myModule;
    public bool nDoorBlocked, eDoorBlocked, sDoorBlocked, wDoorBlocked;

    private void Update()
    {
        x = (int)(transform.position.x + 0.5);
        y = (int)(transform.position.y + 0.5);

        myModule = NearModule(x, y);
        nModule = NearModule(x, y + 1);
        sModule = NearModule(x, y - 1);
        eModule = NearModule(x + 1, y);
        wModule = NearModule(x - 1, y);

        if (myModule != null)
        {
            if (nModule != null)
            {
                if (myModule.GetComponent<Module>().nDoor.IsBlocked ||
                    nModule.GetComponent<Module>().sDoor.IsBlocked)
                {
                    nDoorBlocked = true;
                }
                else nDoorBlocked = false;
            }
            else { nDoorBlocked = true; }

            if (eModule != null)
            {
                if (myModule.GetComponent<Module>().eDoor.IsBlocked ||
                    eModule.GetComponent<Module>().wDoor.IsBlocked)
                {
                    eDoorBlocked = true;
                }
                else eDoorBlocked = false;
            }
            else { eDoorBlocked = true; }

            if (sModule != null)
            {
                if (myModule.GetComponent<Module>().sDoor.IsBlocked ||
                    sModule.GetComponent<Module>().nDoor.IsBlocked)
                {
                    sDoorBlocked = true;
                }
                else sDoorBlocked = false;
            }
            else { sDoorBlocked = true; }

            if (wModule != null)
            {
                if (myModule.GetComponent<Module>().wDoor.IsBlocked ||
                    wModule.GetComponent<Module>().eDoor.IsBlocked)
                {
                    wDoorBlocked = true;
                }
                else wDoorBlocked = false;
            }
            else { wDoorBlocked = true; }
        }
    }

    private void FixedUpdate()
    {

    }



    public GameObject NearModule(int n, int m)
    {
        if (VerifyIndex(n, m))
        {
            return GameManager.Instance.modules[n,m];
        }
        return null;
    }
    bool VerifyIndex(int n, int m)
    {
        return Check(n) && Check(m);
    }
    bool Check(int index)
    {
        return index >= 0 && index < GameManager.Instance.mapScale;
    }
}
