using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    private Collectable collectable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            if (collectable.type == CollectableType.RocketBoost)
            {
                SoundManager.instance.PlayPickupSound();
                Destroy(collision.gameObject);
            }
            else if (collectable.type == CollectableType.ShootBoost)
            {
                SoundManager.instance.PlayPickupSound();
                Destroy(collision.gameObject);
            }
        }
    }
}
