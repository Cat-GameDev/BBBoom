using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayerKeyBoard4 : MonoBehaviour
{
    [SerializeField] private  GameObject playerToLoad;

    private bool hasLoadedPlayer;


    void Update()
    {
        if (GameManager.Instance != null)
        {
            if (!hasLoadedPlayer && GameManager.Instance.activePlayers.Count < GameManager.Instance.maxPlayers)
            {
                if (Keyboard.current.numpad1Key.wasPressedThisFrame || Keyboard.current.numpad3Key.wasPressedThisFrame)
                {
                    Instantiate(playerToLoad, transform.position, transform.rotation);
                    hasLoadedPlayer = true;
                }
            }
        }


    }
}
