using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float time = 1f;
    [SerializeField] private float yClamp = 0.5f;

    private float elapsedTime;

    private void Update()
    {
        if (GameManager.instance.state != GameManager.GameState.Playing)
        {
            return;
        }

            elapsedTime += Time.deltaTime;

        if (elapsedTime > time)
        {
            SpawnObject();

            elapsedTime = 0f;
        }
    }

    private void SpawnObject()
    {
        float offsetY = Random.Range(-yClamp, yClamp);
        Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y + offsetY);
        GameObject obj = Instantiate(prefab, position, Quaternion.identity, this.transform);

        Destroy(obj, 10);
    }
}