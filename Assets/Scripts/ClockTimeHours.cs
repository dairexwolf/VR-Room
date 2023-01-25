using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimeHours : MonoBehaviour
{
    public int hour;
    // Start is called before the first frame update
    void Start()
    {
        hour = DateTime.Now.Hour;
        int min = 60 - DateTime.Now.Minute;   
        transform.Rotate(30 * hour, 0, 0);
        StartCoroutine(ArrowMove(min));
    }

    IEnumerator ArrowMove(float min)
    {
        yield return new WaitForSecondsRealtime(min*60);
        transform.Rotate(30, 0, 0);
        yield return null;
        StartCoroutine(ArrowMove(3600f));
    }
}
