using Newtonsoft.Json.Linq;
using XNode;

namespace outrealxr.holomod
{
    public class RestApiSceneGraph : SceneGraph<RestApiGraph>
    {
        private void Start() {
            ExecuteStartNodes();
        }

        public void ExecuteNodeByName(string nodeName) {
            foreach (var node in graph.nodes)
                if (node is WebRequestHandlerNode webRequestNode && webRequestNode.name == nodeName)
                    webRequestNode.Execute();
        }

        public void ExecuteStartNodes() {
            foreach (var node in graph.nodes)
                if (node is WebRequestHandlerNode {executeOnStart: true} webRequestNode)
                    webRequestNode.Execute();
        }

        public void UpdateNodeValue(string nodeName, string value) {
            foreach (var node in graph.nodes)
                if (node is VariableNode variableNode && variableNode.name == nodeName)
                    variableNode.Parse(JToken.Parse(value));
        }
    }
}