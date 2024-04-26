using Game;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace AudioSystem
{   
    public class SoundOnButtonClick : MonoBehaviour
    {
        [Inject] private AudioController _audioController;

        [SerializeField] private Button _button;
        [SerializeField] private Constants.SoundObject _type;

        private void Start()
        {
            _audioController.AddSoundButton(_type, _button);
        }
    }
}
