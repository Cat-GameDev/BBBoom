using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance { get => instance;}
    [SerializeField] private TMP_Text deathAll;
    public TMP_Text DeathAll { get => deathAll;}
    [SerializeField] private GameObject winBar;
    public GameObject WinBar { get => winBar;}

    [SerializeField] private GameObject pauseScreen,loadingScreen;
    public GameObject LoadingScreen { get => loadingScreen;}

    [SerializeField] private string mainMenuScene;

    public GameObject star;
    [SerializeField] private GameObject firstPauseButton;


    private void Awake()
    {
        UIController.instance = this;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) //|| Gamepad.current.startButton.wasPressedThisFrame)
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
        else
        {
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstPauseButton);
        }
    }

    public void MainMenu()
    {
        foreach (PlayerControler player in GameManager.Instance.activePlayers)
        {
            Destroy(player.gameObject);
        }

        Destroy(GameManager.Instance.gameObject);
        GameManager.Instance = null;
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#endif
    }
}
