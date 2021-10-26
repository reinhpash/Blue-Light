using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private List<GameObject> projectilePool = new List<GameObject>();

    private GameObject projectileHolder;

    [SerializeField]
    private KeyCode keyToPressToShoot;

    private bool projectileSpawned;

    [SerializeField]
    private Transform projectileSpawnPoint;

    [SerializeField]
    private float shootWaitTime = 0.5f;

    private float minShootInterval = 0.2f;

    private float shootTimer;

    private bool canShoot;

    [SerializeField]
    private bool isEnemy;

    public bool isLaser;

    public int ammoAmount = 5;
    private int maxAmmoAmount = 10;

    private Collectable collectable;

    private void Awake()
    {
        if (isEnemy)
        {
            projectileHolder = GameObject.FindWithTag(TagManager.ENEMY_PROJECTILE_HOLDER_TAG);
            ResetShootingTimer();
        }
        else
        {
            projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_HOLDER_TAG);
            
        }


    }
    private void Start()
    {
        if (!isEnemy)
            GameplayUIController.instance.SetRocketText(ammoAmount);
        
    }
    private void Update()
    {

        if (Time.time > shootTimer)
            canShoot = true;



        HandlePlayerShooting();
        HandleEnemyShooting();
    }

    void HandlePlayerShooting()
    {

        if (!canShoot || isEnemy)
            return;

        if (isLaser)
        {
            if (Input.GetKey(keyToPressToShoot))
            {
                GetObjectFromPoolOrSpawnANewOne();
                ResetShootingTimer();
            }
        }
        else
        {
            //Rocket
            //isNeedAmmo = true;
            if (Input.GetKeyDown(keyToPressToShoot))
            {
                if (ammoAmount > 0)
                {
                    ammoAmount--;
                    GameplayUIController.instance.SetRocketText(ammoAmount);
                    GetObjectFromPoolOrSpawnANewOne();
                    ResetShootingTimer();
                }

            }
        }
    }

    void GetObjectFromPoolOrSpawnANewOne()
    {

        for (int i = 0; i < projectilePool.Count; i++)
        {

            if (!projectilePool[i].activeInHierarchy)
            {
                //Using a object from the pool
                projectilePool[i].transform.position = projectileSpawnPoint.position;
                projectilePool[i].SetActive(true);

                projectileSpawned = true;

                break;

            }
            else
                projectileSpawned = false;

        }

        if (!projectileSpawned)
        {
            //If pool is empty or we don't have enough object
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint.position,
                Quaternion.identity);

            projectilePool.Add(newProjectile);

            newProjectile.transform.SetParent(projectileHolder.transform);

            projectileSpawned = true;
        }

    }

    void ResetShootingTimer()
    {
        canShoot = false;
        if (isEnemy)
            shootTimer = Time.time + Random.Range(shootWaitTime, (shootWaitTime + 1f));
        else
            shootTimer = Time.time + shootWaitTime;
    }

    void HandleEnemyShooting()
    {
        if (!isEnemy || !canShoot)
            return;

        ResetShootingTimer();
        GetObjectFromPoolOrSpawnANewOne();
    }

    public void PlayerShootBoost(float boostValue)
    {
        shootWaitTime -= boostValue;
        if (shootWaitTime < minShootInterval)
        {
            shootWaitTime = minShootInterval;
        }
    }

    public void PlayerAmmoBoost(int ammoBoost)
    {
        ammoAmount = ammoBoost + ammoAmount;
        if (ammoAmount > maxAmmoAmount)
        {
            ammoAmount = maxAmmoAmount;
        }
        GameplayUIController.instance.SetRocketText(ammoAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnemy)
            return;
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectable = collision.gameObject.GetComponent<Collectable>();
            if (collectable.type == CollectableType.RocketBoost)
            {
                PlayerAmmoBoost(collectable.RocketBoostAmount);
                SoundManager.instance.PlayPickupSound();
                Destroy(collision.gameObject);
            }
            else if (collectable.type == CollectableType.ShootBoost)
            {
                PlayerShootBoost(collectable.ShootBoostAmount);
                SoundManager.instance.PlayPickupSound();
                Destroy(collision.gameObject);
            }
        }
    }

} // class






































