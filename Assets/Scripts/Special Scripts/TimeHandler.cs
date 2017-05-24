using System.Collections;
using UnityEngine;

public static class TimeHandler
{

    public static IEnumerator WaitForRealTimeSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < (start + time))
        {
            yield return null;
        }
    }
}