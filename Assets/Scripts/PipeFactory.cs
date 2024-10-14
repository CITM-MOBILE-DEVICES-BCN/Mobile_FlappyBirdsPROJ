using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeFactory
{
    private GameObject[] pipePrefabs;

    public PipeFactory(GameObject[] prefabs)
    {
        this.pipePrefabs = prefabs;
    }

    public GameObject CreatePipe(string pipeType, Vector2 position)
    {
        GameObject pipeObject;

        switch (pipeType)
        {
            case "Basic":
                pipeObject = Object.Instantiate(pipePrefabs[0], position, Quaternion.identity);
                break;
            case "Mobile":
                pipeObject = Object.Instantiate(pipePrefabs[1], position, Quaternion.identity);
                break;
            case "DoubleOpening":
                pipeObject = Object.Instantiate(pipePrefabs[2], position, Quaternion.identity);
                break;
            default:
                Debug.LogError("Invalid pipe name");
                return null;
        }

        return pipeObject;
    }
}
