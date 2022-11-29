using UnityEngine.Events;
using XNode;

namespace outrealxr.holomod
{
	[NodeWidth(300)]
	public abstract class WebRequestHandlerNode : SequenceNode
	{
		[Input] public string url;

		[Output] public NodeConnection OutputVars;

		public UnityEvent OnSuccess;
		public UnityEvent OnFail;
		
		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port) {
			return null;
		}
	}
}