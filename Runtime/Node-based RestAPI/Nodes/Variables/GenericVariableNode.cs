using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;
using XNode;

namespace outrealxr.holomod
{
	public abstract class GenericVariableNode<T> : VariableNode
	{
		[Output(ShowBackingValue.Always)] public T Value;

		[SerializeField] protected UnityEvent<T> OnValueUpdate;

		public override void Parse(JToken token) {
			Value = token.Value<T>();
			OnValueUpdate?.Invoke(Value);
		}
		public override JToken Serialize() => JToken.FromObject(Value);

		public override object GetValue(NodePort port) {
			var baseValue = base.GetValue(port);
			if (baseValue != null) return baseValue;
			if (port.fieldName.Equals("Value")) return Value;
			return null;
		}
	}
}