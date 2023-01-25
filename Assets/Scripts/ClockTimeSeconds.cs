using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ClockTimeSeconds : MonoBehaviour
{
    public int sec;
    // Start is called before the first frame update
    void Start()
    {
        sec = DateTime.Now.Second;
        transform.Rotate(6 * sec, 0, 0);
        StartCoroutine(ArrowMove());
    }

    IEnumerator ArrowMove()
    {
        yield return new WaitForSecondsRealtime(1f);
        transform.Rotate(6, 0, 0);
        yield return null;
        StartCoroutine(ArrowMove());
    }
}
