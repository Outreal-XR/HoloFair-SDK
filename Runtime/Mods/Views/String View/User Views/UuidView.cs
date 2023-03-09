using System;

namespace com.outrealxr.holomod
{
    public class UuidView : UserView
    {
        private static string _userUuid;
        private string[] _validIds;

        private static event Action OnUuidReceive;

        public override string Tags => "uuid"; 

        protected override void Start() {
            base.Start();
            ParseArray();
        }


        public static void SetUuId(string id) {
            _userUuid = id;
        }

        public override void SetValue(string value) {
            base.SetValue(value);

            ParseArray();
        }

        private void ParseArray() {
            _validIds = GetValue.Split(',');

            CompareValues();
        }

        public override void CompareValues() {
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