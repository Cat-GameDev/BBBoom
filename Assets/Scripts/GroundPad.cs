using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPad : MonoBehaviour
{
    [SerializeField] private GameObject pad;
    void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            StartCoroutine(lol());
        }
    }

    IEnumerator lol()
    {
        yield return new WaitForSeconds(1f);
        pad.SetActive(false);
        yield return new WaitForSeconds(2f);
        pad.SetActive(true);
    }

}
