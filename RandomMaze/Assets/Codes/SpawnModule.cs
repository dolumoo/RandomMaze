using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnModule : MonoBehaviour
{
    public GameObject[] modules;
    public int mapScale, szoneScale;
    public float[] rotPreset = {0f, 90f, 180f, 270f};

    public int goalX, goalY;

    private void Awake()
    {

    }
   
    private void Start()
    {

    }

    public bool IsSafezone(int x, int y) // 좌표가 safezone인지 체크
    {
        int mapCenterIndex = mapScale / 2;
        int szoneCenterIndex = szoneScale / 2;
        int minIndex = mapCenterIndex - szoneCenterIndex;
        int maxIndex = mapCenterIndex + szoneCenterIndex;

        if (Check(x) && Check(y))
        {
            return true;
        }
        bool Check(int Index)
        {
            return Index >= minIndex && Index <= maxIndex;
        }
        return false;
    }

    public void SpawnObject(int x, int y)
    {
        int index = Random.Range(0, 4);
        int rotIndex = Random.Range(0, 4);
        Vector3 spawnPosition = new Vector3(x, y, 0);
        GameManager.Instance.modules[x, y] = Instantiate(modules[index], spawnPosition, Quaternion.Euler(0, 0, rotPreset[rotIndex]));
    }

    public void SpawnMaze()
    {
        mapScale = GameManager.Instance.mapScale;
        szoneScale = GameManager.Instance.szoneScale;

        goalX = GameManager.Instance.goalX;
        goalY = GameManager.Instance.goalY;

        for (int n = 0; n < mapScale; n++)
        {
            for (int m = 0; m < mapScale; m++)
            {
                if (IsSafezone(n, m))
                {
                    Vector3 spawnPosition = new Vector3(n, m, 0);
                    GameManager.Instance.modules[n, m] = Instantiate(modules[4], spawnPosition, Quaternion.identity);
                }
                else
                {
                    if (n == goalX && m == goalY)
                    {
                        Vector3 spawnPosition = new Vector3(n, m, 0);
                        GameManager.Instance.modules[n, m] = Instantiate(modules[5], spawnPosition, Quaternion.identity);
                    }
                    else
                    {
                        SpawnObject(n, m);
                    }
                }
            }
        }
    }
    public void DestroyMaze()
    {
        for(int n = 0;n < mapScale; n++)
        {
            for(int m = 0; m < mapScale; m++)
            {
                GameObject.Destroy(GameManager.Instance.modules[n,m]);
            }
        }
    }
}

