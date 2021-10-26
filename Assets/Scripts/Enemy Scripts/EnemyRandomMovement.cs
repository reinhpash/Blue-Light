using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private float speed = 12.0f;
    private bool findAnotherPosition;
    Vector3 randomPosition;

    private Vector3 SelectRandomPosition()
    {
        int value_X = (int)Random.Range(minX, maxX);
        int value_Y = (int)Random.Range(minY, maxY);
        Vector3 nextPos = new Vector3();
        nextPos.x = value_X;
        nextPos.y = value_Y;
        nextPos.z = 0.0f;

        return nextPos;
    }

    private void MoveToRandomPosition(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    private void Start()
    {
        randomPosition = SelectRandomPosition();
    }

    private void Update()
    {
        MoveToRandomPosition(randomPosition);
        if (Vector3.Distance(transform.position, randomPosition) < 0.1f)
        {
            randomPosition = SelectRandomPosition();
        }
    }

}
