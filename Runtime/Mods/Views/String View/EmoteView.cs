using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class EmoteView : StringView
    {
        [SerializeField] private Transform _avatarDestination;
        [SerializeField] private Transform _playerControllerDestination;
        
        private Action<string> _onSelect;

        public void SetAction(Action<string> onSelect) => _onSelect = onSelect;
        public void Select() => _onSelect?.Invoke(GetValue);
    }
}