using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayerKeyBoard3 : MonoBehaviour
{
    [SerializeField] private  GameObject playerToLoad;

    private bool hasLoadedPlayer;


    void Update()
    {
        if (GameManager.Instance != null)
        {
            if (!hasLoadedPlayer && GameManager.Instance.activePlayers.Count < GameManager.Instance.maxPlayers)
            {
                if (Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
                {
                    Instantiate(playerToLoad, transform.position, transform.rotation);
                    hasLoadedPlayer = true;
                }
            }
        }


    }
}
