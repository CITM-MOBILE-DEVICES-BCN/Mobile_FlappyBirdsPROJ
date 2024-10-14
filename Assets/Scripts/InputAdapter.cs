using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAdapter : MonoBehaviour
{
    private InputController controls;

    [SerializeField] private Bird playerRef;
    void Awake()
    {
        controls = new InputController();
    }

    private void OnEnable()
    {
        controls.Game.Exit.started += ctx => GameQuit();
        controls.Game.Restart.started += ctx => GameRestart();
        controls.Bird.touch.started += ctx => PlayerFlap();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void GameQuit()
    {
        GameManager.instance.state = GameManager.GameState.Quit;
    }

    private void GameRestart()
    {
        if (GameManager.instance.state == GameManager.GameState.Over)
        {
            GameManager.instance.state = GameManager.GameState.Restart;
        }
    }

    private void PlayerFlap()
    {
        playerRef.state = Bird.State.Flap;
    }
}
