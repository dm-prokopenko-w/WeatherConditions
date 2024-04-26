using System.Collections;
using System.Collections.Generic;
using AudioSystem;
using Core;
using CoroutineSystem;
using UnityEngine;
using UnityEngine.UI;
using static Game.Constants;

namespace AudioSystem
{
    public class Sound : AudioItem
    {
        private Dictionary<SoundObject, SoundEffect> _sounds;
        private ObjectPool<SoundEffect> _pool;
        private Transform _parentActive;
        
        public Sound(Slider slider, Toggle toggle, AudioData save, AudioConfig data) : base(slider, toggle, save, data)
        {
            _sounds = new();
            foreach (var sound in data.Sounds)
            {
                _sounds.Add(sound.Type, sound.Prefab);
            }
        }

        public void InitPool(Transform parentInactive, Transform parentActive)
        {
            _parentActive = parentActive;
            
            _pool = new ObjectPool<SoundEffect>();

            foreach (var sound in _sounds)
            {
                _pool.InitPool(sound.Value, parentInactive);
            }
        }


        public void AddSoundButton(SoundObject type, Button button, CoroutineHandler coroutineHandler)
        {
            if (_sounds.TryGetValue(type, out SoundEffect effect))
            {
                button.onClick.AddListener(() =>
                {
                    var sound = _pool.Spawn(effect, _parentActive);
                    coroutineHandler.StartActiveCoroutine(DespawnSound(sound));
                });
            }
        }
        
        private IEnumerator DespawnSound(SoundEffect sound)
        {
            yield return new WaitForSeconds(sound.SetVolume(!_toggle.isOn, _slider.value));
            _pool.Despawn(sound);
        }
    }
}
