using UnityEngine;

namespace outrealxr.holomod
{
    public class IfStatementNode : SequenceNode
    {
        [Input, SerializeField] private bool _condition;

        [Output, SerializeField] private NodeConnection _true;
        [Output, SerializeField] private NodeConnection _false;

        public override void Execute() {
            if (GetInputPort("_condition").IsConnected)
                _condition = GetInputValue<bool>("_condition");

            if (_condition) {
                if (GetOutputPort("_true").IsConnected)
                    if (GetOutputPort("_true").node is SequenceNode nextNode)
                        nextNode.Execute();
            } else {
                if (GetOutputPort("_false").IsConnected)
                    if (GetOutputPort("_false").node is SequenceNode nextNode)
                        nextNode.Execute();
            }
        }

        protected override void ExecuteLogic() { }
    }
}