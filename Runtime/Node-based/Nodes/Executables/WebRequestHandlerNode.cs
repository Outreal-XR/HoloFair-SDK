using UnityEngine.Events;
using XNode;

namespace outrealxr.holomod
{
	[NodeWidth(300)]
	public abstract class WebRequestHandlerNode : Node, IExecutable
	{
		public bool executeOnStart = false;
		[Input] public string url;

		[Output] public NodeConnection OutputVars;

		public UnityEvent OnSuccess;
		public UnityEvent OnFail;
	
		public abstract void Execute();
		public bool ExecuteOnStart() => executeOnStart;

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port) {
			return null;
		}
	}
}