using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer 
{
   public static AudioClip RandomizeAudioClip(AudioClip[] clips)
   {
        return clips[Random.Range(0, clips.Length)];
   }
}
