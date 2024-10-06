using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private float yBound;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && rb.position.y < yBound)
        {
            Flap();
        }
    }

    private void Flap()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * force);
    }
}