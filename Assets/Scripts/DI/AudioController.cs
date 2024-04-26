using CoroutineSystem;
using Game;
using ItemSystem;
using PopupSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;
using static Game.Constants;

namespace AudioSystem
{
    public class AudioController : IStartable
    {
        [Inject] private ItemController _itemController;
        [Inject] private SaveController _saveController;
        [Inject] private PopupController _popupController;
        [Inject] private AssetLoader _assetLoader;
        [Inject] private CoroutineHandler _coroutineHandler;

        private Music _music;
        private Sound _sound;
        
        public void Start()
        {
            var data = _assetLoader.LoadConfig(AudioConfigPath) as AudioConfig;

            _sound = new Sound(
                SetSlider(SliderViewID + SliderObject.Sound), 
                SetToggle(ToggleViewID + ToggleObject.Sound), 
                SetSave(SoundSaveKey),
                data);

            _sound.InitPool(
                _itemController.GetTransform(TransformViewID + TransformObject.InactiveSoundsParent),
                _itemController.GetTransform(TransformViewID + TransformObject.ActiveSoundsParent));
            
            _music = new Music(
                SetSlider(SliderViewID + SliderObject.Music), 
                SetToggle(ToggleViewID + ToggleObject.Music), 
                SetSave(MusicSaveKey),
                data);
        }

        public void AddMusicSource(AudioSource source) => _music.AddMusicSource(source, _coroutineHandler);
        private Slider SetSlider(string key) => _itemController.GetSlider(key);
        private Toggle SetToggle(string key) => _itemController.GetToggle(key);

        private AudioData SetSave(string key)
        {
            var save = _saveController.Load<AudioData>(key);
            if (save == null)
            {
                save = new AudioData()
                {
                    IsEnable = true,
                    Volume = 1f
                };
                _saveController.Save(key, save);
            }

            _popupController.OnActivePopup.AddListener((id, value) =>
            {
                if (id.Equals(PopupsID.Settings.ToString()) && !value)
                {
                    _saveController.Save(key, save);
                }
            });

            return save;
        }

        public void AddSoundButton(SoundObject type, Button button) => _sound.AddSoundButton(type, button, _coroutineHandler);
    }

    public class AudioItem
    {
        protected Toggle _toggle;
        protected Slider _slider;

        protected AudioItem(Slider slider, Toggle toggle, AudioData save, AudioConfig data)
        {
            _slider = slider;
            
            _slider.value = save.Volume;
            _slider.onValueChanged.AddListener((value) => { save.Volume = value; });

            _toggle = toggle;
            _toggle.isOn = !save.IsEnable;
            _toggle.onValueChanged.AddListener((value) => { save.IsEnable = !value; });
        }
    }

    public class AudioData
    {
        public bool IsEnable;
        public float Volume;
    }
}