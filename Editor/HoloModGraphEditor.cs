using System;
using outrealxr.holomod;
using XNodeEditor;

namespace outrealxr.holomod.Editor
{
    [CustomNodeGraphEditor(typeof(HoloModGraph))]
    public class HoloModGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type) {
            if (typeof(HoloNode).IsAssignableFrom(type)) return base.GetNodeMenuName(type);
            if (typeof(WebRequestHandlerNode).IsAssignableFrom(type)) return base.GetNodeMenuName(type);
            if (typeof(SmartStringNode).IsAssignableFrom(type)) return base.GetNodeMenuName(type);
            return null;
        }
    }
}