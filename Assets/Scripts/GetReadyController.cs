using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float duration;


    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if(GameManager.instance.state == GameManager.GameState.Playing)
        {
            StartCoroutine(FadeRoutine());
        }
    }

    IEnumerator FadeRoutine()
    {
        float time = Time.time;
        while (canvasGroup.alpha != 0)
        {
            canvasGroup.alpha = Mathf.SmoothStep(1, 0, (Time.time - time) / duration);
            yield return null;
        }
    }
}
