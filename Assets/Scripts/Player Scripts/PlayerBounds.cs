using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float min_X, max_X, min_Y, max_Y;
    public float offsetX, offsetY;

    private void Update()
    {
        if (transform.position.x < min_X -offsetX)
        {
            Vector3 newPos = new Vector3(max_X,transform.position.y, transform.position.z);
            transform.position = newPos;
        }
        if (transform.position.x > max_X + offsetX)
        {
            Vector3 newPos = new Vector3(min_X, transform.position.y, transform.position.z);
            transform.position = newPos;
        }

        if (transform.position.y > max_Y)
        {
            Vector3 newPos = new Vector3(transform.position.x, min_Y, transform.position.z);
            transform.position = newPos;
        }
        if (transform.position.y < min_Y)
        {
            Vector3 newPos = new Vector3(transform.position.x, max_Y, transform.position.z);
            transform.position = newPos;
        }
    }
}
