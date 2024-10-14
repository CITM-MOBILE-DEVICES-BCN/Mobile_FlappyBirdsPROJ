using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public enum State
    {
        Idle,
        Flap
    }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float maxRotation = 20f;
    [SerializeField] private float minRotation = 290f;
    [SerializeField] private float yBound;
    [SerializeField] private AudioSource flapFX;
    [SerializeField] private AudioSource hitFX;

    public State state;

    private void Update()
    {
        if(GameManager.instance.state == GameManager.GameState.Waiting)
        {
            rb.Sleep();
        }
        else
        {
            rb.WakeUp();
        }

        switch (state)
        {
            case State.Idle:
                break;
            case State.Flap:
                Flap();
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, rb.velocity.y * rotationSpeed);

        if (transform.rotation.eulerAngles.z > maxRotation && transform.rotation.eulerAngles.z < 90)
        {
            transform.rotation = Quaternion.Euler(0, 0, maxRotation);
        }

        if (transform.rotation.eulerAngles.z < minRotation && transform.rotation.eulerAngles.z > 180)
        {
            transform.rotation = Quaternion.Euler(0, 0, minRotation);
        }
    }

    private void Flap()
    {
        if (GameManager.instance.state == GameManager.GameState.Over
         || GameManager.instance.state == GameManager.GameState.Death)
        {
            return;
        }

        GameManager.instance.state = GameManager.GameState.Playing;
        if (rb.position.y < yBound)
        {
            rb.velocity = Vector2.up * force;
            flapFX.Play();
        }

        state = State.Idle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitFX.Play();
        GameManager.instance.state = GameManager.GameState.Death;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.instance.UpdateScore();
    }
}