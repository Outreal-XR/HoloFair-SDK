using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    [CreateNodeMenu("Variable Node/JArray")]
    public class ArrayVariableNode : VariableNode
    {
        [SerializeField] private UnityEvent<JArray> OnListUpdate;

        public override void Parse(JToken token) {
            var array = JArray.FromObject(token);
            OnListUpdate?.Invoke(array);
        
            var vars = GetOutputPort("ConnectionOut").GetConnections();

            for (var i = 0; i < array.Count; i++) {
                if (i >= vars.Count) continue;
                if (vars[i].node is VariableNode varNode) varNode.Parse(array[i]);
            }
        }

        public override JToken Serialize() {
            var array = new JArray();

            var outputVars = GetOutputPort("OutputVars").GetConnections();
            foreach (var outputVar in outputVars)
                if (outputVar.node is VariableNode varNode)
                    array.Add(varNode.Serialize());

            return array;
        }

    }
}