using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class UserGroupModel : StringModel
    {
        public override string type => "userGroup";

        int[] validIDs;

        public static int userGrpID = -1;
        
        [SerializeField] private UnityEvent OnValid;
        [SerializeField] private UnityEvent OnInvalid;

        public override void Init()
        {
            SetValue(value);
        }

        public void CompareValues() {
            foreach (var grpId in validIDs)
            {
                if (grpId == userGrpID || userGrpID == 2147483647)
                {
                    if (userGrpID == 2147483647)
                    {
                        Debug.LogWarning($"[UserGroupModel] Admin or moderator detected at {gameObject.name}");
                    }
                    else
                    {
                        Debug.LogWarning($"[UserGroupModel] Group ID {userGrpID} matched one of the values in {string.Join(',', validIDs)} at {gameObject.name}");
                    }
                    OnValid?.Invoke();
                    return;
                }
            }
            OnInvalid?.Invoke();
            Debug.LogWarning($"[UserGroupModel] Group ID {userGrpID} didn't match any value in {string.Join(',', validIDs)} at {gameObject.name}");
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