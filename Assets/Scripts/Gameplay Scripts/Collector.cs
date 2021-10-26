using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PROJECTILE_TAG))
            collision.gameObject.SetActive(false);

        if (collision.CompareTag(TagManager.METEOR_TAG)
            || collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            Destroy(collision.gameObject);
        }
    }
}
