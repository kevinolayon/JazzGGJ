using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PointsType")]
public class SOPoints : ScriptableObject
{
    public int hitOrder;
    public int rightTime;
    public int hitSecretOrder;
    public int goodInteraction;
    public int neutralInteraction;
    public int badInteraction;
    public int wrongOrder;
<<<<<<< HEAD
    public int badTime;

    private Dictionary<PointsType, int> pointControl;
   
    public int GetPointValue(PointsType type)
    {
        return pointControl[type];
    }

    public void SetData()
    {
        pointControl = new Dictionary<PointsType, int>();

        pointControl.Add(PointsType.hitOrder, hitOrder);
        pointControl.Add(PointsType.rightTime, rightTime);
        pointControl.Add(PointsType.hitSecretOrder, hitSecretOrder);
        pointControl.Add(PointsType.goodInteraction, goodInteraction);
        pointControl.Add(PointsType.neutralInteraction, neutralInteraction);
        pointControl.Add(PointsType.badInteraction, badInteraction);
        pointControl.Add(PointsType.wrongOrder, wrongOrder);
        pointControl.Add(PointsType.badTime, badTime);
    }
=======
    public int badTimepublic;
>>>>>>> main
}
