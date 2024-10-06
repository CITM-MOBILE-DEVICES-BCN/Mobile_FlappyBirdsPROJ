using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xBound;

    private void Update()
    {
        this.transform.position -= Vector3.right * speed * Time.deltaTime;

        if (this.transform.position.x < xBound)
        {
            Destroy(this.gameObject);
        }
    }
}