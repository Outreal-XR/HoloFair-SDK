using Newtonsoft.Json.Linq;
using outrealxr.holomod;

[CreateNodeMenu("Variable Node/JObject")]
public class ObjectVariableNode : VariableNode
{
    public override void Parse(JToken token) {
        var jObject = JObject.FromObject(token);
        
        var varPorts = GetOutputPort("ConnectionOut").GetConnections();
        
        foreach (var port in varPorts)
            if (jObject.ContainsKey(port.node.name))
                if (port.node is VariableNode varNode)
                    varNode.Parse(jObject.GetValue(varNode.name));
    }

    public override JToken Serialize() {
        var jObject = new JObject();
        var varPorts = GetOutputPort("ConnectionOut").GetConnections();
        
        foreach (var port in varPorts)
                if (port.node is VariableNode varNode)
                    jObject.Add(varNode.name, varNode.Serialize());
        
        return jObject;
    }
}
