using outrealxr.holomod.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ExtensionRequestView : StringView
    {
        [SerializeField] private bool _toRoom;
        [SerializeField] private SerializedObject _input;

        private Action<string, SerializedObject, bool> _onRequestSent;
        public override string Tags => "extensionRequest";

        public void RegisterAction(Action<string, SerializedObject, bool> action) => _onRequestSent = action;


        public void Send()
        {
            _onRequestSent?.Invoke(_value, _input, _toRoom);
        }
    }
}