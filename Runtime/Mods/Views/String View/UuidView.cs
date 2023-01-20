using System;
using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class UuidView : StringView
    {
        [SerializeField] private UnityEvent OnValid;
        [SerializeField] private UnityEvent OnInvalid;

        private static string _userUuid;
        private string[] _validIds;

        private static event Action OnUuidReceive;

        protected override void Start() {
            base.Start();
            OnUuidReceive += CompareValues;
        }

        protected override void OnDestroy() {
            OnUuidReceive -= CompareValues;
        }

        public static void SetUuId(string id) {
            _userUuid = id;
            OnUuidReceive?.Invoke();
        }

        public override void SetValue(string value, Vector3 position) {
            base.SetValue(value, position);
            
            _validIds = value.Split(',');

            CompareValues();
        }

        public void CompareValues() {
            if (_validIds == null) return;
            
            foreach (var validId in _validIds){
                if (!validId.Equals(_userUuid)) continue;

                OnValid?.Invoke();
                return;
            }

            OnInvalid?.Invoke();
        }
    }
}