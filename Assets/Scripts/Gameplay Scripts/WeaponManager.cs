using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    //0 => Laser 1=> Rocket


    [SerializeField] private Transform[] barrels;

    [SerializeField] private float shootTimerTreshold = 0.5f;
    private float shootTimer;
    private bool canShoot;

    //Shoot boost
    private bool isShootBoost;
    [SerializeField] private float defaultValue = 0.5f;
    [SerializeField] private float value = 0.2f;
    public float boostTime = 30;
    private float boostTimer;

    //Rocket
    private float rocketTimer = 0.0f;
    [SerializeField] private float rocketTime = 2.0f;
    private bool canUseRocket;
    private bool isUseRocket;



    // Start is called before the first frame update
    void Start()
    {
        shootTimer = Time.time + shootTimerTreshold;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shootTimer)
            canShoot = true;
        HandleShoot();
    }

    void HandleShoot()
    {
        //If we can't shoot
        if (!canShoot)
            return;
        //Shooting the Laser
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectiles[0], barrels[0].position, Quaternion.identity);
            Instantiate(projectiles[0], barrels[1].position, Quaternion.identity);
            ResetShootTime();
        }

        //Shooting the rocket
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isUseRocket = false;
        }

        if (!isUseRocket)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                //Start ticking
                rocketTimer += Time.deltaTime;

                if (rocketTimer > rocketTime)
                {
                    canUseRocket = true;
                }
            }

            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && canUseRocket)
            {
                Instantiate(projectiles[1], barrels[2].position, Quaternion.identity);
                canUseRocket = false;
                rocketTimer = 0.0f;
                isUseRocket = true;
            }
        }


        
    }

    void ResetShootTime()
    {
        canShoot = false;
        shootTimer = Time.time + shootTimerTreshold;
    }

    void OnShootBoost()
    {
        boostTimer = Time.time + boostTime;
        // On Update we need to use boostTimer - time.deltatime
        if (Time.time < boostTimer)
        {
            shootTimerTreshold = value;
        }
        else
        {
            shootTimerTreshold = defaultValue;
        }
    }
}
