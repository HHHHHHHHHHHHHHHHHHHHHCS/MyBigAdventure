using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private enum Direction
    {
        up, down, left, right
    }


    [SerializeField]
    private Direction direction;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float distance;

    private Vector3 startPos;
    private Vector3 moveDir;
    private float moveDistance;

    private void Awake()
    {
        startPos = transform.position;

        switch (direction)
        {
            case Direction.up:
                {
                    moveDir = Vector3.up;
                    break;
                }
            case Direction.down:
                {
                    moveDir = Vector3.down;
                    break;
                }
            case Direction.left:
                {
                    moveDir = Vector3.left;
                    break;

                }
            case Direction.right:
                {
                    moveDir = Vector3.right;
                    break;
                }
        }
    }

    private void Update()
    {
        if (moveDistance >= distance)
        {
            moveDistance = 0;
            transform.position = startPos;
        }
        else
        {
            float timer = Time.deltaTime * moveSpeed;
            moveDistance += timer;
            transform.position += moveDir * timer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(1);
        if (collision.CompareTag(Tags.player))
        {
            Debug.Log("DIE DIE DIE!");
        }
    }
}
