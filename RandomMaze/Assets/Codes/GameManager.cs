using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static GameManager Instance;

    public int mapScale = 11;
    public int szoneScale = 3;
    public GameObject[,] modules = new GameObject[11,11];
    public int goalX, goalY;


    //Scripts
    public SpawnModule SpawnModule;
    public MazeSolver MazeSolver;
    public UImanager UImanager;

    private void Awake()
    {
        setGoal();


        Instance = this;
    }

    private void Start()
    {
        //SpawnModule.SpawnMaze();
        //MazeSolver.ValidMaze();


        StartCoroutine(GenerateMaze());
    }

    public void ChangeClearScene()
    {
        UImanager.PlayerReachedGoal();
    }

    
    IEnumerator GenerateMaze()
    {
        while (true)
        {
            setGoal();
            MazeSolver.reset();
            SpawnModule.SpawnMaze();
            yield return null;

            if (MazeSolver.ValidMaze())
            {
                UImanager.endLoading();
                break;
            }
            else
            {
                SpawnModule.DestroyMaze();
                yield return null;
            }
        }
    }
    void setGoal()
    {
        int pos = Random.Range(0, 4);
        switch (pos)
        {
            case 0:
                goalX = 0; goalY = Random.Range(0, 11);
                break;
            case 1:
                goalY = 0; goalX = Random.Range(0, 11);
                break;
            case 2:
                goalX = 10; goalY = Random.Range(0, 11);
                break;
            case 3:
                goalY = 10; goalX = Random.Range(0, 11);
                break;
        }
    }
}
    