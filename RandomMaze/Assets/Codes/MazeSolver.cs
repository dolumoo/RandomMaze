using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSolver : MonoBehaviour
{
    public int x, y;
    public GameObject nModule, sModule, eModule, wModule, myModule;


    private void Update()
    {
        x = (int)(transform.position.x + 0.5);
        y = (int)(transform.position.y + 0.5);

        myModule = NearModule(x, y);
        nModule = NearModule(x, y+1);
        sModule = NearModule(x, y-1);
        eModule = NearModule(x+1, y);
        wModule = NearModule(x - 1, y);
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
