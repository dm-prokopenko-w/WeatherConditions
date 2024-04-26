using UnityEngine;
using VContainer;

namespace AudioSystem
{
    public class AudioSourceView : MonoBehaviour
    {
        [Inject] private AudioController _audioController;

        [SerializeField] private AudioSource _source;

        private void Start()
        {
            _audioController.AddMusicSource(_source);
        }
    }
}
