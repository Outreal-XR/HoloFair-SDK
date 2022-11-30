using System.Collections;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class WaitNode : SequenceNode
    {
        public override void Execute () {
            (graph as HoloModGraph).monoBehaviour.StartCoroutine(Wait());
        }

        protected override void ExecuteLogic() {
            throw new System.NotImplementedException();
        }

        private IEnumerator Wait() {
            yield return GetAwaitPeriod();
            if (GetOutputPort("Next").IsConnected) 
                if (GetOutputPort("Next").Connection.node is SequenceNode nextNode)
                    nextNode.Execute();
        }

        protected abstract YieldInstruction GetAwaitPeriod();
    }
}