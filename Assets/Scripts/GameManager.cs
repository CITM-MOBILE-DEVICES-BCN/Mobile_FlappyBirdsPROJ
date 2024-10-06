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
        Over
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

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameOverFX.Play();
        Time.timeScale = 0.0f;
        state = GameState.Over;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        state = GameState.Waiting;
    }
}
