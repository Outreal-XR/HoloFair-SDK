using SaG.GuidReferences;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
	public class SmartStringNode : HoloNode
	{

		[SerializeField] private GuidComponent _guid;
		[SerializeField, TextArea(3, 10)] private string stringFormat;
		[Output(ShowBackingValue.Never)] public string smartString;
	
		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port) {
			if (port.fieldName.Equals("smartString")) return SmartStringSource.Instance.GetFormattedString(stringFormat, _guid != null ? _guid.GetStringGuid() : "");
			return null; // Replace this
		}
	}
}