using outrealxr.holomod.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ExtensionRequestView : View
    {
        [SerializeField] protected string _extentionName;
        [SerializeField] private List<SerializedVar> _inputVariables = new();

        protected Action<string, List<SerializedVar>> _onRequestSent;
        public override string Tags => "extensionRequest";

        public void RegisterAction(Action<string, List<SerializedVar>> action) => _onRequestSent = action;


        public void Send()
        {
            _onRequestSent?.Invoke(_extentionName, _inputVariables);
        }
    }
}