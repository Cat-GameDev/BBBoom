using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    private bool roundOver;

    public List<GameObject> playerWinEveryGame = new List<GameObject>();
    private bool noWinner = false;
    static int player1Win=0,player2Win=0, player3Win=0, player4Win=0;

    void Start()
    {
        foreach (PlayerControler player in GameManager.Instance.activePlayers)
        {
            int randomPoint = Random.Range(0, spawnPoints.Count);
            player.transform.position = spawnPoints[randomPoint].position;

            if (GameManager.Instance.activePlayers.Count <= spawnPoints.Count)
            {
                spawnPoints.RemoveAt(randomPoint);
            }
        }
        GameManager.Instance.canFight = true;
        GameManager.Instance.ActivatePlayers();
    }

    void Update()
    {
        if (GameManager.Instance.CheckActivePlayers() == 1 && !roundOver)
        {
            roundOver = true;
            StartCoroutine(EndRoundCo());
        } else if(GameManager.Instance.CheckActivePlayers() == 0 && !roundOver)
        {
            roundOver = true;
            noWinner = true;
            StartCoroutine(EndRoundCo());
        }
    }

    IEnumerator EndRoundCo()
    {
        UIController.Instance.WinBar.SetActive(true);
        if(noWinner == true) {
            UIController.Instance.DeathAll.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            UIController.Instance.LoadingScreen.SetActive(true);
            GameManager.Instance.GoToNextArena();
        } else {
            UIController.Instance.star.SetActive(true);
            checkWin();
            GameManager.Instance.AddRoundWin();
            yield return new WaitForSeconds(3f);
            UIController.Instance.LoadingScreen.SetActive(true);
            GameManager.Instance.GoToNextArena();
        }
        noWinner = false;

    }


    private void checkWin() {
        if(GameManager.Instance.LastPlayerNumber + 1==1) {
            player1Win++;
        } else if(GameManager.Instance.LastPlayerNumber + 1==2) {
            player2Win++;
        } else if(GameManager.Instance.LastPlayerNumber + 1==3) {
            player3Win++;
        } else if(GameManager.Instance.LastPlayerNumber + 1==4) {
            player4Win++;
        }

        switch(player1Win) {
            case 1: 
                playerWinEveryGame[0].SetActive(true);
                break;
            case 2: 
                playerWinEveryGame[0].SetActive(true);
                playerWinEveryGame[1].SetActive(true);
                break;
            case 3:
                playerWinEveryGame[0].SetActive(true);
                playerWinEveryGame[1].SetActive(true);
                playerWinEveryGame[2].SetActive(true);
                break;
            case 4: 
                playerWinEveryGame[0].SetActive(true);
                playerWinEveryGame[1].SetActive(true);
                playerWinEveryGame[2].SetActive(true);
                playerWinEveryGame[3].SetActive(true);
                break;
            case 5:
                playerWinEveryGame[0].SetActive(true);
                playerWinEveryGame[1].SetActive(true);
                playerWinEveryGame[2].SetActive(true);
                playerWinEveryGame[3].SetActive(true);
                playerWinEveryGame[4].SetActive(true);
                break;
        }

        switch(player2Win) {
            case 1: 
                playerWinEveryGame[5].SetActive(true);
                break;
            case 2: 
                playerWinEveryGame[5].SetActive(true);
                playerWinEveryGame[6].SetActive(true);
                break;
            case 3:
                playerWinEveryGame[5].SetActive(true);
                playerWinEveryGame[6].SetActive(true);
                playerWinEveryGame[7].SetActive(true);
                break;
            case 4: 
                playerWinEveryGame[5].SetActive(true);
                playerWinEveryGame[6].SetActive(true);
                playerWinEveryGame[7].SetActive(true);
                playerWinEveryGame[8].SetActive(true);
                break;
            case 5:
                playerWinEveryGame[5].SetActive(true);
                playerWinEveryGame[6].SetActive(true);
                playerWinEveryGame[7].SetActive(true);
                playerWinEveryGame[8].SetActive(true);
                playerWinEveryGame[9].SetActive(true);
                break;
        }

        switch(player3Win) {
            case 1: 
                playerWinEveryGame[10].SetActive(true);
                break;
            case 2: 
                playerWinEveryGame[10].SetActive(true);
                playerWinEveryGame[11].SetActive(true);
                break;
            case 3:
                playerWinEveryGame[10].SetActive(true);
                playerWinEveryGame[11].SetActive(true);
                playerWinEveryGame[12].SetActive(true);
                break;
            case 4: 
                playerWinEveryGame[10].SetActive(true);
                playerWinEveryGame[11].SetActive(true);
                playerWinEveryGame[12].SetActive(true);
                playerWinEveryGame[13].SetActive(true);
                break;
            case 5:
                playerWinEveryGame[10].SetActive(true);
                playerWinEveryGame[11].SetActive(true);
                playerWinEveryGame[12].SetActive(true);
                playerWinEveryGame[13].SetActive(true);
                playerWinEveryGame[14].SetActive(true);
                break;
        }

        switch(player4Win) {
            case 1: 
                playerWinEveryGame[15].SetActive(true);
                break;
            case 2: 
                playerWinEveryGame[15].SetActive(true);
                playerWinEveryGame[16].SetActive(true);
                break;
            case 3:
                playerWinEveryGame[15].SetActive(true);
                playerWinEveryGame[16].SetActive(true);
                playerWinEveryGame[17].SetActive(true);
                break;
            case 4: 
                playerWinEveryGame[15].SetActive(true);
                playerWinEveryGame[16].SetActive(true);
                playerWinEveryGame[17].SetActive(true);
                playerWinEveryGame[18].SetActive(true);
                break;
            case 5:
                playerWinEveryGame[15].SetActive(true);
                playerWinEveryGame[16].SetActive(true);
                playerWinEveryGame[17].SetActive(true);
                playerWinEveryGame[18].SetActive(true);
                playerWinEveryGame[19].SetActive(true);
                break;
        }

        int[] arr = {player1Win,player2Win,player3Win,player4Win};
        int max = -10;
        for(int i = 0; i < arr.Length; i++)
        {
            if (max < arr[i])
                max = arr[i];
        }
        if(max==player1Win) {
            playerWinEveryGame[20].SetActive(true);
        }
        if(max==player2Win) {
            playerWinEveryGame[21].SetActive(true);
        }
        if(max==player3Win) {
            playerWinEveryGame[22].SetActive(true);
        }
        if(max==player4Win) {
            playerWinEveryGame[23].SetActive(true);
        }
        
    }

}
