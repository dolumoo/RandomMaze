using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static GameManager Instance;

    public int mapScale = 17;
    public int szoneScale = 3;
    public GameObject[,] modules = new GameObject[17,17];
    public int goalX, goalY;


    //Scripts
    public SpawnModule SpawnModule;
    public MazeSolver MazeSolver;

    private void Awake()
    {
        int pos = Random.Range(0, 4);
        switch (pos)
        {
            case 0:
                goalX = 0; goalY = Random.Range(0, 17);
                break;
            case 1:
                goalY = 0; goalX = Random.Range(0, 17);
                break;
            case 2:
                goalX = 16; goalY = Random.Range(0, 17);
                break;
            case 3:
                goalY = 16; goalX = Random.Range(0, 17);
                break;
        }


        Instance = this;
    }

    private void Start()
    {
        SpawnModule.SpawnMaze();
        MazeSolver.ValidMaze();




        /*
        while(true)
        {
            SpawnModule.SpawnMaze();
            if(MazeSolver.ValidMaze()) { break; }
            else { SpawnModule.DestroyMaze(); }
        }
        */
    }
}
    