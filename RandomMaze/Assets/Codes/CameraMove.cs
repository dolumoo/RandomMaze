using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public MazeSolver player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xVec = player.transform.position.x;
        float yVec = player.transform.position.y;
        Vector3 myPos = new Vector3(xVec, yVec, -10f);
        transform.position = myPos;
    }
}
