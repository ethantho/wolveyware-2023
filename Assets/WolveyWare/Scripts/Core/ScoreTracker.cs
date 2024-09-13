using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreTracker
{
    // Start is called before the first frame update
    public static int score = 0;
    public static float bpm = 140;
    public enum ScoreTrackerResult
    {
        start,success, failure
    }

    public static ScoreTrackerResult lastResult = ScoreTrackerResult.start;
}
