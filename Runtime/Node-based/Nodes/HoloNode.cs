using XNode;

namespace outrealxr.holomod
{
	public abstract class HoloNode : Node
	{
		[Output] protected NodeConnection Next;
	}
}