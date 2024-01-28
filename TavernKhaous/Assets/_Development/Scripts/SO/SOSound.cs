using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SOSound", menuName = "ScriptableObjects/Sound")]


public class SOSound : ScriptableObject
{
    public List<SoundData> sounds = new List<SoundData>();
}
