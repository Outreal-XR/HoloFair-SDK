using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
	public abstract class HoloNode : Node
	{
		[Output, SerializeField] protected NodeConnection Next;
	}
}