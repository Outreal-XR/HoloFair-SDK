using Newtonsoft.Json.Linq;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    public class HoloModSceneGraph : SceneGraph<HoloModGraph>
    {
        private void Start() {
            ExecuteStartNodes();
        }

        public void ExecuteNodeByName(string nodeName) {
            foreach (var node in graph.nodes)
                if (node is IExecutable executable && node.name == nodeName)
                    executable.Execute();
        }

        public void ExecuteStartNodes() {
            foreach (var node in graph.nodes)
                if (node is IExecutable executable && executable.ExecuteOnStart())
                    executable.Execute();
        }
    }
}