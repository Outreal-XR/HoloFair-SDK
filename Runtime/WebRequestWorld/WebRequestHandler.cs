using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod.Runtime
{
    public abstract class WebRequestHandler : MonoBehaviour
    {
        [SerializeField] protected UnityEvent OnSuccess;
        [SerializeField] protected UnityEvent OnFail;
     
        [SerializeField, Space(10)] protected string url;
        [SerializeField] protected List<SerializedVar> outputVars = new ();
        
        public void SetUrl(string url) => this.url = url;

        public void AddOutputVar(SerializedVar var) {
            if (outputVars.Contains(var)) return;
            outputVars.Add(var);
        }
        
        public void RemoveOutputVar(SerializedVar var) {
            if (!outputVars.Contains(var)) return;
            outputVars.Remove(var);
        }
    }
}