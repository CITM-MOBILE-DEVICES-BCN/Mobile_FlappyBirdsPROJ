using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private AudioSource pointFX;
    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        scoreUI.text = score.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreUI.text = score.ToString();
        Debug.Log(scoreUI.text);
        pointFX.Play();
    }
}
