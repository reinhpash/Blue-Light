using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private float movementSpeed = 6.0f;
    private int randomIndex;

    private void Awake()
    {
        points = GameObject.FindGameObjectsWithTag(TagManager.HORIZONTAL_POINTS);

        randomIndex = Random.Range(0,points.Length);
    }

    void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[randomIndex].transform.position, movementSpeed * Time.deltaTime);

    }

    private void Update()
    {
        HandleMovement();

        if (Vector3.Distance(transform.position, points[randomIndex].transform.position) < 0.1f)
        {
            randomIndex = Random.Range(0, points.Length);
        }
    }

}
