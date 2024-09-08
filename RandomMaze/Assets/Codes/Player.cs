using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Goal"))
        {
            GameManager.Instance.ChangeClearScene();
            Debug.Log("Goal!");
        }
        else if (col.CompareTag("Enemy"))
        {
            GameManager.Instance.ChangeFailScene();
            Debug.Log("Fail!");
        }

    }
}
