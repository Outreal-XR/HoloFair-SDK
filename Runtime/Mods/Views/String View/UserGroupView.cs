
using System;
using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class UserGroupView : StringView
    {
        [SerializeField] private UnityEvent OnValid;
        [SerializeField] private UnityEvent OnInvalid;

        private static int _userGroupId;
        private int[] _validIds;

        private static event Action OnUserGrpIdReceive;

        protected override void Start() {
            base.Start();
            OnUserGrpIdReceive += CompareValues;
        }

        private void OnDestroy() {
            OnUserGrpIdReceive -= CompareValues;
        }

        public static int UserGroupId => _userGroupId;
        public static void SetUserGroupId(int id) {
            _userGroupId = id;
            OnUserGrpIdReceive?.Invoke();
        }

        public override void SetValue(string value, Vector3 position) {
            base.SetValue(value, position);
            
            var strings = value.Split(',');

            _validIds = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                if (int.TryParse(strings[i], out var intValue)) {
                    _validIds[i] = intValue;
                } else {
                    Debug.LogWarning("[UserGroupModel] The one of the values cannot be parsed. Try to input a integer values seperated with commas.");
                    OnInvalid?.Invoke();
                    return;
                }
            }
            
            CompareValues();
        }

        public void CompareValues() {
            if (_validIds == null) return;
            
            foreach (var grpId in _validIds) {
                if (grpId != UserGroupId && UserGroupId != 2147483647) continue;
                
                if (UserGroupId == 2147483647)
                    Debug.LogWarning($"[UserGroupModel] Admin or moderator detected at {gameObject.name}");
                else
                    Debug.LogWarning($"[UserGroupModel] Group ID {UserGroupId} matched one of " +
                                     $"the values in {string.Join(',', _validIds)} at {gameObject.name}");
                OnValid?.Invoke();
                return;
            }
            OnInvalid?.Invoke();
        }
    }
}
