using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
	[CreateNodeMenu("Variable Node/Iterator")]
	public class ArrayIteratorNode : VariableNode
	{
		[SerializeField] private UnityEvent<int> OnIterationStart;
	
		public override void Parse(JToken token) {
			var array = JArray.FromObject(token);
			var outputVars = GetOutputPort("ConnectionOut").GetConnections();

			for (var i = 0; i < outputVars.Count; i++) {
				var outputVar = outputVars[i];
			
				OnIterationStart?.Invoke(i);
				if (outputVar.node is VariableNode varNode)
					foreach (var elementToken in array)
						varNode.Parse(elementToken);
			}
		}

		public override JToken Serialize() {
			return new JArray();
		}
	}
}