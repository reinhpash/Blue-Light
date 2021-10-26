using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPool : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            Destroy(collision.gameObject);
        }
    }
}
