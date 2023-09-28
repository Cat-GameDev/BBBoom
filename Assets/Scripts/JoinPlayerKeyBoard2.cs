using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayerKeyBoard2 : MonoBehaviour
{
    [SerializeField] private GameObject playerToLoad;

    private bool hasLoadedPlayer;

    
    void Update()
    {
        if(GameManager.Instance != null) {
            if (!hasLoadedPlayer && GameManager.Instance.activePlayers.Count < GameManager.Instance.maxPlayers)
            {
                if (Keyboard.current.jKey.wasPressedThisFrame || Keyboard.current.lKey.wasPressedThisFrame)
                {
                    Instantiate(playerToLoad, transform.position, transform.rotation);
                    hasLoadedPlayer = true;
                }
            }
        }
        
        
    }
}
