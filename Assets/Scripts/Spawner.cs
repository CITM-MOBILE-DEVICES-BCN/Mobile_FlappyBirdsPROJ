using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pipePrefabs;
    [SerializeField] private string[] pipeTypes = { "Basic", "Mobile", "DoubleOpening" };

    [SerializeField] private float time = 1f;
    [SerializeField] private float yClamp = 0.5f;

    private float elapsedTime;
    private PipeFactory pipeFactory;

    private void Start()
    {
        pipeFactory = new PipeFactory(pipePrefabs);
    }

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

        string pipeType = GetRandomPipeType();
        GameObject pipe = pipeFactory.CreatePipe(pipeType, position);

        Destroy(pipe, 10f);
    }

    private string GetRandomPipeType()
    {
        int index = Random.Range(0, pipeTypes.Length);
        return pipeTypes[index];
    }
}