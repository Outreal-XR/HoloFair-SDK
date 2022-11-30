using System;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
	[CreateNodeMenu("Logic/Not Gate")]
	public class NotGateNode : SequenceNode
	{
		[Input(ShowBackingValue.Never), SerializeField] private bool _input;  
		[Output, SerializeField] private bool _output;

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port) {
			if (GetInputPort("_input").IsConnected)
				_input = GetInputValue<bool>("_input");
			
			if (port.fieldName.Equals("_output")) return !_input;
			return null; // Replace this
		}

		protected override void ExecuteLogic() { }
	}
}