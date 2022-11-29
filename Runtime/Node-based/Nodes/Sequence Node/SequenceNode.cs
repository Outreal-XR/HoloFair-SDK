using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
	public abstract class SequenceNode : HoloNode
	{
		[Input] protected NodeConnection Previous;

		public virtual void Execute() {
			ExecuteLogic();
			
			if (GetOutputPort("Next").IsConnected) 
				if (GetOutputPort("Next").node is SequenceNode nextNode)
					nextNode.Execute();
		}

		protected abstract void ExecuteLogic();
	}
}