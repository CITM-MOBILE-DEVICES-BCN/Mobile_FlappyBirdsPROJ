using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}