using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    [SerializeField] private int stompDamage;
    [SerializeField] private float bounceForce = 12f;
    [SerializeField] private PlayerControler thePlayer;

    void Start()
    {
        transform.position = new Vector2(0, 0);
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           if (GameManager.Instance.canFight)
           {
                other.GetComponent<PlayerHeathControler>().DamagePlayer(stompDamage);
           }
            thePlayer.Rb.velocity = new Vector2(thePlayer.Rb.velocity.x, bounceForce);
        }
    }
}
