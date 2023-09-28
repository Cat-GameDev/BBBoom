using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaSelecButton : MonoBehaviour
{
    [SerializeField] private  SpriteRenderer theSR;

    [SerializeField] private  Sprite buttonUp, buttonDown;

    [SerializeField] private  bool isPressed;

    [SerializeField] private  float waitToPopUp;
    private float popCounter;

    [SerializeField] private AnimatorOverrideController theController;
    [SerializeField] private Boom boomType;
    [SerializeField] private BoomStraight boomtype;
    void Update()
    {
        if (isPressed)
        {
            popCounter -= Time.deltaTime;

            if (popCounter <= 0)
            {
                isPressed = false;

                theSR.sprite = buttonUp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isPressed)
        {
            PlayerControler thePlayer = other.GetComponent<PlayerControler>();

            if (thePlayer.Rb.velocity.y < -.1f)
            {
                thePlayer.Anim.runtimeAnimatorController = theController;
                thePlayer.LaunchableBoomPrefab = boomType;
                thePlayer.boomPrefab = boomtype;
                isPressed = true;

                theSR.sprite = buttonDown;

                popCounter = waitToPopUp;
            }

            //AudioManager.instance.PlaySFX(2);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && isPressed)
        {
            isPressed = false;

            theSR.sprite = buttonUp;
        }
    }
}
