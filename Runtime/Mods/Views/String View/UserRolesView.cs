using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class UserRolesView : StringView
    {
        [SerializeField] private UnityEvent OnValid;
        [SerializeField] private UnityEvent OnInvalid;

        private static string[] _userRoles;
        private string[] _validRoles;

        private static event Action OnUserRolesReceive;

        public override string Tags => "roles";

        protected override void Start() {
            base.Start();
            OnUserRolesReceive += CompareValues;
        }

        protected override void OnDestroy() {
            OnUserRolesReceive -= CompareValues;
        }
        
        public static void SetUserRoles(string[] userRoles) {
            _userRoles = userRoles;
            OnUserRolesReceive?.Invoke();
        }

        public override void SetValue(string value) {
            base.SetValue(value);

            _validRoles = value.Split(',');

            CompareValues();
        }

        public void CompareValues() {
            if (_validRoles == null) return;

            foreach (var validRole in _validRoles)
            foreach (var userRole in _userRoles) {
                if (!validRole.Equals(userRole)) continue;

                OnValid?.Invoke();
                return;
            }

            OnInvalid?.Invoke();
        }
    }
}