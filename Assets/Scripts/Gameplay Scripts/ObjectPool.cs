using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects; //Havuz
        public GameObject objectPrefab;//obje
        public int poolSize;//havuz boyutu - obje say�s�
    }

    [SerializeField] private Pool[] pools = null;

    private void Awake()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>(); // yeni s�ra olu�turduk

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab); //Pool size kadar objeyi olu�turduk
                obj.SetActive(false); 

                pools[j].pooledObjects.Enqueue(obj); // objeleri s�raya soktuk
            }
        }
    }

    public GameObject GetPooledObject(int objectType) // s�radaki objeyi �eker
    {
        if (objectType >= pools.Length)
        {
            return null;
        }

        GameObject obj = pools[objectType].pooledObjects.Dequeue();

        obj.SetActive(true);

        pools[objectType].pooledObjects.Enqueue(obj); // objeyi s�raya geri ekler

        return obj;
    }
}