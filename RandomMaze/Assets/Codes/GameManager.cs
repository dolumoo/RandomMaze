using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static GameManager Instance;
    public GameObject[,] modules = new GameObject[9, 9];
    public int mapScale = 9;
    public int szoneScale = 3;

    private void Awake()
    {
        Instance = this;
    }
}
