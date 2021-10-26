using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CollectableType
{
    RocketBoost,
    ShootBoost,
    HealBoost
}
public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public int RocketBoostAmount = 5;
    public float ShootBoostAmount = 0.2f;
    public int healAmount = 50;
    [SerializeField]private float speed = 3.0f;
    private Vector3 tempPos;

    private void Update()
    {
        tempPos = transform.position;
        tempPos.y -= speed * Time.deltaTime;
        transform.position = tempPos;
    }

}
