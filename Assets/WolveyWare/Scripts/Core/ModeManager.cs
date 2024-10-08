using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EndModeReason
{
    Failure,
    User,
    Default
}

public abstract class ModeManager : MonoBehaviour
{
    public static ModeManager Instance { get; protected set; }
    public bool isBlitzMode = false;
    public int lives = 0;

    public virtual void StartMode()
    {
        Instance = this;
    }

    public abstract void OnSuccess(MinigameManager manager);

    public abstract void OnFailure(MinigameManager manager);

    public abstract void OnModeEnded(EndModeReason reason);

    public void EndMode(EndModeReason reason, int score)
    {
        WolveywareCanvasManager.Instance.gameOverScreen.PopulateScreen(reason, score);

        OnModeEnded(reason);
    }

    public void EndCurrentMinigame()
    {
        if (MinigameManager.Current.HasSucceeded())
        {
            OnSuccess(MinigameManager.Current);
            ScoreTracker.lastResult = ScoreTracker.ScoreTrackerResult.success;
        }

        else
        {
            OnFailure(MinigameManager.Current);
            ScoreTracker.lastResult = ScoreTracker.ScoreTrackerResult.failure;
        }
            
    }
}
