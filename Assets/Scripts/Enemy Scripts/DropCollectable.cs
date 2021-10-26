using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectable : MonoBehaviour
{
    [SerializeField] private GameObject[] Collectables;
    public void CheckToSpawnCollectable()
    {
        if (Random.Range(0,25)> 20)
        {
            Instantiate(Collectables[Random.Range(0,Collectables.Length)],transform.position,Quaternion.identity);
        }
    }
}
