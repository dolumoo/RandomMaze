using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int mapScale = 9;
    public int szoneScale = 3;

    private void Awake()
    {
        Instance = this;
    }
}
