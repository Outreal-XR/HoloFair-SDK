using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    [NodeWidth(300)]
    public class UnityEventNode : SequenceNode
    {
        [SerializeField] private UnityEvent _unityEvent;

        protected override void ExecuteLogic() {
            _unityEvent.Invoke();
        }
    }
}