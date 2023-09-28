using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectUI : MonoBehaviour
{
    [SerializeField] private  GameObject joinText;

    void Update()
    {
        if (GameManager.Instance.activePlayers.Count >= GameManager.Instance.maxPlayers)
        {
            joinText.SetActive(false);
        }
        else
        {
            joinText.SetActive(true);
        }
    }
}
