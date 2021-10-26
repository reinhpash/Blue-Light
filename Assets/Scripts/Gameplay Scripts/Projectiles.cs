using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public int damage;
    [SerializeField] AudioClip spawnSound;


    // Start is called before the first frame update
    void OnEnable()
    {
        if (spawnSound)
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 6f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            Debug.Log("Player Hit!");
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        if (collision.CompareTag(TagManager.ENEMY_TAG) || collision.CompareTag(TagManager.METEOR_TAG))
        {
            Debug.Log("Enemy Hit!");
            collision.GetComponent<EnemyHealth>().TakeDamage(damage,0f);
        }

        if (!collision.CompareTag(TagManager.UNTAGGED) && !collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            gameObject.SetActive(false);
        }
    }
}
