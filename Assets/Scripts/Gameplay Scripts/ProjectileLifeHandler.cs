using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeHandler : MonoBehaviour
{

    [SerializeField]
    private float time = 3f;

    private void OnEnable()
    {
        StartCoroutine(Deactive());
    }

    private void OnDisable()
    {
        StopCoroutine(Deactive());
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(time);
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }

}
