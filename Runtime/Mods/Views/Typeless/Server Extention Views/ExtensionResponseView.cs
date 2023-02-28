using outrealxr.holomod.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ExtensionResponseView : StringView
    {
        [SerializeField] private List<SerializedVar> _outputVariables = new();

        private Action<string, List<SerializedVar>> _onResponseReceived;

        public override string Tags => "extensionResponse";

        public List<SerializedVar> OutputVariables => _outputVariables;

    }
}
