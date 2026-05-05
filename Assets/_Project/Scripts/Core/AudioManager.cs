using System.Collections.Generic;
using UnityEngine;
using Bloomkin.Utils;

namespace Bloomkin.Core
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("Music")]
        [SerializeField] private AudioSource _musicSource;

        [Header("SFX Pool")]
        [SerializeField] private int _sfxPoolSize = 16;
        [SerializeField] private Transform _sfxPoolParent;

        [Header("Volume")]
        [Range(0f, 1f)] [SerializeField] private float _masterVolume = 1f;
        [Range(0f, 1f)] [SerializeField] private float _musicVolume  = 0.8f;
        [Range(0f, 1f)] [SerializeField] private float _sfxVolume    = 1f;

        private readonly List<AudioSource> _sfxPool = new();
        private int _sfxPoolIndex;

        public float MasterVolume
        {
            get => _masterVolume;
            set { _masterVolume = Mathf.Clamp01(value); ApplyMusicVolume(); }
        }

        public float MusicVolume
        {
            get => _musicVolume;
            set { _musicVolume = Mathf.Clamp01(value); ApplyMusicVolume(); }
        }

        public float SFXVolume
        {
            get => _sfxVolume;
            set => _sfxVolume = Mathf.Clamp01(value);
        }

        protected override void Awake()
        {
            base.Awake();
            InitPool();
        }

        private void InitPool()
        {
            if (_sfxPoolParent == null)
            {
                var go = new GameObject("SFX Pool");
                go.transform.SetParent(transform);
                _sfxPoolParent = go.transform;
            }

            for (int i = 0; i < _sfxPoolSize; i++)
            {
                var go = new GameObject($"SFX Source {i}");
                go.transform.SetParent(_sfxPoolParent);
                var src = go.AddComponent<AudioSource>();
                src.playOnAwake = false;
                _sfxPool.Add(src);
            }

            if (_musicSource == null)
            {
                var go = new GameObject("Music Source");
                go.transform.SetParent(transform);
                _musicSource = go.AddComponent<AudioSource>();
                _musicSource.loop = true;
                _musicSource.playOnAwake = false;
            }
        }

        public void PlaySFX(AudioClip clip)
        {
            if (clip == null) return;
            var src = NextPoolSource();
            src.clip   = clip;
            src.volume = _sfxVolume * _masterVolume;
            src.Play();
        }

        public void PlaySFXAtPosition(AudioClip clip, Vector3 position, float spatialBlend = 1f)
        {
            if (clip == null) return;
            var src = NextPoolSource();
            src.transform.position = position;
            src.clip         = clip;
            src.volume       = _sfxVolume * _masterVolume;
            src.spatialBlend = spatialBlend;
            src.Play();
        }

        private AudioSource NextPoolSource()
        {
            var src = _sfxPool[_sfxPoolIndex];
            _sfxPoolIndex = (_sfxPoolIndex + 1) % _sfxPool.Count;
            return src;
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (clip == null) { StopMusic(); return; }
            if (_musicSource.clip == clip && _musicSource.isPlaying) return;
            _musicSource.clip   = clip;
            _musicSource.loop   = loop;
            _musicSource.volume = _musicVolume * _masterVolume;
            _musicSource.Play();
        }

        public void StopMusic()   => _musicSource.Stop();
        public void PauseMusic()  => _musicSource.Pause();
        public void ResumeMusic() => _musicSource.UnPause();

        private void ApplyMusicVolume()
        {
            if (_musicSource != null)
                _musicSource.volume = _musicVolume * _masterVolume;
        }
    }
}
