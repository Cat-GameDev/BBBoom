using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private SpriteRenderer theSR;

    [SerializeField] private Sprite downSprite, upSprite;

    [SerializeField] private float stayUpTime, bouncePower;
    private float upCounter;


    void Update()
    {
        if (upCounter > 0)
        {
            upCounter -= Time.deltaTime;

            if (upCounter <= 0)
            {
                theSR.sprite = downSprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            upCounter = stayUpTime;
            theSR.sprite = upSprite;

            Rigidbody2D theRB = other.GetComponent<Rigidbody2D>();

            theRB.velocity = new Vector2(theRB.velocity.x, bouncePower);

            //AudioManager.instance.PlaySFX(6);
        }
    }
}
