using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class EmoteView : StringView
    {
        [SerializeField] private Transform _avatarDestination;
        [SerializeField] private Transform _playerControllerDestination;
        
        private Action<EmoteView> _onSelect;

        public Transform AvatarDestination {
            get {
                if (!_avatarDestination) {
                    Debug.LogError($"[EmoteView] The avatar destination field of \"{gameObject.name}\" is null!");
                    throw new Exception();
                }

                return _avatarDestination;
            }
        }

        public Transform PlayerControllerDestination {
            get {
                if (!_playerControllerDestination) {
                    Debug.LogError($"[EmoteView] The player controller destination field of \"{gameObject.name}\" is null!");
                    throw new Exception();
                }
                return _playerControllerDestination;
            }
        }

        public void SetAction(Action<EmoteView> onSelect) => _onSelect = onSelect;
        public void Select()
        {
            _onSelect?.Invoke(this);
            Analytics.instance.RecordImmediate(this, GetValue);
        }

        public override string Tags => "emote";
    }
}