using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public bool[,] enemyPos = new bool[11, 11];
    public GameObject enemy;
    public int mapScale, szoneScale;
    public int posX, posY;

    public void spawnEnemy()
    {
        for (int i = 0; i < 5; i++)
        {
            while (true)
            {
                int x = Random.Range(0, 11);
                int y = Random.Range(0, 11);
                if (!IsSafezone(x, y))
                {
                    posX = x;
                    posY = y;
                    break;
                }
            }
            if (enemyPos[posX, posY] == true)
            {
                i--;
            }
            else
            {
                Vector3 spawnPos = new Vector3(posX,posY, 0);
                Instantiate(enemy, spawnPos, Quaternion.identity);
                enemyPos[posX, posY] = true;
            }
        }
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
}
