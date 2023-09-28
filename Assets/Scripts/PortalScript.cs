using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private Transform exitPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player" || other.tag == "Boom")
        {
            other.transform.position = exitPoint.position;
        }
    }
}
