using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PolygonCollider2D meteorCollider;

    [SerializeField] private float minSpeed = 4.0f, maxSpeed = 8.0f;
    private float speedX;
    private float speedY;

    [SerializeField] private float minRotationSpeed = 15.0f, maxRotationSpeed = 30.0f;
    private float rotationSpeed;

    private Vector3 tempMovement;

    [SerializeField]private bool moveOnX, MoveOnY = true;


    private void Awake()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if (Random.Range(0, 2) > 0)
            speedX *= -1;


        if (Random.Range(0, 2) > 0)
            rotationSpeed *= -1;

        if (Random.Range(0, 2) > 0)
            moveOnX = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        meteorCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementX();
        HandleMovementY();
        RotateMeteor();
    }

    private void HandleMovementX()
    {
        if (!moveOnX)
            return;

        tempMovement = transform.position;
        tempMovement.x += speedX * Time.deltaTime;
        transform.position = tempMovement;
    }

    private void HandleMovementY()
    {
        if (!MoveOnY)
            return;

        tempMovement = transform.position;
        tempMovement.y -= speedY * Time.deltaTime;
        transform.position = tempMovement;
    }

    private void RotateMeteor()
    {
        transform.Rotate(new Vector3(0,0, rotationSpeed * Time.deltaTime));
    }

  
}
