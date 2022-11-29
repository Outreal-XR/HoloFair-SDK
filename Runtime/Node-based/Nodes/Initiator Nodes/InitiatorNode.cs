using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
	public abstract class InitiatorNode : HoloNode
	{
		[SerializeField] private bool IsCoroutine;

		private void Initialize() {
			var node = GetOutputPort("Next").node;
			
			
		}
	}
}