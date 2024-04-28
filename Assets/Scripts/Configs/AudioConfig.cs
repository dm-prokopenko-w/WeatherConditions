using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Configs/AudioConfig", order = 0)]
    public class AudioConfig : Config
    {
        public List<AudioClip> MusicClips;
        public List<SoundItem> Sounds;
    }
    
    [Serializable]
    public class SoundItem
    {
        public Constants.SoundObject Type;
        public SoundEffect Prefab;
    }
}
