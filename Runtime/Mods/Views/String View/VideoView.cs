using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class VideoView : ImageView
    {
        [SerializeField] private GameObject _loading;
        [SerializeField] private GameObject _live;

        private Action<string> _onPlay;
        public void RegisterOnPlay(Action<string> action) => _onPlay = action;
        public void Play() => _onPlay?.Invoke(GetValue);

        private Action _onStop;
        public void RegisterOnStop(Action action) => _onStop = action;
        public void Stop() => _onStop?.Invoke();

        private Action<string> _onToggle;
        public void RegisterOnToggle(Action<string> action) => _onToggle = action;
        public void Toggle() => _onToggle?.Invoke(GetValue);
    }
}