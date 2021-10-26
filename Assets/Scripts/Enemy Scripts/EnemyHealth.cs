using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;

    private Vector3 healthBarScale;

    [SerializeField] private float health = 100;

    [SerializeField] private GameObject hitEffect;

    [SerializeField] private GameObject destroyEffect;

    private DropCollectable dropCollectable;

    [SerializeField] bool meteor, horizontal, pawn, random;
    private int value;

    private void Awake()
    {
        dropCollectable = GetComponent<DropCollectable>();

        if (meteor || pawn)
        {
            value = 3;
        }
        else if (horizontal)
        {
            value = 1;
        }
        else
        {
            value = 2;
        }
    }

    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageAmount -= damageResistance;

        health -= damageAmount;

        if (health <= 0)
        {
            Instantiate(destroyEffect,transform.position,Quaternion.identity);
            SoundManager.instance.PlayEnemyDestroySound();
            dropCollectable.CheckToSpawnCollectable();
            GameplayUIController.instance.SetScore(value);
            //Dead
            EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitEffect,transform.position,Quaternion.identity);
            SoundManager.instance.PlayEnemyHitSound();
        }

        SetHealthBar();
    }

    public void SetHealthBar()
    {
        if (!healthBar)
            return;

        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100f;
        healthBar.transform.localScale = healthBarScale;
    }
}
