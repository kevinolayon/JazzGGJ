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

public enum SatisfactionType
{
    satisfied,
    dissatisfied,
    verySatisfied
}

public class ScoreManager
{
    private int _currentScore;
    private int _currentOrderScore;

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
        _currentOrderScore = 0;
        UpdateUIScore();
    }

    public void UpdateUIScore()
    {
        onUpdatePoints?.Invoke(_currentOrderScore);
    }

    public void UpdatePoints(PointsType type)
    {
        int value = points.GetPointValue(type);
        _currentOrderScore += value;
    }
}
