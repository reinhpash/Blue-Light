using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioClip enemyHitSound, enemyDestroySound;
    [SerializeField] private AudioClip playerHitSound, playerDestroySound;
    [SerializeField] private AudioClip pickupSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void PlayEnemyHitSound()
    {
        AudioSource.PlayClipAtPoint(enemyHitSound,transform.position);
    }
    public void PlayEnemyDestroySound()
    {
        AudioSource.PlayClipAtPoint(enemyDestroySound, transform.position);
    }

    public void PlayPlayerHitSound()
    {
        AudioSource.PlayClipAtPoint(playerHitSound, transform.position);
    }
    public void PlayPlayerDestroySound()
    {
        AudioSource.PlayClipAtPoint(playerDestroySound, transform.position);
    }

    public void PlayPickupSound()
    {
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
    }
}
