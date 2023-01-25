using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimeMinutes : MonoBehaviour
{
    public int min;
    // Start is called before the first frame update
    void Start()
    {
        min = DateTime.Now.Minute;
        int sec = 60 - DateTime.Now.Second;
        transform.Rotate(30 * min, 0, 0);
        StartCoroutine(ArrowMove(sec));
    }

    IEnumerator ArrowMove(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        transform.Rotate(30, 0, 0);
        yield return null;
        StartCoroutine(ArrowMove(60f));
    }
}
