using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Points points;

    public Action<int> onUpdatePoints;

    public void Int()
    {
        points = new Points();
        Reset();
    }

    public void Reset()
    {
        _currentScore = 0;
    }

    public void UpdateScore(int value)
    {
        _currentScore += value;
        onUpdatePoints?.Invoke(_currentScore);
    }

    public void UpdatePoints(PointsType type, int value)
    {
        points.SetPoint(type, value);
    //}

    //public int GetPointValue()
    //{
    //    int value;

    //    //for(int i = 0; i < points.pointControl.Count; i++)
    //    //{
    //    //    value += points.pointControl[i].
    //    //}

    //    //return 0;
    //}
}

    public class Points
    {
        public Dictionary<PointsType, int> pointControl;

        public Points()
        {
            pointControl = new Dictionary<PointsType, int>();
            pointControl.Add(PointsType.hitOrder, 0);
            pointControl.Add(PointsType.rightTime, 0);
            pointControl.Add(PointsType.hitSecretOrder, 0);
            pointControl.Add(PointsType.goodInteraction, 0);
            pointControl.Add(PointsType.neutralInteraction, 0);
            pointControl.Add(PointsType.badInteraction, 0);
            pointControl.Add(PointsType.wrongOrder, 0);
            pointControl.Add(PointsType.badTime, 0);
        }

        public void SetPoint(PointsType type, int value)
        {
            pointControl[type] = value;
        }
    }
}
