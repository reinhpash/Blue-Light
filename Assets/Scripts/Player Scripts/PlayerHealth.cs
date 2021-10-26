using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float playerMaxHealth = 100f;
    private float playerHealth;

    [SerializeField] private GameObject playerDestroyFX;
    [SerializeField] private GameObject playerHitFX;

    private Collectable collectable;

    private Slider playerHealthSlider;

    private void Awake()
    {
        playerHealth = playerMaxHealth;
        playerHealthSlider = GameObject.FindGameObjectWithTag(TagManager.PLAYER_SLIDER_TAG).GetComponent<Slider>();
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;
    }
    private void Start()
    {
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        playerHealthSlider.value = playerHealth;
        if (playerHealth <= 0)
        {
            //GameOver
            GameoverUIController.instance.OpenGameOverPanel();
            Instantiate(playerDestroyFX, transform.position,Quaternion.identity);
            SoundManager.instance.PlayPlayerDestroySound();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(playerHitFX, transform.position, Quaternion.identity);
            SoundManager.instance.PlayPlayerHitSound();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectable = collision.GetComponent<Collectable>();
            if (collectable.type == CollectableType.HealBoost)
            {
                Heal(collectable.healAmount);
                playerHealthSlider.value = playerHealth;
                SoundManager.instance.PlayPickupSound();
                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            Debug.Log("Colll");
            TakeDamage(Random.Range(10,40));
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag(TagManager.ENEMY_TAG))
        {
            Debug.Log("Enmey");
            TakeDamage(Random.Range(50, 100));
            collision.GetComponent<EnemyHealth>().TakeDamage(100.0f,0);
        }
    }

    public void Heal(int healAmount)
    {
        playerHealth += healAmount;
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }
}
