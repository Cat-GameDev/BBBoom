using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameStartScene;
    [SerializeField] private GameObject introScreen;

    private void Awake()
    {
        introScreen.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
    public void LeaveIntro()
    {
        introScreen.SetActive(false);
    }

    public void IntroScreen()
    {
        introScreen.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#endif
    }
}
