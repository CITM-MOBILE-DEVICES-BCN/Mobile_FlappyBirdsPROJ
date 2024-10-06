using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float maxRotation = 20f;
    [SerializeField] private float minRotation = 290f;
    [SerializeField] private float yBound;
    private InputController controls;
    void Awake()
    {
        controls = new InputController();
    }

    private void OnEnable()
    {
        controls.Bird.touch.started += ctx => Flap();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
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
        if (rb.position.y < yBound)
        {
            rb.velocity = Vector2.up * force;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}