using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class EmoteView : StringView
    {
        [SerializeField] private Transform _avatarDestination;
        [SerializeField] private Transform _playerControllerDestination;
        
        private Action<EmoteView> _onSelect;

        public Transform AvatarDestination => _avatarDestination;
        public Transform PlayerControllerDestination => _playerControllerDestination;

        protected override void Start()
        {
            base.Start();
            tags = "emote";
        }

        public void SetAction(Action<EmoteView> onSelect) => _onSelect = onSelect;
        public void Select()
        {
            _onSelect?.Invoke(this);
            Analytics.instance.RecordImmediate(this, GetValue);
        }
    }
}