using System;
using UnityEngine;

namespace outrealxr.holomod
{
    [CreateNodeMenu("Loop/While Loop")]
    public class WhileLoopNode : SequenceNode
    {
        [Input, SerializeField] private bool _condition;
        [SerializeField] private int _maxIterations = 99;

        public override void Execute() {
            if (GetInputPort("_condition").IsConnected) 
                _condition = GetInputValue<bool>("_condition");
            
            var i = 0;
            while (_condition) {
                if (i >= _maxIterations)
                    throw new Exception("Loop exceeded max iterations.");

                if (GetOutputPort("Next").IsConnected) 
                    if (GetOutputPort("Next").node is SequenceNode nextNode)
                        nextNode.Execute();
                
                i++;
            }
        }

        protected override void ExecuteLogic() { }
    }
}