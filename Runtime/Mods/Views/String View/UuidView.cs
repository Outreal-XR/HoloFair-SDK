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
        [SerializeField] private string[] _validIds;

        private static event Action OnUuidReceive;

        protected override void Start() {
            base.Start();
            ParseArray();
        }


        public static void SetUuId(string id) {
            _userUuid = id;
        }

        public override void SetValue(string value, Vector3 position) {
            base.SetValue(value, position);

            ParseArray();
        }

        private void ParseArray() {
            _validIds = GetValue.Split(',');

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