using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour
{
    [SerializeField] private TMP_Text winText;
    [SerializeField] private Image playerImage;

    [SerializeField] private string mainMenuScene, charSelectScene;

    void Start()
    {
        winText.text = "Player " + (GameManager.Instance.LastPlayerNumber + 1) + " Wins The Game!";
        playerImage.sprite = GameManager.Instance.activePlayers[GameManager.Instance.LastPlayerNumber].GetComponent<SpriteRenderer>().sprite;
    }



    public void PlayAgain()
    {
        GameManager.Instance.StartFirstRound();
    }

    public void SelectCharacters()
    {
        ClearGame();

        SceneManager.LoadScene(charSelectScene);
    }

    public void MainMenu()
    {
        ClearGame();

        SceneManager.LoadScene(mainMenuScene);
    }

    public void ClearGame()
    {
        
        foreach (PlayerControler player in GameManager.Instance.activePlayers)
        {
            Destroy(player.gameObject);
        }

        Destroy(GameManager.Instance.gameObject);
        GameManager.Instance = null;
    }
}
