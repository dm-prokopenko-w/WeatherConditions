using System;
using System.Collections;
using System.Collections.Generic;
using CoroutineSystem;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace AudioSystem
{
    public class Music : AudioItem
    {
        private AudioSource _source;
        private List<AudioClip> _musicClips = new();

        public Music(Slider slider, Toggle toggle, AudioData save, AudioConfig data) :
            base(slider, toggle, save, data)
        {
            _musicClips = data.MusicClips;
        }

        public void AddMusicSource(AudioSource source, CoroutineHandler coroutineHandler)
        {
            _source = source;
            PlayRandomClip(coroutineHandler);
            
            _source.volume = _slider.value;
            _source.mute = !_toggle.isOn;
            
            _slider.onValueChanged.AddListener((value) => { _source.volume = value; });
            _toggle.onValueChanged.AddListener((value) => { _source.mute = !value; });
        }

        private void PlayRandomClip(CoroutineHandler coroutineHandler)
        {
            _source.clip = _musicClips[Random.Range(0, _musicClips.Count)];
            _source.Play();
            coroutineHandler.StartActiveCoroutine(ChangeMusic(() => PlayRandomClip(coroutineHandler)));
        }
        
        private IEnumerator ChangeMusic(Action onEndClip)
        {
            yield return new WaitForSeconds(_source.clip.length);
            onEndClip?.Invoke();
        }
    }
}