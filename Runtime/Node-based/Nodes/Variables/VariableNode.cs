using Newtonsoft.Json.Linq;
using XNode;

namespace outrealxr.holomod
{
    [NodeWidth(300)]
    public abstract class VariableNode : Node
    {
        [Input(connectionType: ConnectionType.Override, backingValue = ShowBackingValue.Never)] public NodeConnection ConnectionIn;
        [Output] public NodeConnection ConnectionOut;

        private NodeConnection _conOut;
    
        protected override void Init() {
            base.Init();
            _conOut = new NodeConnection {Variable = this};
        }

        public override object GetValue(NodePort port) {
            if (port.fieldName == "ConnectionOut") return _conOut;
            return null;
        }

        public abstract void Parse(JToken token);
        public abstract JToken Serialize();
    }
}