using UnityEngine;

namespace outrealxr.holomod
{
	public abstract class SequenceNode : HoloNode
	{
		[Input, SerializeField] protected NodeConnection Previous;

		public virtual void Execute() {
			ExecuteLogic();
			
			if (GetOutputPort("Next").IsConnected) 
				if (GetOutputPort("Next").node is SequenceNode nextNode)
					nextNode.Execute();
		}

		protected abstract void ExecuteLogic();
	}
}