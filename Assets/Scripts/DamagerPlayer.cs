using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerPlayer : MonoBehaviour
{
    [SerializeField] private int damageToDeal = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && GameManager.Instance.canFight)
        {
            other.GetComponent<PlayerHeathControler>().DamagePlayer(damageToDeal);
        }


    }
}
