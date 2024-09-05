using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeSolver : MonoBehaviour
{
    public int posX, posY;
    public GameObject nModule, sModule, eModule, wModule, myModule;
    public bool nDoorBlocked, eDoorBlocked, sDoorBlocked, wDoorBlocked;
    private bool[,] visited = new bool[17,17];

    private void Start()
    {
        posX = (int)(transform.position.x + 0.5);
        posY = (int)(transform.position.y + 0.5);
    }
    private void Update()
    {
        posX = (int)(transform.position.x + 0.5);
        posY = (int)(transform.position.y + 0.5);
    }

    public bool ValidMaze()
    {
        if (SolveMaze(8, 8))
        {
            Debug.Log("Answer exist");
            return true;
        }
        else
        {
            Debug.Log("No Answer");
            return false;
        }
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

    private bool SolveMaze(int x, int y)
    {
        //목표지점에 도달한 경우
        if (x == GameManager.Instance.goalX && y == GameManager.Instance.goalY)
        {
            return true;
        }
        Debug.Log("("+x + "," + y+")");

        void CheckModule()
        {
            myModule = NearModule(x, y);
            nModule = NearModule(x, y + 1);
            sModule = NearModule(x, y - 1);
            eModule = NearModule(x + 1, y);
            wModule = NearModule(x - 1, y);

            //벽이 막혀있는지 체크
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
        // 상하좌우 모듈 업데이트


        // 이미 방문한 경우 중단 
        if(!VerifyIndex(x,y) || visited[x,y]) 
        {
            Debug.Log("Visited place");
            return false; 
        }

        // 현재 좌표를 방문했다고 표시
        visited[x,y] = true;

        // 백트래킹을 통해 상하좌우로 이동 시도
        if (!nDoorBlocked && SolveMaze(x, y + 1))
            return true;
        CheckModule();
        if (!sDoorBlocked && SolveMaze(x, y - 1))
            return true;
        CheckModule();
        if (!eDoorBlocked && SolveMaze(x + 1, y))
            return true;
        CheckModule();
        if (!wDoorBlocked && SolveMaze(x - 1, y))
            return true;

        // 경로가 막혔다면 방문 여부를 초기화 (백트래킹)
        Debug.Log("BackTraking");
        visited[x, y] = false;
        return false;
    }
}
