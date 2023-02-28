using outrealxr.holomod.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ExtensionRequestView : StringView
    {
        [SerializeField] private SerializedObject _input;

        private Action<string, SerializedObject> _onRequestSent;
        public override string Tags => "extensionRequest";

        public void RegisterAction(Action<string, SerializedObject> action) => _onRequestSent = action;


        public void Send()
        {
            _onRequestSent?.Invoke(_value, _input);
        }
    }
}