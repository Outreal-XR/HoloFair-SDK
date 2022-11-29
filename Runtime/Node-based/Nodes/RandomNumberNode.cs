using UnityEngine;
using XNode;
using Random = System.Random;

namespace outrealxr.holomod
{
	public class RandomNumberNode : Node
	{
		[Input, SerializeField] private int _seed;
		
		

		private Random _random;
		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port) {
			
			return null; // Replace this
		}

		public void Execute() {
			_random = new Random(_seed);
		}
	}
}