using outrealxr.holomod.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ExtensionResponseView : View
    {
        [SerializeField] protected string _extentionName;
        [SerializeField] private List<SerializedVar> _outputVariables = new();

        protected Action<string, List<SerializedVar>> _onResponseRecieved;

        public override string Tags => "extensionResponse";
        public void RegisterAction(Action<string, List<SerializedVar>> action) => _onResponseRecieved = action;

        public void Receive()
        {
            _onResponseRecieved?.Invoke(_extentionName, _outputVariables);
        }
    }
}
