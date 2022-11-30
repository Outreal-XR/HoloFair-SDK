using XNode;

namespace outrealxr.holomod
{
    public class HoloModSceneGraph : SceneGraph<HoloModGraph>
    {
        private void Start() {
            graph.monoBehaviour = this;
            ExecuteStartNodes();
        }

        public void ExecuteStartNodes() {
            foreach (var node in graph.nodes) {
                if (node is StartNode startNode) 
                    startNode.Initialize();
            }
        }

        public void ExecuteEvent(string eventName) {
            foreach (var node in graph.nodes) {
                if (node is EventTriggerNode eventNode) 
                    eventNode.Initialize();
            }
        }
    }
}