using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSound : ScriptableObject
{
    public List<SoundData> sounds;

    public SoundData GetSFXByName(string name)
    {
        return sounds.Find(sound =>  sound.name == name);
    }
}
