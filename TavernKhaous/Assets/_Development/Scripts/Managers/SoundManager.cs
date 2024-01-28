using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
   public SOSound sfx;
   public AudioMixer audioMixer;
   public AudioClip GetSFXByName(string name)
    {
        SoundData soundData = sfx.sounds.FirstOrDefault(s => string.Equals(s.clipname, name, System.StringComparison.OrdinalIgnoreCase));
        return soundData.clip;
    }

    
}
