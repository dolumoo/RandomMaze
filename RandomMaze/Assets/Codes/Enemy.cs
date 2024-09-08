using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetPos;
    public float speed = 0.2f;


    void DetectObject(Vector2 direction)
    {
        Vector3 startPos = transform.position + (Vector3)direction * 0.12f;
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, 1.5f);
        Debug.DrawRay(transform.position, direction * 1.5f, Color.cyan);
        if(hit.collider != null)
        {
            Debug.Log("Ray Casted!" + hit.collider.gameObject.name);
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                player = hit.collider.gameObject;
                int posX = (int)(player.transform.position.x + 0.5);
                int posY = (int)(player.transform.position.y + 0.5);
                targetPos = new Vector2(posX, posY);
            }
        }
    }

    private void Update()
    {
        DetectObject(Vector2.up);
        DetectObject(Vector2.down);
        DetectObject(Vector2.left);
        DetectObject(Vector2.right);

        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }
    }
}
