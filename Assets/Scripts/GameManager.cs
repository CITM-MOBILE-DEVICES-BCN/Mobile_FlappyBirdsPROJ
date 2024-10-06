using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverCanvas;

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
        Time.timeScale = 0.0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
