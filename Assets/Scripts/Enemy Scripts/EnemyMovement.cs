using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float min_X, max_X;
    private float min_Y, max_Y;

    [SerializeField] private bool moveOn_X;
    [SerializeField] private bool moveOn_Y;

    [SerializeField] private float speed;
    [SerializeField] private float MovementTreshold_X = 8.0f;
    [SerializeField] private float MovementTreshold_Y = 6.0f;

    private bool moveLeft;
    private bool moveUp = false;
    private Vector3 tempMovementOn_X;
    private Vector3 tempMovementOn_Y;

    private void Start()
    {
        min_X = transform.position.x - MovementTreshold_X;
        max_X = transform.position.x + MovementTreshold_X;

        max_Y = transform.position.y;
        min_Y = transform.position.y - MovementTreshold_Y;

        if (Random.Range(0,2) > 0)
        {
            moveLeft = true;
        }
    }

    private void Update()
    {
        HandleEnemyMovementOnX();
        HandleEnemyMovementOnY();
    }

    void HandleEnemyMovementOnX()
    {
        if (!moveOn_X)
            return;

        if (moveLeft)
        {
            tempMovementOn_X = transform.position;
            tempMovementOn_X.x -= speed * Time.deltaTime;
            transform.position = tempMovementOn_X;

            if (tempMovementOn_X.x < min_X)
            {
                moveLeft = false;
            }
        }
        else
        {
            tempMovementOn_X = transform.position;
            tempMovementOn_X.x += speed * Time.deltaTime;
            transform.position = tempMovementOn_X;

            if (tempMovementOn_X.x > max_X)
            {
                moveLeft = true;
            }
        }
    }

    void HandleEnemyMovementOnY()
    {
        if (!moveOn_Y)
            return;

        if (!moveUp)
        {
            tempMovementOn_Y = transform.position;
            tempMovementOn_Y.y -= speed * Time.deltaTime;
            transform.position = tempMovementOn_Y;

            if (tempMovementOn_Y.y < min_Y)
            {
                moveUp = true;
            }
        }
        else
        {
            tempMovementOn_Y = transform.position;
            tempMovementOn_Y.y += speed * Time.deltaTime;
            transform.position = tempMovementOn_Y;

            if (tempMovementOn_Y.y > max_Y)
            {
                moveUp = false;
            }
        }
    }

}
