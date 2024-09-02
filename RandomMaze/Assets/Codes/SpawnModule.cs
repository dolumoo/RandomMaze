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



    private void Awake()
    {

    }

    private void Start()
    {
        mapScale = GameManager.Instance.mapScale;
        szoneScale = GameManager.Instance.szoneScale;

        for (int n = 0; n < mapScale; n++)
        {
            for (int m = 0; m < mapScale; m++)
            {
                if (IsSafezone(n, m))
                {

                }
                else
                {
                    SpawnObject(n, m);
                }
            }
        }
    }

    public bool IsSafezone(int x, int y) // ��ǥ�� safezone���� üũ
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
}

