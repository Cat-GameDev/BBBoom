using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxPlayers;
    public List<PlayerControler> activePlayers = new List<PlayerControler>();
    private static GameManager instance;
    public static GameManager Instance { get => instance; set => instance = value; }

    [SerializeField] private GameObject playerSpawnEffect;
    public bool canFight;
    [SerializeField] private string[] allLevels;
    private List<string> levelOrder = new List<string>();

    [HideInInspector]
    private int lastPlayerNumber;
    public int LastPlayerNumber { get => lastPlayerNumber;}
    private bool gameWon;

    [SerializeField] private int pointsToWin = 3;
    private List<int> roundWins = new List<int>();
    [SerializeField] private string winLevel;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(PlayerControler newPlayer) 
    {
        if(activePlayers.Count < maxPlayers)
        {
            activePlayers.Add(newPlayer);
            Instantiate(playerSpawnEffect, newPlayer.transform.position, newPlayer.transform.rotation);
        } else
        {
            Destroy(newPlayer.gameObject);
        }
    }

    public void ActivatePlayers()
    {
        foreach (PlayerControler player in activePlayers)
        {
            player.gameObject.SetActive(true);
            player.GetComponent<PlayerHeathControler>().FillHealth();
        }
    }



    public int CheckActivePlayers()
    {
        int playerAliveCount = 0;

        for (int i = 0; i < activePlayers.Count; i++)
        {
            if (activePlayers[i].gameObject.activeInHierarchy)
            {
                playerAliveCount++;
                lastPlayerNumber = i;
            }
        }

        return playerAliveCount;
    }

    public void GoToNextArena()
    {
        if (!gameWon)
        {
            if (levelOrder.Count == 0)
            {
                List<string> allLevelList = new List<string>();
                allLevelList.AddRange(allLevels);

                for (int i = 0; i < allLevels.Length; i++)
                {
                    int selected = Random.Range(0, allLevelList.Count);

                    levelOrder.Add(allLevelList[selected]);
                    allLevelList.RemoveAt(selected);
                }
            }

            string levelToLoad = levelOrder[0];
            levelOrder.RemoveAt(0);

            foreach (PlayerControler player in activePlayers)
            {
                player.gameObject.SetActive(true);
                player.GetComponent<PlayerHeathControler>().FillHealth();
            }

            SceneManager.LoadScene(levelToLoad);

        }
        else
        {
            foreach (PlayerControler player in activePlayers)
            {
                player.gameObject.SetActive(false);
                player.GetComponent<PlayerHeathControler>().FillHealth();
            }

            SceneManager.LoadScene(winLevel);
        }
    }

    public void StartFirstRound()
    {
        roundWins.Clear();
        foreach (PlayerControler player in activePlayers)
        {
            roundWins.Add(0);
        }

        gameWon = false;

        GoToNextArena();
    }

    public void AddRoundWin()
    {
        if (CheckActivePlayers() == 1)
        {
            roundWins[LastPlayerNumber]++;

            if (roundWins[LastPlayerNumber] >= pointsToWin)
            {
                gameWon = true;
            }
        }
    }

}
