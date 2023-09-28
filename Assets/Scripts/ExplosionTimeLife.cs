using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimeLife : MonoBehaviour
{
    [SerializeField] private float timeLife = 0.3f;

    private void Start()
    {
        Destroy(gameObject, timeLife);
    }
}
