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

    private InputController controls;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            controls = new InputController();
        }
    }

    private void OnEnable()
    {
        controls.Game.Exit.started += ctx => Quit();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
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

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
