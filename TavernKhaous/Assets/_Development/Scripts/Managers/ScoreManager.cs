using System;

public enum PointsType
{
    hitOrder,
    rightTime,
    hitSecretOrder,
    goodInteraction,
    neutralInteraction,
    badInteraction,
    wrongOrder,
    badTime
}

public class ScoreManager
{
    private int _currentScore;
    private SOPoints points;

    public Action<int> onUpdatePoints;

    public ScoreManager(SOPoints pts)
    {
        points = pts;
        points.SetData();

        Reset();
    }

    public void Reset()
    {
        _currentScore = 0;
        UpdateUIScore();
    }

    public void UpdateUIScore()
    {
        onUpdatePoints?.Invoke(_currentScore);
    }

    public void UpdatePoints(PointsType type)
    {
        int value = points.GetPointValue(type);
        _currentScore += value;
    }
}
