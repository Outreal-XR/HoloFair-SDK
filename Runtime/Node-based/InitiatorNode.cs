namespace outrealxr.holomod
{
	public abstract class InitiatorNode : HoloNode
	{
		public virtual void Initialize() {
			if (!GetOutputPort("Next").IsConnected) return;
			
			var node = GetOutputPort("Next").node;
			if (node is SequenceNode sequenceNode) 
				sequenceNode.Execute();
		}
	}
}