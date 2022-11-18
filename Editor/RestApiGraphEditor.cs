using System;
using outrealxr.holomod;
using XNodeEditor;

[CustomNodeGraphEditor(typeof(RestApiGraph))]
public class RestApiGraphEditor : NodeGraphEditor 
{
    public override string GetNodeMenuName(Type type) {
        if (typeof(VariableNode).IsAssignableFrom(type)) return base.GetNodeMenuName(type);
        if (typeof(WebRequestHandlerNode).IsAssignableFrom(type)) return base.GetNodeMenuName(type);
        if (typeof(SmartStringNode).IsAssignableFrom(type)) return base.GetNodeMenuName(type);
        return null;
    }
}
