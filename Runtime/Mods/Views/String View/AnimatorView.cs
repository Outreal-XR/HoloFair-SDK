using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class AnimatorView : StringView
    {
        [SerializeField] private Animator _animator;

        private Action<string> _onPlayAnimation;
        public void RegisterPlay(Action<string> action) => _onPlayAnimation = action;
        public void PlayAnimation() => _onPlayAnimation?.Invoke(GetValue);
    }
}
