using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyPointToPointMovement : MonoBehaviour
{
    [SerializeField] private float minX, maxX, minY, maxY;

    public Transform[] pointsToMove;
    private int currentPointIndex;
    [SerializeField] private float speed = 12.0f;
    private Vector3 targetPosition;
    private int currentMoveIndex;

    [SerializeField]
    private bool moveRandomly;

    private bool findAnotherPosition;

    private void Start()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("MovementPoint");

        for (int i = 0; i < array.Length; i++)
        {
            pointsToMove[i] = array[i].gameObject.transform;
        }
        SelectBehaviour();
    }

    void SelectBehaviour()
    {
        if (moveRandomly)
            SelectMovementPoint();
        else
            SelectPointToPointPosition();
    }

    private void SelectMovementPoint()
    {
        while (pointsToMove[currentMoveIndex].position == transform.position)
        {
            currentMoveIndex = Random.Range(0, pointsToMove.Length);
        }
        
        targetPosition = pointsToMove[currentMoveIndex].position;
    }

    void SelectPointToPointPosition()
    {

        if (currentMoveIndex == pointsToMove.Length)
            currentMoveIndex = 0;

        targetPosition = pointsToMove[currentMoveIndex].position;

        currentMoveIndex++;

    }

    private void RandomMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position,
           targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SelectMovementPoint();
        }
    }

    private void PointMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position,
           targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SelectPointToPointPosition();
        }
    }




    private void Update()
    {
        PointMovement();
    }
}
