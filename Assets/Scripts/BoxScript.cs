using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxScript : MonoBehaviour
{
    [SerializeField] private GameObject BoxInside;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boom")
        {
            Destroy(gameObject);
            BoxInside.SetActive(true);
        }
    }


}
