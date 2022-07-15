using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class UserGroupModel : StringModel
    {
        public override string type => "userGroup";

        public int[] validIDs;

        [HideInInspector] public int userGrpID;
        
        [SerializeField] private UnityEvent OnValid;
        [SerializeField] private UnityEvent OnInvalid;

        public void CompareValues() {
            foreach (var grpId in validIDs)
                if (grpId == userGrpID) {
                    OnValid?.Invoke();
                    return;
                }
            
            OnInvalid?.Invoke();
        }

        public override void SetValue(string val) {
            base.SetValue(val);

            var strings = val.Split(',');

            validIDs = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                if (int.TryParse(strings[i], out var intValue)) {
                    validIDs[i] = intValue;
                } else {
                    Debug.LogWarning("[UserGroupModel] The one of the values cannot be parsed. Try to input a integer values seperated with commas.");
                    OnInvalid?.Invoke();
                    return;
                }
            }
            
            CompareValues();
        }
    }
}