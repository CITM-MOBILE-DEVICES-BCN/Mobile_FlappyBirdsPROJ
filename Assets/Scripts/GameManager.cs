using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Waiting,
        Playing,
        Death,
        Over,
        Restart,
        Quit
    }

    public static GameManager instance;
    public GameState state = GameState.Waiting;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private AudioSource gameOverFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        switch (state)
        {
            case GameState.Waiting:
                break;
            case GameState.Playing:
                break;
            case GameState.Death:
                GameOver();
                break;
            case GameState.Over:
                break;
            case GameState.Restart:
                RestartGame();
                break;
            case GameState.Quit:
                Quit();
                break;
            default:
                break;
        }
    }

    private void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameOverFX.Play();
        Time.timeScale = 0.0f;
        state = GameState.Over;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        state = GameState.Waiting;
    }

    private void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
