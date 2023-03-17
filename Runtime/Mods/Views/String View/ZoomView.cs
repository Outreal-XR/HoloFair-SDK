using System;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ZoomView : StringView
    {
        public enum ViewType
        {
            Popup,
            Fullscreen
        }

        public override string Tags => "zoom";
        
        private string _meetingNumber;
        private string _password;
        private ViewType _viewType;

        private Action<string, string, ViewType> _onJoin;
        public void RegisterJoin(Action<string, string, ViewType> action) => _onJoin = action;
        public void Join() => _onJoin?.Invoke(_meetingNumber, _password, _viewType);

        private Action<string, string, ViewType> _onCreate;
        public void RegisterCreate(Action<string, string, ViewType> action) => _onCreate = action;
        public void Create() => _onCreate?.Invoke(_meetingNumber, _password, _viewType);

        public override void SetValue(string value) {
            base.SetValue(value);

            var values = value.Split(',');
            
            if (values.Length != 3) {
                Debug.LogError("[ZoomView] String value is incorrect. Needs to be 3 string values separated by 2 commas.");
                return;
            }

            _meetingNumber = values[0];
            _password = values[1];

            if (int.TryParse(values[3], out var result)) 
                _viewType = (ViewType) result;
        }
    }
}
