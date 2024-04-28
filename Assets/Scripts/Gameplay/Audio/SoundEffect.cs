using UnityEngine;

namespace AudioSystem
{
    public class SoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;

        public float SetVolume(bool isMute, float value)
        {
            _source.mute = isMute;
            _source.volume = value;
            return _source.clip.length;
        }
    }
}